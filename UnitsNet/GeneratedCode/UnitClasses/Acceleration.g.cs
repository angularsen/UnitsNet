// Copyright © 2007 by Initial Force AS.  All rights reserved.
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
    ///     Acceleration, in physics, is the rate at which the velocity of an object changes over time. An object's acceleration is the net result of any and all forces acting on the object, as described by Newton's Second Law. The SI unit for acceleration is the Meter per second squared (m/s2). Accelerations are vector quantities (they have magnitude and direction) and add according to the parallelogram law. As a vector, the calculated net force is equal to the product of the object's mass (a scalar quantity) and the acceleration.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Acceleration : IComparable, IComparable<Acceleration>
    {
        /// <summary>
        ///     Base unit of Acceleration.
        /// </summary>
        private readonly double _meterPerSecondSquared;

        public Acceleration(double meterpersecondsquared) : this()
        {
            _meterPerSecondSquared = meterpersecondsquared;
        }

        #region Properties

        public static AccelerationUnit BaseUnit
        {
            get { return AccelerationUnit.MeterPerSecondSquared; }
        }

        /// <summary>
        ///     Get Acceleration in CentimeterPerSecondSquared.
        /// </summary>
        public double CentimeterPerSecondSquared
        {
            get { return (_meterPerSecondSquared) / 1e-2d; }
        }

        /// <summary>
        ///     Get Acceleration in DecimeterPerSecondSquared.
        /// </summary>
        public double DecimeterPerSecondSquared
        {
            get { return (_meterPerSecondSquared) / 1e-1d; }
        }

        /// <summary>
        ///     Get Acceleration in KilometerPerSecondSquared.
        /// </summary>
        public double KilometerPerSecondSquared
        {
            get { return (_meterPerSecondSquared) / 1e3d; }
        }

        /// <summary>
        ///     Get Acceleration in MeterPerSecondSquared.
        /// </summary>
        public double MeterPerSecondSquared
        {
            get { return _meterPerSecondSquared; }
        }

        /// <summary>
        ///     Get Acceleration in MicrometerPerSecondSquared.
        /// </summary>
        public double MicrometerPerSecondSquared
        {
            get { return (_meterPerSecondSquared) / 1e-6d; }
        }

        /// <summary>
        ///     Get Acceleration in MillimeterPerSecondSquared.
        /// </summary>
        public double MillimeterPerSecondSquared
        {
            get { return (_meterPerSecondSquared) / 1e-3d; }
        }

        /// <summary>
        ///     Get Acceleration in NanometerPerSecondSquared.
        /// </summary>
        public double NanometerPerSecondSquared
        {
            get { return (_meterPerSecondSquared) / 1e-9d; }
        }

        #endregion

        #region Static 

        public static Acceleration Zero
        {
            get { return new Acceleration(); }
        }

        /// <summary>
        ///     Get Acceleration from CentimeterPerSecondSquared.
        /// </summary>
        public static Acceleration FromCentimeterPerSecondSquared(double centimeterpersecondsquared)
        {
            return new Acceleration((centimeterpersecondsquared) * 1e-2d);
        }

        /// <summary>
        ///     Get Acceleration from DecimeterPerSecondSquared.
        /// </summary>
        public static Acceleration FromDecimeterPerSecondSquared(double decimeterpersecondsquared)
        {
            return new Acceleration((decimeterpersecondsquared) * 1e-1d);
        }

        /// <summary>
        ///     Get Acceleration from KilometerPerSecondSquared.
        /// </summary>
        public static Acceleration FromKilometerPerSecondSquared(double kilometerpersecondsquared)
        {
            return new Acceleration((kilometerpersecondsquared) * 1e3d);
        }

        /// <summary>
        ///     Get Acceleration from MeterPerSecondSquared.
        /// </summary>
        public static Acceleration FromMeterPerSecondSquared(double meterpersecondsquared)
        {
            return new Acceleration(meterpersecondsquared);
        }

        /// <summary>
        ///     Get Acceleration from MicrometerPerSecondSquared.
        /// </summary>
        public static Acceleration FromMicrometerPerSecondSquared(double micrometerpersecondsquared)
        {
            return new Acceleration((micrometerpersecondsquared) * 1e-6d);
        }

        /// <summary>
        ///     Get Acceleration from MillimeterPerSecondSquared.
        /// </summary>
        public static Acceleration FromMillimeterPerSecondSquared(double millimeterpersecondsquared)
        {
            return new Acceleration((millimeterpersecondsquared) * 1e-3d);
        }

        /// <summary>
        ///     Get Acceleration from NanometerPerSecondSquared.
        /// </summary>
        public static Acceleration FromNanometerPerSecondSquared(double nanometerpersecondsquared)
        {
            return new Acceleration((nanometerpersecondsquared) * 1e-9d);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AccelerationUnit" /> to <see cref="Acceleration" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Acceleration unit value.</returns>
        public static Acceleration From(double value, AccelerationUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AccelerationUnit.CentimeterPerSecondSquared:
                    return FromCentimeterPerSecondSquared(value);
                case AccelerationUnit.DecimeterPerSecondSquared:
                    return FromDecimeterPerSecondSquared(value);
                case AccelerationUnit.KilometerPerSecondSquared:
                    return FromKilometerPerSecondSquared(value);
                case AccelerationUnit.MeterPerSecondSquared:
                    return FromMeterPerSecondSquared(value);
                case AccelerationUnit.MicrometerPerSecondSquared:
                    return FromMicrometerPerSecondSquared(value);
                case AccelerationUnit.MillimeterPerSecondSquared:
                    return FromMillimeterPerSecondSquared(value);
                case AccelerationUnit.NanometerPerSecondSquared:
                    return FromNanometerPerSecondSquared(value);

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
        public static string GetAbbreviation(AccelerationUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Acceleration operator -(Acceleration right)
        {
            return new Acceleration(-right._meterPerSecondSquared);
        }

        public static Acceleration operator +(Acceleration left, Acceleration right)
        {
            return new Acceleration(left._meterPerSecondSquared + right._meterPerSecondSquared);
        }

        public static Acceleration operator -(Acceleration left, Acceleration right)
        {
            return new Acceleration(left._meterPerSecondSquared - right._meterPerSecondSquared);
        }

        public static Acceleration operator *(double left, Acceleration right)
        {
            return new Acceleration(left*right._meterPerSecondSquared);
        }

        public static Acceleration operator *(Acceleration left, double right)
        {
            return new Acceleration(left._meterPerSecondSquared*(double)right);
        }

        public static Acceleration operator /(Acceleration left, double right)
        {
            return new Acceleration(left._meterPerSecondSquared/(double)right);
        }

        public static double operator /(Acceleration left, Acceleration right)
        {
            return Convert.ToDouble(left._meterPerSecondSquared/right._meterPerSecondSquared);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Acceleration)) throw new ArgumentException("Expected type Acceleration.", "obj");
            return CompareTo((Acceleration) obj);
        }

        public int CompareTo(Acceleration other)
        {
            return _meterPerSecondSquared.CompareTo(other._meterPerSecondSquared);
        }

        public static bool operator <=(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared <= right._meterPerSecondSquared;
        }

        public static bool operator >=(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared >= right._meterPerSecondSquared;
        }

        public static bool operator <(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared < right._meterPerSecondSquared;
        }

        public static bool operator >(Acceleration left, Acceleration right)
        {
            return left._meterPerSecondSquared > right._meterPerSecondSquared;
        }

        public static bool operator ==(Acceleration left, Acceleration right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meterPerSecondSquared == right._meterPerSecondSquared;
        }

        public static bool operator !=(Acceleration left, Acceleration right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meterPerSecondSquared != right._meterPerSecondSquared;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _meterPerSecondSquared.Equals(((Acceleration) obj)._meterPerSecondSquared);
        }

        public override int GetHashCode()
        {
            return _meterPerSecondSquared.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AccelerationUnit unit)
        {
            switch (unit)
            {
                case AccelerationUnit.CentimeterPerSecondSquared:
                    return CentimeterPerSecondSquared;
                case AccelerationUnit.DecimeterPerSecondSquared:
                    return DecimeterPerSecondSquared;
                case AccelerationUnit.KilometerPerSecondSquared:
                    return KilometerPerSecondSquared;
                case AccelerationUnit.MeterPerSecondSquared:
                    return MeterPerSecondSquared;
                case AccelerationUnit.MicrometerPerSecondSquared:
                    return MicrometerPerSecondSquared;
                case AccelerationUnit.MillimeterPerSecondSquared:
                    return MillimeterPerSecondSquared;
                case AccelerationUnit.NanometerPerSecondSquared:
                    return NanometerPerSecondSquared;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in" 
        /// </exception>
        public static Acceleration Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",  // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                            numFormat.NumberGroupSeparator,    // adds provided (or current) culture's group separator
                            numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator
            var exponentialRegex = @"(?:[eE][-+]?\d+)?)";
            var regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?{4}{5}",
                            numRegex,                // capture base (integral) Quantity value
                            exponentialRegex,        // capture exponential (if any), end of Quantity capturing
                            @"\s?",                  // ignore whitespace (allows both "1kg", "1 kg")
                            @"(?<unit>[^\s\d,]+)",   // capture Unit (non-whitespace) input
                            @"(and)?,?",             // allow "and" & "," separators between quantities
                            @"(?<invalid>[a-z]*)?"); // capture invalid input

            var quantities = ParseWithRegex(regexString, str, formatProvider);
            if (quantities.Count == 0)
            {
                throw new ArgumentException(
                    "Expected string to have at least one pair of quantity and unit in the format"
                    + " \"&lt;quantity&gt; &lt;unit&gt;\". Eg. \"5.5 m\" or \"1ft 2in\"");
            }
            return quantities.Aggregate((x, y) => x + y);
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Acceleration> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Acceleration>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;
                if (groups["invalid"].Value != "")
                {
                    var newEx = new UnitsNetException("Invalid string detected: " + groups["invalid"].Value);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
                if (valueString == "" && unitString == "") continue;

                try
                {
                    AccelerationUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch(AmbiguousUnitParseException ambiguousException)
                {
                    throw;
                }
                catch(Exception ex)
                {
                    var newEx = new UnitsNetException("Error parsing string.", ex);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                    throw newEx;
                }
            }
            return converted;
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static AccelerationUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<AccelerationUnit>(str.Trim());

            if (unit == AccelerationUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized AccelerationUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is MeterPerSecondSquared
        /// </summary>
        public static AccelerationUnit ToStringDefaultUnit { get; set; } = AccelerationUnit.MeterPerSecondSquared;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(AccelerationUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(AccelerationUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
