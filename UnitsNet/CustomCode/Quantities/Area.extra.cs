// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Area<T>
    {
        #region Static Methods

        /// <summary>Get circle area from a diameter.</summary>
        public static Area<T> FromCircleDiameter(Length<T> diameter )
        {
            var radius = Length<T>.FromMeters(diameter.Meters / 2d);
            return FromCircleRadius(radius);
        }

        /// <summary>Get circle area from a radius.</summary>
        public static Area<T> FromCircleRadius(Length<T> radius )
        {
            return FromSquareMeters(Math.PI * radius.Meters * radius.Meters);
        }

        #endregion

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Area{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static Length<T> operator /(Area<T> area, Length<T> length )
        {
            return Length<T>.FromMeters(area.SquareMeters / length.Meters);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="Area{T}"/> times <see cref="MassFlux{T}"/>.</summary>
        public static MassFlow<T> operator *(Area<T> area, MassFlux<T> massFlux )
        {
            return MassFlow<T>.FromGramsPerSecond(area.SquareMeters * massFlux.GramsPerSecondPerSquareMeter);
        }

        /// <summary>Get <see cref="VolumeFlow{T}"/> from <see cref="Area{T}"/> times <see cref="Speed{T}"/>.</summary>
        public static VolumeFlow<T> operator *(Area<T> area, Speed<T> speed )
        {
            return VolumeFlow<T>.FromCubicMetersPerSecond(area.SquareMeters * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="LinearDensity"/> from <see cref="Area"/> times <see cref="Density"/>.</summary>
        public static LinearDensity operator *(Area area, Density density)
        {
            return LinearDensity.FromKilogramsPerMeter(area.SquareMeters * density.KilogramsPerCubicMeter);
        }
    }
}
