// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace UnitsNet
{
    /// <summary>
    /// Extension methods for <see cref="PowerRatio"/>.
    /// </summary>
    public static class PowerRatioExtensions
    {
        /// <summary>
        ///     Gets a <see cref="Power"/> from a <see cref="PowerRatio"/>.
        /// </summary>
        /// <remarks>
        /// Provides a nicer syntax for converting a power ratio back to a power.
        /// <example><c>var power = powerRatio.ToPower();</c></example>
        /// </remarks>
        public static Power ToPower(this PowerRatio powerRatio)
        {
            return PowerRatio.ToPower(powerRatio);
        }

        /// <summary>
        ///     Gets a <see cref="AmplitudeRatio"/> from a <see cref="PowerRatio"/>.
        /// </summary>
        /// <param name="powerRatio">The power ratio.</param>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        public static AmplitudeRatio ToAmplitudeRatio(this PowerRatio powerRatio, ElectricResistance impedance)
        {
            return PowerRatio.ToAmplitudeRatio(powerRatio, impedance);
        }
    }

    /// <summary>
    /// Extension methods for <see cref="Power"/>.
    /// </summary>
    public static class PowerExtensions
    {
        /// <summary>
        ///     Gets a <see cref="PowerRatio"/> from a <see cref="Power"/> relative to one watt.
        /// </summary>
        /// <remarks>
        /// Provides a nicer syntax for converting a power to a power ratio (relative to 1 watt).
        /// <example><c>var powerRatio = power.ToPowerRatio();</c></example>
        /// </remarks>
        public static PowerRatio ToPowerRatio(this Power power)
        {
            return PowerRatio.FromPower(power);
        }
    }

    public partial struct PowerRatio
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerRatio"/> struct from the specified power referenced to one watt. 
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>
        public PowerRatio(Power power)
            : this()
        {
            if (power.Watts <= 0)
                throw new ArgumentOutOfRangeException(
                    "power", "The base-10 logarithm of a number ≤ 0 is undefined. Power must be greater than 0 W.");

            // P(dBW) = 10*log10(value(W)/reference(W))
            _decibelWatts = 10 * Math.Log10(power / Power.FromWatts(1));
        }

        /// <summary>
        ///     Gets a <see cref="PowerRatio"/> from a <see cref="Power"/> relative to one watt.
        /// </summary>
        /// <param name="power">The power relative to one watt.</param>
        public static PowerRatio FromPower(Power power)
        {
            return new PowerRatio(power);
        }

        /// <summary>
        ///     Gets a <see cref="Power"/> from a <see cref="PowerRatio"/> (which is a power level relative to one watt).
        /// </summary>
        /// <param name="powerRatio">The power level relative to one watt.</param>
        public static Power ToPower(PowerRatio powerRatio)
        {
            // P(W) = 1W * 10^(P(dBW)/10)
            return Power.FromWatts(Math.Pow(10, powerRatio._decibelWatts / 10));
        }

        /// <summary>
        ///     Gets a <see cref="AmplitudeRatio"/> from a <see cref="PowerRatio"/>.
        /// </summary>
        /// <param name="powerRatio">The power ratio.</param>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        /// <remarks>http://www.maximintegrated.com/en/app-notes/index.mvp/id/808</remarks>
        public static AmplitudeRatio ToAmplitudeRatio(PowerRatio powerRatio, ElectricResistance impedance)
        {
            // E(dBV) = 10*log10(Z(Ω)/1) + P(dBW)
            return AmplitudeRatio.FromDecibelVolts(10 * Math.Log10(impedance.Ohms / 1) + powerRatio.DecibelWatts);
        }
    }
}