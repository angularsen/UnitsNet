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
    ///     Rotational speed (sometimes called speed of revolution) is the number of complete rotations, revolutions, cycles, or turns per time unit. Rotational speed is a cyclic frequency, measured in radians per second or in hertz in the SI System by scientists, or in revolutions per minute (rpm or min-1) or revolutions per second in everyday life. The symbol for rotational speed is ω (the Greek lowercase letter "omega").
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class RotationalSpeed
#else
    public partial struct RotationalSpeed : IComparable, IComparable<RotationalSpeed>
#endif
    {
        /// <summary>
        ///     Base unit of RotationalSpeed.
        /// </summary>
        private readonly double _radiansPerSecond;

#if WINDOWS_UWP
        public RotationalSpeed() : this(0)
        {
        }
#endif

        public RotationalSpeed(double radianspersecond)
        {
            _radiansPerSecond = Convert.ToDouble(radianspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        RotationalSpeed(long radianspersecond)
        {
            _radiansPerSecond = Convert.ToDouble(radianspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        RotationalSpeed(decimal radianspersecond)
        {
            _radiansPerSecond = Convert.ToDouble(radianspersecond);
        }

        #region Properties

        public static RotationalSpeedUnit BaseUnit
        {
            get { return RotationalSpeedUnit.RadianPerSecond; }
        }

        /// <summary>
        ///     Get RotationalSpeed in CentiradiansPerSecond.
        /// </summary>
        public double CentiradiansPerSecond
        {
            get { return (_radiansPerSecond) / 1e-2d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in DeciradiansPerSecond.
        /// </summary>
        public double DeciradiansPerSecond
        {
            get { return (_radiansPerSecond) / 1e-1d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in DegreesPerMinute.
        /// </summary>
        public double DegreesPerMinute
        {
            get { return (180*60/Math.PI)*_radiansPerSecond; }
        }

        /// <summary>
        ///     Get RotationalSpeed in DegreesPerSecond.
        /// </summary>
        public double DegreesPerSecond
        {
            get { return (180/Math.PI)*_radiansPerSecond; }
        }

        /// <summary>
        ///     Get RotationalSpeed in MicrodegreesPerSecond.
        /// </summary>
        public double MicrodegreesPerSecond
        {
            get { return ((180/Math.PI)*_radiansPerSecond) / 1e-6d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in MicroradiansPerSecond.
        /// </summary>
        public double MicroradiansPerSecond
        {
            get { return (_radiansPerSecond) / 1e-6d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in MillidegreesPerSecond.
        /// </summary>
        public double MillidegreesPerSecond
        {
            get { return ((180/Math.PI)*_radiansPerSecond) / 1e-3d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in MilliradiansPerSecond.
        /// </summary>
        public double MilliradiansPerSecond
        {
            get { return (_radiansPerSecond) / 1e-3d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in NanodegreesPerSecond.
        /// </summary>
        public double NanodegreesPerSecond
        {
            get { return ((180/Math.PI)*_radiansPerSecond) / 1e-9d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in NanoradiansPerSecond.
        /// </summary>
        public double NanoradiansPerSecond
        {
            get { return (_radiansPerSecond) / 1e-9d; }
        }

        /// <summary>
        ///     Get RotationalSpeed in RadiansPerSecond.
        /// </summary>
        public double RadiansPerSecond
        {
            get { return _radiansPerSecond; }
        }

        /// <summary>
        ///     Get RotationalSpeed in RevolutionsPerMinute.
        /// </summary>
        public double RevolutionsPerMinute
        {
            get { return (_radiansPerSecond/6.2831853072)*60; }
        }

        /// <summary>
        ///     Get RotationalSpeed in RevolutionsPerSecond.
        /// </summary>
        public double RevolutionsPerSecond
        {
            get { return _radiansPerSecond/6.2831853072; }
        }

        #endregion

        #region Static

        public static RotationalSpeed Zero
        {
            get { return new RotationalSpeed(); }
        }

        /// <summary>
        ///     Get RotationalSpeed from CentiradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromCentiradiansPerSecond(double centiradianspersecond)
        {
            return new RotationalSpeed((centiradianspersecond) * 1e-2d);
        }

        /// <summary>
        ///     Get RotationalSpeed from DeciradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromDeciradiansPerSecond(double deciradianspersecond)
        {
            return new RotationalSpeed((deciradianspersecond) * 1e-1d);
        }

        /// <summary>
        ///     Get RotationalSpeed from DegreesPerMinute.
        /// </summary>
        public static RotationalSpeed FromDegreesPerMinute(double degreesperminute)
        {
            return new RotationalSpeed((Math.PI/(180*60))*degreesperminute);
        }

        /// <summary>
        ///     Get RotationalSpeed from DegreesPerSecond.
        /// </summary>
        public static RotationalSpeed FromDegreesPerSecond(double degreespersecond)
        {
            return new RotationalSpeed((Math.PI/180)*degreespersecond);
        }

        /// <summary>
        ///     Get RotationalSpeed from MicrodegreesPerSecond.
        /// </summary>
        public static RotationalSpeed FromMicrodegreesPerSecond(double microdegreespersecond)
        {
            return new RotationalSpeed(((Math.PI/180)*microdegreespersecond) * 1e-6d);
        }

        /// <summary>
        ///     Get RotationalSpeed from MicroradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromMicroradiansPerSecond(double microradianspersecond)
        {
            return new RotationalSpeed((microradianspersecond) * 1e-6d);
        }

        /// <summary>
        ///     Get RotationalSpeed from MillidegreesPerSecond.
        /// </summary>
        public static RotationalSpeed FromMillidegreesPerSecond(double millidegreespersecond)
        {
            return new RotationalSpeed(((Math.PI/180)*millidegreespersecond) * 1e-3d);
        }

        /// <summary>
        ///     Get RotationalSpeed from MilliradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromMilliradiansPerSecond(double milliradianspersecond)
        {
            return new RotationalSpeed((milliradianspersecond) * 1e-3d);
        }

        /// <summary>
        ///     Get RotationalSpeed from NanodegreesPerSecond.
        /// </summary>
        public static RotationalSpeed FromNanodegreesPerSecond(double nanodegreespersecond)
        {
            return new RotationalSpeed(((Math.PI/180)*nanodegreespersecond) * 1e-9d);
        }

        /// <summary>
        ///     Get RotationalSpeed from NanoradiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromNanoradiansPerSecond(double nanoradianspersecond)
        {
            return new RotationalSpeed((nanoradianspersecond) * 1e-9d);
        }

        /// <summary>
        ///     Get RotationalSpeed from RadiansPerSecond.
        /// </summary>
        public static RotationalSpeed FromRadiansPerSecond(double radianspersecond)
        {
            return new RotationalSpeed(radianspersecond);
        }

        /// <summary>
        ///     Get RotationalSpeed from RevolutionsPerMinute.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerMinute(double revolutionsperminute)
        {
            return new RotationalSpeed((revolutionsperminute*6.2831853072)/60);
        }

        /// <summary>
        ///     Get RotationalSpeed from RevolutionsPerSecond.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerSecond(double revolutionspersecond)
        {
            return new RotationalSpeed(revolutionspersecond*6.2831853072);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable RotationalSpeed from nullable CentiradiansPerSecond.
        /// </summary>
        public static RotationalSpeed? FromCentiradiansPerSecond(double? centiradianspersecond)
        {
            if (centiradianspersecond.HasValue)
            {
                return FromCentiradiansPerSecond(centiradianspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable DeciradiansPerSecond.
        /// </summary>
        public static RotationalSpeed? FromDeciradiansPerSecond(double? deciradianspersecond)
        {
            if (deciradianspersecond.HasValue)
            {
                return FromDeciradiansPerSecond(deciradianspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable DegreesPerMinute.
        /// </summary>
        public static RotationalSpeed? FromDegreesPerMinute(double? degreesperminute)
        {
            if (degreesperminute.HasValue)
            {
                return FromDegreesPerMinute(degreesperminute.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable DegreesPerSecond.
        /// </summary>
        public static RotationalSpeed? FromDegreesPerSecond(double? degreespersecond)
        {
            if (degreespersecond.HasValue)
            {
                return FromDegreesPerSecond(degreespersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable MicrodegreesPerSecond.
        /// </summary>
        public static RotationalSpeed? FromMicrodegreesPerSecond(double? microdegreespersecond)
        {
            if (microdegreespersecond.HasValue)
            {
                return FromMicrodegreesPerSecond(microdegreespersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable MicroradiansPerSecond.
        /// </summary>
        public static RotationalSpeed? FromMicroradiansPerSecond(double? microradianspersecond)
        {
            if (microradianspersecond.HasValue)
            {
                return FromMicroradiansPerSecond(microradianspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable MillidegreesPerSecond.
        /// </summary>
        public static RotationalSpeed? FromMillidegreesPerSecond(double? millidegreespersecond)
        {
            if (millidegreespersecond.HasValue)
            {
                return FromMillidegreesPerSecond(millidegreespersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable MilliradiansPerSecond.
        /// </summary>
        public static RotationalSpeed? FromMilliradiansPerSecond(double? milliradianspersecond)
        {
            if (milliradianspersecond.HasValue)
            {
                return FromMilliradiansPerSecond(milliradianspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable NanodegreesPerSecond.
        /// </summary>
        public static RotationalSpeed? FromNanodegreesPerSecond(double? nanodegreespersecond)
        {
            if (nanodegreespersecond.HasValue)
            {
                return FromNanodegreesPerSecond(nanodegreespersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable NanoradiansPerSecond.
        /// </summary>
        public static RotationalSpeed? FromNanoradiansPerSecond(double? nanoradianspersecond)
        {
            if (nanoradianspersecond.HasValue)
            {
                return FromNanoradiansPerSecond(nanoradianspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable RadiansPerSecond.
        /// </summary>
        public static RotationalSpeed? FromRadiansPerSecond(double? radianspersecond)
        {
            if (radianspersecond.HasValue)
            {
                return FromRadiansPerSecond(radianspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable RevolutionsPerMinute.
        /// </summary>
        public static RotationalSpeed? FromRevolutionsPerMinute(double? revolutionsperminute)
        {
            if (revolutionsperminute.HasValue)
            {
                return FromRevolutionsPerMinute(revolutionsperminute.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable RotationalSpeed from nullable RevolutionsPerSecond.
        /// </summary>
        public static RotationalSpeed? FromRevolutionsPerSecond(double? revolutionspersecond)
        {
            if (revolutionspersecond.HasValue)
            {
                return FromRevolutionsPerSecond(revolutionspersecond.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RotationalSpeedUnit" /> to <see cref="RotationalSpeed" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalSpeed unit value.</returns>
        public static RotationalSpeed From(double val, RotationalSpeedUnit fromUnit)
        {
            switch (fromUnit)
            {
                case RotationalSpeedUnit.CentiradianPerSecond:
                    return FromCentiradiansPerSecond(val);
                case RotationalSpeedUnit.DeciradianPerSecond:
                    return FromDeciradiansPerSecond(val);
                case RotationalSpeedUnit.DegreePerMinute:
                    return FromDegreesPerMinute(val);
                case RotationalSpeedUnit.DegreePerSecond:
                    return FromDegreesPerSecond(val);
                case RotationalSpeedUnit.MicrodegreePerSecond:
                    return FromMicrodegreesPerSecond(val);
                case RotationalSpeedUnit.MicroradianPerSecond:
                    return FromMicroradiansPerSecond(val);
                case RotationalSpeedUnit.MillidegreePerSecond:
                    return FromMillidegreesPerSecond(val);
                case RotationalSpeedUnit.MilliradianPerSecond:
                    return FromMilliradiansPerSecond(val);
                case RotationalSpeedUnit.NanodegreePerSecond:
                    return FromNanodegreesPerSecond(val);
                case RotationalSpeedUnit.NanoradianPerSecond:
                    return FromNanoradiansPerSecond(val);
                case RotationalSpeedUnit.RadianPerSecond:
                    return FromRadiansPerSecond(val);
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return FromRevolutionsPerMinute(val);
                case RotationalSpeedUnit.RevolutionPerSecond:
                    return FromRevolutionsPerSecond(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RotationalSpeedUnit" /> to <see cref="RotationalSpeed" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalSpeed unit value.</returns>
        public static RotationalSpeed? From(double? value, RotationalSpeedUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case RotationalSpeedUnit.CentiradianPerSecond:
                    return FromCentiradiansPerSecond(value.Value);
                case RotationalSpeedUnit.DeciradianPerSecond:
                    return FromDeciradiansPerSecond(value.Value);
                case RotationalSpeedUnit.DegreePerMinute:
                    return FromDegreesPerMinute(value.Value);
                case RotationalSpeedUnit.DegreePerSecond:
                    return FromDegreesPerSecond(value.Value);
                case RotationalSpeedUnit.MicrodegreePerSecond:
                    return FromMicrodegreesPerSecond(value.Value);
                case RotationalSpeedUnit.MicroradianPerSecond:
                    return FromMicroradiansPerSecond(value.Value);
                case RotationalSpeedUnit.MillidegreePerSecond:
                    return FromMillidegreesPerSecond(value.Value);
                case RotationalSpeedUnit.MilliradianPerSecond:
                    return FromMilliradiansPerSecond(value.Value);
                case RotationalSpeedUnit.NanodegreePerSecond:
                    return FromNanodegreesPerSecond(value.Value);
                case RotationalSpeedUnit.NanoradianPerSecond:
                    return FromNanoradiansPerSecond(value.Value);
                case RotationalSpeedUnit.RadianPerSecond:
                    return FromRadiansPerSecond(value.Value);
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return FromRevolutionsPerMinute(value.Value);
                case RotationalSpeedUnit.RevolutionPerSecond:
                    return FromRevolutionsPerSecond(value.Value);

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
        public static string GetAbbreviation(RotationalSpeedUnit unit)
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
        public static string GetAbbreviation(RotationalSpeedUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static RotationalSpeed operator -(RotationalSpeed right)
        {
            return new RotationalSpeed(-right._radiansPerSecond);
        }

        public static RotationalSpeed operator +(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left._radiansPerSecond + right._radiansPerSecond);
        }

        public static RotationalSpeed operator -(RotationalSpeed left, RotationalSpeed right)
        {
            return new RotationalSpeed(left._radiansPerSecond - right._radiansPerSecond);
        }

        public static RotationalSpeed operator *(double left, RotationalSpeed right)
        {
            return new RotationalSpeed(left*right._radiansPerSecond);
        }

        public static RotationalSpeed operator *(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left._radiansPerSecond*(double)right);
        }

        public static RotationalSpeed operator /(RotationalSpeed left, double right)
        {
            return new RotationalSpeed(left._radiansPerSecond/(double)right);
        }

        public static double operator /(RotationalSpeed left, RotationalSpeed right)
        {
            return Convert.ToDouble(left._radiansPerSecond/right._radiansPerSecond);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is RotationalSpeed)) throw new ArgumentException("Expected type RotationalSpeed.", "obj");
            return CompareTo((RotationalSpeed) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(RotationalSpeed other)
        {
            return _radiansPerSecond.CompareTo(other._radiansPerSecond);
        }

#if !WINDOWS_UWP
        public static bool operator <=(RotationalSpeed left, RotationalSpeed right)
        {
            return left._radiansPerSecond <= right._radiansPerSecond;
        }

        public static bool operator >=(RotationalSpeed left, RotationalSpeed right)
        {
            return left._radiansPerSecond >= right._radiansPerSecond;
        }

        public static bool operator <(RotationalSpeed left, RotationalSpeed right)
        {
            return left._radiansPerSecond < right._radiansPerSecond;
        }

        public static bool operator >(RotationalSpeed left, RotationalSpeed right)
        {
            return left._radiansPerSecond > right._radiansPerSecond;
        }

        public static bool operator ==(RotationalSpeed left, RotationalSpeed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._radiansPerSecond == right._radiansPerSecond;
        }

        public static bool operator !=(RotationalSpeed left, RotationalSpeed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._radiansPerSecond != right._radiansPerSecond;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _radiansPerSecond.Equals(((RotationalSpeed) obj)._radiansPerSecond);
        }

        public override int GetHashCode()
        {
            return _radiansPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(RotationalSpeedUnit unit)
        {
            switch (unit)
            {
                case RotationalSpeedUnit.CentiradianPerSecond:
                    return CentiradiansPerSecond;
                case RotationalSpeedUnit.DeciradianPerSecond:
                    return DeciradiansPerSecond;
                case RotationalSpeedUnit.DegreePerMinute:
                    return DegreesPerMinute;
                case RotationalSpeedUnit.DegreePerSecond:
                    return DegreesPerSecond;
                case RotationalSpeedUnit.MicrodegreePerSecond:
                    return MicrodegreesPerSecond;
                case RotationalSpeedUnit.MicroradianPerSecond:
                    return MicroradiansPerSecond;
                case RotationalSpeedUnit.MillidegreePerSecond:
                    return MillidegreesPerSecond;
                case RotationalSpeedUnit.MilliradianPerSecond:
                    return MilliradiansPerSecond;
                case RotationalSpeedUnit.NanodegreePerSecond:
                    return NanodegreesPerSecond;
                case RotationalSpeedUnit.NanoradianPerSecond:
                    return NanoradiansPerSecond;
                case RotationalSpeedUnit.RadianPerSecond:
                    return RadiansPerSecond;
                case RotationalSpeedUnit.RevolutionPerMinute:
                    return RevolutionsPerMinute;
                case RotationalSpeedUnit.RevolutionPerSecond:
                    return RevolutionsPerSecond;

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
        public static RotationalSpeed Parse(string str)
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
        public static RotationalSpeed Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => RotationalSpeed.FromRadiansPerSecond(x.RadiansPerSecond + y.RadiansPerSecond));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<RotationalSpeed> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<RotationalSpeed>();

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
                    RotationalSpeedUnit unit = ParseUnit(unitString, formatProvider);
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
        public static RotationalSpeedUnit ParseUnit(string str)
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
        public static RotationalSpeedUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static RotationalSpeedUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<RotationalSpeedUnit>(str.Trim());

            if (unit == RotationalSpeedUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized RotationalSpeedUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is RadianPerSecond
        /// </summary>
        public static RotationalSpeedUnit ToStringDefaultUnit { get; set; } = RotationalSpeedUnit.RadianPerSecond;

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
        public string ToString(RotationalSpeedUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(RotationalSpeedUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(RotationalSpeedUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(RotationalSpeedUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of RotationalSpeed
        /// </summary>
        public static RotationalSpeed MaxValue
        {
            get
            {
                return new RotationalSpeed(double.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of RotationalSpeed
        /// </summary>
        public static RotationalSpeed MinValue
        {
            get
            {
                return new RotationalSpeed(double.MinValue);
            }
        }
    }
}
