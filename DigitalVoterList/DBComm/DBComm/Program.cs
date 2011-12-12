// ----------------------------------------------------------------------
// <copyright file="Program.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DBComm.DBComm
{
    using System;
    using global::DBComm.DBComm.DataGeneration;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var dbc = new DBCreator(new MySqlConnection(
                   "server=localhost;" + "port=3306;" + "password=abc123;" + "uid=root;"));
            var g = new Generator(DigitalVoterList.GetInstance(new MySqlConnection(
                    "server=localhost;" + "port=3306;" + "uid=root;" + "password=abc123;")));

            g.Generate(10, 100, 500);
            Console.WriteLine("done");
        }
    }
}
