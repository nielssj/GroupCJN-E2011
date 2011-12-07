// -----------------------------------------------------------------------
// <copyright file="DBCreator.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DataGeneration
{
    using System;

    using MySql.Data.MySqlClient;

    /// <summary>
    /// Class to create a new instance of the DVL database from the DBCommands.conf file, which should be placed in the same folder.
    /// </summary>
    public class DBCreator
    {
        public DBCreator(MySqlConnection c)
        {
            var createConnection = c.Clone(); // When a connection is closed, it looses its password, so we clone the connection,
            var insertConnection = c.Clone(); // One for creating the database, and one for filling it with data.

            createConnection.Open();
            var command = createConnection.CreateCommand();
            command.CommandText = System.IO.File.ReadAllText(@"..\..\DBComm\DataGeneration\DBCommands.conf");
            command.ExecuteNonQuery();
            createConnection.Close();   // Can't reuse the connection, since we now append the db name to the connection string
                                        // and that can't be done without closing.

            var g = new Generator(DigitalVoterList.GetInstance(insertConnection));
            g.Generate(100, 1000, 10000);
        }
    }
}
