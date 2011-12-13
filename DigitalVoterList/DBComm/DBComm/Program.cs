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
                   "server=mysql.itu.dk;" + "port=3306;" + "password=abc123;" + "uid=groupCJN;"));
            var g = new Generator(DigitalVoterList.GetInstance("groupCJN", "abc123", "mysql.itu.dk", "3306"));

            g.Generate(10, 100, 50000);
            Console.WriteLine("done");
        }
    }
}
