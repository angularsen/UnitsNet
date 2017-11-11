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

namespace UnitsNet.CustomCode.Extensions
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
}