// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DBComm.DBComm
{
    using System;
    using System.Diagnostics;
    using global::DBComm.DBComm.DataGeneration;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch w = new Stopwatch();
            w.Start();

            var dbc = new DBCreator(new MySqlConnection(
                    "server=localhost;" + "port=3306;" + "uid=root;" + "password=abc123;"));

            w.Stop();
            Console.WriteLine(w.Elapsed);

            Console.WriteLine("done");
        }
    }
}
