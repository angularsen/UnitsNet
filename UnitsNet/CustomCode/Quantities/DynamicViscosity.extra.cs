// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct DynamicViscosity
    {
        /// <summary>Get <see cref="KinematicViscosity"/> from <see cref="DynamicViscosity"/> divided by <see cref="Density"/>.</summary>
        public static KinematicViscosity operator /(DynamicViscosity dynamicViscosity, Density density)
        {
            return KinematicViscosity.FromSquareMetersPerSecond(dynamicViscosity.NewtonSecondsPerMeterSquared / density.KilogramsPerCubicMeter);
        }
    }
}
