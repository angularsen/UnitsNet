// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct AmplitudeRatio
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AmplitudeRatio" /> struct from the specified electric potential
        ///     referenced to one volt RMS. This assumes both the specified electric potential and the one volt reference have the
        ///     same
        ///     resistance.
        /// </summary>
        /// <param name="voltage">The electric potential referenced to one volt.</param>
        public AmplitudeRatio(ElectricPotential voltage)
            : this()
        {
            if (voltage.Volts <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(voltage),
                    "The base-10 logarithm of a number ≤ 0 is undefined. Voltage must be greater than 0 V.");

            // E(dBV) = 20*log10(value(V)/reference(V))
            _value = 20 * Math.Log10(voltage.Volts / 1);
            _unit = AmplitudeRatioUnit.DecibelVolt;
        }

        /// <summary>
        ///     Gets an <see cref="ElectricPotential" /> from this <see cref="AmplitudeRatio" />.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting an amplitude ratio back to a voltage.
        ///     <example>
        ///         <c>var voltage = voltageRatio.ToElectricPotential();</c>
        ///     </example>
        /// </remarks>
        public ElectricPotential ToElectricPotential()
        {
            // E(V) = 1V * 10^(E(dBV)/20)
            return ElectricPotential.FromVolts( Math.Pow( 10, DecibelVolts / 20 ) );
        }

        /// <summary>
        ///     Converts this <see cref="AmplitudeRatio" /> to a <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        /// <remarks>http://www.maximintegrated.com/en/app-notes/index.mvp/id/808</remarks>
        public PowerRatio ToPowerRatio( ElectricResistance impedance )
        {
            // P(dBW) = E(dBV) - 10*log10(Z(Ω)/1)
            return PowerRatio.FromDecibelWatts( DecibelVolts - 10 * Math.Log10( impedance.Ohms / 1 ) );
        }

        #region Static Methods

        /// <summary>
        ///     Gets an <see cref="AmplitudeRatio" /> in decibels (dB) relative to 1 volt RMS from an
        ///     <see cref="ElectricPotential" />.
        /// </summary>
        /// <param name="voltage">The voltage (electric potential) relative to one volt RMS.</param>
        public static AmplitudeRatio FromElectricPotential(ElectricPotential voltage)
        {
            return new AmplitudeRatio(voltage);
        }

        #endregion
    }
}
