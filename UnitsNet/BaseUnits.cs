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
using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
#if !WINDOWS_UWP
    public sealed partial class BaseUnits : IEquatable<BaseUnits> { }
#endif

    /// <summary>
    ///     Represents the base units for a quantity. All quantities, both base and derived, can be
    ///     represented by a combination of these seven base units.
    /// </summary>
    public sealed partial class BaseUnits
    {
        /// <summary>
        /// Creates an instance of if the base units class that represents the base units for a quantity.
        /// All quantities, both base and derived, can be represented by a combination of these seven base units.
        /// </summary>
        /// <param name="length">The length unit (L).</param>
        /// <param name="mass">The mass unit (M).</param>
        /// <param name="time">The time unit (T).</param>
        /// <param name="current">The electric current unit (I).</param>
        /// <param name="temperature">The temperature unit (Θ).</param>
        /// <param name="amount">The amount of substance unit (N).</param>
        /// <param name="luminousIntensity">The luminous intensity unit (J).</param>
        public BaseUnits(LengthUnit length, MassUnit mass, DurationUnit time, ElectricCurrentUnit current,
            TemperatureUnit temperature, AmountOfSubstanceUnit amount, LuminousIntensityUnit luminousIntensity)
        {
            Length = length;
            Mass = mass;
            Time = time;
            Current = current;
            Temperature = temperature;
            Amount = amount;
            LuminousIntensity = luminousIntensity;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is BaseUnits))
                return false;

            return Equals((BaseUnits)obj);
        }

        /// <summary>
        /// Checks if all of the base units are equal to another instance's.
        /// </summary>
        /// <param name="other">The other instance to check if equal to.</param>
        /// <returns>True if equal, otherwise false.</returns>
#if WINDOWS_UWP
        [Windows.Foundation.Metadata.DefaultOverload]
#endif
        public bool Equals(BaseUnits other)
        {
            if(other is null)
                return false;

            return Length == other.Length &&
                Mass == other.Mass &&
                Time == other.Time &&
                Current == other.Current &&
                Temperature == other.Temperature &&
                Amount == other.Amount &&
                LuminousIntensity == other.LuminousIntensity;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new {Length, Mass, Time, Current, Temperature, Amount, LuminousIntensity}.GetHashCode();
        }

#if !WINDOWS_UWP

        /// <summary>
        /// Checks if this instance is equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        /// <seealso cref="Equals(BaseUnits)"/>
        public static bool operator ==(BaseUnits left, BaseUnits right)
        {
            return left is null ? right is null : left.Equals(right);
        }

        /// <summary>
        /// Checks if this instance is not equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if not equal, otherwise false.</returns>
        /// <seealso cref="Equals(BaseUnits)"/>
        public static bool operator !=(BaseUnits left, BaseUnits right)
        {
            return !(left == right);
        }

#endif

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("[Length]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Length));
            sb.AppendFormat("[Mass]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Mass));
            sb.AppendFormat("[Time]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Time));
            sb.AppendFormat("[Current]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Current));
            sb.AppendFormat("[Temperature]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Temperature));
            sb.AppendFormat("[Amount]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Amount));
            sb.AppendFormat("[LuminousIntensity]: {0}", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(LuminousIntensity));

            return sb.ToString();
        }

        /// <summary>
        /// Gets the length unit (L).
        /// </summary>
        public LengthUnit Length { get; }

        /// <summary>
        /// Gets the mass unit (M).
        /// </summary>
        public MassUnit Mass{ get; }

        /// <summary>
        /// Gets the time unit (T).
        /// </summary>
        public DurationUnit Time{ get; }

        /// <summary>
        /// Gets the electric current unit (I).
        /// </summary>
        public ElectricCurrentUnit Current{ get; }

        /// <summary>
        /// Gets the temperature unit (Θ).
        /// </summary>
        public TemperatureUnit Temperature{ get; }

        /// <summary>
        /// Gets the amount of substance unit (N).
        /// </summary>
        public AmountOfSubstanceUnit Amount{ get; }

        /// <summary>
        /// Gets the luminous intensity unit (J).
        /// </summary>
        public LuminousIntensityUnit LuminousIntensity{ get; }
    }
}
