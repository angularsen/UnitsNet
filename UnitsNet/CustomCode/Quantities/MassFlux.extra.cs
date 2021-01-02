// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct MassFlux<T>
    {
        /// <summary>Get <see cref="Density{T}"/> from <see cref="MassFlux{T}"/> divided by <see cref="Speed{T}"/>.</summary>
        public static Density<T> operator /(MassFlux<T> massFlux, Speed<T> speed )
        {
            return Density<T>.FromKilogramsPerCubicMeter(massFlux.KilogramsPerSecondPerSquareMeter / speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Speed{T}"/> from <see cref="MassFlux{T}"/> divided by <see cref="Density{T}"/>.</summary>
        public static Speed<T> operator /(MassFlux<T> massFlux, Density<T> density )
        {
            return Speed<T>.FromMetersPerSecond(massFlux.KilogramsPerSecondPerSquareMeter / density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="MassFlux{T}"/> times <see cref="Area{T}"/>.</summary>
        public static MassFlow<T> operator *(MassFlux<T> massFlux, Area<T> area )
        {
            return MassFlow<T>.FromGramsPerSecond(massFlux.GramsPerSecondPerSquareMeter * area.SquareMeters);
        }
    }
}
