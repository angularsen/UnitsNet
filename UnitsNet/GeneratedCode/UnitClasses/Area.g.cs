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
    ///     Area is a quantity that expresses the extent of a two-dimensional surface or shape, or planar lamina, in the plane. Area can be understood as the amount of material with a given thickness that would be necessary to fashion a model of the shape, or the amount of paint necessary to cover the surface with a single coat.[1] It is the two-dimensional analog of the length of a curve (a one-dimensional concept) or the volume of a solid (a three-dimensional concept).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Area
#else
    public partial struct Area : IComparable, IComparable<Area>
#endif
    {
        /// <summary>
        ///     Base unit of Area.
        /// </summary>
        private readonly double _squareMeters;

#if WINDOWS_UWP
        public Area() : this(0)
        {
        }
#endif

        public Area(double squaremeters)
        {
            _squareMeters = Convert.ToDouble(squaremeters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Area(long squaremeters)
        {
            _squareMeters = Convert.ToDouble(squaremeters);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Area(decimal squaremeters)
        {
            _squareMeters = Convert.ToDouble(squaremeters);
        }

        #region Properties

        public static AreaUnit BaseUnit
        {
            get { return AreaUnit.SquareMeter; }
        }

        /// <summary>
        ///     Get Area in SquareCentimeters.
        /// </summary>
        public double SquareCentimeters
        {
            get { return _squareMeters/1e-4; }
        }

        /// <summary>
        ///     Get Area in SquareDecimeters.
        /// </summary>
        public double SquareDecimeters
        {
            get { return _squareMeters/1e-2; }
        }

        /// <summary>
        ///     Get Area in SquareFeet.
        /// </summary>
        public double SquareFeet
        {
            get { return _squareMeters/0.092903; }
        }

        /// <summary>
        ///     Get Area in SquareInches.
        /// </summary>
        public double SquareInches
        {
            get { return _squareMeters/0.00064516; }
        }

        /// <summary>
        ///     Get Area in SquareKilometers.
        /// </summary>
        public double SquareKilometers
        {
            get { return _squareMeters/1e6; }
        }

        /// <summary>
        ///     Get Area in SquareMeters.
        /// </summary>
        public double SquareMeters
        {
            get { return _squareMeters; }
        }

        /// <summary>
        ///     Get Area in SquareMicrometers.
        /// </summary>
        public double SquareMicrometers
        {
            get { return _squareMeters/1e-12; }
        }

        /// <summary>
        ///     Get Area in SquareMiles.
        /// </summary>
        public double SquareMiles
        {
            get { return _squareMeters/2.59e6; }
        }

        /// <summary>
        ///     Get Area in SquareMillimeters.
        /// </summary>
        public double SquareMillimeters
        {
            get { return _squareMeters/1e-6; }
        }

        /// <summary>
        ///     Get Area in SquareYards.
        /// </summary>
        public double SquareYards
        {
            get { return _squareMeters/0.836127; }
        }

        #endregion

        #region Static

        public static Area Zero
        {
            get { return new Area(); }
        }

        /// <summary>
        ///     Get Area from SquareCentimeters.
        /// </summary>
        public static Area FromSquareCentimeters(double squarecentimeters)
        {
            return new Area(squarecentimeters*1e-4);
        }

        /// <summary>
        ///     Get Area from SquareDecimeters.
        /// </summary>
        public static Area FromSquareDecimeters(double squaredecimeters)
        {
            return new Area(squaredecimeters*1e-2);
        }

        /// <summary>
        ///     Get Area from SquareFeet.
        /// </summary>
        public static Area FromSquareFeet(double squarefeet)
        {
            return new Area(squarefeet*0.092903);
        }

        /// <summary>
        ///     Get Area from SquareInches.
        /// </summary>
        public static Area FromSquareInches(double squareinches)
        {
            return new Area(squareinches*0.00064516);
        }

        /// <summary>
        ///     Get Area from SquareKilometers.
        /// </summary>
        public static Area FromSquareKilometers(double squarekilometers)
        {
            return new Area(squarekilometers*1e6);
        }

        /// <summary>
        ///     Get Area from SquareMeters.
        /// </summary>
        public static Area FromSquareMeters(double squaremeters)
        {
            return new Area(squaremeters);
        }

        /// <summary>
        ///     Get Area from SquareMicrometers.
        /// </summary>
        public static Area FromSquareMicrometers(double squaremicrometers)
        {
            return new Area(squaremicrometers*1e-12);
        }

        /// <summary>
        ///     Get Area from SquareMiles.
        /// </summary>
        public static Area FromSquareMiles(double squaremiles)
        {
            return new Area(squaremiles*2.59e6);
        }

        /// <summary>
        ///     Get Area from SquareMillimeters.
        /// </summary>
        public static Area FromSquareMillimeters(double squaremillimeters)
        {
            return new Area(squaremillimeters*1e-6);
        }

        /// <summary>
        ///     Get Area from SquareYards.
        /// </summary>
        public static Area FromSquareYards(double squareyards)
        {
            return new Area(squareyards*0.836127);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Area from nullable SquareCentimeters.
        /// </summary>
        public static Area? FromSquareCentimeters(double? squarecentimeters)
        {
            if (squarecentimeters.HasValue)
            {
                return FromSquareCentimeters(squarecentimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareDecimeters.
        /// </summary>
        public static Area? FromSquareDecimeters(double? squaredecimeters)
        {
            if (squaredecimeters.HasValue)
            {
                return FromSquareDecimeters(squaredecimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareFeet.
        /// </summary>
        public static Area? FromSquareFeet(double? squarefeet)
        {
            if (squarefeet.HasValue)
            {
                return FromSquareFeet(squarefeet.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareInches.
        /// </summary>
        public static Area? FromSquareInches(double? squareinches)
        {
            if (squareinches.HasValue)
            {
                return FromSquareInches(squareinches.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareKilometers.
        /// </summary>
        public static Area? FromSquareKilometers(double? squarekilometers)
        {
            if (squarekilometers.HasValue)
            {
                return FromSquareKilometers(squarekilometers.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareMeters.
        /// </summary>
        public static Area? FromSquareMeters(double? squaremeters)
        {
            if (squaremeters.HasValue)
            {
                return FromSquareMeters(squaremeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareMicrometers.
        /// </summary>
        public static Area? FromSquareMicrometers(double? squaremicrometers)
        {
            if (squaremicrometers.HasValue)
            {
                return FromSquareMicrometers(squaremicrometers.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareMiles.
        /// </summary>
        public static Area? FromSquareMiles(double? squaremiles)
        {
            if (squaremiles.HasValue)
            {
                return FromSquareMiles(squaremiles.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareMillimeters.
        /// </summary>
        public static Area? FromSquareMillimeters(double? squaremillimeters)
        {
            if (squaremillimeters.HasValue)
            {
                return FromSquareMillimeters(squaremillimeters.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Area from nullable SquareYards.
        /// </summary>
        public static Area? FromSquareYards(double? squareyards)
        {
            if (squareyards.HasValue)
            {
                return FromSquareYards(squareyards.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AreaUnit" /> to <see cref="Area" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Area unit value.</returns>
        public static Area From(double val, AreaUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AreaUnit.SquareCentimeter:
                    return FromSquareCentimeters(val);
                case AreaUnit.SquareDecimeter:
                    return FromSquareDecimeters(val);
                case AreaUnit.SquareFoot:
                    return FromSquareFeet(val);
                case AreaUnit.SquareInch:
                    return FromSquareInches(val);
                case AreaUnit.SquareKilometer:
                    return FromSquareKilometers(val);
                case AreaUnit.SquareMeter:
                    return FromSquareMeters(val);
                case AreaUnit.SquareMicrometer:
                    return FromSquareMicrometers(val);
                case AreaUnit.SquareMile:
                    return FromSquareMiles(val);
                case AreaUnit.SquareMillimeter:
                    return FromSquareMillimeters(val);
                case AreaUnit.SquareYard:
                    return FromSquareYards(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AreaUnit" /> to <see cref="Area" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Area unit value.</returns>
        public static Area? From(double? value, AreaUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case AreaUnit.SquareCentimeter:
                    return FromSquareCentimeters(value.Value);
                case AreaUnit.SquareDecimeter:
                    return FromSquareDecimeters(value.Value);
                case AreaUnit.SquareFoot:
                    return FromSquareFeet(value.Value);
                case AreaUnit.SquareInch:
                    return FromSquareInches(value.Value);
                case AreaUnit.SquareKilometer:
                    return FromSquareKilometers(value.Value);
                case AreaUnit.SquareMeter:
                    return FromSquareMeters(value.Value);
                case AreaUnit.SquareMicrometer:
                    return FromSquareMicrometers(value.Value);
                case AreaUnit.SquareMile:
                    return FromSquareMiles(value.Value);
                case AreaUnit.SquareMillimeter:
                    return FromSquareMillimeters(value.Value);
                case AreaUnit.SquareYard:
                    return FromSquareYards(value.Value);

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
        public static string GetAbbreviation(AreaUnit unit)
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
        public static string GetAbbreviation(AreaUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Area operator -(Area right)
        {
            return new Area(-right._squareMeters);
        }

        public static Area operator +(Area left, Area right)
        {
            return new Area(left._squareMeters + right._squareMeters);
        }

        public static Area operator -(Area left, Area right)
        {
            return new Area(left._squareMeters - right._squareMeters);
        }

        public static Area operator *(double left, Area right)
        {
            return new Area(left*right._squareMeters);
        }

        public static Area operator *(Area left, double right)
        {
            return new Area(left._squareMeters*(double)right);
        }

        public static Area operator /(Area left, double right)
        {
            return new Area(left._squareMeters/(double)right);
        }

        public static double operator /(Area left, Area right)
        {
            return Convert.ToDouble(left._squareMeters/right._squareMeters);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Area)) throw new ArgumentException("Expected type Area.", "obj");
            return CompareTo((Area) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Area other)
        {
            return _squareMeters.CompareTo(other._squareMeters);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Area left, Area right)
        {
            return left._squareMeters <= right._squareMeters;
        }

        public static bool operator >=(Area left, Area right)
        {
            return left._squareMeters >= right._squareMeters;
        }

        public static bool operator <(Area left, Area right)
        {
            return left._squareMeters < right._squareMeters;
        }

        public static bool operator >(Area left, Area right)
        {
            return left._squareMeters > right._squareMeters;
        }

        public static bool operator ==(Area left, Area right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._squareMeters == right._squareMeters;
        }

        public static bool operator !=(Area left, Area right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._squareMeters != right._squareMeters;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _squareMeters.Equals(((Area) obj)._squareMeters);
        }

        public override int GetHashCode()
        {
            return _squareMeters.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AreaUnit unit)
        {
            switch (unit)
            {
                case AreaUnit.SquareCentimeter:
                    return SquareCentimeters;
                case AreaUnit.SquareDecimeter:
                    return SquareDecimeters;
                case AreaUnit.SquareFoot:
                    return SquareFeet;
                case AreaUnit.SquareInch:
                    return SquareInches;
                case AreaUnit.SquareKilometer:
                    return SquareKilometers;
                case AreaUnit.SquareMeter:
                    return SquareMeters;
                case AreaUnit.SquareMicrometer:
                    return SquareMicrometers;
                case AreaUnit.SquareMile:
                    return SquareMiles;
                case AreaUnit.SquareMillimeter:
                    return SquareMillimeters;
                case AreaUnit.SquareYard:
                    return SquareYards;

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
        public static Area Parse(string str)
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
        public static Area Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Area.FromSquareMeters(x.SquareMeters + y.SquareMeters));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Area> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Area>();

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
                    AreaUnit unit = ParseUnit(unitString, formatProvider);
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
        public static AreaUnit ParseUnit(string str)
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
        public static AreaUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static AreaUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<AreaUnit>(str.Trim());

            if (unit == AreaUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized AreaUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is SquareMeter
        /// </summary>
        public static AreaUnit ToStringDefaultUnit { get; set; } = AreaUnit.SquareMeter;

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
        public string ToString(AreaUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(AreaUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(AreaUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(AreaUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
