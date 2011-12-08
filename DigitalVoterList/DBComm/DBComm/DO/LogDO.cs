// -----------------------------------------------------------------------
// <copyright file="LogDO.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DBComm.DBComm.DO
{
    using System;
    using System.Data.Linq.Mapping;
    using System.Diagnostics.Contracts;

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
        public DateTime? Time { get; private set; }

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
        public ActivityEnum? Activity { get; private set; }

        /// <summary>
        /// Has all the fields of the object been initialized?
        /// </summary>
        /// <returns>
        /// True if all fields are non-null.
        /// </returns>
        public bool FullyInitialized()
        {
            return PrimaryKey != null && Time != null && Table != null && Cpr != null && Activity != null;
        }

        /// <summary>
        /// Set the values of this object to the values of the dummy object, if the dummys value is non-null.
        /// </summary>
        /// <param name="dummy">
        /// The dummy object, representing new values.
        /// </param>
        public void UpdateValues(IDataObject dummy)
        {
            LogDO logDummy = dummy as LogDO;
            Contract.Assert(logDummy != null);

            this.PrimaryKey = logDummy.PrimaryKey ?? this.PrimaryKey;
            this.Time = logDummy.Time ?? this.Time;
            this.Table = logDummy.Table ?? this.Table;
            this.Cpr = logDummy.Cpr ?? this.Cpr;
            this.Activity = logDummy.Activity ?? this.Activity;
        }

        #endregion
    }
}