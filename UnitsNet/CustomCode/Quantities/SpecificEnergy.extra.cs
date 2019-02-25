// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificEnergy
    {
        public static Energy operator *(SpecificEnergy specificEnergy, Mass mass)
        {
            return Energy.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }

        public static Energy operator *(Mass mass, SpecificEnergy specificEnergy)
        {
            return Energy.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }

        public static BrakeSpecificFuelConsumption operator /(double value, SpecificEnergy specificEnergy)
        {
            return BrakeSpecificFuelConsumption.FromKilogramsPerJoule(value / specificEnergy.JoulesPerKilogram);
        }

        public static double operator *(SpecificEnergy specificEnergy, BrakeSpecificFuelConsumption bsfc)
        {
            return specificEnergy.JoulesPerKilogram * bsfc.KilogramsPerJoule;
        }

        public static Power operator *(SpecificEnergy specificEnergy, MassFlow massFlow)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond * specificEnergy.JoulesPerKilogram);
        }
    }
}
