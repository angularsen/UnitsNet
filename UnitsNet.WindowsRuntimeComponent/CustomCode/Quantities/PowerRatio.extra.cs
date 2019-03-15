// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class PowerRatio
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PowerRatio" /> struct from the specified power referenced to one watt.
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
        private PowerRatio(Power power)
            : this()
        {
            if (power.Watts <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(power), "The base-10 logarithm of a number ≤ 0 is undefined. Power must be greater than 0 W.");

            // P(dBW) = 10*log10(value(W)/reference(W))
            _value = 10 * Math.Log10(power.Watts / 1);
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
        public Power ToPower()
        {
            // P(W) = 1W * 10^(P(dBW)/10)
            return Power.FromWatts(Math.Pow(10, DecibelWatts / 10));
        }

        /// <summary>
        ///     Gets a <see cref="AmplitudeRatio" /> from this <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        public AmplitudeRatio ToAmplitudeRatio(ElectricResistance impedance)
        {
            // E(dBV) = 10*log10(Z(Ω)/1) + P(dBW)
            return AmplitudeRatio.FromDecibelVolts(10 * Math.Log10(impedance.Ohms / 1) + DecibelWatts);
        }

        #region Static Methods

        /// <summary>
        ///     Gets a <see cref="PowerRatio" /> from a <see cref="Power" /> relative to one watt.
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>
        public static PowerRatio FromPower(Power power)
        {
            return new PowerRatio(power);
        }

        #endregion
    }
}
