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
    using MySql.Data.MySqlClient;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Table(Name = "log")]
    public class LogDO : IDataObject
    {
        #region Implementation of IDataObject

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public LogDO(uint? primaryKey, DateTime? time, uint? table, uint? cpr, ActivityEnum? activity)
        {
            this.PrimaryKey = primaryKey;
            this.Time = time;
            this.Table = table;
            this.Cpr = cpr;
            this.Activity = activity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogDO"/> class.
        /// </summary>
        public LogDO()
        {

        }

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

        public void ResetAssociations()
        {

        }

        #endregion
    }
}