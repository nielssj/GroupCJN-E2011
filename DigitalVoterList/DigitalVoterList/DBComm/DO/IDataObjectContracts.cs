// -----------------------------------------------------------------------
// <copyright file="IDataObjectContracts.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.DBComm.DO
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [ContractClassFor(typeof(IDataObject))]
    abstract class IDataObjectContracts : IDataObject
    {
        #region Implementation of IDataObject

        public uint? PrimaryKey
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        [Pure]
        bool IDataObject.FullyInitialized()
        {
            return false;
        }

        void IDataObject.UpdateValues(IDataObject dummy)
        {
            Contract.Requires(dummy.GetType() == this.GetType());
        }

        #endregion
    }
}
