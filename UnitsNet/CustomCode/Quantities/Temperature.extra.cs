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

using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
#if WINDOWS_UWP
    public sealed partial class Temperature
#else
    public partial struct Temperature
#endif
    {
        // Windows Runtime Component does not allow operator overloads: https://msdn.microsoft.com/en-us/library/br230301.aspx
#if !WINDOWS_UWP
        /// <summary>
        ///     Add a <see cref="TemperatureDelta" /> to a <see cref="Temperature" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator +(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins + right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Add a <see cref="TemperatureDelta" /> to a <see cref="Temperature" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator +(TemperatureDelta left, Temperature right)
        {
            return new Temperature(left.Kelvins + right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Subtract a <see cref="TemperatureDelta" /> from a <see cref="Temperature" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator -(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins - right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Subtract two temperatures to get a <see cref="TemperatureDelta"/> in this temperature's unit, which you can later convert to any temperature unit.
        ///     This is useful since Celsius, Fahrenheit and Kelvins don't share a common zero point on the scale and normal subtraction
        ///     would operate on Kelvins and likely give an unexpected result.
        ///     Example:
        ///     double deltaCelsius = celsius30.ToDelta(celsius20).DegreesCelsius; // 10 C
        ///     double wrongDeltaCelsius = (celsius30 - celsius20).DegreesCelsius; // 303.15 K - 293.15 K = 10 K = -263.15 degrees Celsius
        /// </summary>
        /// <returns>A temperature delta.</returns>
        public TemperatureDelta ToDelta(Temperature other) => TemperatureDelta.FromTemperatures(this, other);
#endif
    }
}
