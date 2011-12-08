// <copyright file="LogDOFactory.cs">Copyright ©  2011</copyright>

using System;
using Microsoft.Pex.Framework;
using DBComm.DBComm.DO;

namespace DBComm.DBComm.DO
{
    /// <summary>A factory for DBComm.DBComm.DO.LogDO instances</summary>
    public static partial class LogDOFactory
    {
        /// <summary>A factory for DBComm.DBComm.DO.LogDO instances</summary>
        [PexFactoryMethod(typeof(LogDO))]
        public static LogDO Create(IDataObject dummy_iDataObject)
        {
            LogDO logDO = new LogDO();
            logDO.UpdateValues(dummy_iDataObject);
            return logDO;

            // TODO: Edit factory method of LogDO
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
