// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct PowerRatio<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PowerRatio{T}" /> struct from the specified power referenced to one watt.
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>

        public PowerRatio(Power<T> power )
            : this()
        {
            if (power.Watts <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(power), "The base-10 logarithm of a number ≤ 0 is undefined. Power must be greater than 0 W.");

            // P(dBW) = 10*log10(value(W)/reference(W))
            Value = 10 * Math.Log10(power.Watts / 1);
            _unit = PowerRatioUnit.DecibelWatt;
        }

        /// <summary>
        ///     Gets a <see cref="Power{T}" /> from this <see cref="PowerRatio{T}" /> (which is a power level relative to one watt).
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a power ratio back to a power.
        ///     <example>
        ///         <c>var power = powerRatio.ToPower();</c>
        ///     </example>
        /// </remarks>
        public Power<T> ToPower()
        {
            // P(W) = 1W * 10^(P(dBW)/10)
            return Power<T>.FromWatts(Math.Pow(10, DecibelWatts / 10));
        }

        /// <summary>
        ///     Gets a <see cref="AmplitudeRatio{T}" /> from this <see cref="PowerRatio{T}" />.
        /// </summary>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        public AmplitudeRatio<T> ToAmplitudeRatio(ElectricResistance<T> impedance )
        {
            // E(dBV) = 10*log10(Z(Ω)/1) + P(dBW)
            return AmplitudeRatio<T>.FromDecibelVolts(10 * Math.Log10(impedance.Ohms / 1) + DecibelWatts);
        }

        #region Static Methods

        /// <summary>
        ///     Gets a <see cref="PowerRatio{T}" /> from a <see cref="Power{T}" /> relative to one watt.
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>
        public static PowerRatio<T> FromPower(Power<T> power )
        {
            return new PowerRatio<T>( power);
        }

        #endregion
    }
}
