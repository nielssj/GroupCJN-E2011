// <copyright file="RandomPreparation.cs">Copyright ©  2011</copyright>

using System;
using Microsoft.Pex.Framework;
using System.Moles;

namespace System.Preparations
{
    /// <summary>Contains a method to prepare the type Random</summary>
    public static partial class RandomPreparation
    {
        /// <summary>Prepares the environment (and the moles) before executing any method of the prepared type Random</summary>
        [PexPreparationMethod(typeof(Random))]
        public static void Prepare()
        {
            MRandom.BehaveAsCurrent();
            // TODO: use Moles to replace API that call into the environment
        }
    }
}
