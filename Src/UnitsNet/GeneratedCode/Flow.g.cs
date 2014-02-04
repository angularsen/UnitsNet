// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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
using System.Globalization;
using System.Linq;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// In physics and engineering, in particular fluid dynamics and hydrometry, the volumetric flow rate, (also known as volume flow rate, rate of fluid flow or volume velocity) is the volume of fluid which passes through a given surface per unit time. The SI unit is m3·s−1 (cubic meters per second). In US Customary Units and British Imperial Units, volumetric flow rate is often expressed as ft3/s (cubic feet per second). It is usually represented by the symbol Q.
    /// </summary>
    public partial struct Flow : IComparable, IComparable<Flow>
    {
        /// <summary>
        /// Base unit of Flow.
        /// </summary>
        public readonly double CubicMetersPerSecond;

        public Flow(double cubicmeterspersecond) : this()
        {
            CubicMetersPerSecond = cubicmeterspersecond;
        }

        #region Properties

        /// <summary>
        /// Get Flow in CubicMetersPerHour.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicMetersPerHour and y is value in base unit CubicMetersPerSecond.</remarks>
        public double CubicMetersPerHour
        { 
            get { return CubicMetersPerSecond / 0.000277777777777778; }
        }

        #endregion

        #region Static 

        public static Flow Zero
        {
            get { return new Flow(); }
        }
        
        /// <summary>
        /// Get Flow from CubicMetersPerHour.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMetersPerHour and y is value in base unit CubicMetersPerSecond.</remarks>
        public static Flow FromCubicMetersPerHour(double cubicmetersperhour)
        { 
            return new Flow(0.000277777777777778 * cubicmetersperhour);
        }

        /// <summary>
        /// Get Flow from CubicMetersPerSecond.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMetersPerSecond and y is value in base unit CubicMetersPerSecond.</remarks>
        public static Flow FromCubicMetersPerSecond(double cubicmeterspersecond)
        { 
            return new Flow(1 * cubicmeterspersecond);
        }

        /// <summary>
        /// Try to dynamically convert from Flow to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Flow unit value.</returns> 
        public static Flow From(double value, FlowUnit fromUnit)
        {
            switch (fromUnit)
            {
                case FlowUnit.CubicMeterPerHour:
                    return FromCubicMetersPerHour(value);
                case FlowUnit.CubicMeterPerSecond:
                    return FromCubicMetersPerSecond(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        /// Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(FlowUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Flow operator -(Flow right)
        {
            return new Flow(-right.CubicMetersPerSecond);
        }

        public static Flow operator +(Flow left, Flow right)
        {
            return new Flow(left.CubicMetersPerSecond + right.CubicMetersPerSecond);
        }

        public static Flow operator -(Flow left, Flow right)
        {
            return new Flow(left.CubicMetersPerSecond - right.CubicMetersPerSecond);
        }

        public static Flow operator *(double left, Flow right)
        {
            return new Flow(left*right.CubicMetersPerSecond);
        }

        public static Flow operator *(Flow left, double right)
        {
            return new Flow(left.CubicMetersPerSecond*right);
        }

        public static Flow operator /(Flow left, double right)
        {
            return new Flow(left.CubicMetersPerSecond/right);
        }

        public static double operator /(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond/right.CubicMetersPerSecond;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Flow)) throw new ArgumentException("Expected type Flow.", "obj");
            return CompareTo((Flow) obj);
        }

        public int CompareTo(Flow other)
        {
            return CubicMetersPerSecond.CompareTo(other.CubicMetersPerSecond);
        }

        public static bool operator <=(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond <= right.CubicMetersPerSecond;
        }

        public static bool operator >=(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond >= right.CubicMetersPerSecond;
        }

        public static bool operator <(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond < right.CubicMetersPerSecond;
        }

        public static bool operator >(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond > right.CubicMetersPerSecond;
        }

        public static bool operator ==(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond == right.CubicMetersPerSecond;
        }

        public static bool operator !=(Flow left, Flow right)
        {
            return left.CubicMetersPerSecond != right.CubicMetersPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CubicMetersPerSecond.Equals(((Flow) obj).CubicMetersPerSecond);
        }

        public override int GetHashCode()
        {
            return CubicMetersPerSecond.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Flow to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(FlowUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case FlowUnit.CubicMeterPerHour:
                    newValue = CubicMetersPerHour;
                    return true;
                case FlowUnit.CubicMeterPerSecond:
                    newValue = CubicMetersPerSecond;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Flow to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(FlowUnit toUnit)
        {
            double newValue;
            if (!TryConvert(toUnit, out newValue))
                throw new NotImplementedException("toUnit: " + toUnit);

            return newValue;
        }

        #endregion

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(FlowUnit unit, CultureInfo culture = null)
        {
            return ToString(culture, unit, "{0:0.##} {1}", CubicMetersPerSecond);
        }

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        public string ToString(CultureInfo culture, FlowUnit unit, string format, params object[] args)
        {
            string abbreviation = UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {CubicMetersPerSecond, abbreviation}
                .Concat(args)
                .ToArray();

            return string.Format(culture, format, finalArgs);
        }

        /// <summary>
        /// Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(FlowUnit.CubicMeterPerSecond);
        }
    }
} 
