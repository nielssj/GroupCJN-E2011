// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm
{
    using System;
    using global::DigitalVoterList.DBComm.DataGeneration;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var dbc = new DBCreator(new MySqlConnection(
                    "server=localhost;" + "port=3306;" + "uid=root;" + "password=abc123;" + "Sql Server Mode=true;"));

            Console.WriteLine("done");
        }
    }
}
