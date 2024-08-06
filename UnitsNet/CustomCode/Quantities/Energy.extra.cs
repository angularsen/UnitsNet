// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Energy
    {
        /// <summary>Get <see cref="Power"/> from <see cref="Energy"/> divided by <see cref="TimeSpan"/>.</summary>
        public static Power operator /(Energy energy, TimeSpan time)
        {
            return Power.FromWatts(energy.Joules / time.TotalSeconds);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="Energy"/> divided by <see cref="Duration"/>.</summary>
        public static Power operator /(Energy energy, Duration duration)
        {
            return Power.FromWatts(energy.Joules / duration.Seconds);
        }

        /// <summary>Get <see cref="Duration"/> from <see cref="Energy"/> divided by <see cref="Power"/>.</summary>
        public static Duration operator /(Energy energy, Power power)
        {
            return Duration.FromSeconds(energy.Joules / (double)power.Watts);
        }

        /// <summary>Get <see cref="ElectricCharge"/> from <see cref="Energy"/> divided by <see cref="ElectricPotential"/>.</summary>
        public static ElectricCharge operator /(Energy energy, ElectricPotential potential)
        {
            return ElectricCharge.FromCoulombs(energy.Joules / potential.Volts);
        }

        /// <summary>Get <see cref="ElectricPotential"/> from <see cref="Energy"/> divided by <see cref="ElectricCharge"/>.</summary>
        public static ElectricPotential operator /(Energy energy, ElectricCharge current)
        {
            return ElectricPotential.FromVolts(energy.Joules / current.Coulombs);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="Energy"/> times <see cref="Frequency"/>.</summary>
        public static Power operator *(Energy energy, Frequency frequency)
        {
            return Power.FromWatts(energy.Joules * frequency.PerSecond);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="Frequency"/> times <see cref="Power"/>.</summary>
        public static Power operator *(Frequency frequency, Energy energy)
        {
            return Power.FromWatts(energy.Joules * frequency.PerSecond);
        }

        /// <summary>Get <see cref="Entropy"/> from <see cref="Energy"/> divided by <see cref="TemperatureDelta"/> </summary>
        public static Entropy operator /(Energy energy, TemperatureDelta temperatureDelta)
        {
            return Entropy.FromJoulesPerKelvin(energy.Joules / temperatureDelta.Kelvins);
        }

        /// <summary>Get <see cref="TemperatureDelta"/> from <see cref="Energy"/> divided by <see cref="Entropy"/>.</summary>
        public static TemperatureDelta operator /(Energy energy, Entropy entropy)
        {
            return TemperatureDelta.FromKelvins(energy.Joules / entropy.JoulesPerKelvin);
        }

        /// <summary>Get <see cref="SpecificEnergy"/> from <see cref="Energy"/> divided by <see cref="Mass"/> </summary>
        public static SpecificEnergy operator /(Energy energy, Mass mass)
        {
            return SpecificEnergy.FromJoulesPerKilogram(energy.Joules / mass.Kilograms);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="Energy"/> divided by <see cref="SpecificEnergy"/>.</summary>
        public static Mass operator /(Energy energy, SpecificEnergy specificEnergy)
        {
            return Mass.FromKilograms(energy.Joules / specificEnergy.JoulesPerKilogram);
        }
    }
}
