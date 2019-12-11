// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct ElectricResistance
    {
        /// <summary>Get <see cref="ElectricPotential"/> from <see cref="ElectricResistance"/> multiplied by <see cref="ElectricCurrent"/>.</summary>
        /// <remarks>Ohm's law implementation</remarks>
        public static ElectricPotential operator *(ElectricResistance resistance, ElectricCurrent current)
        {
            return ElectricPotential.FromVolts(resistance.Ohms * current.Amperes);
        }
    }
}
