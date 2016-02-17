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
    ///     The density, or more precisely, the volumetric mass density, of a substance is its mass per unit volume.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Density : IComparable, IComparable<Density>
    {
        /// <summary>
        ///     Base unit of Density.
        /// </summary>
        private readonly double _kilogramsPerCubicMeter;

        public Density(double kilogramspercubicmeter) : this()
        {
            _kilogramsPerCubicMeter = kilogramspercubicmeter;
        }

        #region Properties

        public static DensityUnit BaseUnit
        {
            get { return DensityUnit.KilogramPerCubicMeter; }
        }

        /// <summary>
        ///     Get Density in KilogramsPerCubicCentimeter.
        /// </summary>
        public double KilogramsPerCubicCentimeter
        {
            get { return _kilogramsPerCubicMeter*0.00000001; }
        }

        /// <summary>
        ///     Get Density in KilogramsPerCubicMeter.
        /// </summary>
        public double KilogramsPerCubicMeter
        {
            get { return _kilogramsPerCubicMeter; }
        }

        /// <summary>
        ///     Get Density in KilogramsPerCubicMillimeter.
        /// </summary>
        public double KilogramsPerCubicMillimeter
        {
            get { return _kilogramsPerCubicMeter*0.000000000001; }
        }

        /// <summary>
        ///     Get Density in KilopoundsPerCubicFoot.
        /// </summary>
        public double KilopoundsPerCubicFoot
        {
            get { return (_kilogramsPerCubicMeter*0.062427961) / 1e3d; }
        }

        /// <summary>
        ///     Get Density in KilopoundsPerCubicInch.
        /// </summary>
        public double KilopoundsPerCubicInch
        {
            get { return (_kilogramsPerCubicMeter/27679.904710191) / 1e3d; }
        }

        /// <summary>
        ///     Get Density in PoundsPerCubicFoot.
        /// </summary>
        public double PoundsPerCubicFoot
        {
            get { return _kilogramsPerCubicMeter*0.062427961; }
        }

        /// <summary>
        ///     Get Density in PoundsPerCubicInch.
        /// </summary>
        public double PoundsPerCubicInch
        {
            get { return _kilogramsPerCubicMeter/27679.904710191; }
        }

        /// <summary>
        ///     Get Density in TonnesPerCubicCentimeter.
        /// </summary>
        public double TonnesPerCubicCentimeter
        {
            get { return _kilogramsPerCubicMeter*0.00000000001; }
        }

        /// <summary>
        ///     Get Density in TonnesPerCubicMeter.
        /// </summary>
        public double TonnesPerCubicMeter
        {
            get { return _kilogramsPerCubicMeter*0.001; }
        }

        /// <summary>
        ///     Get Density in TonnesPerCubicMillimeter.
        /// </summary>
        public double TonnesPerCubicMillimeter
        {
            get { return _kilogramsPerCubicMeter*0.000000000000001; }
        }

        #endregion

        #region Static 

        public static Density Zero
        {
            get { return new Density(); }
        }

        /// <summary>
        ///     Get Density from KilogramsPerCubicCentimeter.
        /// </summary>
        public static Density FromKilogramsPerCubicCentimeter(double kilogramspercubiccentimeter)
        {
            return new Density(kilogramspercubiccentimeter*100000000);
        }

        /// <summary>
        ///     Get Density from KilogramsPerCubicMeter.
        /// </summary>
        public static Density FromKilogramsPerCubicMeter(double kilogramspercubicmeter)
        {
            return new Density(kilogramspercubicmeter);
        }

        /// <summary>
        ///     Get Density from KilogramsPerCubicMillimeter.
        /// </summary>
        public static Density FromKilogramsPerCubicMillimeter(double kilogramspercubicmillimeter)
        {
            return new Density(kilogramspercubicmillimeter*1000000000000);
        }

        /// <summary>
        ///     Get Density from KilopoundsPerCubicFoot.
        /// </summary>
        public static Density FromKilopoundsPerCubicFoot(double kilopoundspercubicfoot)
        {
            return new Density((kilopoundspercubicfoot/0.062427961) * 1e3d);
        }

        /// <summary>
        ///     Get Density from KilopoundsPerCubicInch.
        /// </summary>
        public static Density FromKilopoundsPerCubicInch(double kilopoundspercubicinch)
        {
            return new Density((kilopoundspercubicinch*27679.904710191) * 1e3d);
        }

        /// <summary>
        ///     Get Density from PoundsPerCubicFoot.
        /// </summary>
        public static Density FromPoundsPerCubicFoot(double poundspercubicfoot)
        {
            return new Density(poundspercubicfoot/0.062427961);
        }

        /// <summary>
        ///     Get Density from PoundsPerCubicInch.
        /// </summary>
        public static Density FromPoundsPerCubicInch(double poundspercubicinch)
        {
            return new Density(poundspercubicinch*27679.904710191);
        }

        /// <summary>
        ///     Get Density from TonnesPerCubicCentimeter.
        /// </summary>
        public static Density FromTonnesPerCubicCentimeter(double tonnespercubiccentimeter)
        {
            return new Density(tonnespercubiccentimeter*100000000000);
        }

        /// <summary>
        ///     Get Density from TonnesPerCubicMeter.
        /// </summary>
        public static Density FromTonnesPerCubicMeter(double tonnespercubicmeter)
        {
            return new Density(tonnespercubicmeter*1000);
        }

        /// <summary>
        ///     Get Density from TonnesPerCubicMillimeter.
        /// </summary>
        public static Density FromTonnesPerCubicMillimeter(double tonnespercubicmillimeter)
        {
            return new Density(tonnespercubicmillimeter*1000000000000000);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DensityUnit" /> to <see cref="Density" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Density unit value.</returns>
        public static Density From(double value, DensityUnit fromUnit)
        {
            switch (fromUnit)
            {
                case DensityUnit.KilogramPerCubicCentimeter:
                    return FromKilogramsPerCubicCentimeter(value);
                case DensityUnit.KilogramPerCubicMeter:
                    return FromKilogramsPerCubicMeter(value);
                case DensityUnit.KilogramPerCubicMillimeter:
                    return FromKilogramsPerCubicMillimeter(value);
                case DensityUnit.KilopoundPerCubicFoot:
                    return FromKilopoundsPerCubicFoot(value);
                case DensityUnit.KilopoundPerCubicInch:
                    return FromKilopoundsPerCubicInch(value);
                case DensityUnit.PoundPerCubicFoot:
                    return FromPoundsPerCubicFoot(value);
                case DensityUnit.PoundPerCubicInch:
                    return FromPoundsPerCubicInch(value);
                case DensityUnit.TonnePerCubicCentimeter:
                    return FromTonnesPerCubicCentimeter(value);
                case DensityUnit.TonnePerCubicMeter:
                    return FromTonnesPerCubicMeter(value);
                case DensityUnit.TonnePerCubicMillimeter:
                    return FromTonnesPerCubicMillimeter(value);

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
        public static string GetAbbreviation(DensityUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Density operator -(Density right)
        {
            return new Density(-right._kilogramsPerCubicMeter);
        }

        public static Density operator +(Density left, Density right)
        {
            return new Density(left._kilogramsPerCubicMeter + right._kilogramsPerCubicMeter);
        }

        public static Density operator -(Density left, Density right)
        {
            return new Density(left._kilogramsPerCubicMeter - right._kilogramsPerCubicMeter);
        }

        public static Density operator *(double left, Density right)
        {
            return new Density(left*right._kilogramsPerCubicMeter);
        }

        public static Density operator *(Density left, double right)
        {
            return new Density(left._kilogramsPerCubicMeter*(double)right);
        }

        public static Density operator /(Density left, double right)
        {
            return new Density(left._kilogramsPerCubicMeter/(double)right);
        }

        public static double operator /(Density left, Density right)
        {
            return Convert.ToDouble(left._kilogramsPerCubicMeter/right._kilogramsPerCubicMeter);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Density)) throw new ArgumentException("Expected type Density.", "obj");
            return CompareTo((Density) obj);
        }

        public int CompareTo(Density other)
        {
            return _kilogramsPerCubicMeter.CompareTo(other._kilogramsPerCubicMeter);
        }

        public static bool operator <=(Density left, Density right)
        {
            return left._kilogramsPerCubicMeter <= right._kilogramsPerCubicMeter;
        }

        public static bool operator >=(Density left, Density right)
        {
            return left._kilogramsPerCubicMeter >= right._kilogramsPerCubicMeter;
        }

        public static bool operator <(Density left, Density right)
        {
            return left._kilogramsPerCubicMeter < right._kilogramsPerCubicMeter;
        }

        public static bool operator >(Density left, Density right)
        {
            return left._kilogramsPerCubicMeter > right._kilogramsPerCubicMeter;
        }

        public static bool operator ==(Density left, Density right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilogramsPerCubicMeter == right._kilogramsPerCubicMeter;
        }

        public static bool operator !=(Density left, Density right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilogramsPerCubicMeter != right._kilogramsPerCubicMeter;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _kilogramsPerCubicMeter.Equals(((Density) obj)._kilogramsPerCubicMeter);
        }

        public override int GetHashCode()
        {
            return _kilogramsPerCubicMeter.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(DensityUnit unit)
        {
            switch (unit)
            {
                case DensityUnit.KilogramPerCubicCentimeter:
                    return KilogramsPerCubicCentimeter;
                case DensityUnit.KilogramPerCubicMeter:
                    return KilogramsPerCubicMeter;
                case DensityUnit.KilogramPerCubicMillimeter:
                    return KilogramsPerCubicMillimeter;
                case DensityUnit.KilopoundPerCubicFoot:
                    return KilopoundsPerCubicFoot;
                case DensityUnit.KilopoundPerCubicInch:
                    return KilopoundsPerCubicInch;
                case DensityUnit.PoundPerCubicFoot:
                    return PoundsPerCubicFoot;
                case DensityUnit.PoundPerCubicInch:
                    return PoundsPerCubicInch;
                case DensityUnit.TonnePerCubicCentimeter:
                    return TonnesPerCubicCentimeter;
                case DensityUnit.TonnePerCubicMeter:
                    return TonnesPerCubicMeter;
                case DensityUnit.TonnePerCubicMillimeter:
                    return TonnesPerCubicMillimeter;

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
        /// <param name="formatProvider">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
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
        public static Density Parse(string str, IFormatProvider formatProvider = null)
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
        private static List<Density> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Density>();

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
                    DensityUnit unit = ParseUnit(unitString, formatProvider);
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
        public static DensityUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<DensityUnit>(str.Trim());

            if (unit == DensityUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized DensityUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is KilogramPerCubicMeter
        /// </summary>
        public static DensityUnit ToStringDefaultUnit { get; set; } = DensityUnit.KilogramPerCubicMeter;

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
        public string ToString(DensityUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(DensityUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
