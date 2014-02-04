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
    /// In geometry, an angle is the figure formed by two rays, called the sides of the angle, sharing a common endpoint, called the vertex of the angle.
    /// </summary>
    public partial struct Angle : IComparable, IComparable<Angle>
    {
        /// <summary>
        /// Base unit of Angle.
        /// </summary>
        public readonly double Degrees;

        public Angle(double degrees) : this()
        {
            Degrees = degrees;
        }

        #region Properties

        /// <summary>
        /// Get Angle in Gradians.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Gradians and y is value in base unit Degrees.</remarks>
        public double Gradians
        { 
            get { return Degrees / 0.9; }
        }

        /// <summary>
        /// Get Angle in Radians.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Radians and y is value in base unit Degrees.</remarks>
        public double Radians
        { 
            get { return Degrees / 57.2957795130823; }
        }

        #endregion

        #region Static 

        public static Angle Zero
        {
            get { return new Angle(); }
        }
        
        /// <summary>
        /// Get Angle from Degrees.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Degrees and y is value in base unit Degrees.</remarks>
        public static Angle FromDegrees(double degrees)
        { 
            return new Angle(1 * degrees);
        }

        /// <summary>
        /// Get Angle from Gradians.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Gradians and y is value in base unit Degrees.</remarks>
        public static Angle FromGradians(double gradians)
        { 
            return new Angle(0.9 * gradians);
        }

        /// <summary>
        /// Get Angle from Radians.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Radians and y is value in base unit Degrees.</remarks>
        public static Angle FromRadians(double radians)
        { 
            return new Angle(57.2957795130823 * radians);
        }

        /// <summary>
        /// Try to dynamically convert from Angle to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Angle unit value.</returns> 
        public static Angle From(double value, AngleUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AngleUnit.Degree:
                    return FromDegrees(value);
                case AngleUnit.Gradian:
                    return FromGradians(value);
                case AngleUnit.Radian:
                    return FromRadians(value);

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
        public static string GetAbbreviation(AngleUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Angle operator -(Angle right)
        {
            return new Angle(-right.Degrees);
        }

        public static Angle operator +(Angle left, Angle right)
        {
            return new Angle(left.Degrees + right.Degrees);
        }

        public static Angle operator -(Angle left, Angle right)
        {
            return new Angle(left.Degrees - right.Degrees);
        }

        public static Angle operator *(double left, Angle right)
        {
            return new Angle(left*right.Degrees);
        }

        public static Angle operator *(Angle left, double right)
        {
            return new Angle(left.Degrees*right);
        }

        public static Angle operator /(Angle left, double right)
        {
            return new Angle(left.Degrees/right);
        }

        public static double operator /(Angle left, Angle right)
        {
            return left.Degrees/right.Degrees;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Angle)) throw new ArgumentException("Expected type Angle.", "obj");
            return CompareTo((Angle) obj);
        }

        public int CompareTo(Angle other)
        {
            return Degrees.CompareTo(other.Degrees);
        }

        public static bool operator <=(Angle left, Angle right)
        {
            return left.Degrees <= right.Degrees;
        }

        public static bool operator >=(Angle left, Angle right)
        {
            return left.Degrees >= right.Degrees;
        }

        public static bool operator <(Angle left, Angle right)
        {
            return left.Degrees < right.Degrees;
        }

        public static bool operator >(Angle left, Angle right)
        {
            return left.Degrees > right.Degrees;
        }

        public static bool operator ==(Angle left, Angle right)
        {
            return left.Degrees == right.Degrees;
        }

        public static bool operator !=(Angle left, Angle right)
        {
            return left.Degrees != right.Degrees;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Degrees.Equals(((Angle) obj).Degrees);
        }

        public override int GetHashCode()
        {
            return Degrees.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Angle to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(AngleUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case AngleUnit.Degree:
                    newValue = Degrees;
                    return true;
                case AngleUnit.Gradian:
                    newValue = Gradians;
                    return true;
                case AngleUnit.Radian:
                    newValue = Radians;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Angle to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(AngleUnit toUnit)
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
        public string ToString(AngleUnit unit, CultureInfo culture = null)
        {
            return ToString(unit, culture, "{0:0.##} {1}");
        }

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        public string ToString(AngleUnit unit, CultureInfo culture, string format, params object[] args)
        {
            string abbreviation = UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {Convert(unit), abbreviation}
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
            return ToString(AngleUnit.Degree);
        }
    }
} 
