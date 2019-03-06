// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificEnergy
    {
        /// <summary>Get <see cref="Energy"/> from <see cref="SpecificEnergy"/> times <see cref="Mass"/>.</summary>
        public static Energy operator *(SpecificEnergy specificEnergy, Mass mass)
        {
            return Energy.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }

        /// <summary>Get <see cref="Energy"/> from <see cref="Mass"/> times <see cref="SpecificEnergy"/>.</summary>
        public static Energy operator *(Mass mass, SpecificEnergy specificEnergy)
        {
            return Energy.FromJoules(specificEnergy.JoulesPerKilogram * mass.Kilograms);
        }

        /// <summary>Get <see cref="BrakeSpecificFuelConsumption"/> from <see cref="double"/> divided by <see cref="SpecificEnergy"/>.</summary>
        public static BrakeSpecificFuelConsumption operator /(double value, SpecificEnergy specificEnergy)
        {
            return BrakeSpecificFuelConsumption.FromKilogramsPerJoule(value / specificEnergy.JoulesPerKilogram);
        }

        /// <summary>Get <see cref="double"/> from <see cref="SpecificEnergy"/> times <see cref="BrakeSpecificFuelConsumption"/>.</summary>
        public static double operator *(SpecificEnergy specificEnergy, BrakeSpecificFuelConsumption bsfc)
        {
            return specificEnergy.JoulesPerKilogram * bsfc.KilogramsPerJoule;
        }

        /// <summary>Get <see cref="Power"/> from <see cref="SpecificEnergy"/> times <see cref="MassFlow"/>.</summary>
        public static Power operator *(SpecificEnergy specificEnergy, MassFlow massFlow)
        {
            return Power.FromWatts(massFlow.KilogramsPerSecond * specificEnergy.JoulesPerKilogram);
        }
    }
}
