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

#if WINDOWS_UWP
using Culture = System.String;
#else
using Culture = System.IFormatProvider;
#endif

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     Many different units of length have been used around the world. The main units in modern use are U.S. customary units in the United States and the Metric system elsewhere. British Imperial units are still used for some purposes in the United Kingdom and some other countries. The metric system is sub-divided into SI and non-SI units.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Length
#else
    public partial struct Length : IComparable, IComparable<Length>
#endif
    {
        /// <summary>
        ///     Base unit of Length.
        /// </summary>
        private readonly double _meters;

#if WINDOWS_UWP
        public Length() : this(0)
        {
        }
#endif

        public Length(double meters)
        {
            _meters = Convert.ToDouble(meters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Length(long meters)
        {
            _meters = Convert.ToDouble(meters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Length(decimal meters)
        {
            _meters = Convert.ToDouble(meters);
        }

        #region Properties

        public static LengthUnit BaseUnit
        {
            get { return LengthUnit.Meter; }
        }

        /// <summary>
        ///     Get Length in Centimeters.
        /// </summary>
        public double Centimeters
        {
            get { return (_meters) / 1e-2d; }
        }

        /// <summary>
        ///     Get Length in Decimeters.
        /// </summary>
        public double Decimeters
        {
            get { return (_meters) / 1e-1d; }
        }

        /// <summary>
        ///     Get Length in Feet.
        /// </summary>
        public double Feet
        {
            get { return _meters/0.3048; }
        }

        /// <summary>
        ///     Get Length in Inches.
        /// </summary>
        public double Inches
        {
            get { return _meters/2.54e-2; }
        }

        /// <summary>
        ///     Get Length in Kilometers.
        /// </summary>
        public double Kilometers
        {
            get { return (_meters) / 1e3d; }
        }

        /// <summary>
        ///     Get Length in Meters.
        /// </summary>
        public double Meters
        {
            get { return _meters; }
        }

        /// <summary>
        ///     Get Length in Microinches.
        /// </summary>
        public double Microinches
        {
            get { return _meters/2.54e-8; }
        }

        /// <summary>
        ///     Get Length in Micrometers.
        /// </summary>
        public double Micrometers
        {
            get { return (_meters) / 1e-6d; }
        }

        /// <summary>
        ///     Get Length in Mils.
        /// </summary>
        public double Mils
        {
            get { return _meters/2.54e-5; }
        }

        /// <summary>
        ///     Get Length in Miles.
        /// </summary>
        public double Miles
        {
            get { return _meters/1609.34; }
        }

        /// <summary>
        ///     Get Length in Millimeters.
        /// </summary>
        public double Millimeters
        {
            get { return (_meters) / 1e-3d; }
        }

        /// <summary>
        ///     Get Length in Nanometers.
        /// </summary>
        public double Nanometers
        {
            get { return (_meters) / 1e-9d; }
        }

        /// <summary>
        ///     Get Length in NauticalMiles.
        /// </summary>
        public double NauticalMiles
        {
            get { return _meters/1852; }
        }

        /// <summary>
        ///     Get Length in Yards.
        /// </summary>
        public double Yards
        {
            get { return _meters/0.9144; }
        }

        #endregion

        #region Static

        public static Length Zero
        {
            get { return new Length(); }
        }

        /// <summary>
        ///     Get Length from Centimeters.
        /// </summary>
        public static Length FromCentimeters(double centimeters)
        {
            return new Length((centimeters) * 1e-2d);
        }

        /// <summary>
        ///     Get Length from Decimeters.
        /// </summary>
        public static Length FromDecimeters(double decimeters)
        {
            return new Length((decimeters) * 1e-1d);
        }

        /// <summary>
        ///     Get Length from Feet.
        /// </summary>
        public static Length FromFeet(double feet)
        {
            return new Length(feet*0.3048);
        }

        /// <summary>
        ///     Get Length from Inches.
        /// </summary>
        public static Length FromInches(double inches)
        {
            return new Length(inches*2.54e-2);
        }

        /// <summary>
        ///     Get Length from Kilometers.
        /// </summary>
        public static Length FromKilometers(double kilometers)
        {
            return new Length((kilometers) * 1e3d);
        }

        /// <summary>
        ///     Get Length from Meters.
        /// </summary>
        public static Length FromMeters(double meters)
        {
            return new Length(meters);
        }

        /// <summary>
        ///     Get Length from Microinches.
        /// </summary>
        public static Length FromMicroinches(double microinches)
        {
            return new Length(microinches*2.54e-8);
        }

        /// <summary>
        ///     Get Length from Micrometers.
        /// </summary>
        public static Length FromMicrometers(double micrometers)
        {
            return new Length((micrometers) * 1e-6d);
        }

        /// <summary>
        ///     Get Length from Mils.
        /// </summary>
        public static Length FromMils(double mils)
        {
            return new Length(mils*2.54e-5);
        }

        /// <summary>
        ///     Get Length from Miles.
        /// </summary>
        public static Length FromMiles(double miles)
        {
            return new Length(miles*1609.34);
        }

        /// <summary>
        ///     Get Length from Millimeters.
        /// </summary>
        public static Length FromMillimeters(double millimeters)
        {
            return new Length((millimeters) * 1e-3d);
        }

        /// <summary>
        ///     Get Length from Nanometers.
        /// </summary>
        public static Length FromNanometers(double nanometers)
        {
            return new Length((nanometers) * 1e-9d);
        }

        /// <summary>
        ///     Get Length from NauticalMiles.
        /// </summary>
        public static Length FromNauticalMiles(double nauticalmiles)
        {
            return new Length(nauticalmiles*1852);
        }

        /// <summary>
        ///     Get Length from Yards.
        /// </summary>
        public static Length FromYards(double yards)
        {
            return new Length(yards*0.9144);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Length from nullable Centimeters.
        /// </summary>
        public static Length? FromCentimeters(double? centimeters)
        {
            if (centimeters.HasValue)
            {
                return FromCentimeters(centimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Decimeters.
        /// </summary>
        public static Length? FromDecimeters(double? decimeters)
        {
            if (decimeters.HasValue)
            {
                return FromDecimeters(decimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Feet.
        /// </summary>
        public static Length? FromFeet(double? feet)
        {
            if (feet.HasValue)
            {
                return FromFeet(feet.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Inches.
        /// </summary>
        public static Length? FromInches(double? inches)
        {
            if (inches.HasValue)
            {
                return FromInches(inches.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Kilometers.
        /// </summary>
        public static Length? FromKilometers(double? kilometers)
        {
            if (kilometers.HasValue)
            {
                return FromKilometers(kilometers.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Meters.
        /// </summary>
        public static Length? FromMeters(double? meters)
        {
            if (meters.HasValue)
            {
                return FromMeters(meters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Microinches.
        /// </summary>
        public static Length? FromMicroinches(double? microinches)
        {
            if (microinches.HasValue)
            {
                return FromMicroinches(microinches.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Micrometers.
        /// </summary>
        public static Length? FromMicrometers(double? micrometers)
        {
            if (micrometers.HasValue)
            {
                return FromMicrometers(micrometers.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Mils.
        /// </summary>
        public static Length? FromMils(double? mils)
        {
            if (mils.HasValue)
            {
                return FromMils(mils.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Miles.
        /// </summary>
        public static Length? FromMiles(double? miles)
        {
            if (miles.HasValue)
            {
                return FromMiles(miles.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Millimeters.
        /// </summary>
        public static Length? FromMillimeters(double? millimeters)
        {
            if (millimeters.HasValue)
            {
                return FromMillimeters(millimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Nanometers.
        /// </summary>
        public static Length? FromNanometers(double? nanometers)
        {
            if (nanometers.HasValue)
            {
                return FromNanometers(nanometers.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable NauticalMiles.
        /// </summary>
        public static Length? FromNauticalMiles(double? nauticalmiles)
        {
            if (nauticalmiles.HasValue)
            {
                return FromNauticalMiles(nauticalmiles.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Length from nullable Yards.
        /// </summary>
        public static Length? FromYards(double? yards)
        {
            if (yards.HasValue)
            {
                return FromYards(yards.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LengthUnit" /> to <see cref="Length" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Length unit value.</returns>
        public static Length From(double val, LengthUnit fromUnit)
        {
            switch (fromUnit)
            {
                case LengthUnit.Centimeter:
                    return FromCentimeters(val);
                case LengthUnit.Decimeter:
                    return FromDecimeters(val);
                case LengthUnit.Foot:
                    return FromFeet(val);
                case LengthUnit.Inch:
                    return FromInches(val);
                case LengthUnit.Kilometer:
                    return FromKilometers(val);
                case LengthUnit.Meter:
                    return FromMeters(val);
                case LengthUnit.Microinch:
                    return FromMicroinches(val);
                case LengthUnit.Micrometer:
                    return FromMicrometers(val);
                case LengthUnit.Mil:
                    return FromMils(val);
                case LengthUnit.Mile:
                    return FromMiles(val);
                case LengthUnit.Millimeter:
                    return FromMillimeters(val);
                case LengthUnit.Nanometer:
                    return FromNanometers(val);
                case LengthUnit.NauticalMile:
                    return FromNauticalMiles(val);
                case LengthUnit.Yard:
                    return FromYards(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LengthUnit" /> to <see cref="Length" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Length unit value.</returns>
        public static Length? From(double? value, LengthUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case LengthUnit.Centimeter:
                    return FromCentimeters(value.Value);
                case LengthUnit.Decimeter:
                    return FromDecimeters(value.Value);
                case LengthUnit.Foot:
                    return FromFeet(value.Value);
                case LengthUnit.Inch:
                    return FromInches(value.Value);
                case LengthUnit.Kilometer:
                    return FromKilometers(value.Value);
                case LengthUnit.Meter:
                    return FromMeters(value.Value);
                case LengthUnit.Microinch:
                    return FromMicroinches(value.Value);
                case LengthUnit.Micrometer:
                    return FromMicrometers(value.Value);
                case LengthUnit.Mil:
                    return FromMils(value.Value);
                case LengthUnit.Mile:
                    return FromMiles(value.Value);
                case LengthUnit.Millimeter:
                    return FromMillimeters(value.Value);
                case LengthUnit.Nanometer:
                    return FromNanometers(value.Value);
                case LengthUnit.NauticalMile:
                    return FromNauticalMiles(value.Value);
                case LengthUnit.Yard:
                    return FromYards(value.Value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
#endif

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(LengthUnit unit)
        {
            return GetAbbreviation(unit, null);
        }

        /// <summary>
        ///     Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        [UsedImplicitly]
        public static string GetAbbreviation(LengthUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Length operator -(Length right)
        {
            return new Length(-right._meters);
        }

        public static Length operator +(Length left, Length right)
        {
            return new Length(left._meters + right._meters);
        }

        public static Length operator -(Length left, Length right)
        {
            return new Length(left._meters - right._meters);
        }

        public static Length operator *(double left, Length right)
        {
            return new Length(left*right._meters);
        }

        public static Length operator *(Length left, double right)
        {
            return new Length(left._meters*(double)right);
        }

        public static Length operator /(Length left, double right)
        {
            return new Length(left._meters/(double)right);
        }

        public static double operator /(Length left, Length right)
        {
            return Convert.ToDouble(left._meters/right._meters);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Length)) throw new ArgumentException("Expected type Length.", "obj");
            return CompareTo((Length) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Length other)
        {
            return _meters.CompareTo(other._meters);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Length left, Length right)
        {
            return left._meters <= right._meters;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left._meters >= right._meters;
        }

        public static bool operator <(Length left, Length right)
        {
            return left._meters < right._meters;
        }

        public static bool operator >(Length left, Length right)
        {
            return left._meters > right._meters;
        }

        public static bool operator ==(Length left, Length right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meters == right._meters;
        }

        public static bool operator !=(Length left, Length right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._meters != right._meters;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _meters.Equals(((Length) obj)._meters);
        }

        public override int GetHashCode()
        {
            return _meters.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.Centimeter:
                    return Centimeters;
                case LengthUnit.Decimeter:
                    return Decimeters;
                case LengthUnit.Foot:
                    return Feet;
                case LengthUnit.Inch:
                    return Inches;
                case LengthUnit.Kilometer:
                    return Kilometers;
                case LengthUnit.Meter:
                    return Meters;
                case LengthUnit.Microinch:
                    return Microinches;
                case LengthUnit.Micrometer:
                    return Micrometers;
                case LengthUnit.Mil:
                    return Mils;
                case LengthUnit.Mile:
                    return Miles;
                case LengthUnit.Millimeter:
                    return Millimeters;
                case LengthUnit.Nanometer:
                    return Nanometers;
                case LengthUnit.NauticalMile:
                    return NauticalMiles;
                case LengthUnit.Yard:
                    return Yards;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static Length Parse(string str)
        {
            return Parse(str, null);
        }

        /// <summary>
        ///     Parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="culture">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected string to have one or two pairs of quantity and unit in the format
        ///     "&lt;quantity&gt; &lt;unit&gt;". Eg. "5.5 m" or "1ft 2in"
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     More than one unit is represented by the specified unit abbreviation.
        ///     Example: Volume.Parse("1 cup") will throw, because it can refer to any of
        ///     <see cref="VolumeUnit.MetricCup" />, <see cref="VolumeUnit.UsLegalCup" /> and <see cref="VolumeUnit.UsCustomaryCup" />.
        /// </exception>
        /// <exception cref="UnitsNetException">
        ///     If anything else goes wrong, typically due to a bug or unhandled case.
        ///     We wrap exceptions in <see cref="UnitsNetException" /> to allow you to distinguish
        ///     Units.NET exceptions from other exceptions.
        /// </exception>
        public static Length Parse(string str, [CanBeNull] Culture culture)
        {
            if (str == null) throw new ArgumentNullException("str");

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
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
            return quantities.Aggregate((x, y) => Length.FromMeters(x.Meters + y.Meters));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Length> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Length>();

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
                    LengthUnit unit = ParseUnit(unitString, formatProvider);
                    double value = double.Parse(valueString, formatProvider);

                    converted.Add(From(value, unit));
                }
                catch(AmbiguousUnitParseException)
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
        public static LengthUnit ParseUnit(string str)
        {
            return ParseUnit(str, (IFormatProvider)null);
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static LengthUnit ParseUnit(string str, [CanBeNull] string cultureName)
        {
            return ParseUnit(str, cultureName == null ? null : new CultureInfo(cultureName));
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
#if WINDOWS_UWP
        internal
#else
        public
#endif
        static LengthUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<LengthUnit>(str.Trim());

            if (unit == LengthUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized LengthUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Meter
        /// </summary>
        public static LengthUnit ToStringDefaultUnit { get; set; } = LengthUnit.Meter;

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(ToStringDefaultUnit);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(LengthUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(LengthUnit unit, [CanBeNull] Culture culture)
        {
            return ToString(unit, culture, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(LengthUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
        {
            double value = As(unit);
            string format = UnitFormatter.GetFormat(value, significantDigitsAfterRadix);
            return ToString(unit, culture, format);
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
        public string ToString(LengthUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
            [NotNull] params object[] args)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            if (args == null) throw new ArgumentNullException(nameof(args));

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            double value = As(unit);
            object[] formatArgs = UnitFormatter.GetFormatArgs(unit, value, formatProvider, args);
            return string.Format(formatProvider, format, formatArgs);
        }
    }
}
