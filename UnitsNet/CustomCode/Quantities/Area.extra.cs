// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Area
    {
        #region Static Methods

        /// <summary>Get circle area from a diameter.</summary>
        public static Area FromCircleDiameter(Length diameter)
        {
            var radius = Length.FromMeters(diameter.Meters / 2d);
            return FromCircleRadius(radius);
        }

        /// <summary>Get circle area from a radius.</summary>
        public static Area FromCircleRadius(Length radius)
        {
            return FromSquareMeters(Math.PI * radius.Meters * radius.Meters);
        }

        #endregion

        /// <summary>
        /// Calculates the inverse of this quantity.
        /// </summary>
        /// <returns>The corresponding inverse quantity, <see cref="ReciprocalArea"/>.</returns>
        public ReciprocalArea Inverse()
        {
            if (SquareMeters == 0.0)
                return new ReciprocalArea(0.0, UnitsNet.Units.ReciprocalAreaUnit.InverseSquareMeter);

            return new ReciprocalArea(1 / SquareMeters, UnitsNet.Units.ReciprocalAreaUnit.InverseSquareMeter);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Area"/> divided by <see cref="Length"/>.</summary>
        public static Length operator /(Area area, Length length)
        {
            return Length.FromMeters(area.SquareMeters / length.Meters);
        }

        /// <summary>Get <see cref="ReciprocalLength"/> from <see cref="Area"/> divided by <see cref="Volume"/>.</summary>
        public static ReciprocalLength operator /(Area area, Volume volume)
        {
            return ReciprocalLength.FromInverseMeters(area.SquareMeters / volume.CubicMeters);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="Area"/> times <see cref="MassFlux"/>.</summary>
        public static MassFlow operator *(Area area, MassFlux massFlux)
        {
            return MassFlow.FromGramsPerSecond(area.SquareMeters * massFlux.GramsPerSecondPerSquareMeter);
        }

        /// <summary>Get <see cref="VolumeFlow"/> from <see cref="Area"/> times <see cref="Speed"/>.</summary>
        public static VolumeFlow operator *(Area area, Speed speed)
        {
            return VolumeFlow.FromCubicMetersPerSecond(area.SquareMeters * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="LinearDensity"/> from <see cref="Area"/> times <see cref="Density"/>.</summary>
        public static LinearDensity operator *(Area area, Density density)
        {
            return LinearDensity.FromKilogramsPerMeter(area.SquareMeters * density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="Ratio"/> from <see cref="Area"/> times <see cref="ReciprocalArea"/>.</summary>
        public static Ratio operator *(Area area, ReciprocalArea reciprocalArea)
        {
            return Ratio.FromDecimalFractions(area.SquareMeters * reciprocalArea.InverseSquareMeters);
        }
    }
}
