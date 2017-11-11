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
}