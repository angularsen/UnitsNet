// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct ElectricResistivity
    {
        /// <summary>
        /// Calculates the inverse or <see cref="ElectricConductivity"/> of this unit.
        /// </summary>
        /// <returns>The inverse or <see cref="ElectricConductivity"/> of this unit.</returns>
        public ElectricConductivity Inverse()
        {
            if (OhmMeters == 0.0)
                return new ElectricConductivity( 0, ElectricConductivityUnit.SiemensPerMeter );

            return new ElectricConductivity( 1 / OhmMeters, ElectricConductivityUnit.SiemensPerMeter );
        }
    }
}
