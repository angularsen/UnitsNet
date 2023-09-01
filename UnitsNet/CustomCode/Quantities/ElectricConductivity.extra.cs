// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct ElectricConductivity
    {
        /// <summary>
        /// Calculates the inverse or <see cref="ElectricResistivity"/> of this unit.
        /// </summary>
        /// <returns>The inverse or <see cref="ElectricResistivity"/> of this unit.</returns>
        public ElectricResistivity Inverse()
        {
            if (SiemensPerMeter == 0.0)
                return new ElectricResistivity( 0.0, ElectricResistivityUnit.OhmMeter );

            return new ElectricResistivity( 1 / SiemensPerMeter, ElectricResistivityUnit.OhmMeter );
        }
    }
}
