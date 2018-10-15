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
    /// <summary>
    ///     Represents the base units for a quantity or 
    /// </summary>
    public sealed class BaseUnits
    {
        /// <inheritdoc />
        public BaseUnits(LengthUnit length, MassUnit mass, DurationUnit time, ElectricCurrentUnit current,
            TemperatureUnit temperature, AmountOfSubstanceUnit amount, LuminousIntensityUnit luminousIntensity)
        {
            if(length == LengthUnit.Undefined)
                throw new ArgumentException("The given length unit is undefined.", nameof(length));
            else if(mass == MassUnit.Undefined)
                throw new ArgumentException("The given mass unit is undefined.", nameof(mass));
            else if(time == DurationUnit.Undefined)
                throw new ArgumentException("The given time unit is undefined.", nameof(time));
            else if(current == ElectricCurrentUnit.Undefined)
                throw new ArgumentException("The given electric current unit is undefined.", nameof(current));
            else if(temperature == TemperatureUnit.Undefined)
                throw new ArgumentException("The given temperature unit is undefined.", nameof(temperature));
            else if(amount == AmountOfSubstanceUnit.Undefined)
                throw new ArgumentException("The given amount of substance unit is undefined.", nameof(amount));
            else if(luminousIntensity == LuminousIntensityUnit.Undefined)
                throw new ArgumentException("The given luminous intensity unit is undefined.", nameof(luminousIntensity));

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

            var other = (BaseUnits)obj;

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
        /// Check if two dimensions are equal.
        /// </summary>
        /// <param name="left">Left.</param>
        /// <param name="right">Right.</param>
        /// <returns>True if equal.</returns>
        public static bool operator ==(BaseUnits left, BaseUnits right)
        {
            return left?.Equals(right) == true;
        }

        /// <summary>
        /// Check if two dimensions are unequal.
        /// </summary>
        /// <param name="left">Left.</param>
        /// <param name="right">Right.</param>
        /// <returns>True if not equal.</returns>
        public static bool operator !=(BaseUnits left, BaseUnits right)
        {
            return !(left == right);
        }

#endif

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("[Length]: {0} ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Length));
            sb.AppendFormat("[Mass]: {0} ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Mass));
            sb.AppendFormat("[Time]: {0} ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Time));
            sb.AppendFormat("[Current]: {0} ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Current));
            sb.AppendFormat("[Temperature]: {0} ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Temperature));
            sb.AppendFormat("[Amount]: {0} ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Amount));
            sb.AppendFormat("[LuminousIntensity]: {0} ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(LuminousIntensity));

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
