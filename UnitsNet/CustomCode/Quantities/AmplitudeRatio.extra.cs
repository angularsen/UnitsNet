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
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        public AmplitudeRatio(ElectricPotential voltage, byte significantDigits = 15)
            : this()
        {
            if (!QuantityValue.IsPositive(voltage.Value))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(voltage),
                    "The base-10 logarithm of a number ≤ 0 is undefined. Voltage must be greater than 0 V.");
            }

            // E(dBV) = 20*log10(value(V)/reference(V))
            _value = voltage.Volts.ToLogSpace(LogarithmicScalingFactor, significantDigits);
            _unit = AmplitudeRatioUnit.DecibelVolt;
        }

        /// <summary>
        ///     Gets an <see cref="ElectricPotential" /> from this <see cref="AmplitudeRatio" />.
        /// </summary>
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        /// <remarks>
        ///     Provides a nicer syntax for converting an amplitude ratio back to a voltage.
        ///     <example>
        ///         <c>var voltage = voltageRatio.ToElectricPotential();</c>
        ///     </example>
        /// </remarks>
        public ElectricPotential ToElectricPotential(byte significantDigits = 15)
        {
            // E(V) = 1V * 10^(E(dBV)/20)
            return ElectricPotential.FromVolts(DecibelVolts.ToLinearSpace(LogarithmicScalingFactor, significantDigits));
        }

        /// <summary>
        ///     Converts this <see cref="AmplitudeRatio" /> to a <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        /// <remarks>http://www.maximintegrated.com/en/app-notes/index.mvp/id/808</remarks>
        public PowerRatio ToPowerRatio(ElectricResistance impedance, byte significantDigits = 15)
        {
            // P(dBW) = E(dBV) - 10*log10(Z(Ω)/1)
            return PowerRatio.FromDecibelWatts(DecibelVolts - impedance.Ohms.ToLogSpace(LogarithmicScalingFactor / 2, significantDigits));
        }

        #region Static Methods

        /// <summary>
        ///     Gets an <see cref="AmplitudeRatio" /> in decibels (dB) relative to 1 volt RMS from an
        ///     <see cref="ElectricPotential" />.
        /// </summary>
        /// <param name="voltage">The voltage (electric potential) relative to one volt RMS.</param>
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        public static AmplitudeRatio FromElectricPotential(ElectricPotential voltage, byte significantDigits = 15)
        {
            return new AmplitudeRatio(voltage, significantDigits);
        }

        #endregion
    }
}
