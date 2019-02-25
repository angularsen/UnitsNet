// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct BrakeSpecificFuelConsumption
    {
        public static MassFlow operator *(BrakeSpecificFuelConsumption bsfc, Power power)
        {
            return MassFlow.FromKilogramsPerSecond(bsfc.KilogramsPerJoule*power.Watts);
        }

        public static SpecificEnergy operator /(double value, BrakeSpecificFuelConsumption bsfc)
        {
            return SpecificEnergy.FromJoulesPerKilogram(value/bsfc.KilogramsPerJoule);
        }

        public static double operator *(BrakeSpecificFuelConsumption bsfc, SpecificEnergy specificEnergy)
        {
            return specificEnergy.JoulesPerKilogram*bsfc.KilogramsPerJoule;
        }
    }
}
