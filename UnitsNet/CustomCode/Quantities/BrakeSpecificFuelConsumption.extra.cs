// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct BrakeSpecificFuelConsumption
    {
        /// <summary>Get <see cref="MassFlow"/> from <see cref="BrakeSpecificFuelConsumption"/> times <see cref="Power"/>.</summary>
        public static MassFlow operator *(BrakeSpecificFuelConsumption bsfc, Power power)
        {
            return MassFlow.FromKilogramsPerSecond(bsfc.KilogramsPerJoule*power.Watts);
        }

        /// <summary>Get <see cref="SpecificEnergy"/> from <paramref name="value"/> divided by <see cref="BrakeSpecificFuelConsumption"/>.</summary>
        public static SpecificEnergy operator /(double value, BrakeSpecificFuelConsumption bsfc)
        {
            return SpecificEnergy.FromJoulesPerKilogram(value/bsfc.KilogramsPerJoule);
        }

        /// <summary>Get constant from <see cref="BrakeSpecificFuelConsumption"/> times <see cref="SpecificEnergy"/>.</summary>
        public static double operator *(BrakeSpecificFuelConsumption bsfc, SpecificEnergy specificEnergy)
        {
            return specificEnergy.JoulesPerKilogram*bsfc.KilogramsPerJoule;
        }
    }
}
