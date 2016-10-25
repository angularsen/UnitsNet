// Copyright Â© 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
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
    ///     A sinusoidally time-varying representation of ElectricPotential.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class AcPotential
#else
    public partial struct AcPotential : IComparable, IComparable<AcPotential>
#endif
    {
        /// <summary>
        ///     Base unit of AcPotential.
        /// </summary>
        private readonly double _voltsPeak;

#if WINDOWS_UWP
        public AcPotential() : this(0)
        {
        }
#endif

        public AcPotential(double voltsPeak)
        {
          _voltsPeak = Math.Abs(Convert.ToDouble(voltsPeak));
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        AcPotential(long voltsPeak)
        {
          this._voltsPeak = Math.Abs(Convert.ToDouble(voltsPeak));
        }


      // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        AcPotential(decimal voltsPeak)
        {
          _voltsPeak = Math.Abs(Convert.ToDouble(voltsPeak));
        }

        #region Properties

        public static AcPotentialUnit BaseUnit
        {
            get { return AcPotentialUnit.VoltPeak; }
        }

        /// <summary>
        ///     Get peak value of AcPotential.
        /// </summary>
        public double VoltsPeak
        {
            get { return _voltsPeak; }
        }

        /// <summary>
        ///     Get peak to peak value of AcPotential.
        /// </summary>
        public double VoltsPeakToPeak
        {
            get { return 2*_voltsPeak; }
        }

        /// <summary>
        ///     Get RMS value of AcPotential.
        /// </summary>
        public double VoltsRMS
        {
            get { return _voltsPeak/Math.Sqrt(2); }
        }

        #endregion

        #region Static

        public static AcPotential Zero
        {
            get { return new AcPotential(); }
        }

        /// <summary>
        ///     Get AcPotential from VoltsPeak.
        /// </summary>
        public static AcPotential FromVoltsPeak(double voltsPeak)
        {
            return new AcPotential(voltsPeak);
        }

        /// <summary>
        ///     Get AcPotential from VoltsPeakToPeak.
        /// </summary>
        public static AcPotential FromVoltsPeakToPeak(double voltspeaktopeak)
        {
            return new AcPotential(voltspeaktopeak/2);
        }

        /// <summary>
        ///     Get AcPotential from VoltsRMS.
        /// </summary>
        public static AcPotential FromVoltsRMS(double voltsrms)
        {
            return new AcPotential(Math.Sqrt(2)*voltsrms);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable AcPotential from nullable VoltsPeak.
        /// </summary>
        public static AcPotential? FromVoltsPeak(double? voltsPeak)
        {
            if (voltsPeak.HasValue)
            {
                return FromVoltsPeak(voltsPeak.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable AcPotential from nullable VoltsPeakToPeak.
        /// </summary>
        public static AcPotential? FromVoltsPeakToPeak(double? voltspeaktopeak)
        {
            if (voltspeaktopeak.HasValue)
            {
                return FromVoltsPeakToPeak(voltspeaktopeak.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable AcPotential from nullable VoltsRMS.
        /// </summary>
        public static AcPotential? FromVoltsRMS(double? voltsrms)
        {
            if (voltsrms.HasValue)
            {
                return FromVoltsRMS(voltsrms.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AcPotentialUnit" /> to <see cref="AcPotential" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>AcPotential unit value.</returns>
        public static AcPotential From(double val, AcPotentialUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AcPotentialUnit.VoltPeak:
                    return FromVoltsPeak(val);
                case AcPotentialUnit.VoltPeakToPeak:
                    return FromVoltsPeakToPeak(val);
                case AcPotentialUnit.VoltRMS:
                    return FromVoltsRMS(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AcPotentialUnit" /> to <see cref="AcPotential" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>AcPotential unit value.</returns>
        public static AcPotential? From(double? value, AcPotentialUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case AcPotentialUnit.VoltPeak:
                    return FromVoltsPeak(value.Value);
                case AcPotentialUnit.VoltPeakToPeak:
                    return FromVoltsPeakToPeak(value.Value);
                case AcPotentialUnit.VoltRMS:
                    return FromVoltsRMS(value.Value);

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
        public static string GetAbbreviation(AcPotentialUnit unit)
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
        public static string GetAbbreviation(AcPotentialUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static AcPotential operator -(AcPotential right)
        {
            return new AcPotential(-right._voltsPeak);
        }

        public static AcPotential operator +(AcPotential left, AcPotential right)
        {
            return new AcPotential(left._voltsPeak + right._voltsPeak);
        }

        public static AcPotential operator -(AcPotential left, AcPotential right)
        {
            return new AcPotential(left._voltsPeak - right._voltsPeak);
        }

        public static AcPotential operator *(double left, AcPotential right)
        {
            return new AcPotential(left*right._voltsPeak);
        }

        public static AcPotential operator *(AcPotential left, double right)
        {
            return new AcPotential(left._voltsPeak*(double)right);
        }

        public static AcPotential operator /(AcPotential left, double right)
        {
            return new AcPotential(left._voltsPeak/(double)right);
        }

        public static double operator /(AcPotential left, AcPotential right)
        {
            return Convert.ToDouble(left._voltsPeak/right._voltsPeak);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is AcPotential)) throw new ArgumentException("Expected type AcPotential.", "obj");
            return CompareTo((AcPotential) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(AcPotential other)
        {
            return _voltsPeak.CompareTo(other._voltsPeak);
        }

#if !WINDOWS_UWP
        public static bool operator <=(AcPotential left, AcPotential right)
        {
            return left._voltsPeak <= right._voltsPeak;
        }

        public static bool operator >=(AcPotential left, AcPotential right)
        {
            return left._voltsPeak >= right._voltsPeak;
        }

        public static bool operator <(AcPotential left, AcPotential right)
        {
            return left._voltsPeak < right._voltsPeak;
        }

        public static bool operator >(AcPotential left, AcPotential right)
        {
            return left._voltsPeak > right._voltsPeak;
        }

        public static bool operator ==(AcPotential left, AcPotential right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._voltsPeak == right._voltsPeak;
        }

        public static bool operator !=(AcPotential left, AcPotential right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._voltsPeak != right._voltsPeak;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _voltsPeak.Equals(((AcPotential) obj)._voltsPeak);
        }

        public override int GetHashCode()
        {
            return _voltsPeak.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AcPotentialUnit unit)
        {
            switch (unit)
            {
                case AcPotentialUnit.VoltPeak:
                    return VoltsPeak;
                case AcPotentialUnit.VoltPeakToPeak:
                    return VoltsPeakToPeak;
                case AcPotentialUnit.VoltRMS:
                    return VoltsRMS;

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
        public static AcPotential Parse(string str)
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
        public static AcPotential Parse(string str, [CanBeNull] Culture culture)
        {
            if (str == null) throw new ArgumentNullException("str");

#if WINDOWS_UWP
            IFormatProvider formatProvider = culture == null ? null : new CultureInfo(culture);
#else
            IFormatProvider formatProvider = culture;
#endif
            return UnitParser.ParseUnit<AcPotential>(str, formatProvider,
                delegate(string value, string unit, IFormatProvider formatProvider2)
                {
                    double parsedValue = double.Parse(value, formatProvider2);
                    AcPotentialUnit parsedUnit = ParseUnit(unit, formatProvider2);
                    return From(parsedValue, parsedUnit);
                }, (x, y) => FromVoltsPeak(x.VoltsPeak + y.VoltsPeak));
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse([CanBeNull] string str, out AcPotential result)
        {
            return TryParse(str, null, out result);
        }

        /// <summary>
        ///     Try to parse a string with one or two quantities of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <param name="str">String to parse. Typically in the form: {number} {unit}</param>
        /// <param name="culture">Format to use when parsing number and unit. If it is null, it defaults to <see cref="NumberFormatInfo.CurrentInfo"/> for parsing the number and <see cref="CultureInfo.CurrentUICulture"/> for parsing the unit abbreviation by culture/language.</param>
        /// <param name="result">Resulting unit quantity if successful.</param>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        public static bool TryParse([CanBeNull] string str, [CanBeNull] Culture culture, out AcPotential result)
        {
            try
            {
                result = Parse(str, culture);
                return true;
            }
            catch
            {
                result = default(AcPotential);
                return false;
            }
        }

        /// <summary>
        ///     Parse a unit string.
        /// </summary>
        /// <example>
        ///     Length.ParseUnit("m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static AcPotentialUnit ParseUnit(string str)
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
        public static AcPotentialUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static AcPotentialUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<AcPotentialUnit>(str.Trim());

            if (unit == AcPotentialUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized AcPotentialUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is VoltPeak
        /// </summary>
        public static AcPotentialUnit ToStringDefaultUnit { get; set; } = AcPotentialUnit.VoltPeak;

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
        public string ToString(AcPotentialUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(AcPotentialUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(AcPotentialUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(AcPotentialUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of AcPotential
        /// </summary>
        public static AcPotential MaxValue
        {
            get
            {
                return new AcPotential(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of AcPotential
        /// </summary>
        public static AcPotential MinValue
        {
            get
            {
                return new AcPotential(double.MinValue);
            }
        }
    }
}
