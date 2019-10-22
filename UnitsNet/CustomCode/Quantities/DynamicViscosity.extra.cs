// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct DynamicViscosity<T>
    {
        /// <summary>Get <see cref="KinematicViscosity{T}"/> from <see cref="DynamicViscosity{T}"/> divided by <see cref="Density{T}"/>.</summary>
        public static KinematicViscosity<T> operator /(DynamicViscosity<T> dynamicViscosity, Density<T> density )
        {
            return KinematicViscosity<T>.FromSquareMetersPerSecond(dynamicViscosity.NewtonSecondsPerMeterSquared / density.KilogramsPerCubicMeter);
        }
    }
}
