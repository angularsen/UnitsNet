// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Pressure<T>
    {
        /// <summary>Get <see cref="Force{T}"/> from <see cref="Pressure{T}"/> times <see cref="Area{T}"/>.</summary>
        public static Force<T> operator *(Pressure<T> pressure, Area<T> area )
        {
            return Force<T>.FromNewtons(pressure.Pascals * area.SquareMeters);
        }

        /// <summary>Get <see cref="Force{T}"/> from <see cref="Area{T}"/> times <see cref="Pressure{T}"/>.</summary>
        public static Force<T> operator *(Area<T> area, Pressure<T> pressure )
        {
            return Force<T>.FromNewtons(pressure.Pascals * area.SquareMeters);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Pressure{T}"/> divided by <see cref="SpecificWeight{T}"/>.</summary>
        public static Length<T> operator /(Pressure<T> pressure, SpecificWeight<T> specificWeight )
        {
            return new Length<T>( pressure.Pascals / specificWeight.NewtonsPerCubicMeter, UnitsNet.Units.LengthUnit.Meter);
        }

        /// <summary>Get <see cref="SpecificWeight{T}"/> from <see cref="Pressure{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static SpecificWeight<T> operator /(Pressure<T> pressure, Length<T> length )
        {
            return new SpecificWeight<T>( pressure.Pascals / length.Meters, UnitsNet.Units.SpecificWeightUnit.NewtonPerCubicMeter);
        }
    }
}
