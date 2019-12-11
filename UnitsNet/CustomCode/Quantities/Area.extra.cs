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

        /// <summary>Get <see cref="Length"/> from <see cref="Area"/> divided by <see cref="Length"/>.</summary>
        public static Length operator /(Area area, Length length)
        {
            return Length.FromMeters(area.SquareMeters / length.Meters);
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
    }
}
