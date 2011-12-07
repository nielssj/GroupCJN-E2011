// -----------------------------------------------------------------------
// <copyright file="DBCreator.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DataGeneration
{
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Class to create a new instance of the DVL database from the DBCommands.conf file, which should be placed in the same folder.
    /// </summary>
    public class DBCreator
    {
        public DBCreator(MySqlConnection c)
        {
            var dvl = DigitalVoterList.GetInstance(c);

            string queries = System.IO.File.ReadAllText(@"..\..\DBComm\DataGeneration\DBCommands.conf");

            dvl.ExecuteCommand(queries);
        }
    }
}
