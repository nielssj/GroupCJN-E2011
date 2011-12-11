// -----------------------------------------------------------------------
// <copyright file="SetupInfo.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.PollingTable
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public struct SetupInfo
    {
        #region Constants and Fields

        public SetupInfo(string ip, string table, string password)
        {
            this.ip = ip;
            this.table = table;
            this.password = password;
        }

        public string Ip
        {
            get
            {
                return this.ip;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
        }

        public string Table
        {
            get
            {
                return this.table;
            }
        }

        public string ip;
        public string password;
        public string table;

        #endregion
    }
}