﻿// -----------------------------------------------------------------------
// <copyright file="Municipality.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DO
{
    using System.Collections.Generic;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Table(Name = "Municipality")]
    public class MunicipalityDO : IDataObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MunicipalityDO"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        public MunicipalityDO(uint? id, string address, string name)
        {
            this.Id = id;
            this.Address = address;
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MunicipalityDO"/> class. 
        /// Parameter-less constructor required for entity mapping. No field-
        /// initialization is done, i.e. all fields are null.
        /// </summary>
        public MunicipalityDO()
        {
        }

        /// <summary>
        /// Gets PrimaryKey.
        /// </summary>
        [Column(IsPrimaryKey = true, Name = "id")]
        public uint? PrimaryKey
        {
            get
            {
                return this.Id;
            }

            private set
            {
                this.Id = value;
            }
        }

        private EntitySet<PollingStationDO> _pStations = new EntitySet<PollingStationDO>();

        [Association(Name = "FK_PT_M", Storage = "_pStations", ThisKey = "PrimaryKey", OtherKey = "MunicipalityId")]
        public ICollection<PollingStationDO> PollingStations
        {
            get
            {
                return _pStations;
            }

            set
            {
                Contract.Requires(value != null);
                _pStations.AddRange(value);
            }
        }

        /// <summary>
        /// Gets Id.
        /// </summary>
        public uint? Id { get; private set; }

        /// <summary>
        /// Gets Address.
        /// </summary>
        [Column]
        public string Address { get; private set; }

        /// <summary>
        /// Gets Name.
        /// </summary>
        [Column]
        public string Name { get; private set; }

        #region Implementation of IDataObject

        /// <summary>
        /// Has all the fields of the object been initialized?
        /// </summary>
        /// <returns>
        /// True if all fields are non-null.
        /// </returns>
        public bool FullyInitialized()
        {
            return Id != null && Address != null && Name != null;
        }

        /// <summary>
        /// Set the values of this object to the values of the dummy object, if the dummys value is non-null.
        /// </summary>
        /// <param name="dummy">
        /// The dummy object, representing new values.
        /// </param>
        public void UpdateValues(IDataObject dummy)
        {
            MunicipalityDO municipalityDummy = dummy as MunicipalityDO;
            Contract.Assert(municipalityDummy != null);

            this.Address = municipalityDummy.Address ?? this.Address;
            this.Id = municipalityDummy.Id ?? this.Id;
            this.Name = municipalityDummy.Name ?? this.Name;
        }

        #endregion
    }
}