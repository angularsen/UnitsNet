// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct SpecificWeight<T>
    {
        /// <summary>Get <see cref="Pressure{T}"/> from <see cref="SpecificWeight{T}"/> times <see cref="Length{T}"/>.</summary>
        public static Pressure<T> operator *(SpecificWeight<T> specificWeight, Length<T> length )
        {
            return new Pressure<T>( specificWeight.NewtonsPerCubicMeter * length.Meters, UnitsNet.Units.PressureUnit.Pascal);
        }

        /// <summary>Get <see cref="ForcePerLength{T}"/> from <see cref="SpecificWeight{T}"/> times <see cref="Area{T}"/>.</summary>
        public static ForcePerLength<T> operator *(SpecificWeight<T> specificWeight, Area<T> area )
        {
            return new ForcePerLength<T>( specificWeight.NewtonsPerCubicMeter * area.SquareMeters, ForcePerLengthUnit.NewtonPerMeter);
        }

        /// <summary>Get <see cref="ForcePerLength{T}"/> from <see cref="Area{T}"/> times <see cref="SpecificWeight{T}"/>.</summary>
        public static ForcePerLength<T> operator *(Area<T> area, SpecificWeight<T> specificWeight )
        {
            return new ForcePerLength<T>( area.SquareMeters * specificWeight.NewtonsPerCubicMeter, ForcePerLengthUnit.NewtonPerMeter);
        }

        /// <summary>Get <see cref="Acceleration{T}"/> from <see cref="SpecificWeight{T}"/> divided by <see cref="Density{T}"/>.</summary>
        public static Acceleration<T> operator /(SpecificWeight<T> specificWeight, Density<T> density )
        {
            return new Acceleration<T>( specificWeight.NewtonsPerCubicMeter / density.KilogramsPerCubicMeter, UnitsNet.Units.AccelerationUnit.MeterPerSecondSquared);
        }

        /// <summary>Get <see cref="Density{T}"/> from <see cref="SpecificWeight{T}"/> divided by <see cref="Acceleration{T}"/>.</summary>
        public static Density<T> operator /(SpecificWeight<T> specific, Acceleration<T> acceleration )
        {
            return new Density<T>( specific.NewtonsPerCubicMeter / acceleration.MetersPerSecondSquared, UnitsNet.Units.DensityUnit.KilogramPerCubicMeter);
        }
    }
}
