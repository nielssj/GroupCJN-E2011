// -----------------------------------------------------------------------
// <copyright file="VoterBoxManagerController.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Controllers
{
    using System;
    using System.Linq;
    using DBComm.DBComm;
    using DBComm.DBComm.DAO;
    using DBComm.DBComm.DataGeneration;
    using DBComm.DBComm.DO;
    using DigitalVoterList.Central.Models;
    using DigitalVoterList.Central.Views;

    using MySql.Data.MySqlClient;

    /// <summary>
    /// The Controller responsible for monitoring the VoterBoxManager (view)
    /// and propagating input in an appropiate fashion to the VoterBoxManager (model).
    /// </summary>
    public class VoterBoxManagerController
    {
        private VoterBoxManager model;
        private VoterBoxManagerWindow view;

        private PollingStationDAO pDAO;
        private MunicipalityDAO mDAO;
        private VoterDAO vDAO;

        public VoterBoxManagerController(VoterBoxManager model, VoterBoxManagerWindow view)
        {
            this.model = model;
            this.view = view;

            view.AddConnectHandler(this.Connect);
            view.AddUploadHandler(this.Upload);

            view.Show();
        }

        public void Connect()
        {
            DBCreator creator = new DBCreator(view.Address);
        }

        public void Upload()
        {
            if (model.Filter != null)
            {
                this.fetchData();
                this.insertData();
            }
            Console.WriteLine("Done");
        }

        private void fetchData()
        {
            pDAO = new PollingStationDAO(DigitalVoterList.GetDefaultInstance());
            mDAO = new MunicipalityDAO(DigitalVoterList.GetDefaultInstance());
            vDAO = new VoterDAO(DigitalVoterList.GetDefaultInstance());

            VoterFilter f = model.Filter;

            if (f.CPRNO != 0)
            {
                model.Voters = vDAO.Read(v => v.PrimaryKey == f.CPRNO);
                VoterDO voter = model.Voters.First();
                model.PollingStations = pDAO.Read(ps => ps.PrimaryKey == voter.PollingStationId);
                PollingStationDO pollingStation = model.PollingStations.First();
                model.Municipalities = mDAO.Read(m => m.PrimaryKey == pollingStation.MunicipalityId);
            }
            else if (f.PollingStation != null)
            {
                model.PollingStations = pDAO.Read(ps => ps.PrimaryKey == f.PollingStation.PrimaryKey);
                model.Voters = vDAO.Read(v => v.PollingStationId == f.PollingStation.PrimaryKey);
                model.Municipalities = mDAO.Read(m => m.PrimaryKey == f.PollingStation.MunicipalityId);
            }
            else if (f.Municipality != null)
            {
                model.Municipalities = mDAO.Read(m => m.PrimaryKey == f.Municipality.PrimaryKey);
                model.PollingStations = pDAO.Read(p => p.MunicipalityId == f.Municipality.PrimaryKey);

                model.Voters = Enumerable.Empty<VoterDO>();
                foreach (var ps in model.PollingStations)
                {
                    PollingStationDO ps1 = ps;
                    model.Voters = model.Voters.Concat(vDAO.Read(v => v.PollingStationId == ps1.PrimaryKey));
                }
            }
        }

        private void insertData()
        {
            foreach (var municipality in model.Municipalities)
            {
                municipality.ResetAssociations();
            }
            foreach (var pollingStation in model.PollingStations)
            {
                pollingStation.ResetAssociations();
            }
            foreach (var voter in model.Voters)
            {
                voter.ResetAssociations();
            }

            mDAO = new MunicipalityDAO(DigitalVoterList.GetInstance(new MySqlConnection("server=mysql.itu.dk;" + "port=3306;" + "uid=jmei;" + "password=abc123;")));
            pDAO = new PollingStationDAO(DigitalVoterList.GetInstance(new MySqlConnection("server=mysql.itu.dk;" + "port=3306;" + "uid=jmei;" + "password=abc123;")));
            vDAO = new VoterDAO(DigitalVoterList.GetInstance(new MySqlConnection("server=mysql.itu.dk;" + "port=3306;" + "uid=jmei;" + "password=abc123;")));

            mDAO.Create(model.Municipalities);
            pDAO.Create(model.PollingStations);
            vDAO.Create(model.Voters);
        }
    }
}