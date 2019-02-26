// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct MassFlux
    {
        /// <summary>Get <see cref="Density"/> from <see cref="MassFlux"/> divided by <see cref="Speed"/>.</summary>
        public static Density operator /(MassFlux massFlux, Speed speed)
        {
            return Density.FromKilogramsPerCubicMeter(massFlux.KilogramsPerSecondPerSquareMeter / speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="Speed"/> from <see cref="MassFlux"/> divided by <see cref="Density"/>.</summary>
        public static Speed operator /(MassFlux massFlux, Density density)
        {
            return Speed.FromMetersPerSecond(massFlux.KilogramsPerSecondPerSquareMeter / density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="MassFlux"/> times <see cref="Area"/>.</summary>
        public static MassFlow operator *(MassFlux massFlux, Area area)
        {
            return MassFlow.FromGramsPerSecond(massFlux.GramsPerSecondPerSquareMeter * area.SquareMeters);
        }
    }
}
