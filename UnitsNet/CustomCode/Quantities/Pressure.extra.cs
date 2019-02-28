// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Pressure
    {
        /// <summary>Get <see cref="Force"/> from <see cref="Pressure"/> times <see cref="Area"/>.</summary>
        public static Force operator *(Pressure pressure, Area area)
        {
            return Force.FromNewtons(pressure.Pascals * area.SquareMeters);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="Area"/> times <see cref="Pressure"/>.</summary>
        public static Force operator *(Area area, Pressure pressure)
        {
            return Force.FromNewtons(pressure.Pascals * area.SquareMeters);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Pressure"/> divided by <see cref="SpecificWeight"/>.</summary>
        public static Length operator /(Pressure pressure, SpecificWeight specificWeight)
        {
            return new Length(pressure.Pascals / specificWeight.NewtonsPerCubicMeter, UnitsNet.Units.LengthUnit.Meter);
        }

        /// <summary>Get <see cref="SpecificWeight"/> from <see cref="Pressure"/> divided by <see cref="Length"/>.</summary>
        public static SpecificWeight operator /(Pressure pressure, Length length)
        {
            return new SpecificWeight(pressure.Pascals / length.Meters, UnitsNet.Units.SpecificWeightUnit.NewtonPerCubicMeter);
        }
    }
}
