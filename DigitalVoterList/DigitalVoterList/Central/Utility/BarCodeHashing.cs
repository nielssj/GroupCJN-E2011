// -----------------------------------------------------------------------
// <copyright file="BarCodeHashing.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DigitalVoterList.Central.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BarCodeHashing
    {
        public static long Hash(uint cprno)
        {
            return Convert.ToInt64(cprno) * 101;
        }

        public static uint UnHash(string barcode)
        {
            long bc = Convert.ToInt64(barcode);
            return Convert.ToUInt32(bc / 101);
        }
    }
}
