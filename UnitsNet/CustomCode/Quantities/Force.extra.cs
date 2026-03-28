// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Force
    {
        /// <summary>Get <see cref="Force"/> from <see cref="Pressure"/> divided by <see cref="Area"/>.</summary>
        public static Force FromPressureByArea(Pressure p, Area area)
        {
            double newtons = p.Pascals * area.SquareMeters;
            return new Force(newtons, ForceUnit.Newton);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="Mass"/> times <see cref="Acceleration"/>.</summary>
        public static Force FromMassByAcceleration(Mass mass, Acceleration acceleration)
        {
            return new Force(mass.Kilograms * acceleration.MetersPerSecondSquared, ForceUnit.Newton);
        }
    }
}
