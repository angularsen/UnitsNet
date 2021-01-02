// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct MassFlow<T>
    {
        /// <summary>Get <see cref="Mass{T}"/> from <see cref="MassFlow{T}"/> times <see cref="TimeSpan"/>.</summary>
        public static Mass<T> operator *(MassFlow<T> massFlow, TimeSpan time)
        {
            return Mass<T>.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="TimeSpan"/> times <see cref="MassFlow{T}"/>.</summary>
        public static Mass<T> operator *(TimeSpan time, MassFlow<T> massFlow )
        {
            return Mass<T>.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="MassFlow{T}"/> times <see cref="Duration{T}"/>.</summary>
        public static Mass<T> operator *(MassFlow<T> massFlow, Duration<T> duration )
        {
            return Mass<T>.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="Duration{T}"/> times <see cref="MassFlow{T}"/>.</summary>
        public static Mass<T> operator *(Duration<T> duration, MassFlow<T> massFlow )
        {
            return Mass<T>.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Power{T}"/> from <see cref="MassFlow{T}"/> divided by <see cref="BrakeSpecificFuelConsumption{T}"/>.</summary>
        public static Power<T> operator /(MassFlow<T> massFlow, BrakeSpecificFuelConsumption<T> bsfc )
        {
            return Power<T>.FromWatts(massFlow.KilogramsPerSecond / bsfc.KilogramsPerJoule);
        }

        /// <summary>Get <see cref="BrakeSpecificFuelConsumption{T}"/> from <see cref="MassFlow{T}"/> divided by <see cref="Power{T}"/>.</summary>
        public static BrakeSpecificFuelConsumption<T> operator /(MassFlow<T> massFlow, Power<T> power )
        {
            return BrakeSpecificFuelConsumption<T>.FromKilogramsPerJoule(massFlow.KilogramsPerSecond / power.Watts);
        }

        /// <summary>Get <see cref="Power{T}"/> from <see cref="MassFlow{T}"/> times <see cref="SpecificEnergy{T}"/>.</summary>
        public static Power<T> operator *(MassFlow<T> massFlow, SpecificEnergy<T> specificEnergy )
        {
            return Power<T>.FromWatts(massFlow.KilogramsPerSecond * specificEnergy.JoulesPerKilogram);
        }

        /// <summary>Get <see cref="MassFlux{T}"/> from <see cref="MassFlow{T}"/> divided by <see cref="Area{T}"/>.</summary>
        public static MassFlux<T> operator /(MassFlow<T> massFlow, Area<T> area )
        {
            return MassFlux<T>.FromKilogramsPerSecondPerSquareMeter(massFlow.KilogramsPerSecond / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="MassFlow{T}"/> divided by <see cref="MassFlux{T}"/>.</summary>
        public static Area<T> operator /(MassFlow<T> massFlow, MassFlux<T> massFlux )
        {
            return Area<T>.FromSquareMeters(massFlow.KilogramsPerSecond / massFlux.KilogramsPerSecondPerSquareMeter);
        }

        /// <summary>Get <see cref="Density{T}"/> from <see cref="MassFlow{T}"/> divided by <see cref="VolumeFlow{T}"/>.</summary>
        public static Density<T> operator /(MassFlow<T> massFlow, VolumeFlow<T> volumeFlow )
        {
            return Density<T>.FromKilogramsPerCubicMeter(massFlow.KilogramsPerSecond / volumeFlow.CubicMetersPerSecond);
        }

        /// <summary>Get <see cref="VolumeFlow{T}"/> from <see cref="MassFlow{T}"/> divided by <see cref="Density{T}"/>.</summary>
        public static VolumeFlow<T> operator /(MassFlow<T> massFlow, Density<T> density )
        {
            return VolumeFlow<T>.FromCubicMetersPerSecond(massFlow.KilogramsPerSecond / density.KilogramsPerCubicMeter);
        }
    }
}
