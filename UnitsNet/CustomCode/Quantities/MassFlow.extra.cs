// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct MassFlow
    {
        public static Mass operator *(MassFlow massFlow, TimeSpan time)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        public static Mass operator *(TimeSpan time, MassFlow massFlow)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * time.TotalSeconds);
        }

        public static Mass operator *(MassFlow massFlow, Duration duration)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        public static Mass operator *(Duration duration, MassFlow massFlow)
        {
            return Mass.FromKilograms(massFlow.KilogramsPerSecond * duration.Seconds);
        }

        public static Power operator /(MassFlow massFlow, BrakeSpecificFuelConsumption bsfc)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond / bsfc.KilogramsPerJoule);
        }

        public static BrakeSpecificFuelConsumption operator /(MassFlow massFlow, Power power)
        {
            return BrakeSpecificFuelConsumption.FromKilogramsPerJoule(massFlow.KilogramsPerSecond / power.Watts);
        }

        public static Power operator *(MassFlow massFlow, SpecificEnergy specificEnergy)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond * specificEnergy.JoulesPerKilogram);
        }

        public static MassFlux operator /(MassFlow massFlow, Area area)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(massFlow.KilogramsPerSecond / area.SquareMeters);
        }

        public static Area operator /(MassFlow massFlow, MassFlux massFlux)
        {
            return Area.FromSquareMeters(massFlow.KilogramsPerSecond / massFlux.KilogramsPerSecondPerSquareMeter);
        }

        public static Density operator /(MassFlow massFlow, VolumeFlow volumeFlow)
        {
            return Density.FromKilogramsPerCubicMeter(massFlow.KilogramsPerSecond / volumeFlow.CubicMetersPerSecond);
        }

        public static VolumeFlow operator /(MassFlow massFlow, Density density)
        {
            return VolumeFlow.FromCubicMetersPerSecond(massFlow.KilogramsPerSecond / density.KilogramsPerCubicMeter);
        }
    }
}
