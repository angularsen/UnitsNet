// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct JapaneseHydrometerScale
    {
        private static readonly Density WaterDensityAt4C = Density.FromKilogramsPerCubicMeter(999.974950);

        /// <summary>
        ///     Converts this hydrometer scale reading to an equivalent density, using the density of water at 4 °C as the reference.
        /// </summary>
        /// <param name="unit">The density unit to convert to.</param>
        /// <returns>A <see cref="Density" /> representing the equivalent density.</returns>
        public Density ToDensity(DensityUnit unit = DensityUnit.CentigramPerDeciliter)
        {
            return (WaterDensityAt4C / ReciprocalSpecificGravities).ToUnit(unit);
        }

        /// <summary>
        ///     Converts this hydrometer scale reading to an equivalent specific gravity.
        /// </summary>
        /// <returns>A <see cref="Ratio" /> representing the equivalent specific gravity.</returns>
        public Ratio ToSpecificGravity()
        {
            return Ratio.FromDecimalFractions(1 / ReciprocalSpecificGravities);
        }
    }
}
