// -----------------------------------------------------------------------
// <copyright file="PessimisticVoterDAO.cs" company="DVL">
// <author>Jan Meier</author>
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;

    using global::DigitalVoterList.DBComm.DO;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Database(Name = ("DVL"))]
    public class DigitalVoterList : DataContext
    {
        public DigitalVoterList()
            : base(
                new MySqlConnection(
                    "server=localhost;" + "port=3306;" + "uid=root;" + "password=abc123;" + "Sql Server Mode=true;"
                    + "database=dvl"))
        {
        }

        public Table<PollingStationDO> pollingStations;

        public Table<VoterDO> voters;

        public Table<MunicipalityDO> municipalities;
    }
}
