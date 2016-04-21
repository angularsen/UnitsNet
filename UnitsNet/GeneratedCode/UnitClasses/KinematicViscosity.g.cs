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
    ///     The viscosity of a fluid is a measure of its resistance to gradual deformation by shear stress or tensile stress.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class KinematicViscosity
#else
    public partial struct KinematicViscosity : IComparable, IComparable<KinematicViscosity>
#endif
    {
        /// <summary>
        ///     Base unit of KinematicViscosity.
        /// </summary>
        private readonly double _squareMetersPerSecond;

#if WINDOWS_UWP
        public KinematicViscosity() : this(0)
        {
        }
#endif

        public KinematicViscosity(double squaremeterspersecond)
        {
            _squareMetersPerSecond = Convert.ToDouble(squaremeterspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        KinematicViscosity(long squaremeterspersecond)
        {
            _squareMetersPerSecond = Convert.ToDouble(squaremeterspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        KinematicViscosity(decimal squaremeterspersecond)
        {
            _squareMetersPerSecond = Convert.ToDouble(squaremeterspersecond);
        }

        #region Properties

        public static KinematicViscosityUnit BaseUnit
        {
            get { return KinematicViscosityUnit.SquareMeterPerSecond; }
        }

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

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable KinematicViscosity from nullable Centistokes.
        /// </summary>
        public static KinematicViscosity? FromCentistokes(double? centistokes)
        {
            if (centistokes.HasValue)
            {
                return FromCentistokes(centistokes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable KinematicViscosity from nullable Decistokes.
        /// </summary>
        public static KinematicViscosity? FromDecistokes(double? decistokes)
        {
            if (decistokes.HasValue)
            {
                return FromDecistokes(decistokes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable KinematicViscosity from nullable Kilostokes.
        /// </summary>
        public static KinematicViscosity? FromKilostokes(double? kilostokes)
        {
            if (kilostokes.HasValue)
            {
                return FromKilostokes(kilostokes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable KinematicViscosity from nullable Microstokes.
        /// </summary>
        public static KinematicViscosity? FromMicrostokes(double? microstokes)
        {
            if (microstokes.HasValue)
            {
                return FromMicrostokes(microstokes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable KinematicViscosity from nullable Millistokes.
        /// </summary>
        public static KinematicViscosity? FromMillistokes(double? millistokes)
        {
            if (millistokes.HasValue)
            {
                return FromMillistokes(millistokes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable KinematicViscosity from nullable Nanostokes.
        /// </summary>
        public static KinematicViscosity? FromNanostokes(double? nanostokes)
        {
            if (nanostokes.HasValue)
            {
                return FromNanostokes(nanostokes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable KinematicViscosity from nullable SquareMetersPerSecond.
        /// </summary>
        public static KinematicViscosity? FromSquareMetersPerSecond(double? squaremeterspersecond)
        {
            if (squaremeterspersecond.HasValue)
            {
                return FromSquareMetersPerSecond(squaremeterspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable KinematicViscosity from nullable Stokes.
        /// </summary>
        public static KinematicViscosity? FromStokes(double? stokes)
        {
            if (stokes.HasValue)
            {
                return FromStokes(stokes.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="KinematicViscosityUnit" /> to <see cref="KinematicViscosity" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>KinematicViscosity unit value.</returns>
        public static KinematicViscosity From(double val, KinematicViscosityUnit fromUnit)
        {
            switch (fromUnit)
            {
                case KinematicViscosityUnit.Centistokes:
                    return FromCentistokes(val);
                case KinematicViscosityUnit.Decistokes:
                    return FromDecistokes(val);
                case KinematicViscosityUnit.Kilostokes:
                    return FromKilostokes(val);
                case KinematicViscosityUnit.Microstokes:
                    return FromMicrostokes(val);
                case KinematicViscosityUnit.Millistokes:
                    return FromMillistokes(val);
                case KinematicViscosityUnit.Nanostokes:
                    return FromNanostokes(val);
                case KinematicViscosityUnit.SquareMeterPerSecond:
                    return FromSquareMetersPerSecond(val);
                case KinematicViscosityUnit.Stokes:
                    return FromStokes(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="KinematicViscosityUnit" /> to <see cref="KinematicViscosity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>KinematicViscosity unit value.</returns>
        public static KinematicViscosity? From(double? value, KinematicViscosityUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case KinematicViscosityUnit.Centistokes:
                    return FromCentistokes(value.Value);
                case KinematicViscosityUnit.Decistokes:
                    return FromDecistokes(value.Value);
                case KinematicViscosityUnit.Kilostokes:
                    return FromKilostokes(value.Value);
                case KinematicViscosityUnit.Microstokes:
                    return FromMicrostokes(value.Value);
                case KinematicViscosityUnit.Millistokes:
                    return FromMillistokes(value.Value);
                case KinematicViscosityUnit.Nanostokes:
                    return FromNanostokes(value.Value);
                case KinematicViscosityUnit.SquareMeterPerSecond:
                    return FromSquareMetersPerSecond(value.Value);
                case KinematicViscosityUnit.Stokes:
                    return FromStokes(value.Value);

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
        public static string GetAbbreviation(KinematicViscosityUnit unit)
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
        public static string GetAbbreviation(KinematicViscosityUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is KinematicViscosity)) throw new ArgumentException("Expected type KinematicViscosity.", "obj");
            return CompareTo((KinematicViscosity) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(KinematicViscosity other)
        {
            return _squareMetersPerSecond.CompareTo(other._squareMetersPerSecond);
        }

#if !WINDOWS_UWP
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
#endif

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
        public static KinematicViscosity Parse(string str)
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
        public static KinematicViscosity Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => KinematicViscosity.FromSquareMetersPerSecond(x.SquareMetersPerSecond + y.SquareMetersPerSecond));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<KinematicViscosity> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<KinematicViscosity>();

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
                    KinematicViscosityUnit unit = ParseUnit(unitString, formatProvider);
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
        public static KinematicViscosityUnit ParseUnit(string str)
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
        public static KinematicViscosityUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static KinematicViscosityUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<KinematicViscosityUnit>(str.Trim());

            if (unit == KinematicViscosityUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized KinematicViscosityUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is SquareMeterPerSecond
        /// </summary>
        public static KinematicViscosityUnit ToStringDefaultUnit { get; set; } = KinematicViscosityUnit.SquareMeterPerSecond;

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
        public string ToString(KinematicViscosityUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(KinematicViscosityUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(KinematicViscosityUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(KinematicViscosityUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of KinematicViscosity
        /// </summary>
        public static KinematicViscosity MaxValue
        {
            get
            {
                return new KinematicViscosity(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of KinematicViscosity
        /// </summary>
        public static KinematicViscosity MinValue
        {
            get
            {
                return new KinematicViscosity(double.MinValue);
            }
        }
    }
}
