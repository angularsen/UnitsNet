// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     The viscosity of a fluid is a measure of its resistance to gradual deformation by shear stress or tensile stress.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct KinematicViscosity : IComparable, IComparable<KinematicViscosity>
    {
        /// <summary>
        ///     Base unit of KinematicViscosity.
        /// </summary>
        private readonly double _squareMetersPerSecond;

        public KinematicViscosity(double squaremeterspersecond) : this()
        {
            _squareMetersPerSecond = squaremeterspersecond;
        }

        #region Properties

        /// <summary>
        ///     Get KinematicViscosity in Centistokes.
        /// </summary>
        public double Centistokes
        {
            get { return (_squareMetersPerSecond*1e4) / 1e-2d; }
        }

        /// <summary>
        ///     Get KinematicViscosity in Decistokes.
        /// </summary>
        public double Decistokes
        {
            get { return (_squareMetersPerSecond*1e4) / 1e-1d; }
        }

        /// <summary>
        ///     Get KinematicViscosity in Kilostokes.
        /// </summary>
        public double Kilostokes
        {
            get { return (_squareMetersPerSecond*1e4) / 1e3d; }
        }

        /// <summary>
        ///     Get KinematicViscosity in Microstokes.
        /// </summary>
        public double Microstokes
        {
            get { return (_squareMetersPerSecond*1e4) / 1e-6d; }
        }

        /// <summary>
        ///     Get KinematicViscosity in Millistokes.
        /// </summary>
        public double Millistokes
        {
            get { return (_squareMetersPerSecond*1e4) / 1e-3d; }
        }

        /// <summary>
        ///     Get KinematicViscosity in Nanostokes.
        /// </summary>
        public double Nanostokes
        {
            get { return (_squareMetersPerSecond*1e4) / 1e-9d; }
        }

        /// <summary>
        ///     Get KinematicViscosity in SquareMetersPerSecond.
        /// </summary>
        public double SquareMetersPerSecond
        {
            get { return _squareMetersPerSecond; }
        }

        /// <summary>
        ///     Get KinematicViscosity in Stokes.
        /// </summary>
        public double Stokes
        {
            get { return _squareMetersPerSecond*1e4; }
        }

        #endregion

        #region Static 

        public static KinematicViscosity Zero
        {
            get { return new KinematicViscosity(); }
        }

        /// <summary>
        ///     Get KinematicViscosity from Centistokes.
        /// </summary>
        public static KinematicViscosity FromCentistokes(double centistokes)
        {
            return new KinematicViscosity((centistokes/1e4) * 1e-2d);
        }

        /// <summary>
        ///     Get KinematicViscosity from Decistokes.
        /// </summary>
        public static KinematicViscosity FromDecistokes(double decistokes)
        {
            return new KinematicViscosity((decistokes/1e4) * 1e-1d);
        }

        /// <summary>
        ///     Get KinematicViscosity from Kilostokes.
        /// </summary>
        public static KinematicViscosity FromKilostokes(double kilostokes)
        {
            return new KinematicViscosity((kilostokes/1e4) * 1e3d);
        }

        /// <summary>
        ///     Get KinematicViscosity from Microstokes.
        /// </summary>
        public static KinematicViscosity FromMicrostokes(double microstokes)
        {
            return new KinematicViscosity((microstokes/1e4) * 1e-6d);
        }

        /// <summary>
        ///     Get KinematicViscosity from Millistokes.
        /// </summary>
        public static KinematicViscosity FromMillistokes(double millistokes)
        {
            return new KinematicViscosity((millistokes/1e4) * 1e-3d);
        }

        /// <summary>
        ///     Get KinematicViscosity from Nanostokes.
        /// </summary>
        public static KinematicViscosity FromNanostokes(double nanostokes)
        {
            return new KinematicViscosity((nanostokes/1e4) * 1e-9d);
        }

        /// <summary>
        ///     Get KinematicViscosity from SquareMetersPerSecond.
        /// </summary>
        public static KinematicViscosity FromSquareMetersPerSecond(double squaremeterspersecond)
        {
            return new KinematicViscosity(squaremeterspersecond);
        }

        /// <summary>
        ///     Get KinematicViscosity from Stokes.
        /// </summary>
        public static KinematicViscosity FromStokes(double stokes)
        {
            return new KinematicViscosity(stokes/1e4);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="KinematicViscosityUnit" /> to <see cref="KinematicViscosity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>KinematicViscosity unit value.</returns>
        public static KinematicViscosity From(double value, KinematicViscosityUnit fromUnit)
        {
            switch (fromUnit)
            {
                case KinematicViscosityUnit.Centistokes:
                    return FromCentistokes(value);
                case KinematicViscosityUnit.Decistokes:
                    return FromDecistokes(value);
                case KinematicViscosityUnit.Kilostokes:
                    return FromKilostokes(value);
                case KinematicViscosityUnit.Microstokes:
                    return FromMicrostokes(value);
                case KinematicViscosityUnit.Millistokes:
                    return FromMillistokes(value);
                case KinematicViscosityUnit.Nanostokes:
                    return FromNanostokes(value);
                case KinematicViscosityUnit.SquareMeterPerSecond:
                    return FromSquareMetersPerSecond(value);
                case KinematicViscosityUnit.Stokes:
                    return FromStokes(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(KinematicViscosityUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static KinematicViscosity operator -(KinematicViscosity right)
        {
            return new KinematicViscosity(-right._squareMetersPerSecond);
        }

        public static KinematicViscosity operator +(KinematicViscosity left, KinematicViscosity right)
        {
            return new KinematicViscosity(left._squareMetersPerSecond + right._squareMetersPerSecond);
        }

        public static KinematicViscosity operator -(KinematicViscosity left, KinematicViscosity right)
        {
            return new KinematicViscosity(left._squareMetersPerSecond - right._squareMetersPerSecond);
        }

        public static KinematicViscosity operator *(double left, KinematicViscosity right)
        {
            return new KinematicViscosity(left*right._squareMetersPerSecond);
        }

        public static KinematicViscosity operator *(KinematicViscosity left, double right)
        {
            return new KinematicViscosity(left._squareMetersPerSecond*(double)right);
        }

        public static KinematicViscosity operator /(KinematicViscosity left, double right)
        {
            return new KinematicViscosity(left._squareMetersPerSecond/(double)right);
        }

        public static double operator /(KinematicViscosity left, KinematicViscosity right)
        {
            return Convert.ToDouble(left._squareMetersPerSecond/right._squareMetersPerSecond);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is KinematicViscosity)) throw new ArgumentException("Expected type KinematicViscosity.", "obj");
            return CompareTo((KinematicViscosity) obj);
        }

        public int CompareTo(KinematicViscosity other)
        {
            return _squareMetersPerSecond.CompareTo(other._squareMetersPerSecond);
        }

        public static bool operator <=(KinematicViscosity left, KinematicViscosity right)
        {
            return left._squareMetersPerSecond <= right._squareMetersPerSecond;
        }

        public static bool operator >=(KinematicViscosity left, KinematicViscosity right)
        {
            return left._squareMetersPerSecond >= right._squareMetersPerSecond;
        }

        public static bool operator <(KinematicViscosity left, KinematicViscosity right)
        {
            return left._squareMetersPerSecond < right._squareMetersPerSecond;
        }

        public static bool operator >(KinematicViscosity left, KinematicViscosity right)
        {
            return left._squareMetersPerSecond > right._squareMetersPerSecond;
        }

        public static bool operator ==(KinematicViscosity left, KinematicViscosity right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._squareMetersPerSecond == right._squareMetersPerSecond;
        }

        public static bool operator !=(KinematicViscosity left, KinematicViscosity right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._squareMetersPerSecond != right._squareMetersPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _squareMetersPerSecond.Equals(((KinematicViscosity) obj)._squareMetersPerSecond);
        }

        public override int GetHashCode()
        {
            return _squareMetersPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(KinematicViscosityUnit unit)
        {
            switch (unit)
            {
                case KinematicViscosityUnit.Centistokes:
                    return Centistokes;
                case KinematicViscosityUnit.Decistokes:
                    return Decistokes;
                case KinematicViscosityUnit.Kilostokes:
                    return Kilostokes;
                case KinematicViscosityUnit.Microstokes:
                    return Microstokes;
                case KinematicViscosityUnit.Millistokes:
                    return Millistokes;
                case KinematicViscosityUnit.Nanostokes:
                    return Nanostokes;
                case KinematicViscosityUnit.SquareMeterPerSecond:
                    return SquareMetersPerSecond;
                case KinematicViscosityUnit.Stokes:
                    return Stokes;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string with at least one quantity of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected valid quantity and unit. Input string needs to have at least one valid quantity in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;".
        /// </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static KinematicViscosity Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var regexString = string.Format(@"(?:(?<value>[-+]?{0}{1}{2}{3}\s?)+?",
                            numRegex,              // capture base (integral) Quantity value
                            @"(?:[eE][-+]?\d+)?)", // capture exponential (if any), end of Quantity capturing
                            @"\s?",                // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>[^\s\d]+)"); // capture Unit (non-numeric, non-whitespace) input

            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<KinematicViscosity>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;

                try
                {
                    KinematicViscosityUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch (Exception e)
                {
                    var newEx = new UnitsNetException("Error parsing string.", e);
                    newEx.Data["input"] = str;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }

            if(converted.Count == 0) // No valid matches
            {
                var ex = new ArgumentException(
                    "Expected valid quantity and unit. Input string needs to have at least one valid quantity in the format \"<quantity><unit> or <quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }
            return converted.Aggregate((x, y) => x + y);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static KinematicViscosityUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<KinematicViscosityUnit>(str.Trim());

            if (unit == KinematicViscosityUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized KinematicViscosityUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(KinematicViscosityUnit.SquareMeterPerSecond);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(KinematicViscosityUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
        {
            return ToString(unit, culture, UnitFormatter.GetFormat(As(unit), significantDigitsAfterRadix));
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(KinematicViscosityUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
