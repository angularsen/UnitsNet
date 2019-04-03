// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct MolarMass
    {
        /// <summary>Get <see cref="AmountOfSubstance" /> from <see cref="MolarMass" /> divided by <see cref="Mass" />.</summary>
        public static AmountOfSubstance operator /(Mass mass, MolarMass molarMass)
        {
            return AmountOfSubstance.FromMoles(mass.Kilograms / molarMass.KilogramsPerMole);
        }

    }
}
