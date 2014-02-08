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
    /// In mathematics, a ratio is a relationship between two numbers of the same kind (e.g., objects, persons, students, spoonfuls, units of whatever identical dimension), usually expressed as "a to b" or a:b, sometimes expressed arithmetically as a dimensionless quotient of the two that explicitly indicates how many times the first number contains the second (not necessarily an integer).
    /// </summary>
    public partial struct Ratio : IComparable, IComparable<Ratio>
    {
        /// <summary>
        /// Base unit of Ratio.
        /// </summary>
        public readonly double DecimalFractions;

        public Ratio(double decimalfractions) : this()
        {
            DecimalFractions = decimalfractions;
        }

        #region Properties

        /// <summary>
        /// Get Ratio in PartsPerBillions.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in PartsPerBillions and y is value in base unit DecimalFractions.</remarks>
        public double PartsPerBillions
        { 
            get { return DecimalFractions / 1E-09; }
        }

        /// <summary>
        /// Get Ratio in PartsPerMillions.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in PartsPerMillions and y is value in base unit DecimalFractions.</remarks>
        public double PartsPerMillions
        { 
            get { return DecimalFractions / 1E-06; }
        }

        /// <summary>
        /// Get Ratio in PartsPerThousands.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in PartsPerThousands and y is value in base unit DecimalFractions.</remarks>
        public double PartsPerThousands
        { 
            get { return DecimalFractions / 0.001; }
        }

        /// <summary>
        /// Get Ratio in PartsPerTrillions.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in PartsPerTrillions and y is value in base unit DecimalFractions.</remarks>
        public double PartsPerTrillions
        { 
            get { return DecimalFractions / 1E-12; }
        }

        /// <summary>
        /// Get Ratio in Percents.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Percents and y is value in base unit DecimalFractions.</remarks>
        public double Percents
        { 
            get { return DecimalFractions / 0.01; }
        }

        #endregion

        #region Static 

        public static Ratio Zero
        {
            get { return new Ratio(); }
        }
        
        /// <summary>
        /// Get Ratio from DecimalFractions.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in DecimalFractions and y is value in base unit DecimalFractions.</remarks>
        public static Ratio FromDecimalFractions(double decimalfractions)
        { 
            return new Ratio(1 * decimalfractions);
        }

        /// <summary>
        /// Get Ratio from PartsPerBillions.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in PartsPerBillions and y is value in base unit DecimalFractions.</remarks>
        public static Ratio FromPartsPerBillions(double partsperbillions)
        { 
            return new Ratio(1E-09 * partsperbillions);
        }

        /// <summary>
        /// Get Ratio from PartsPerMillions.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in PartsPerMillions and y is value in base unit DecimalFractions.</remarks>
        public static Ratio FromPartsPerMillions(double partspermillions)
        { 
            return new Ratio(1E-06 * partspermillions);
        }

        /// <summary>
        /// Get Ratio from PartsPerThousands.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in PartsPerThousands and y is value in base unit DecimalFractions.</remarks>
        public static Ratio FromPartsPerThousands(double partsperthousands)
        { 
            return new Ratio(0.001 * partsperthousands);
        }

        /// <summary>
        /// Get Ratio from PartsPerTrillions.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in PartsPerTrillions and y is value in base unit DecimalFractions.</remarks>
        public static Ratio FromPartsPerTrillions(double partspertrillions)
        { 
            return new Ratio(1E-12 * partspertrillions);
        }

        /// <summary>
        /// Get Ratio from Percents.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Percents and y is value in base unit DecimalFractions.</remarks>
        public static Ratio FromPercents(double percents)
        { 
            return new Ratio(0.01 * percents);
        }

        /// <summary>
        /// Try to dynamically convert from Ratio to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Ratio unit value.</returns> 
        public static Ratio From(double value, RatioUnit fromUnit)
        {
            switch (fromUnit)
            {
                case RatioUnit.DecimalFraction:
                    return FromDecimalFractions(value);
                case RatioUnit.PartsPerBillion:
                    return FromPartsPerBillions(value);
                case RatioUnit.PartsPerMillion:
                    return FromPartsPerMillions(value);
                case RatioUnit.PartsPerThousand:
                    return FromPartsPerThousands(value);
                case RatioUnit.PartsPerTrillion:
                    return FromPartsPerTrillions(value);
                case RatioUnit.Percent:
                    return FromPercents(value);

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
        public static string GetAbbreviation(RatioUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Ratio operator -(Ratio right)
        {
            return new Ratio(-right.DecimalFractions);
        }

        public static Ratio operator +(Ratio left, Ratio right)
        {
            return new Ratio(left.DecimalFractions + right.DecimalFractions);
        }

        public static Ratio operator -(Ratio left, Ratio right)
        {
            return new Ratio(left.DecimalFractions - right.DecimalFractions);
        }

        public static Ratio operator *(double left, Ratio right)
        {
            return new Ratio(left*right.DecimalFractions);
        }

        public static Ratio operator *(Ratio left, double right)
        {
            return new Ratio(left.DecimalFractions*right);
        }

        public static Ratio operator /(Ratio left, double right)
        {
            return new Ratio(left.DecimalFractions/right);
        }

        public static double operator /(Ratio left, Ratio right)
        {
            return left.DecimalFractions/right.DecimalFractions;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Ratio)) throw new ArgumentException("Expected type Ratio.", "obj");
            return CompareTo((Ratio) obj);
        }

        public int CompareTo(Ratio other)
        {
            return DecimalFractions.CompareTo(other.DecimalFractions);
        }

        public static bool operator <=(Ratio left, Ratio right)
        {
            return left.DecimalFractions <= right.DecimalFractions;
        }

        public static bool operator >=(Ratio left, Ratio right)
        {
            return left.DecimalFractions >= right.DecimalFractions;
        }

        public static bool operator <(Ratio left, Ratio right)
        {
            return left.DecimalFractions < right.DecimalFractions;
        }

        public static bool operator >(Ratio left, Ratio right)
        {
            return left.DecimalFractions > right.DecimalFractions;
        }

        public static bool operator ==(Ratio left, Ratio right)
        {
            return left.DecimalFractions == right.DecimalFractions;
        }

        public static bool operator !=(Ratio left, Ratio right)
        {
            return left.DecimalFractions != right.DecimalFractions;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return DecimalFractions.Equals(((Ratio) obj).DecimalFractions);
        }

        public override int GetHashCode()
        {
            return DecimalFractions.GetHashCode();
        }

        #endregion
        
        #region Conversion

        /// <summary>
        /// Convert to the unit representation in <paramref name="asUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(RatioUnit unit)
        {
            switch (unit)
            {
                case RatioUnit.DecimalFraction:
                    return DecimalFractions;
                case RatioUnit.PartsPerBillion:
                    return PartsPerBillions;
                case RatioUnit.PartsPerMillion:
                    return PartsPerMillions;
                case RatioUnit.PartsPerThousand:
                    return PartsPerThousands;
                case RatioUnit.PartsPerTrillion:
                    return PartsPerTrillions;
                case RatioUnit.Percent:
                    return Percents;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(RatioUnit unit, CultureInfo culture = null)
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
        public string ToString(RatioUnit unit, CultureInfo culture, string format, params object[] args)
        {
            string abbreviation = UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {As(unit), abbreviation}
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
            return ToString(RatioUnit.DecimalFraction);
        }
    }
} 
