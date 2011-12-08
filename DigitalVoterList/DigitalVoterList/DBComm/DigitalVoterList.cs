﻿// -----------------------------------------------------------------------
// <copyright file="DigitalVoterList.cs" company="DVL">
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
    /// The data context representing the DVL database.
    /// </summary>
    [Database(Name = ("dvl"))]
    public class DigitalVoterList : DataContext
    {
        public Table<PollingStationDO> pollingStations;

        public Table<VoterDO> voters;

        public Table<MunicipalityDO> municipalities;

        /// <summary>
        /// Initialize the datacontext via the base constructor.
        /// </summary>
        /// <param name="c">A working connection.</param>
        private DigitalVoterList(MySqlConnection c)
            : base(c)
        {
        }

        /// <summary>
        /// Create a new database with the default connection parameters.
        /// * server = localhost
        /// * port = 3306
        /// * uid = root
        /// * password = abc123
        /// * sql server mode = true
        /// * database = dvl
        /// </summary>
        /// <returns>A new datacontext instance.</returns>
        public static DigitalVoterList GetDefaultInstance()
        {
            return new DigitalVoterList(new MySqlConnection(
                    "server=localhost;" + "port=3306;" + "uid=root;" + "password=abc123;" + "Sql Server Mode=true;"
                    + "database=dvl;"));
        }

        /// <summary>
        /// Create a new database instance based on the connection.
        /// </summary>
        /// <param name="c">The connection to the db. The connection should be initialized and ready to connect.</param>
        /// <returns>A new datacontext.</returns>
        public static DigitalVoterList GetInstance(MySqlConnection c)
        {
            c.ConnectionString += ";Sql Server Mode=true;"; // Added to be sure that LINQ queries are supported by the DB. 
                                                            // No harm will be done if this parameter is already set.
            return new DigitalVoterList(c);
        }
    }
}