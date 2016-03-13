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
    ///     The density, or more precisely, the volumetric mass density, of a substance is its mass per unit volume.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Density
#else
    public partial struct Density : IComparable, IComparable<Density>
#endif
    {
        /// <summary>
        ///     Base unit of Density.
        /// </summary>
        private readonly double _kilogramsPerCubicMeter;

#if WINDOWS_UWP
        public Density() : this(0)
        {
        }
#endif

        public Density(double kilogramspercubicmeter)
        {
            _kilogramsPerCubicMeter = Convert.ToDouble(kilogramspercubicmeter);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Density(long kilogramspercubicmeter)
        {
            _kilogramsPerCubicMeter = Convert.ToDouble(kilogramspercubicmeter);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Density(decimal kilogramspercubicmeter)
        {
            _kilogramsPerCubicMeter = Convert.ToDouble(kilogramspercubicmeter);
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

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Density from nullable KilogramsPerCubicCentimeter.
        /// </summary>
        public static Density? FromKilogramsPerCubicCentimeter(double? kilogramspercubiccentimeter)
        {
            if (kilogramspercubiccentimeter.HasValue)
            {
                return FromKilogramsPerCubicCentimeter(kilogramspercubiccentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable KilogramsPerCubicMeter.
        /// </summary>
        public static Density? FromKilogramsPerCubicMeter(double? kilogramspercubicmeter)
        {
            if (kilogramspercubicmeter.HasValue)
            {
                return FromKilogramsPerCubicMeter(kilogramspercubicmeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable KilogramsPerCubicMillimeter.
        /// </summary>
        public static Density? FromKilogramsPerCubicMillimeter(double? kilogramspercubicmillimeter)
        {
            if (kilogramspercubicmillimeter.HasValue)
            {
                return FromKilogramsPerCubicMillimeter(kilogramspercubicmillimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable KilopoundsPerCubicFoot.
        /// </summary>
        public static Density? FromKilopoundsPerCubicFoot(double? kilopoundspercubicfoot)
        {
            if (kilopoundspercubicfoot.HasValue)
            {
                return FromKilopoundsPerCubicFoot(kilopoundspercubicfoot.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable KilopoundsPerCubicInch.
        /// </summary>
        public static Density? FromKilopoundsPerCubicInch(double? kilopoundspercubicinch)
        {
            if (kilopoundspercubicinch.HasValue)
            {
                return FromKilopoundsPerCubicInch(kilopoundspercubicinch.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable PoundsPerCubicFoot.
        /// </summary>
        public static Density? FromPoundsPerCubicFoot(double? poundspercubicfoot)
        {
            if (poundspercubicfoot.HasValue)
            {
                return FromPoundsPerCubicFoot(poundspercubicfoot.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable PoundsPerCubicInch.
        /// </summary>
        public static Density? FromPoundsPerCubicInch(double? poundspercubicinch)
        {
            if (poundspercubicinch.HasValue)
            {
                return FromPoundsPerCubicInch(poundspercubicinch.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable TonnesPerCubicCentimeter.
        /// </summary>
        public static Density? FromTonnesPerCubicCentimeter(double? tonnespercubiccentimeter)
        {
            if (tonnespercubiccentimeter.HasValue)
            {
                return FromTonnesPerCubicCentimeter(tonnespercubiccentimeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable TonnesPerCubicMeter.
        /// </summary>
        public static Density? FromTonnesPerCubicMeter(double? tonnespercubicmeter)
        {
            if (tonnespercubicmeter.HasValue)
            {
                return FromTonnesPerCubicMeter(tonnespercubicmeter.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Density from nullable TonnesPerCubicMillimeter.
        /// </summary>
        public static Density? FromTonnesPerCubicMillimeter(double? tonnespercubicmillimeter)
        {
            if (tonnespercubicmillimeter.HasValue)
            {
                return FromTonnesPerCubicMillimeter(tonnespercubicmillimeter.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DensityUnit" /> to <see cref="Density" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Density unit value.</returns>
        public static Density From(double val, DensityUnit fromUnit)
        {
            switch (fromUnit)
            {
                case DensityUnit.KilogramPerCubicCentimeter:
                    return FromKilogramsPerCubicCentimeter(val);
                case DensityUnit.KilogramPerCubicMeter:
                    return FromKilogramsPerCubicMeter(val);
                case DensityUnit.KilogramPerCubicMillimeter:
                    return FromKilogramsPerCubicMillimeter(val);
                case DensityUnit.KilopoundPerCubicFoot:
                    return FromKilopoundsPerCubicFoot(val);
                case DensityUnit.KilopoundPerCubicInch:
                    return FromKilopoundsPerCubicInch(val);
                case DensityUnit.PoundPerCubicFoot:
                    return FromPoundsPerCubicFoot(val);
                case DensityUnit.PoundPerCubicInch:
                    return FromPoundsPerCubicInch(val);
                case DensityUnit.TonnePerCubicCentimeter:
                    return FromTonnesPerCubicCentimeter(val);
                case DensityUnit.TonnePerCubicMeter:
                    return FromTonnesPerCubicMeter(val);
                case DensityUnit.TonnePerCubicMillimeter:
                    return FromTonnesPerCubicMillimeter(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="DensityUnit" /> to <see cref="Density" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Density unit value.</returns>
        public static Density? From(double? value, DensityUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case DensityUnit.KilogramPerCubicCentimeter:
                    return FromKilogramsPerCubicCentimeter(value.Value);
                case DensityUnit.KilogramPerCubicMeter:
                    return FromKilogramsPerCubicMeter(value.Value);
                case DensityUnit.KilogramPerCubicMillimeter:
                    return FromKilogramsPerCubicMillimeter(value.Value);
                case DensityUnit.KilopoundPerCubicFoot:
                    return FromKilopoundsPerCubicFoot(value.Value);
                case DensityUnit.KilopoundPerCubicInch:
                    return FromKilopoundsPerCubicInch(value.Value);
                case DensityUnit.PoundPerCubicFoot:
                    return FromPoundsPerCubicFoot(value.Value);
                case DensityUnit.PoundPerCubicInch:
                    return FromPoundsPerCubicInch(value.Value);
                case DensityUnit.TonnePerCubicCentimeter:
                    return FromTonnesPerCubicCentimeter(value.Value);
                case DensityUnit.TonnePerCubicMeter:
                    return FromTonnesPerCubicMeter(value.Value);
                case DensityUnit.TonnePerCubicMillimeter:
                    return FromTonnesPerCubicMillimeter(value.Value);

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
        public static string GetAbbreviation(DensityUnit unit)
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
        public static string GetAbbreviation(DensityUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Density)) throw new ArgumentException("Expected type Density.", "obj");
            return CompareTo((Density) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Density other)
        {
            return _kilogramsPerCubicMeter.CompareTo(other._kilogramsPerCubicMeter);
        }

#if !WINDOWS_UWP
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
#endif

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
        public static Density Parse(string str)
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
        public static Density Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Density.FromKilogramsPerCubicMeter(x.KilogramsPerCubicMeter + y.KilogramsPerCubicMeter));
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
        public static DensityUnit ParseUnit(string str)
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
        public static DensityUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static DensityUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<DensityUnit>(str.Trim());

            if (unit == DensityUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized DensityUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
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
        ///     Get string representation of value and unit. Using current UI culture and two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(DensityUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(DensityUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(DensityUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(DensityUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
