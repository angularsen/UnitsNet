// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificEnergy<T>
    {
        /// <summary>Get <see cref="Energy{T}"/> from <see cref="SpecificEnergy{T}"/> times <see cref="Mass{T}"/>.</summary>
        public static Energy<T> operator *(SpecificEnergy<T> specificEnergy, Mass<T> mass )
        {
            return Energy<T>.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }

        /// <summary>Get <see cref="Energy{T}"/> from <see cref="Mass{T}"/> times <see cref="SpecificEnergy{T}"/>.</summary>
        public static Energy<T> operator *(Mass<T> mass, SpecificEnergy<T> specificEnergy )
        {
            return Energy<T>.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }

        /// <summary>Get <see cref="BrakeSpecificFuelConsumption{T}"/> from <see cref="double"/> divided by <see cref="SpecificEnergy{T}"/>.</summary>
        public static BrakeSpecificFuelConsumption<T> operator /(double value, SpecificEnergy<T> specificEnergy )
        {
            return BrakeSpecificFuelConsumption<T>.FromKilogramsPerJoule(value / specificEnergy.JoulesPerKilogram);
        }

        /// <summary>Get <see cref="double"/> from <see cref="SpecificEnergy{T}"/> times <see cref="BrakeSpecificFuelConsumption{T}"/>.</summary>
        public static double operator *(SpecificEnergy<T> specificEnergy, BrakeSpecificFuelConsumption<T> bsfc )
        {
            return specificEnergy.JoulesPerKilogram * bsfc.KilogramsPerJoule;
        }

        /// <summary>Get <see cref="Power{T}"/> from <see cref="SpecificEnergy{T}"/> times <see cref="MassFlow{T}"/>.</summary>
        public static Power<T> operator *(SpecificEnergy<T> specificEnergy, MassFlow<T> massFlow )
        {
            return Power<T>.FromWatts(massFlow.KilogramsPerSecond * specificEnergy.JoulesPerKilogram);
        }
    }
}
