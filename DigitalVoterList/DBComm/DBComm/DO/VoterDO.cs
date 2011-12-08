﻿// -----------------------------------------------------------------------
// <copyright file="Voter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DBComm.DBComm.DO
{
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Table(Name = "Voter")]
    public class VoterDO : IDataObject
    {
        private uint? primaryKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoterDO"/> class.
        /// </summary>
        /// <param name="pollingStationId">
        /// The polling station id.
        /// </param>
        /// <param name="cpr">
        /// The cpr no.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="cardPrinted">
        /// The card printed status.
        /// </param>
        /// <param name="voted">
        /// The voted status.
        /// </param>
        public VoterDO(uint pollingStationId, uint cpr, string name, string address, string city, bool cardPrinted, bool voted)
        {
            Contract.Requires(cpr >= 101000001 && cpr <= 3112999999);

            this.PollingStationId = pollingStationId;
            this.PrimaryKey = cpr;
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.CardPrinted = cardPrinted;
            this.Voted = voted;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoterDO"/> class. 
        /// Parameter-less constructor required for entity mapping. No field-
        /// initialization is done, i.e. all fields are null.
        /// </summary>
        public VoterDO()
        {
        }

        /// <summary>
        /// Gets PrimaryKey.
        /// </summary>
        [Column(IsPrimaryKey = true, Name = "cpr")]
        public uint? PrimaryKey
        {
            get
            {
                return this.primaryKey;
            }

            private set
            {
                Contract.Requires(value >= 101000001 && value <= 3112999999);
                this.primaryKey = value;
            }
        }

        /// <summary>
        /// Gets Cpr as a string.
        /// </summary>
        [Pure]
        public string CprString
        {
            get
            {
                Contract.Requires(PrimaryKey != null);
                Contract.Ensures(Contract.Result<string>().Length == 10);

                string result = this.PrimaryKey.ToString();

                if (result.Length < 10)
                {
                    return "0" + result;
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the id of the polling station this voter is associated with.
        /// </summary>
        [Column]
        public uint? PollingStationId { get; private set; }

        /// <summary>
        /// Gets Name.
        /// </summary>
        [Column]
        public string Name { get; private set; }

        /// <summary>
        /// Gets Address.
        /// </summary>
        [Column]
        public string Address { get; private set; }

        /// <summary>
        /// Gets City.
        /// </summary>
        [Column]
        public string City { get; private set; }

        /// <summary>
        /// Gets a value indicating whether a card has been printed for this voter.
        /// </summary>
        [Column]
        public bool? CardPrinted { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this voter has voted.
        /// </summary>
        [Column]
        public bool? Voted { get; set ; }

        private EntityRef<PollingStationDO> _pollingStation;

        /// <summary>
        /// Gets or sets PollingStation associated with this voter..
        /// </summary>
        [Association(Name = "FK_V_PS", Storage = "_pollingStation", ThisKey = "PollingStationId")]
        public PollingStationDO PollingStation
        {
            get
            {
                return _pollingStation.Entity;
            }

            set
            {
                Contract.Requires(value != null);
                _pollingStation.Entity = value;
            }
        }

        /// <summary>
        /// Is the object fully initialized, i.e. do all fields have non-null values?
        /// </summary>
        /// <returns>True if no fields are null.</returns>
        public bool FullyInitialized()
        {
            return PollingStationId != null && PrimaryKey != null && Name != null && Address != null && CardPrinted != null
                   && Voted != null;
        }

        /// <summary>
        /// Set the values of this object to the values of the dummy object, if the dummys value is non-null.
        /// </summary>
        /// <param name="dummy">
        /// The dummy object, representing new values.
        /// </param>
        public void UpdateValues(IDataObject dummy)
        {
            Contract.Requires(dummy != null); // Re-stipulate this contract, since it must be checked before the added contracts.
            Contract.Requires(dummy.GetType() == this.GetType());
            Contract.Requires(((VoterDO)dummy).PrimaryKey >= 101000001 && ((VoterDO)dummy).PrimaryKey <= 3012999999);

            VoterDO voterDummy = dummy as VoterDO;
            Contract.Assert(voterDummy != null);

            PollingStationId = voterDummy.PollingStationId ?? this.PollingStationId;
            PrimaryKey = voterDummy.PrimaryKey ?? this.PrimaryKey;
            Name = voterDummy.Name ?? this.Name;
            Address = voterDummy.Address ?? this.Address;
            CardPrinted = voterDummy.CardPrinted ?? this.CardPrinted;
            Voted = voterDummy.Voted ?? this.Voted;
        }

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant((PrimaryKey >= 101000001 && PrimaryKey <= 3112999999) || PrimaryKey == null);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = obj as VoterDO;

            return other.Name == this.Name && other.PollingStationId == this.PollingStationId
                   && other.Address == this.Address;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
