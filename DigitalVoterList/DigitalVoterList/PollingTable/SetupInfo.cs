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

        public SetupInfo(string ip, uint tableNo)
        {
            this.ip = ip;
            this.tableNo = tableNo;
        }

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public uint TableNo
        {
            get { return tableNo; }
            set { tableNo = value; }
        }

        private string ip;
        private uint tableNo;

        #endregion
    }
}