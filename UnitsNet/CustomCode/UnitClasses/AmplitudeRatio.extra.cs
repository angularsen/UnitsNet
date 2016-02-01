// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
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
    ///     Extension methods for <see cref="AmplitudeRatio" />.
    /// </summary>
    public static class AmplitudeRatioExtensions
    {
        /// <summary>
        ///     Gets an <see cref="ElectricPotential" /> from <see cref="AmplitudeRatio" />.
        /// </summary>
        /// <paramref name="amplitudeRatio">The amplitude ratio to convert.</paramref>
        /// <remarks>
        ///     Provides a nicer syntax for converting an amplitude ratio back to a voltage.
        ///     <example>
        ///         <c>var voltage = voltageRatio.ToElectricPotential();</c>
        ///     </example>
        /// </remarks>
        public static ElectricPotential ToElectricPotential(this AmplitudeRatio amplitudeRatio)
        {
            return AmplitudeRatio.ToElectricPotential(amplitudeRatio);
        }

        /// <summary>
        ///     Converts a <see cref="AmplitudeRatio" /> to a <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="amplitudeRatio">The amplitude ratio to convert.</param>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        /// <remarks>http://www.maximintegrated.com/en/app-notes/index.mvp/id/808</remarks>
        public static PowerRatio ToPowerRatio(this AmplitudeRatio amplitudeRatio, ElectricResistance impedance)
        {
            return AmplitudeRatio.ToPowerRatio(amplitudeRatio, impedance);
        }
    }

    /// <summary>
    ///     Extension methods for <see cref="ElectricPotential" />.
    /// </summary>
    public static class ElectricPotentialExtensions
    {
        /// <summary>
        ///     Gets an <see cref="AmplitudeRatio" /> in decibels (dB) relative to 1 volt RMS from an
        ///     <see cref="ElectricPotential" />.
        /// </summary>
        /// <remarks>
        ///     Provides a nicer syntax for converting a voltage to an amplitude ratio (relative to 1 volt RMS).
        ///     <example>
        ///         <c>var voltageRatio = voltage.ToAmplitudeRatio();</c>
        ///     </example>
        /// </remarks>
        public static AmplitudeRatio ToAmplitudeRatio(this ElectricPotential voltage)
        {
            return AmplitudeRatio.FromElectricPotential(voltage);
        }
    }

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
            _decibelVolts = 20*Math.Log10(voltage/ElectricPotential.FromVolts(1));
        }

        /// <summary>
        ///     Gets an <see cref="AmplitudeRatio" /> in decibels (dB) relative to 1 volt RMS from an
        ///     <see cref="ElectricPotential" />.
        /// </summary>
        /// <param name="voltage">The voltage (electric potential) relative to one volt RMS.</param>
        public static AmplitudeRatio FromElectricPotential(ElectricPotential voltage)
        {
            return new AmplitudeRatio(voltage);
        }

        /// <summary>
        ///     Gets an <see cref="ElectricPotential" /> from <see cref="AmplitudeRatio" />.
        /// </summary>
        /// <param name="voltageRatio">The voltage ratio to convert to voltage (electric potential).</param>
        public static ElectricPotential ToElectricPotential(AmplitudeRatio voltageRatio)
        {
            // E(V) = 1V * 10^(E(dBV)/20)
            return ElectricPotential.FromVolts(Math.Pow(10, voltageRatio._decibelVolts/20));
        }

        /// <summary>
        ///     Converts a <see cref="AmplitudeRatio" /> to a <see cref="PowerRatio" />.
        /// </summary>
        /// <param name="amplitudeRatio">The amplitude ratio to convert.</param>
        /// <param name="impedance">The input impedance of the load. This is usually 50, 75 or 600 ohms.</param>
        /// <remarks>http://www.maximintegrated.com/en/app-notes/index.mvp/id/808</remarks>
        public static PowerRatio ToPowerRatio(AmplitudeRatio amplitudeRatio, ElectricResistance impedance)
        {
            // P(dBW) = E(dBV) - 10*log10(Z(Ω)/1)
            return PowerRatio.FromDecibelWatts(amplitudeRatio.DecibelVolts - 10*Math.Log10(impedance.Ohms/1));
        }
    }
}