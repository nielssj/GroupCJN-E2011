namespace DigitalVoterList.Central.Models
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;

    using DBComm.DBComm.DAO;
    using DBComm.DBComm.DO;

    using DigitalVoterList.Central.Utility;

    using PDFjet.NET;

    /// <summary>
    /// The class responsible votercard generation.
    /// </summary>
    public class VoterCardGenerator : ISubModel
    {
        /// <summary> Predicates to group upon (Based on individual properties).</summary>
        public readonly List<Func<VoterDO, String>> GroupPredicates = new List<Func<VoterDO, string>>
        {
            (v => v.PollingStation.Municipality.Name),  // Municipality
            (v => v.PollingStation.Name),               // Polling Station
            (v => v.Name.Substring(0, 1)),              // First Letter in name
            (v => v.City)                               // City
        };
        
        private const double U = (100.0 / 35.278); // Conversion factor from 'mm' to 'points' (DPI = 72).
        
        private VoterFilter filter;
        private string destination;
        private int property;
        private int limit;
        private BackgroundWorker worker;

        private int voterCount;
        private int voterDoneCount;
        private int voterDonePerc;
        private int groupCount;
        private int groupDoneCount;
        private string currentGroupName;
        private IGrouping<String, VoterDO> currentGroup;
        private IEnumerator<IGrouping<String, VoterDO>> groupsEnumerator;

        public VoterCardGenerator(VoterFilter filter)
        {
            this.filter = filter;
        }
        
        public delegate void CountChangedHandler(int changedTo);
        public delegate void TextChangedHandler(string changedTo);

        /// <summary> Notify me when the number of groups to be generated changes. </summary>
        public event CountChangedHandler GroupCountChanged;
        /// <summary> Notify me when the number of generated groups changes. </summary>
        public event CountChangedHandler GroupDoneCountChanged;
        /// <summary> Notify me when the percentage of generated voters (in the current group) changes. </summary>
        public event CountChangedHandler VoterDonePercChanged;
        /// <summary> Notify me when the name of the current group being generated changes. </summary>
        public event TextChangedHandler CurrentGroupChanged;
        /// <summary> Notify me when the generation process ends (interrupted or completed) </summary>
        public event Action<String> GenerationEnded;

        public int VoterDonePerc
        {
            get { return voterDonePerc; }
            private set { voterDonePerc = value; VoterDonePercChanged(voterDonePerc); }
        }
        public int GroupCount
        {
            get { return groupCount; }
            private set { groupCount = value; GroupCountChanged(groupCount); }
        }
        public int GroupDoneCount
        {
            get { return groupDoneCount; }
            private set { groupDoneCount = value; GroupDoneCountChanged(groupDoneCount); }
        }
        public string CurrentGroupName
        {
            get { return this.currentGroupName; }
            private set { this.currentGroupName = value; CurrentGroupChanged(this.currentGroupName); }
        }

        /// <summary>
        /// Abort the current generator process, if one is currently running.
        /// </summary>
        public void Abort()
        {
            if (worker != null)
            {
                worker.CancelAsync();
                if (GenerationEnded != null) GenerationEnded("Aborted");
            }
        }

        /// <summary>
        /// Generate voter card(s) based on voter filter and grouping selection.
        /// </summary>
        /// <param name="destination">Destination folder for resulting files (path).</param>
        /// <param name="property">Index of the desired group predicate to for grouping.</param>
        /// <param name="limit">Batch size limit (voters / file).</param>
        public void Generate(String destination, int property, int limit)
        {
            this.destination = destination;
            this.property = property;
            this.limit = limit;

            var voterDAO = new VoterDAO();
            IEnumerable<VoterDO> voters = voterDAO.Read(v => v.Name.StartsWith("A")).ToList();
            //IEnumerable<VoterDO> voters = voterDAO.Read(filter.ToPredicate()).ToList();

            IEnumerable<IGrouping<String, VoterDO>> groups = this.GroupByData(voters, property);
            this.GroupCount = groups.Count();
            this.groupsEnumerator = GroupByData(voters, property).GetEnumerator();
            this.GroupDoneCount = 0;
            
            if(this.groupsEnumerator.MoveNext())
            {
                this.currentGroup = this.groupsEnumerator.Current;
                this.CurrentGroupName = this.currentGroup.Key;
                this.voterCount = this.currentGroup.Count();
                this.voterDoneCount = 0;
                this.voterDonePerc = 0;

                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.ProgressChanged += (o, eA) => VoterDonePerc = eA.ProgressPercentage;
                worker.RunWorkerCompleted += this.GroupGenerated;
                worker.DoWork += this.GenerateGroup;
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Generate file(s) for the current group.
        /// </summary>
        /// <param name="sender">BackgroundWorker to handle the generation process.</param>
        /// <param name="e">Worker event parameters (currently not used).</param>
        private void GenerateGroup(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            
            // If 'limit' is set split the group into multiple files (partial groups).
            if (limit > 0)
            {
                int i = 0;
                foreach (var partialGroup in GroupByLimit(currentGroup, limit))
                {
                    string partialGroupName = currentGroupName + (i++); //numbered 0 to n 'number of parital groups'.
                    this.GenerateFile(sender, e, partialGroup, partialGroupName);
                    if (e.Cancel) break;
                }
            }
            // ..Otherwise generate the entire group.
            else
                this.GenerateFile(sender, e, currentGroup, currentGroupName);
        }

        /// <summary>
        /// (To be called when a group has finished being generated)
        /// Prepares for and starts the generation of the next group, if any remain.
        /// If no groups remain; the voters are updated in the database.
        /// </summary>
        /// <param name="sender">BackgroundWorker that just completed a generation process.</param>
        /// <param name="e">Worker event completion parameters (currently not used).</param>
        private void GroupGenerated(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            var worker = sender as BackgroundWorker;
            this.GroupDoneCount++;
            
            // Prepare and start generation of next group, if any remain.
            if (this.groupsEnumerator.MoveNext())
            {
                this.currentGroup = this.groupsEnumerator.Current;
                this.CurrentGroupName = this.currentGroup.Key;
                this.voterCount = this.currentGroup.Count();
                this.voterDoneCount = 0;
                this.VoterDonePerc = 0;

                worker.RunWorkerAsync();
            }
            // ..Otherwise update voters in db and declare completed.
            else
            {
                this.CurrentGroupName = "Updating Database..";
                
                var voterDAO = new VoterDAO();
                var template = new VoterDO(null, null, null, null, null, true, null);
                voterDAO.Update(v => v.Name.StartsWith("A"), template);
                //voterDAO.Update(filter.ToPredicate(), template);

                GenerationEnded("Completed");
            }
        }

        /// <summary>
        /// Populate a card with the information of a given voter.
        /// </summary>
        /// <param name="page">The page containing the card.</param>
        /// <param name="pdf">The pdf containing the page.</param>
        /// <param name="xO">The horizontal offset of the card in points.</param>
        /// <param name="yO">The vertical offset of the card in points.</param>
        /// <param name="voter">The voter whose information to be populated onto the card.</param>
        private static void PopulateCard(Page page, PDF pdf, double xO, double yO, VoterDO voter)
        {
            // ----- POPULATE: POLLING STATION -----
            PollingStationDO ps = voter.PollingStation;

            var font = new Font(pdf, CoreFont.HELVETICA);
            font.SetSize(9);

            var t = new TextLine(font, ps.Name);
            t.SetPosition(xO + 9 * U, yO + 27.5 * U);
            t.DrawOn(page);

            t = new TextLine(font, ps.Address);
            t.SetPosition(xO + 9 * U, yO + 32 * U);
            t.DrawOn(page);

            t = new TextLine(font, "valgfrit");
            t.SetPosition(xO + 29 * U, yO + 48.8 * U);
            t.DrawOn(page);

            t = new TextLine(font, "02-04861");
            t.SetPosition(xO + 29 * U, yO + 58.7 * U);
            t.DrawOn(page);

            t = new TextLine(font, "09:00 - 20:00");
            t.SetPosition(xO + 29 * U, yO + 68.2 * U);
            t.DrawOn(page);


            // ----- POPULATE: VOTER -----
            MunicipalityDO mun = voter.PollingStation.Municipality;

            font = new Font(pdf, CoreFont.COURIER);
            font.SetSize(10);

            // Add top voter number 'Vælgernr.'
            t = new TextLine(font, "02-04861");
            t.SetPosition(xO + 102 * U, yO + 12 * U);
            t.DrawOn(page);

            // Add sender 'Afsender'
            t = new TextLine(font, mun.Name);
            t.SetPosition(xO + 102 * U, yO + 32.5 * U);
            t.DrawOn(page);

            t = new TextLine(font, mun.Address);
            t.SetPosition(xO + 102 * U, yO + 36.5 * U);
            t.DrawOn(page);

            t = new TextLine(font, mun.City);
            t.SetPosition(xO + 102 * U, yO + 40.5 * U);
            t.DrawOn(page);

            // Add reciever 'Modtager'
            t = new TextLine(font, voter.Name);
            t.SetPosition(xO + 102 * U, yO + 62.5 * U);
            t.DrawOn(page);

            t = new TextLine(font, voter.Address);
            t.SetPosition(xO + 102 * U, yO + 66.5 * U);
            t.DrawOn(page);

            t = new TextLine(font, voter.City);
            t.SetPosition(xO + 102 * U, yO + 70.5 * U);
            t.DrawOn(page);

            // Add CPR barcode
            string barcode = BarCodeHashing.Hash(voter.PrimaryKey.Value).ToString();
            var b = new BarCode(BarCode.CODE128, barcode);
            b.SetPosition(xO + 160 * U, yO + 60 * U);
            b.DrawOn(page);

            t = new TextLine(font, barcode);
            t.SetPosition(xO + 160 * U, yO + 72 * U);
            t.DrawOn(page);
        }

        /// <summary>
        /// Generate lines, boxes, watermark and default text of voter card
        /// </summary>
        /// <param name="page">The page containing the card.</param>
        /// <param name="pdf">The pdf containing the page.</param>
        /// <param name="xO">The horizontal offset of the card in points.</param>
        /// <param name="yO">The vertical offset of the card in points.</param>
        private static void GenerateCard(Page page, PDF pdf, double xO, double yO)
        {
            // Add watermark.
            var font = new Font(pdf, CoreFont.HELVETICA_BOLD);
            font.SetSize(55);
            var t = new TextLine(font, "FAKE VALGKORT");
            var lightBlue = new[] { 0.647, 0.812, 0.957 };
            t.SetColor(lightBlue);
            t.SetPosition(xO + 20 * U, yO + 50 * U);
            t.DrawOn(page);

            // Add 'Afstemningssted' box.
            var b = new Box(xO + 6 * U, yO + 20 * U, 80 * U, 22 * U);
            b.DrawOn(page);

            // Add 'Valgbord' box.
            b = new Box(xO + 6 * U, yO + 44.5 * U, 80 * U, 7 * U);
            b.DrawOn(page);

            // Add 'Vælgernr' box.
            b = new Box(xO + 6 * U, yO + 54 * U, 80 * U, 7 * U);
            b.DrawOn(page);

            // Add 'Afstemningstid' box.
            b = new Box(xO + 6 * U, yO + 63.5 * U, 80 * U, 7 * U);
            b.DrawOn(page);

            // Add lines.
            var l = new Line(xO + 96 * U, yO + 5 * U, xO + 96 * U, yO + 85 * U);
            l.DrawOn(page);
            l = new Line(xO + 96 * U, yO + 25 * U, xO + 205 * U, yO + 25 * U);
            l.DrawOn(page);
            l = new Line(xO + 96 * U, yO + 45 * U, xO + 205 * U, yO + 45 * U);
            l.DrawOn(page);
            l = new Line(xO + 6 * U, yO + 85 * U, xO + 205 * U, yO + 85 * U);
            l.DrawOn(page);

            // Add default text.
            font = new Font(pdf, CoreFont.HELVETICA);
            font.SetSize(7);
            t = new TextLine(font, "Afstemningssted:");
            t.SetPosition(xO + 7 * U, yO + 23 * U);
            t.DrawOn(page);
            t = new TextLine(font, "Vælgernr.:");
            t.SetPosition(xO + 7 * U, yO + 58 * U);
            t.DrawOn(page);
            t = new TextLine(font, "Afstemningstid:");
            t.SetPosition(xO + 7 * U, yO + 68 * U);
            t.DrawOn(page);
            t = new TextLine(font, "Afsender:");
            t.SetPosition(xO + 98 * U, yO + 29 * U);
            t.DrawOn(page);
            t = new TextLine(font, "Modtager:");
            t.SetPosition(xO + 98 * U, yO + 49 * U);
            t.DrawOn(page);


            font = new Font(pdf, CoreFont.HELVETICA);
            font.SetSize(9);
            t = new TextLine(font, "Folketingsvalg");
            t.SetPosition(xO + 7 * U, yO + 10 * U);
            t.DrawOn(page);
            t = new TextLine(font, "20. november 2001");
            t.SetPosition(xO + 7 * U, yO + 14 * U);
            t.DrawOn(page);
            t = new TextLine(font, "Valgbord:");
            t.SetPosition(xO + 7 * U, yO + 49 * U);
            t.DrawOn(page);

            font = new Font(pdf, CoreFont.HELVETICA_OBLIQUE);
            font.SetSize(7);
            t = new TextLine(font, "Medbring kortet ved afstemningen");
            t.SetPosition(xO + 6.5 * U, yO + 18.5 * U);
            t.DrawOn(page);
        }

        /// <summary>
        /// Generate a single batch (pdf-file) containing one or more voter cards.
        /// </summary>
        /// <param name="voters">The voter(s) to be on the voter card(s) in the file.</param>
        /// <param name="fileName">The name of the file.</param>
        private void GenerateFile(object sender, DoWorkEventArgs e, IEnumerable<VoterDO> voters, String fileName)
        {
            var worker = sender as BackgroundWorker;

            String path = destination + "\\" + fileName + ".pdf";
            var fos = new FileStream(path, FileMode.Create);
            var bos = new BufferedStream(fos);

            // Compose PDF
            var pdf = new PDF(bos);

            // Compose Page
            var page = new Page(pdf, A4.PORTRAIT);

            int pageCount = 0;
            foreach (var voter in voters)
            {
                GenerateCard(page, pdf, 0, pageCount * U);
                PopulateCard(page, pdf, 0, pageCount * U, voter);
                if (pageCount != 200) pageCount += 100;
                else
                {
                    pageCount = 0;
                    page = new Page(pdf, A4.PORTRAIT);
                }
                
                // Update progress percentage?
                voterDoneCount++;
                double perc = (Convert.ToDouble(voterDoneCount) / Convert.ToDouble(voterCount)) * 100;
                int iperc = (int)perc;
                if(iperc != VoterDonePerc) worker.ReportProgress(iperc);

                // Cancelled? 
                // If yes, flag cancelled and break, but make sure file stream is closed properly.
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }

            pdf.Flush();
            bos.Close();
        }

        /// <summary>
        /// Group voters by the selected data property (such as municipality or polling station).
        /// </summary>
        /// <param name="voters">The voters to be grouped.</param>
        /// <returns>An IEnumerable containing the resulting batches.</returns>
        private IEnumerable<IGrouping<String, VoterDO>> GroupByData(IEnumerable<VoterDO> voters, int property)
        {
            return voters.GroupBy(this.GroupPredicates[property]);
        }

        /// <summary>
        /// Group voters into batches of the selected limit.
        /// </summary>
        /// <param name="voters">The voters to be grouped.</param>
        /// <returns>An IEnumerable containing the resulting batches.</returns>
        private IEnumerable<IEnumerable<VoterDO>> GroupByLimit(IEnumerable<VoterDO> voters, int limit)
        {
            var groups = new List<IEnumerable<VoterDO>>();

            for (int i = 0; i <= voters.Count() / limit; i++)
                groups.Add(voters.Skip(i * limit).Take(limit));

            return groups;
        }

    }
}
