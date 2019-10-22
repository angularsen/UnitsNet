// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct BrakeSpecificFuelConsumption<T>
    {
        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="BrakeSpecificFuelConsumption{T}"/> times <see cref="Power{T}"/>.</summary>
        public static MassFlow<T> operator *(BrakeSpecificFuelConsumption<T> bsfc, Power<T> power )
        {
            return MassFlow<T>.FromKilogramsPerSecond(bsfc.KilogramsPerJoule*power.Watts);
        }

        /// <summary>Get <see cref="SpecificEnergy{T}"/> from <paramref name="value"/> divided by <see cref="BrakeSpecificFuelConsumption{T}"/>.</summary>
        public static SpecificEnergy<T> operator /(double value, BrakeSpecificFuelConsumption<T> bsfc )
        {
            return SpecificEnergy<T>.FromJoulesPerKilogram(value/bsfc.KilogramsPerJoule);
        }

        /// <summary>Get constant from <see cref="BrakeSpecificFuelConsumption{T}"/> times <see cref="SpecificEnergy{T}"/>.</summary>
        public static double operator *(BrakeSpecificFuelConsumption<T> bsfc, SpecificEnergy<T> specificEnergy )
        {
            return specificEnergy.JoulesPerKilogram*bsfc.KilogramsPerJoule;
        }
    }
}
