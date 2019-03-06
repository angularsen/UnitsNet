// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct MassFlow
    {
        /// <summary>Get <see cref="Mass"/> from <see cref="MassFlow"/> times <see cref="TimeSpan"/>.</summary>
        public static Mass operator *(MassFlow massFlow, TimeSpan time)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="TimeSpan"/> times <see cref="MassFlow"/>.</summary>
        public static Mass operator *(TimeSpan time, MassFlow massFlow)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="MassFlow"/> times <see cref="Duration"/>.</summary>
        public static Mass operator *(MassFlow massFlow, Duration duration)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="Duration"/> times <see cref="MassFlow"/>.</summary>
        public static Mass operator *(Duration duration, MassFlow massFlow)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="MassFlow"/> divided by <see cref="BrakeSpecificFuelConsumption"/>.</summary>
        public static Power operator /(MassFlow massFlow, BrakeSpecificFuelConsumption bsfc)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond / bsfc.KilogramsPerJoule);
        }

        /// <summary>Get <see cref="BrakeSpecificFuelConsumption"/> from <see cref="MassFlow"/> divided by <see cref="Power"/>.</summary>
        public static BrakeSpecificFuelConsumption operator /(MassFlow massFlow, Power power)
        {
            return BrakeSpecificFuelConsumption.FromKilogramsPerJoule(massFlow.KilogramsPerSecond / power.Watts);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="MassFlow"/> times <see cref="SpecificEnergy"/>.</summary>
        public static Power operator *(MassFlow massFlow, SpecificEnergy specificEnergy)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond * specificEnergy.JoulesPerKilogram);
        }

        /// <summary>Get <see cref="MassFlux"/> from <see cref="MassFlow"/> divided by <see cref="Area"/>.</summary>
        public static MassFlux operator /(MassFlow massFlow, Area area)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(massFlow.KilogramsPerSecond / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="MassFlow"/> divided by <see cref="MassFlux"/>.</summary>
        public static Area operator /(MassFlow massFlow, MassFlux massFlux)
        {
            return Area.FromSquareMeters(massFlow.KilogramsPerSecond / massFlux.KilogramsPerSecondPerSquareMeter);
        }

        /// <summary>Get <see cref="Density"/> from <see cref="MassFlow"/> divided by <see cref="VolumeFlow"/>.</summary>
        public static Density operator /(MassFlow massFlow, VolumeFlow volumeFlow)
        {
            return Density.FromKilogramsPerCubicMeter(massFlow.KilogramsPerSecond / volumeFlow.CubicMetersPerSecond);
        }

        /// <summary>Get <see cref="VolumeFlow"/> from <see cref="MassFlow"/> divided by <see cref="Density"/>.</summary>
        public static VolumeFlow operator /(MassFlow massFlow, Density density)
        {
            return VolumeFlow.FromCubicMetersPerSecond(massFlow.KilogramsPerSecond / density.KilogramsPerCubicMeter);
        }
    }
}
