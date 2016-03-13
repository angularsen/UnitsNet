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
    ///     Mass flow is the ratio of the mass change to the time during which the change occurred (value of mass changes per unit time).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class MassFlow
#else
    public partial struct MassFlow : IComparable, IComparable<MassFlow>
#endif
    {
        /// <summary>
        ///     Base unit of MassFlow.
        /// </summary>
        private readonly double _gramsPerSecond;

#if WINDOWS_UWP
        public MassFlow() : this(0)
        {
        }
#endif

        public MassFlow(double gramspersecond)
        {
            _gramsPerSecond = Convert.ToDouble(gramspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        MassFlow(long gramspersecond)
        {
            _gramsPerSecond = Convert.ToDouble(gramspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        MassFlow(decimal gramspersecond)
        {
            _gramsPerSecond = Convert.ToDouble(gramspersecond);
        }

        #region Properties

        public static MassFlowUnit BaseUnit
        {
            get { return MassFlowUnit.GramPerSecond; }
        }

        /// <summary>
        ///     Get MassFlow in CentigramsPerSecond.
        /// </summary>
        public double CentigramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e-2d; }
        }

        /// <summary>
        ///     Get MassFlow in DecagramsPerSecond.
        /// </summary>
        public double DecagramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e1d; }
        }

        /// <summary>
        ///     Get MassFlow in DecigramsPerSecond.
        /// </summary>
        public double DecigramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e-1d; }
        }

        /// <summary>
        ///     Get MassFlow in GramsPerSecond.
        /// </summary>
        public double GramsPerSecond
        {
            get { return _gramsPerSecond; }
        }

        /// <summary>
        ///     Get MassFlow in HectogramsPerSecond.
        /// </summary>
        public double HectogramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e2d; }
        }

        /// <summary>
        ///     Get MassFlow in KilogramsPerSecond.
        /// </summary>
        public double KilogramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e3d; }
        }

        /// <summary>
        ///     Get MassFlow in MicrogramsPerSecond.
        /// </summary>
        public double MicrogramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e-6d; }
        }

        /// <summary>
        ///     Get MassFlow in MilligramsPerSecond.
        /// </summary>
        public double MilligramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e-3d; }
        }

        /// <summary>
        ///     Get MassFlow in NanogramsPerSecond.
        /// </summary>
        public double NanogramsPerSecond
        {
            get { return (_gramsPerSecond) / 1e-9d; }
        }

        /// <summary>
        ///     Get MassFlow in TonnesPerDay.
        /// </summary>
        public double TonnesPerDay
        {
            get { return _gramsPerSecond*0.0864000; }
        }

        #endregion

        #region Static

        public static MassFlow Zero
        {
            get { return new MassFlow(); }
        }

        /// <summary>
        ///     Get MassFlow from CentigramsPerSecond.
        /// </summary>
        public static MassFlow FromCentigramsPerSecond(double centigramspersecond)
        {
            return new MassFlow((centigramspersecond) * 1e-2d);
        }

        /// <summary>
        ///     Get MassFlow from DecagramsPerSecond.
        /// </summary>
        public static MassFlow FromDecagramsPerSecond(double decagramspersecond)
        {
            return new MassFlow((decagramspersecond) * 1e1d);
        }

        /// <summary>
        ///     Get MassFlow from DecigramsPerSecond.
        /// </summary>
        public static MassFlow FromDecigramsPerSecond(double decigramspersecond)
        {
            return new MassFlow((decigramspersecond) * 1e-1d);
        }

        /// <summary>
        ///     Get MassFlow from GramsPerSecond.
        /// </summary>
        public static MassFlow FromGramsPerSecond(double gramspersecond)
        {
            return new MassFlow(gramspersecond);
        }

        /// <summary>
        ///     Get MassFlow from HectogramsPerSecond.
        /// </summary>
        public static MassFlow FromHectogramsPerSecond(double hectogramspersecond)
        {
            return new MassFlow((hectogramspersecond) * 1e2d);
        }

        /// <summary>
        ///     Get MassFlow from KilogramsPerSecond.
        /// </summary>
        public static MassFlow FromKilogramsPerSecond(double kilogramspersecond)
        {
            return new MassFlow((kilogramspersecond) * 1e3d);
        }

        /// <summary>
        ///     Get MassFlow from MicrogramsPerSecond.
        /// </summary>
        public static MassFlow FromMicrogramsPerSecond(double microgramspersecond)
        {
            return new MassFlow((microgramspersecond) * 1e-6d);
        }

        /// <summary>
        ///     Get MassFlow from MilligramsPerSecond.
        /// </summary>
        public static MassFlow FromMilligramsPerSecond(double milligramspersecond)
        {
            return new MassFlow((milligramspersecond) * 1e-3d);
        }

        /// <summary>
        ///     Get MassFlow from NanogramsPerSecond.
        /// </summary>
        public static MassFlow FromNanogramsPerSecond(double nanogramspersecond)
        {
            return new MassFlow((nanogramspersecond) * 1e-9d);
        }

        /// <summary>
        ///     Get MassFlow from TonnesPerDay.
        /// </summary>
        public static MassFlow FromTonnesPerDay(double tonnesperday)
        {
            return new MassFlow(tonnesperday/0.0864000);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable MassFlow from nullable CentigramsPerSecond.
        /// </summary>
        public static MassFlow? FromCentigramsPerSecond(double? centigramspersecond)
        {
            if (centigramspersecond.HasValue)
            {
                return FromCentigramsPerSecond(centigramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable DecagramsPerSecond.
        /// </summary>
        public static MassFlow? FromDecagramsPerSecond(double? decagramspersecond)
        {
            if (decagramspersecond.HasValue)
            {
                return FromDecagramsPerSecond(decagramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable DecigramsPerSecond.
        /// </summary>
        public static MassFlow? FromDecigramsPerSecond(double? decigramspersecond)
        {
            if (decigramspersecond.HasValue)
            {
                return FromDecigramsPerSecond(decigramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable GramsPerSecond.
        /// </summary>
        public static MassFlow? FromGramsPerSecond(double? gramspersecond)
        {
            if (gramspersecond.HasValue)
            {
                return FromGramsPerSecond(gramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable HectogramsPerSecond.
        /// </summary>
        public static MassFlow? FromHectogramsPerSecond(double? hectogramspersecond)
        {
            if (hectogramspersecond.HasValue)
            {
                return FromHectogramsPerSecond(hectogramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable KilogramsPerSecond.
        /// </summary>
        public static MassFlow? FromKilogramsPerSecond(double? kilogramspersecond)
        {
            if (kilogramspersecond.HasValue)
            {
                return FromKilogramsPerSecond(kilogramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable MicrogramsPerSecond.
        /// </summary>
        public static MassFlow? FromMicrogramsPerSecond(double? microgramspersecond)
        {
            if (microgramspersecond.HasValue)
            {
                return FromMicrogramsPerSecond(microgramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable MilligramsPerSecond.
        /// </summary>
        public static MassFlow? FromMilligramsPerSecond(double? milligramspersecond)
        {
            if (milligramspersecond.HasValue)
            {
                return FromMilligramsPerSecond(milligramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable NanogramsPerSecond.
        /// </summary>
        public static MassFlow? FromNanogramsPerSecond(double? nanogramspersecond)
        {
            if (nanogramspersecond.HasValue)
            {
                return FromNanogramsPerSecond(nanogramspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable MassFlow from nullable TonnesPerDay.
        /// </summary>
        public static MassFlow? FromTonnesPerDay(double? tonnesperday)
        {
            if (tonnesperday.HasValue)
            {
                return FromTonnesPerDay(tonnesperday.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MassFlowUnit" /> to <see cref="MassFlow" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>MassFlow unit value.</returns>
        public static MassFlow From(double val, MassFlowUnit fromUnit)
        {
            switch (fromUnit)
            {
                case MassFlowUnit.CentigramPerSecond:
                    return FromCentigramsPerSecond(val);
                case MassFlowUnit.DecagramPerSecond:
                    return FromDecagramsPerSecond(val);
                case MassFlowUnit.DecigramPerSecond:
                    return FromDecigramsPerSecond(val);
                case MassFlowUnit.GramPerSecond:
                    return FromGramsPerSecond(val);
                case MassFlowUnit.HectogramPerSecond:
                    return FromHectogramsPerSecond(val);
                case MassFlowUnit.KilogramPerSecond:
                    return FromKilogramsPerSecond(val);
                case MassFlowUnit.MicrogramPerSecond:
                    return FromMicrogramsPerSecond(val);
                case MassFlowUnit.MilligramPerSecond:
                    return FromMilligramsPerSecond(val);
                case MassFlowUnit.NanogramPerSecond:
                    return FromNanogramsPerSecond(val);
                case MassFlowUnit.TonnePerDay:
                    return FromTonnesPerDay(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MassFlowUnit" /> to <see cref="MassFlow" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>MassFlow unit value.</returns>
        public static MassFlow? From(double? value, MassFlowUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case MassFlowUnit.CentigramPerSecond:
                    return FromCentigramsPerSecond(value.Value);
                case MassFlowUnit.DecagramPerSecond:
                    return FromDecagramsPerSecond(value.Value);
                case MassFlowUnit.DecigramPerSecond:
                    return FromDecigramsPerSecond(value.Value);
                case MassFlowUnit.GramPerSecond:
                    return FromGramsPerSecond(value.Value);
                case MassFlowUnit.HectogramPerSecond:
                    return FromHectogramsPerSecond(value.Value);
                case MassFlowUnit.KilogramPerSecond:
                    return FromKilogramsPerSecond(value.Value);
                case MassFlowUnit.MicrogramPerSecond:
                    return FromMicrogramsPerSecond(value.Value);
                case MassFlowUnit.MilligramPerSecond:
                    return FromMilligramsPerSecond(value.Value);
                case MassFlowUnit.NanogramPerSecond:
                    return FromNanogramsPerSecond(value.Value);
                case MassFlowUnit.TonnePerDay:
                    return FromTonnesPerDay(value.Value);

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
        public static string GetAbbreviation(MassFlowUnit unit)
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
        public static string GetAbbreviation(MassFlowUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static MassFlow operator -(MassFlow right)
        {
            return new MassFlow(-right._gramsPerSecond);
        }

        public static MassFlow operator +(MassFlow left, MassFlow right)
        {
            return new MassFlow(left._gramsPerSecond + right._gramsPerSecond);
        }

        public static MassFlow operator -(MassFlow left, MassFlow right)
        {
            return new MassFlow(left._gramsPerSecond - right._gramsPerSecond);
        }

        public static MassFlow operator *(double left, MassFlow right)
        {
            return new MassFlow(left*right._gramsPerSecond);
        }

        public static MassFlow operator *(MassFlow left, double right)
        {
            return new MassFlow(left._gramsPerSecond*(double)right);
        }

        public static MassFlow operator /(MassFlow left, double right)
        {
            return new MassFlow(left._gramsPerSecond/(double)right);
        }

        public static double operator /(MassFlow left, MassFlow right)
        {
            return Convert.ToDouble(left._gramsPerSecond/right._gramsPerSecond);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is MassFlow)) throw new ArgumentException("Expected type MassFlow.", "obj");
            return CompareTo((MassFlow) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(MassFlow other)
        {
            return _gramsPerSecond.CompareTo(other._gramsPerSecond);
        }

#if !WINDOWS_UWP
        public static bool operator <=(MassFlow left, MassFlow right)
        {
            return left._gramsPerSecond <= right._gramsPerSecond;
        }

        public static bool operator >=(MassFlow left, MassFlow right)
        {
            return left._gramsPerSecond >= right._gramsPerSecond;
        }

        public static bool operator <(MassFlow left, MassFlow right)
        {
            return left._gramsPerSecond < right._gramsPerSecond;
        }

        public static bool operator >(MassFlow left, MassFlow right)
        {
            return left._gramsPerSecond > right._gramsPerSecond;
        }

        public static bool operator ==(MassFlow left, MassFlow right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._gramsPerSecond == right._gramsPerSecond;
        }

        public static bool operator !=(MassFlow left, MassFlow right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._gramsPerSecond != right._gramsPerSecond;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _gramsPerSecond.Equals(((MassFlow) obj)._gramsPerSecond);
        }

        public override int GetHashCode()
        {
            return _gramsPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(MassFlowUnit unit)
        {
            switch (unit)
            {
                case MassFlowUnit.CentigramPerSecond:
                    return CentigramsPerSecond;
                case MassFlowUnit.DecagramPerSecond:
                    return DecagramsPerSecond;
                case MassFlowUnit.DecigramPerSecond:
                    return DecigramsPerSecond;
                case MassFlowUnit.GramPerSecond:
                    return GramsPerSecond;
                case MassFlowUnit.HectogramPerSecond:
                    return HectogramsPerSecond;
                case MassFlowUnit.KilogramPerSecond:
                    return KilogramsPerSecond;
                case MassFlowUnit.MicrogramPerSecond:
                    return MicrogramsPerSecond;
                case MassFlowUnit.MilligramPerSecond:
                    return MilligramsPerSecond;
                case MassFlowUnit.NanogramPerSecond:
                    return NanogramsPerSecond;
                case MassFlowUnit.TonnePerDay:
                    return TonnesPerDay;

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
        public static MassFlow Parse(string str)
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
        public static MassFlow Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => MassFlow.FromGramsPerSecond(x.GramsPerSecond + y.GramsPerSecond));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<MassFlow> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<MassFlow>();

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
                    MassFlowUnit unit = ParseUnit(unitString, formatProvider);
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
        public static MassFlowUnit ParseUnit(string str)
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
        public static MassFlowUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static MassFlowUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<MassFlowUnit>(str.Trim());

            if (unit == MassFlowUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized MassFlowUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is GramPerSecond
        /// </summary>
        public static MassFlowUnit ToStringDefaultUnit { get; set; } = MassFlowUnit.GramPerSecond;

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
        public string ToString(MassFlowUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(MassFlowUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(MassFlowUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(MassFlowUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
