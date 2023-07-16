// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct ElectricPotential
    {
        /// <summary>
        ///     Gets an <see cref="AmplitudeRatio" /> in decibels (dB) relative to 1 volt RMS from this <see cref="ElectricPotential" />.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a voltage to an amplitude ratio (relative to 1 volt RMS).
        ///     <example>
        ///         <c>var voltageRatio = voltage.ToAmplitudeRatio();</c>
        ///     </example>
        /// </remarks>
        public AmplitudeRatio ToAmplitudeRatio()
        {
            return AmplitudeRatio.FromElectricPotential(this);
        }

        /// <summary>Get <see cref="ElectricResistance"/> from <see cref="ElectricPotential"/> divided by <see cref="ElectricCurrent"/>.</summary>
        /// <remarks>Ohm's law implementation</remarks>
        public static ElectricResistance operator /(ElectricPotential potential, ElectricCurrent current)
        {
            return ElectricResistance.FromOhms(potential.Volts / current.Amperes);
        }

        /// <summary>Get <see cref="ElectricCurrent"/> from <see cref="ElectricPotential"/> divided by <see cref="ElectricResistance"/>.</summary>
        /// <remarks>Ohm's law implementation</remarks>
        public static ElectricCurrent operator /(ElectricPotential potential, ElectricResistance resistance)
        {
            return ElectricCurrent.FromAmperes(potential.Volts / resistance.Ohms);
        }

        /// <summary>Calculate <see cref="Power"/> from <see cref="ElectricPotential"/> multiplied by <see cref="ElectricCurrent"/>.</summary>
        /// <remarks>Electric power is defined as P = U * I.</remarks>
        public static Power operator *(ElectricPotential potential, ElectricCurrent current)
        {
            return Power.FromWatts(potential.Volts * current.Amperes);
        }

        /// <summary>Get <see cref="Energy"/> from <see cref="ElectricPotential"/> times <see cref="ElectricCharge"/>.</summary>
        public static Energy operator *(ElectricPotential potential, ElectricCharge charge)
        {
            return Energy.FromJoules(potential.Volts * charge.Coulombs);
        }
    }
}
