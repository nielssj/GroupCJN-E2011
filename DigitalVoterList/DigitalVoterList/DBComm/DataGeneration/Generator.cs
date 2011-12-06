// -----------------------------------------------------------------------
// <copyright file="Generator.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DataGeneration
{
    using System;
    using System.Data.Linq;
    using System.Diagnostics.CodeAnalysis;

    using global::DigitalVoterList.DBComm.DAO;
    using global::DigitalVoterList.DBComm.DO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "*", Justification = "Generator code")]
    public class Generator
    {
        private DataContext db;

        private Data data = new Data();

        private Random r = new Random();

        public void Generate(int municipalities, int stations, int voters)
        {
            this.GenerateMunicipalities(municipalities);
            this.GeneratePollingStations(stations, municipalities);
            this.GenerateVoters(voters, stations);
        }

        public void GenerateMunicipalities(int municipalities)
        {
            var dao = new MunicipalityDAO();

            for (uint i = 0; i < municipalities; i++)
            {
                var municipality = new MunicipalityDO(i, data.GetRoadname() + " " + r.Next(1000), data.GetMunicipalityname());

                dao.Create(municipality);
            }
        }

        public void GeneratePollingStations(int stations, int municipalities)
        {
            var dao = new PollingStationDAO();

            for (uint i = 0; i < stations; i++)
            {
                var pollingstation = new PollingStationDO(
                    (uint?)this.r.Next(municipalities), i, "Station " + r.Next(100), data.GetRoadname() + " " + r.Next(1000));

                dao.Create(pollingstation);
            }
        }

        public void GenerateVoters(int voters, int pollingstations)
        {
            var dao = new VoterDAO();

            for (uint i = 0; i < voters; i++)
            {
                uint cpr = data.GetCPR();

                var voter = new VoterDO((uint)this.r.Next(pollingstations), cpr, data.GetFirstName(cpr) + " " + data.GetLastname(), data.GetRoadname() + r.Next(1000), data.GetCityname(), false, false);

                dao.Create(voter);
            }
        }
    }
}