// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
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

#if !WINDOWS_UWP
// Operator overloads not supported in Universal Windows Platform (WinRT Components)
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Temperature
    {
        /// <summary>
        ///     Add a <see cref="Temperature" /> and a <see cref="TemperatureDelta" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator +(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins + right.KelvinsDelta);
        }

        /// <summary>
        ///     Add a <see cref="TemperatureDelta" /> and a <see cref="Temperature" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator +(TemperatureDelta left, Temperature right)
        {
            return new Temperature(left.KelvinsDelta + right.Kelvins);
        }

        /// <summary>
        ///     Subtract a <see cref="Temperature" /> by a <see cref="TemperatureDelta" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator -(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins - right.KelvinsDelta);
        }

        /// <summary>
        ///     Subtract a <see cref="Temperature" /> by a <see cref="TemperatureDelta" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The delta temperature (difference).</returns>
        public static TemperatureDelta operator -(Temperature left, Temperature right)
        {
            return new TemperatureDelta(left.Kelvins - right.Kelvins);
        }

        /// <summary>
        ///     Multiply temperature with a <paramref name="factor" /> in a given <paramref name="unit" />.
        /// </summary>
        /// <remarks>
        ///     Due to different temperature units having different zero points, we cannot simply
        ///     multiply or divide a temperature by a factor. We must first convert to the desired unit, then perform the
        ///     calculation.
        /// </remarks>
        /// <param name="factor">Factor to multiply by.</param>
        /// <param name="unit">Unit to perform multiplication in.</param>
        /// <returns>The resulting <see cref="Temperature" />.</returns>
        public Temperature Multiply(double factor, TemperatureUnit unit)
        {
            double resultInUnit = As(unit) * factor;
            return From(resultInUnit, unit);
        }


        /// <summary>
        ///     Divide temperature by a <paramref name="divisor" /> in a given <paramref name="unit" />.
        /// </summary>
        /// <remarks>
        ///     Due to different temperature units having different zero points, we cannot simply
        ///     multiply or divide a temperature by a factor. We must first convert to the desired unit, then perform the
        ///     calculation.
        /// </remarks>
        /// <param name="divisor">Factor to multiply by.</param>
        /// <param name="unit">Unit to perform multiplication in.</param>
        /// <returns>The resulting <see cref="Temperature" />.</returns>
        public Temperature Divide(double divisor, TemperatureUnit unit)
        {
            double resultInUnit = As(unit) / divisor;
            return From(resultInUnit, unit);
        }
    }
}

#endif