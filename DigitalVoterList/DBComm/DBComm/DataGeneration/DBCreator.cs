// -----------------------------------------------------------------------
// <copyright file="DBCreator.cs" company="DVL">
// <author>Jan Meier</author>
// </copyright>
// -----------------------------------------------------------------------

namespace DBComm.DBComm.DataGeneration
{
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Class to create a new instance of the DVL database from the DBCommands.conf file, which should be placed in the same folder.
    /// </summary>
    public class DBCreator
    {
        private string dbName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBCreator"/> class. 
        /// Create a db on the following server.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="port">The port.</param> 
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="dbName"> The name of the database.</param>
        public DBCreator(string server, string port, string dbName, string user, string password)
        {
            this.dbName = dbName;

            string connString = "server=" + server + ";uid=" + user + ";password=" + password + ";port=" + port + ";";
            this.createDB(new MySqlConnection(connString));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBCreator"/> class.
        /// </summary>
        /// <param name="c">The connection.</param>
        /// <param name="dbName"> The name of the database.</param>
        public DBCreator(MySqlConnection c, string dbName)
        {
            this.dbName = dbName;

            this.createDB(c);
        }

        private void createDB(MySqlConnection c)
        {
            c.Open();

            var dbCommand = c.CreateCommand();
            dbCommand.CommandText = string.Format("DROP DATABASE IF EXISTS {0}; CREATE DATABASE {0}; USE {0};", this.dbName);
            dbCommand.ExecuteNonQuery();

            var insertCommand = c.CreateCommand();
            insertCommand.CommandText = System.IO.File.ReadAllText(@"..\..\..\DBComm\DBComm\DataGeneration\DBCommands.conf");
            insertCommand.ExecuteNonQuery();
            c.Close();
        }
    }
}
