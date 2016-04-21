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
    ///     Temperature change rate is the ratio of the temperature change to the time during which the change occurred (value of temperature changes per unit time).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class TemperatureChangeRate
#else
    public partial struct TemperatureChangeRate : IComparable, IComparable<TemperatureChangeRate>
#endif
    {
        /// <summary>
        ///     Base unit of TemperatureChangeRate.
        /// </summary>
        private readonly double _degreesCelsiusPerSecond;

#if WINDOWS_UWP
        public TemperatureChangeRate() : this(0)
        {
        }
#endif

        public TemperatureChangeRate(double degreescelsiuspersecond)
        {
            _degreesCelsiusPerSecond = Convert.ToDouble(degreescelsiuspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        TemperatureChangeRate(long degreescelsiuspersecond)
        {
            _degreesCelsiusPerSecond = Convert.ToDouble(degreescelsiuspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        TemperatureChangeRate(decimal degreescelsiuspersecond)
        {
            _degreesCelsiusPerSecond = Convert.ToDouble(degreescelsiuspersecond);
        }

        #region Properties

        public static TemperatureChangeRateUnit BaseUnit
        {
            get { return TemperatureChangeRateUnit.DegreeCelsiusPerSecond; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in CentidegreesCelsiusPerSecond.
        /// </summary>
        public double CentidegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-2d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in DecadegreesCelsiusPerSecond.
        /// </summary>
        public double DecadegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e1d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in DecidegreesCelsiusPerSecond.
        /// </summary>
        public double DecidegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-1d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in DegreesCelsiusPerSecond.
        /// </summary>
        public double DegreesCelsiusPerSecond
        {
            get { return _degreesCelsiusPerSecond; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in HectodegreesCelsiusPerSecond.
        /// </summary>
        public double HectodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e2d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in KilodegreesCelsiusPerSecond.
        /// </summary>
        public double KilodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e3d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in MicrodegreesCelsiusPerSecond.
        /// </summary>
        public double MicrodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-6d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in MillidegreesCelsiusPerSecond.
        /// </summary>
        public double MillidegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-3d; }
        }

        /// <summary>
        ///     Get TemperatureChangeRate in NanodegreesCelsiusPerSecond.
        /// </summary>
        public double NanodegreesCelsiusPerSecond
        {
            get { return (_degreesCelsiusPerSecond) / 1e-9d; }
        }

        #endregion

        #region Static

        public static TemperatureChangeRate Zero
        {
            get { return new TemperatureChangeRate(); }
        }

        /// <summary>
        ///     Get TemperatureChangeRate from CentidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromCentidegreesCelsiusPerSecond(double centidegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((centidegreescelsiuspersecond) * 1e-2d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from DecadegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromDecadegreesCelsiusPerSecond(double decadegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((decadegreescelsiuspersecond) * 1e1d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from DecidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromDecidegreesCelsiusPerSecond(double decidegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((decidegreescelsiuspersecond) * 1e-1d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from DegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromDegreesCelsiusPerSecond(double degreescelsiuspersecond)
        {
            return new TemperatureChangeRate(degreescelsiuspersecond);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from HectodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromHectodegreesCelsiusPerSecond(double hectodegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((hectodegreescelsiuspersecond) * 1e2d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from KilodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromKilodegreesCelsiusPerSecond(double kilodegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((kilodegreescelsiuspersecond) * 1e3d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from MicrodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromMicrodegreesCelsiusPerSecond(double microdegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((microdegreescelsiuspersecond) * 1e-6d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from MillidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromMillidegreesCelsiusPerSecond(double millidegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((millidegreescelsiuspersecond) * 1e-3d);
        }

        /// <summary>
        ///     Get TemperatureChangeRate from NanodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate FromNanodegreesCelsiusPerSecond(double nanodegreescelsiuspersecond)
        {
            return new TemperatureChangeRate((nanodegreescelsiuspersecond) * 1e-9d);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable CentidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromCentidegreesCelsiusPerSecond(double? centidegreescelsiuspersecond)
        {
            if (centidegreescelsiuspersecond.HasValue)
            {
                return FromCentidegreesCelsiusPerSecond(centidegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable DecadegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromDecadegreesCelsiusPerSecond(double? decadegreescelsiuspersecond)
        {
            if (decadegreescelsiuspersecond.HasValue)
            {
                return FromDecadegreesCelsiusPerSecond(decadegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable DecidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromDecidegreesCelsiusPerSecond(double? decidegreescelsiuspersecond)
        {
            if (decidegreescelsiuspersecond.HasValue)
            {
                return FromDecidegreesCelsiusPerSecond(decidegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable DegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromDegreesCelsiusPerSecond(double? degreescelsiuspersecond)
        {
            if (degreescelsiuspersecond.HasValue)
            {
                return FromDegreesCelsiusPerSecond(degreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable HectodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromHectodegreesCelsiusPerSecond(double? hectodegreescelsiuspersecond)
        {
            if (hectodegreescelsiuspersecond.HasValue)
            {
                return FromHectodegreesCelsiusPerSecond(hectodegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable KilodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromKilodegreesCelsiusPerSecond(double? kilodegreescelsiuspersecond)
        {
            if (kilodegreescelsiuspersecond.HasValue)
            {
                return FromKilodegreesCelsiusPerSecond(kilodegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable MicrodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromMicrodegreesCelsiusPerSecond(double? microdegreescelsiuspersecond)
        {
            if (microdegreescelsiuspersecond.HasValue)
            {
                return FromMicrodegreesCelsiusPerSecond(microdegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable MillidegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromMillidegreesCelsiusPerSecond(double? millidegreescelsiuspersecond)
        {
            if (millidegreescelsiuspersecond.HasValue)
            {
                return FromMillidegreesCelsiusPerSecond(millidegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable TemperatureChangeRate from nullable NanodegreesCelsiusPerSecond.
        /// </summary>
        public static TemperatureChangeRate? FromNanodegreesCelsiusPerSecond(double? nanodegreescelsiuspersecond)
        {
            if (nanodegreescelsiuspersecond.HasValue)
            {
                return FromNanodegreesCelsiusPerSecond(nanodegreescelsiuspersecond.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureChangeRateUnit" /> to <see cref="TemperatureChangeRate" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>TemperatureChangeRate unit value.</returns>
        public static TemperatureChangeRate From(double val, TemperatureChangeRateUnit fromUnit)
        {
            switch (fromUnit)
            {
                case TemperatureChangeRateUnit.CentidegreeCelsiusPerSecond:
                    return FromCentidegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond:
                    return FromDecadegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.DecidegreeCelsiusPerSecond:
                    return FromDecidegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.DegreeCelsiusPerSecond:
                    return FromDegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.HectodegreeCelsiusPerSecond:
                    return FromHectodegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.KilodegreeCelsiusPerSecond:
                    return FromKilodegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond:
                    return FromMicrodegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.MillidegreeCelsiusPerSecond:
                    return FromMillidegreesCelsiusPerSecond(val);
                case TemperatureChangeRateUnit.NanodegreeCelsiusPerSecond:
                    return FromNanodegreesCelsiusPerSecond(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureChangeRateUnit" /> to <see cref="TemperatureChangeRate" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>TemperatureChangeRate unit value.</returns>
        public static TemperatureChangeRate? From(double? value, TemperatureChangeRateUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case TemperatureChangeRateUnit.CentidegreeCelsiusPerSecond:
                    return FromCentidegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond:
                    return FromDecadegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.DecidegreeCelsiusPerSecond:
                    return FromDecidegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.DegreeCelsiusPerSecond:
                    return FromDegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.HectodegreeCelsiusPerSecond:
                    return FromHectodegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.KilodegreeCelsiusPerSecond:
                    return FromKilodegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond:
                    return FromMicrodegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.MillidegreeCelsiusPerSecond:
                    return FromMillidegreesCelsiusPerSecond(value.Value);
                case TemperatureChangeRateUnit.NanodegreeCelsiusPerSecond:
                    return FromNanodegreesCelsiusPerSecond(value.Value);

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
        public static string GetAbbreviation(TemperatureChangeRateUnit unit)
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
        public static string GetAbbreviation(TemperatureChangeRateUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static TemperatureChangeRate operator -(TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(-right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator +(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond + right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator -(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond - right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator *(double left, TemperatureChangeRate right)
        {
            return new TemperatureChangeRate(left*right._degreesCelsiusPerSecond);
        }

        public static TemperatureChangeRate operator *(TemperatureChangeRate left, double right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond*(double)right);
        }

        public static TemperatureChangeRate operator /(TemperatureChangeRate left, double right)
        {
            return new TemperatureChangeRate(left._degreesCelsiusPerSecond/(double)right);
        }

        public static double operator /(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return Convert.ToDouble(left._degreesCelsiusPerSecond/right._degreesCelsiusPerSecond);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is TemperatureChangeRate)) throw new ArgumentException("Expected type TemperatureChangeRate.", "obj");
            return CompareTo((TemperatureChangeRate) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(TemperatureChangeRate other)
        {
            return _degreesCelsiusPerSecond.CompareTo(other._degreesCelsiusPerSecond);
        }

#if !WINDOWS_UWP
        public static bool operator <=(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond <= right._degreesCelsiusPerSecond;
        }

        public static bool operator >=(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond >= right._degreesCelsiusPerSecond;
        }

        public static bool operator <(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond < right._degreesCelsiusPerSecond;
        }

        public static bool operator >(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            return left._degreesCelsiusPerSecond > right._degreesCelsiusPerSecond;
        }

        public static bool operator ==(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degreesCelsiusPerSecond == right._degreesCelsiusPerSecond;
        }

        public static bool operator !=(TemperatureChangeRate left, TemperatureChangeRate right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._degreesCelsiusPerSecond != right._degreesCelsiusPerSecond;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _degreesCelsiusPerSecond.Equals(((TemperatureChangeRate) obj)._degreesCelsiusPerSecond);
        }

        public override int GetHashCode()
        {
            return _degreesCelsiusPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(TemperatureChangeRateUnit unit)
        {
            switch (unit)
            {
                case TemperatureChangeRateUnit.CentidegreeCelsiusPerSecond:
                    return CentidegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond:
                    return DecadegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.DecidegreeCelsiusPerSecond:
                    return DecidegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.DegreeCelsiusPerSecond:
                    return DegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.HectodegreeCelsiusPerSecond:
                    return HectodegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.KilodegreeCelsiusPerSecond:
                    return KilodegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond:
                    return MicrodegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.MillidegreeCelsiusPerSecond:
                    return MillidegreesCelsiusPerSecond;
                case TemperatureChangeRateUnit.NanodegreeCelsiusPerSecond:
                    return NanodegreesCelsiusPerSecond;

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
        public static TemperatureChangeRate Parse(string str)
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
        public static TemperatureChangeRate Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => TemperatureChangeRate.FromDegreesCelsiusPerSecond(x.DegreesCelsiusPerSecond + y.DegreesCelsiusPerSecond));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<TemperatureChangeRate> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<TemperatureChangeRate>();

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
                    TemperatureChangeRateUnit unit = ParseUnit(unitString, formatProvider);
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
        public static TemperatureChangeRateUnit ParseUnit(string str)
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
        public static TemperatureChangeRateUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static TemperatureChangeRateUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<TemperatureChangeRateUnit>(str.Trim());

            if (unit == TemperatureChangeRateUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized TemperatureChangeRateUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is DegreeCelsiusPerSecond
        /// </summary>
        public static TemperatureChangeRateUnit ToStringDefaultUnit { get; set; } = TemperatureChangeRateUnit.DegreeCelsiusPerSecond;

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
        public string ToString(TemperatureChangeRateUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(TemperatureChangeRateUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(TemperatureChangeRateUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(TemperatureChangeRateUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of TemperatureChangeRate
        /// </summary>
        public static TemperatureChangeRate MaxValue
        {
            get
            {
                return new TemperatureChangeRate(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of TemperatureChangeRate
        /// </summary>
        public static TemperatureChangeRate MinValue
        {
            get
            {
                return new TemperatureChangeRate(double.MinValue);
            }
        }
    }
}
