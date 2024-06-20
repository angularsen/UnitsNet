// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct ElectricConductance
    {
        /// <summary>Get <see cref="ElectricConductancePerArea"/> from <see cref="ElectricConductance"/> divided by <see cref="Area"/>.</summary>
        public static ElectricConductancePerArea operator /(ElectricConductance ec, Area area)
        {
            return ElectricConductancePerArea.FromElectricConductanceByArea(ec, area);
        }
    }
}