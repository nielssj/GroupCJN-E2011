// -----------------------------------------------------------------------
// <copyright file="ServerSetup.cs" company="DVL">
// <author>Jan Meier</author>
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Models
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The model for the server setup window. This has no real state to store, and only one method, for saving the credentials
    /// typed by the user.
    /// </summary>
    public class ServerSetup
    {
        private const string Path = "c:/ServerSetupDVL.conf";

        public ServerSetup()
        {

        }

        public void SaveCredentials(string server, int port, string user, string password, string db)
        {
            IEnumerable<string> credentials = new List<string>() { server, port.ToString(), user, password, db };

            File.WriteAllLines(Path, credentials);
        }
    }
}
