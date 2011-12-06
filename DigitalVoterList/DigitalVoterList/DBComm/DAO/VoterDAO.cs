// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoterDAO.cs" company="DVL">
//   Jan Meier
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DAO
{
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::DigitalVoterList.DBComm.DO;

    /// <summary>
    /// DAO for the voters table.
    /// </summary>
    public class VoterDAO : AbstractDataAccessObject<VoterDO>
    {
        /// <summary>
        /// Create this object.
        /// </summary>
        /// <param name="t">
        /// The object to insert.
        /// </param>
        /// <returns>
        /// True if the object was created, false otherwise.
        /// </returns>
        public new bool Create(VoterDO t)
        {
            // Method is re-implemented here, because it is not possible to add the ensures in the abstract DAO.
            Contract.Requires(t != null);
            Contract.Requires(t.FullyInitialized());
            Contract.Ensures(this.Read(o => o.PrimaryKey == t.PrimaryKey).Contains(t));
            return base.Create(t);
        }

        /// <summary>
        /// Update the primary key by first deleting the entry and 
        /// inserting a new one.
        /// </summary>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        /// <param name="dummy">
        /// The dummy.
        /// </param>
        protected override void DeleteAndInsert(VoterDO oldValue, VoterDO dummy)
        {
            this.Delete(v => v.PrimaryKey == oldValue.PrimaryKey);
            this.Create(dummy);
        }
    }
}