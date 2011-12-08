namespace DigitalVoterList.Central.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using DBComm.DBComm.DAO;
    using DBComm.DBComm.DO;

    using PDFjet.NET;

    /// <summary>
    /// The class responsible votercard generation.
    /// </summary>
    public class VoterCardGenerator : ISubModel
    {
        private const double U = (100.0 / 35.278); // Conversion factor from 'mm' to 'points' (DPI = 72).

        public VoterCardGenerator()
        {
            this.Generate();
        }

        /// <summary>
        /// Generate voter card(s) based on voter filter and grouping selection.
        /// </summary>
        public void Generate()
        {
            var fos = new FileStream("Example.pdf", FileMode.Create);
            var bos = new BufferedStream(fos);

            // Compose PDF
            var pdf = new PDF(bos);

            // Compose Page
            var page = new Page(pdf, A4.PORTRAIT);

            var voterDAO = new VoterDAO();
            IEnumerable<VoterDO> voters = voterDAO.Read(v => v.Name.StartsWith("A")).ToList();

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
            }

            pdf.Flush();
            bos.Close();
        }

        private static void PopulateCard(Page page, PDF pdf, double xO, double yO, VoterDO voter)
        //private static void PopulateCard(Page page, PDF pdf, double xO, double yO)
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

            var b = new BarCode(BarCode.CODE128, voter.CprString);
            b.SetPosition(xO + 160 * U, yO + 60 * U);
            b.DrawOn(page);

            t = new TextLine(font, voter.CprString);
            t.SetPosition(xO + 160 * U, yO + 72 * U);
            t.DrawOn(page);
        }

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

            // Add 'Afstemningssted' box
            var b = new Box(xO + 6 * U, yO + 20 * U, 80 * U, 22 * U);
            b.DrawOn(page);

            // Add 'Valgbord' box
            b = new Box(xO + 6 * U, yO + 44.5 * U, 80 * U, 7 * U);
            b.DrawOn(page);

            // Add 'Vælgernr' box
            b = new Box(xO + 6 * U, yO + 54 * U, 80 * U, 7 * U);
            b.DrawOn(page);

            // Add 'Afstemningstid' box
            b = new Box(xO + 6 * U, yO + 63.5 * U, 80 * U, 7 * U);
            b.DrawOn(page);

            //Add lines
            var l = new Line(xO + 96 * U, yO + 5 * U, xO + 96 * U, yO + 85 * U);
            l.DrawOn(page);
            l = new Line(xO + 96 * U, yO + 25 * U, xO + 205 * U, yO + 25 * U);
            l.DrawOn(page);
            l = new Line(xO + 96 * U, yO + 45 * U, xO + 205 * U, yO + 45 * U);
            l.DrawOn(page);
            l = new Line(xO + 6 * U, yO + 85 * U, xO + 205 * U, yO + 85 * U);
            l.DrawOn(page);

            //Add text
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
    }
}
