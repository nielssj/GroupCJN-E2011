﻿using System;

namespace DigitalVoterList
{
    using System.Windows.Forms;

    using DigitalVoterList.PollingTable.Log;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Launch 'Central' client.
            //new Central.Main();

            new LogController(new LogWindow(), new LogModel());

            // Launch 'PollingTable' client.
            //new PollingTable
        }
    }
}
