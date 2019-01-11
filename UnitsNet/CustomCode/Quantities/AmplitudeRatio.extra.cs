// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class AmplitudeRatio
#else
    public partial struct AmplitudeRatio
#endif
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AmplitudeRatio" /> struct from the specified electric potential
        ///     referenced to one volt RMS. This assumes both the specified electric potential and the one volt reference have the
        ///     same
        ///     resistance.
        /// </summary>
        /// <param name="voltage">The electric potential referenced to one volt.</param>

        // Windows Runtime Component does not allow public methods/ctors with same number of parameters: https://msdn.microsoft.com/en-us/library/br230301.aspx#Overloaded methods
#if WINDOWS_UWP
        internal
#else
        public
#endif
            AmplitudeRatio(ElectricPotential voltage)
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
