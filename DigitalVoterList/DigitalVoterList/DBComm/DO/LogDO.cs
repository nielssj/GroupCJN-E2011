// -----------------------------------------------------------------------
// <copyright file="LogDO.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DO
{
    using System;
    using System.Data.Linq.Mapping;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Table(Name = "log")]
    public class LogDO : IDataObject
    {
        #region Implementation of IDataObject

        /// <summary>
        /// Gets the primary key of this data object.
        /// </summary>
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public uint? PrimaryKey { get; private set; }

        /// <summary>
        /// Gets Time.
        /// </summary>
        [Column]
        public DateTime Time { get; private set; }

        /// <summary>
        /// Gets Table.
        /// </summary>
        [Column]
        public uint? Table { get; private set; }

        /// <summary>
        /// Gets Cpr.
        /// </summary>
        [Column]
        public uint? Cpr { get; private set; }

        /// <summary>
        /// Gets Activity.
        /// </summary>
        [Column]
        public ActivityEnum Activity { get; private set; }

        /// <summary>
        /// Has all the fields of the object been initialized?
        /// </summary>
        /// <returns>
        /// True if all fields are non-null.
        /// </returns>
        public bool FullyInitialized()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the values of this object to the values of the dummy object, if the dummys value is non-null.
        /// </summary>
        /// <param name="dummy">
        /// The dummy object, representing new values.
        /// </param>
        public void UpdateValues(IDataObject dummy)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
