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
    ///     Brake specific fuel consumption (BSFC) is a measure of the fuel efficiency of any prime mover that burns fuel and produces rotational, or shaft, power. It is typically used for comparing the efficiency of internal combustion engines with a shaft output.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class BrakeSpecificFuelConsumption
#else
    public partial struct BrakeSpecificFuelConsumption : IComparable, IComparable<BrakeSpecificFuelConsumption>
#endif
    {
        /// <summary>
        ///     Base unit of BrakeSpecificFuelConsumption.
        /// </summary>
        private readonly double _kilogramsPerJoule;

#if WINDOWS_UWP
        public BrakeSpecificFuelConsumption() : this(0)
        {
        }
#endif

        public BrakeSpecificFuelConsumption(double kilogramsperjoule)
        {
            _kilogramsPerJoule = Convert.ToDouble(kilogramsperjoule);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        BrakeSpecificFuelConsumption(long kilogramsperjoule)
        {
            _kilogramsPerJoule = Convert.ToDouble(kilogramsperjoule);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        BrakeSpecificFuelConsumption(decimal kilogramsperjoule)
        {
            _kilogramsPerJoule = Convert.ToDouble(kilogramsperjoule);
        }

        #region Properties

        public static BrakeSpecificFuelConsumptionUnit BaseUnit
        {
            get { return BrakeSpecificFuelConsumptionUnit.KilogramPerJoule; }
        }

        /// <summary>
        ///     Get BrakeSpecificFuelConsumption in GramsPerKiloWattHour.
        /// </summary>
        public double GramsPerKiloWattHour
        {
            get { return _kilogramsPerJoule*3.6e9; }
        }

        /// <summary>
        ///     Get BrakeSpecificFuelConsumption in KilogramsPerJoule.
        /// </summary>
        public double KilogramsPerJoule
        {
            get { return _kilogramsPerJoule; }
        }

        /// <summary>
        ///     Get BrakeSpecificFuelConsumption in PoundsPerMechanicalHorsepowerHour.
        /// </summary>
        public double PoundsPerMechanicalHorsepowerHour
        {
            get { return _kilogramsPerJoule/1.689659410672e-7; }
        }

        #endregion

        #region Static

        public static BrakeSpecificFuelConsumption Zero
        {
            get { return new BrakeSpecificFuelConsumption(); }
        }

        /// <summary>
        ///     Get BrakeSpecificFuelConsumption from GramsPerKiloWattHour.
        /// </summary>
        public static BrakeSpecificFuelConsumption FromGramsPerKiloWattHour(double gramsperkilowatthour)
        {
            return new BrakeSpecificFuelConsumption(gramsperkilowatthour/3.6e9);
        }

        /// <summary>
        ///     Get BrakeSpecificFuelConsumption from KilogramsPerJoule.
        /// </summary>
        public static BrakeSpecificFuelConsumption FromKilogramsPerJoule(double kilogramsperjoule)
        {
            return new BrakeSpecificFuelConsumption(kilogramsperjoule);
        }

        /// <summary>
        ///     Get BrakeSpecificFuelConsumption from PoundsPerMechanicalHorsepowerHour.
        /// </summary>
        public static BrakeSpecificFuelConsumption FromPoundsPerMechanicalHorsepowerHour(double poundspermechanicalhorsepowerhour)
        {
            return new BrakeSpecificFuelConsumption(poundspermechanicalhorsepowerhour*1.689659410672e-7);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable BrakeSpecificFuelConsumption from nullable GramsPerKiloWattHour.
        /// </summary>
        public static BrakeSpecificFuelConsumption? FromGramsPerKiloWattHour(double? gramsperkilowatthour)
        {
            if (gramsperkilowatthour.HasValue)
            {
                return FromGramsPerKiloWattHour(gramsperkilowatthour.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable BrakeSpecificFuelConsumption from nullable KilogramsPerJoule.
        /// </summary>
        public static BrakeSpecificFuelConsumption? FromKilogramsPerJoule(double? kilogramsperjoule)
        {
            if (kilogramsperjoule.HasValue)
            {
                return FromKilogramsPerJoule(kilogramsperjoule.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable BrakeSpecificFuelConsumption from nullable PoundsPerMechanicalHorsepowerHour.
        /// </summary>
        public static BrakeSpecificFuelConsumption? FromPoundsPerMechanicalHorsepowerHour(double? poundspermechanicalhorsepowerhour)
        {
            if (poundspermechanicalhorsepowerhour.HasValue)
            {
                return FromPoundsPerMechanicalHorsepowerHour(poundspermechanicalhorsepowerhour.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="BrakeSpecificFuelConsumptionUnit" /> to <see cref="BrakeSpecificFuelConsumption" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>BrakeSpecificFuelConsumption unit value.</returns>
        public static BrakeSpecificFuelConsumption From(double val, BrakeSpecificFuelConsumptionUnit fromUnit)
        {
            switch (fromUnit)
            {
                case BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour:
                    return FromGramsPerKiloWattHour(val);
                case BrakeSpecificFuelConsumptionUnit.KilogramPerJoule:
                    return FromKilogramsPerJoule(val);
                case BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour:
                    return FromPoundsPerMechanicalHorsepowerHour(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="BrakeSpecificFuelConsumptionUnit" /> to <see cref="BrakeSpecificFuelConsumption" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>BrakeSpecificFuelConsumption unit value.</returns>
        public static BrakeSpecificFuelConsumption? From(double? value, BrakeSpecificFuelConsumptionUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour:
                    return FromGramsPerKiloWattHour(value.Value);
                case BrakeSpecificFuelConsumptionUnit.KilogramPerJoule:
                    return FromKilogramsPerJoule(value.Value);
                case BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour:
                    return FromPoundsPerMechanicalHorsepowerHour(value.Value);

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
        public static string GetAbbreviation(BrakeSpecificFuelConsumptionUnit unit)
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
        public static string GetAbbreviation(BrakeSpecificFuelConsumptionUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static BrakeSpecificFuelConsumption operator -(BrakeSpecificFuelConsumption right)
        {
            return new BrakeSpecificFuelConsumption(-right._kilogramsPerJoule);
        }

        public static BrakeSpecificFuelConsumption operator +(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            return new BrakeSpecificFuelConsumption(left._kilogramsPerJoule + right._kilogramsPerJoule);
        }

        public static BrakeSpecificFuelConsumption operator -(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            return new BrakeSpecificFuelConsumption(left._kilogramsPerJoule - right._kilogramsPerJoule);
        }

        public static BrakeSpecificFuelConsumption operator *(double left, BrakeSpecificFuelConsumption right)
        {
            return new BrakeSpecificFuelConsumption(left*right._kilogramsPerJoule);
        }

        public static BrakeSpecificFuelConsumption operator *(BrakeSpecificFuelConsumption left, double right)
        {
            return new BrakeSpecificFuelConsumption(left._kilogramsPerJoule*(double)right);
        }

        public static BrakeSpecificFuelConsumption operator /(BrakeSpecificFuelConsumption left, double right)
        {
            return new BrakeSpecificFuelConsumption(left._kilogramsPerJoule/(double)right);
        }

        public static double operator /(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            return Convert.ToDouble(left._kilogramsPerJoule/right._kilogramsPerJoule);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is BrakeSpecificFuelConsumption)) throw new ArgumentException("Expected type BrakeSpecificFuelConsumption.", "obj");
            return CompareTo((BrakeSpecificFuelConsumption) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(BrakeSpecificFuelConsumption other)
        {
            return _kilogramsPerJoule.CompareTo(other._kilogramsPerJoule);
        }

#if !WINDOWS_UWP
        public static bool operator <=(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            return left._kilogramsPerJoule <= right._kilogramsPerJoule;
        }

        public static bool operator >=(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            return left._kilogramsPerJoule >= right._kilogramsPerJoule;
        }

        public static bool operator <(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            return left._kilogramsPerJoule < right._kilogramsPerJoule;
        }

        public static bool operator >(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            return left._kilogramsPerJoule > right._kilogramsPerJoule;
        }

        public static bool operator ==(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilogramsPerJoule == right._kilogramsPerJoule;
        }

        public static bool operator !=(BrakeSpecificFuelConsumption left, BrakeSpecificFuelConsumption right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilogramsPerJoule != right._kilogramsPerJoule;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _kilogramsPerJoule.Equals(((BrakeSpecificFuelConsumption) obj)._kilogramsPerJoule);
        }

        public override int GetHashCode()
        {
            return _kilogramsPerJoule.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(BrakeSpecificFuelConsumptionUnit unit)
        {
            switch (unit)
            {
                case BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour:
                    return GramsPerKiloWattHour;
                case BrakeSpecificFuelConsumptionUnit.KilogramPerJoule:
                    return KilogramsPerJoule;
                case BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour:
                    return PoundsPerMechanicalHorsepowerHour;

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
        public static BrakeSpecificFuelConsumption Parse(string str)
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
        public static BrakeSpecificFuelConsumption Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => BrakeSpecificFuelConsumption.FromKilogramsPerJoule(x.KilogramsPerJoule + y.KilogramsPerJoule));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<BrakeSpecificFuelConsumption> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<BrakeSpecificFuelConsumption>();

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
                    BrakeSpecificFuelConsumptionUnit unit = ParseUnit(unitString, formatProvider);
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
        public static BrakeSpecificFuelConsumptionUnit ParseUnit(string str)
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
        public static BrakeSpecificFuelConsumptionUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static BrakeSpecificFuelConsumptionUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<BrakeSpecificFuelConsumptionUnit>(str.Trim());

            if (unit == BrakeSpecificFuelConsumptionUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized BrakeSpecificFuelConsumptionUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is KilogramPerJoule
        /// </summary>
        public static BrakeSpecificFuelConsumptionUnit ToStringDefaultUnit { get; set; } = BrakeSpecificFuelConsumptionUnit.KilogramPerJoule;

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
        public string ToString(BrakeSpecificFuelConsumptionUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(BrakeSpecificFuelConsumptionUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(BrakeSpecificFuelConsumptionUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(BrakeSpecificFuelConsumptionUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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

        /// <summary>
        /// Represents the largest possible value of BrakeSpecificFuelConsumption
        /// </summary>
        public static BrakeSpecificFuelConsumption MaxValue
        {
            get
            {
                return new BrakeSpecificFuelConsumption(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of BrakeSpecificFuelConsumption
        /// </summary>
        public static BrakeSpecificFuelConsumption MinValue
        {
            get
            {
                return new BrakeSpecificFuelConsumption(double.MinValue);
            }
        }
    }
}
