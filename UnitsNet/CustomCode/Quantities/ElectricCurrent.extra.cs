using System;
using System.Collections.Generic;
using System.Text;

namespace UnitsNet
{
    public partial struct ElectricCurrent
    {
        /// <summary>Get <see cref="ElectricPotential"/> from <see cref="ElectricResistance"/> multiplied by <see cref="ElectricCurrent"/>.</summary>
        /// <remarks>Ohm's law implementation</remarks>
        public static ElectricPotential operator *(ElectricCurrent current, ElectricResistance resistance)
        {
            return ElectricPotential.FromVolts(resistance.Ohms * current.Amperes);
        }
    }
}
