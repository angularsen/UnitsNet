// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Area
    {
        #region Static Methods

        public static Area FromCircleDiameter(Length diameter)
        {
            var radius = Length.FromMeters(diameter.Meters / 2d);
            return FromCircleRadius(radius);
        }

        public static Area FromCircleRadius(Length radius)
        {
            return FromSquareMeters(Math.PI * radius.Meters * radius.Meters);
        }

        #endregion

        public static Length operator /(Area area, Length length)
        {
            return Length.FromMeters(area.SquareMeters / length.Meters);
        }

        public static MassFlow operator *(Area area, MassFlux massFlux)
        {
            return MassFlow.FromGramsPerSecond(area.SquareMeters * massFlux.GramsPerSecondPerSquareMeter);
        }

        public static VolumeFlow operator *(Area area, Speed speed)
        {
            return VolumeFlow.FromCubicMetersPerSecond(area.SquareMeters * speed.MetersPerSecond);
        }
    }
}
