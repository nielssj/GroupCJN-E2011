// -----------------------------------------------------------------------
// <copyright file="Data.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DataGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "*", Justification = "Generator code")]
    public class Data
    {
        private readonly Random random = new Random();

        private readonly string[] boynames = System.IO.File.ReadAllLines(@"..\..\DataGeneration\Namedata\boynames.txt");
        private readonly string[] citynames = System.IO.File.ReadAllLines(@"..\..\DataGeneration\Namedata\citynames.txt");
        private readonly string[] girlnames = System.IO.File.ReadAllLines(@"..\..\DataGeneration\Namedata\girlnames.txt");
        private readonly string[] lastnames = System.IO.File.ReadAllLines(@"..\..\DataGeneration\Namedata\lastnames.txt");
        private readonly string[] municipalitynames = System.IO.File.ReadAllLines(@"..\..\DataGeneration\Namedata\municipalitynames.txt");
        private readonly string[] roadnames = System.IO.File.ReadAllLines(@"..\..\DataGeneration\Namedata\roadnames.txt");

        private ICollection<string> cprs = new HashSet<string>();

        public string GetCityname()
        {
            return citynames[random.Next(citynames.Length)];
        }

        public string GetLastname()
        {
            return lastnames[random.Next(lastnames.Length)];
        }

        public string GetMunicipalityname()
        {
            return municipalitynames[random.Next(municipalitynames.Length)];
        }

        public string GetRoadname()
        {
            return roadnames[random.Next(roadnames.Length)];
        }

        public string GetFirstName(uint cpr)
        {
            string scpr = cpr.ToString();

            uint sex = uint.Parse(scpr.Substring(scpr.Length - 2, 2));

            if (sex % 2 == 0)
            {
                return this.GetGirlname();
            }

            return this.GetBoyname();
        }

        public uint GetCPR()
        {


            return this.createCPR();
        }

        private uint createCPR()
        {
            var cpr = string.Empty + random.Next(0, 32) + random.Next(1, 13) + random.Next(10, 100) + random.Next(10, 100)
                      + random.Next(10, 100);

            if (!cprs.Contains(cpr))
            {
                cprs.Add(cpr);
                return uint.Parse(cpr);
            }

            return this.createCPR();
        }

        private string GetBoyname()
        {
            return boynames[random.Next(boynames.Length)];
        }

        private string GetGirlname()
        {
            return girlnames[random.Next(girlnames.Length)];
        }

    }
}
