// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct PowerRatio
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PowerRatio" /> struct from the specified power referenced to one watt.
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        public PowerRatio(Power power, byte significantDigits = 15)
            : this()
        {
            if (!QuantityValue.IsPositive(power.Value))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(power), "The base-10 logarithm of a number ≤ 0 is undefined. Power must be greater than 0 W.");
            }

            // P(dBW) = 10*log10(value(W)/reference(W))
            _value = power.Watts.ToLogSpace(LogarithmicScalingFactor, significantDigits);
            _unit = PowerRatioUnit.DecibelWatt;
        }

        /// <summary>
        ///     Gets a <see cref="Power" /> from this <see cref="PowerRatio" /> (which is a power level relative to one watt).
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a power ratio back to a power.
        ///     <example>
        ///         <c>var power = powerRatio.ToPower();</c>
        ///     </example>
        /// </remarks>
        public Power ToPower(byte significantDigits = 15)
        {
            // P(W) = 1W * 10^(P(dBW)/10)
            return Power.FromWatts(DecibelWatts.ToLinearSpace(LogarithmicScalingFactor, significantDigits));
        }

        /// <summary>
        ///     Gets a <see cref="AmplitudeRatio" /> from this <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        public AmplitudeRatio ToAmplitudeRatio(ElectricResistance impedance, byte significantDigits = 15)
        {
            // E(dBV) = 10*log10(Z(Ω)/1) + P(dBW)
            return AmplitudeRatio.FromDecibelVolts(impedance.Ohms.ToLogSpace(LogarithmicScalingFactor, significantDigits) + DecibelWatts);
        }

        #region Static Methods

        /// <summary>
        ///     Gets a <see cref="PowerRatio" /> from a <see cref="Power" /> relative to one watt.
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        public static PowerRatio FromPower(Power power, byte significantDigits = 15)
        {
            return new PowerRatio(power, significantDigits);
        }

        #endregion
    }
}
