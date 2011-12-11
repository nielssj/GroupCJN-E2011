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

        public SetupInfo(string ip, string TableNoNo)
        {
            this.ip = ip;
            this.TableNoNo = TableNoNo;
        }

        public string Ip { get { return this.ip; } }

        public string TableNo
        {
            get
            {
                return this.TableNoNo;
            }
        }

        public string ip;
        public string TableNoNo;

        #endregion
    }
}