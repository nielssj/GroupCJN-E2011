// -----------------------------------------------------------------------
// <copyright file="DBCreator.cs" company="">
// TODO: Update copyright text.
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
        /// <summary>
        /// Create a new creator connecting to the specified string.
        /// The string can have two formats, specified below.
        /// </summary>
        /// <param name="conn">A fully initialized connection string specifying at least server, user and password.
        /// A string only containing the server adress. This assumes that the server has a user root with password abc123</param>
        public DBCreator(string conn)
        {
            if (conn.Contains(";"))
            {
                // We assume this string is properly initialized
                this.createDB(new MySqlConnection(conn));
            }
            else
            {
                string connectionString = "server=" + conn + "; user=root; password=abc123;";
                this.createDB(new MySqlConnection(connectionString));
            }
        }

        public DBCreator(MySqlConnection c)
        {
            this.createDB(c);
        }

        public void createDB(MySqlConnection c)
        {
            c.Open();
            var command = c.CreateCommand();
            command.CommandText = System.IO.File.ReadAllText(@"..\..\..\DBComm\DBComm\DataGeneration\DBCommands.conf");
            command.ExecuteNonQuery();
            c.Close();
        }
    }
}
