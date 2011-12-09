namespace DigitalVoterList.Central.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq.Expressions;

    using DBComm.DBComm.DAO;
    using DBComm.DBComm.DO;

    using PDFjet.NET;

    /// <summary>
    /// The class responsible votercard generation.
    /// </summary>
    public class VoterCardGenerator : ISubModel
    {
        /// <summary> Predicates to group upon (Based on individual properties).</summary>
        public readonly List<Func<VoterDO, String>> GroupPredicates = new List<Func<VoterDO, string>>()
        {
            (v => v.PollingStation.Municipality.Name),  // Municipality
            (v => v.PollingStation.Name),               // Polling Station
            (v => v.Name.Substring(0, 1)),              // First Letter in name
            (v => v.City)                               // City
        };
        
        private const double U = (100.0 / 35.278); // Conversion factor from 'mm' to 'points' (DPI = 72).
        
        private VoterFilter filter;
        private string destination;

        private int voterCount;
        private int voterDoneCount;
        private int groupCount;
        private int groupDoneCount;
        private string currentGroup;

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
        /// <summary> Notify me when the number of voters to be generatedchanges. </summary>
        public event CountChangedHandler VoterCountChanged;
        /// <summary>Notify me when the number of generated groups changes. </summary>
        public event CountChangedHandler VoterDoneCountChanged;
        /// <summary> Notify me when the name of the current group being generated changes. </summary>
        public event TextChangedHandler CurrentGroupChanged;

        public int VoterCount
        {
            get { return voterCount; }
            private set { voterCount = value; VoterCountChanged(voterCount); }
        }
        public int VoterDoneCount
        {
            get { return voterDoneCount; }
            private set { voterDoneCount = value; VoterDoneCountChanged(voterDoneCount); }
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
        public string CurrentGroup
        {
            get { return currentGroup; }
            private set { currentGroup = value; CurrentGroupChanged(currentGroup); }
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
            var voterDAO = new VoterDAO();
            //IEnumerable<VoterDO> voters = voterDAO.Read(v => v.Name.StartsWith("A")).ToList();
            IEnumerable<VoterDO> voters = voterDAO.Read(filter.ToPredicate()).ToList();

            GroupDoneCount = 0;
            GroupCount = this.GroupByData(voters, property).Count();
            foreach (var group in GroupByData(voters, property))
            {
                CurrentGroup = group.Key;
                VoterDoneCount = 0;
                VoterCount = group.Count();
                if (limit > 0)
                {
                    int i = 0;
                    foreach (var limitGroup in GroupByLimit(group, limit))
                        this.GenerateFile(limitGroup, group.Key + (i++));
                }
                else
                {
                    this.GenerateFile(group, group.Key);
                }
                GroupDoneCount++;
            }
            CurrentGroup = "Complete!";
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
            var b = new BarCode(BarCode.CODE128, voter.CprString);
            b.SetPosition(xO + 160 * U, yO + 60 * U);
            b.DrawOn(page);

            t = new TextLine(font, voter.CprString);
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
        private void GenerateFile(IEnumerable<VoterDO> voters, String fileName)
        {
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
                VoterDoneCount++;
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
