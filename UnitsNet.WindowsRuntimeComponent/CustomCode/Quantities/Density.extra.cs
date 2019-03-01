// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    public sealed partial class Density
    {
        /// <summary>
        ///     Gets <see cref="Molarity" /> from this <see cref="Density" />.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public Molarity ToMolarity(Mass molecularWeight)
        {
            return Molarity.FromMolesPerCubicMeter(KilogramsPerCubicMeter / molecularWeight.Kilograms);
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Density" /> from <see cref="Molarity" />.
        /// </summary>
        /// <param name="molarity"></param>
        /// <param name="molecularWeight"></param>
        public static Density FromMolarity(Molarity molarity, Mass molecularWeight)
        {
            return new Density(molarity.MolesPerCubicMeter * molecularWeight.Kilograms, DensityUnit.KilogramPerCubicMeter);
        }

        #endregion
    }
}
