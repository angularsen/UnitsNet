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
    ///     In everyday use and in kinematics, the speed of an object is the magnitude of its velocity (the rate of change of its position); it is thus a scalar quantity.[1] The average speed of an object in an interval of time is the distance travelled by the object divided by the duration of the interval;[2] the instantaneous speed is the limit of the average speed as the duration of the time interval approaches zero.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Speed
#else
    public partial struct Speed : IComparable, IComparable<Speed>
#endif
    {
        /// <summary>
        ///     Base unit of Speed.
        /// </summary>
        private readonly double _metersPerSecond;

#if WINDOWS_UWP
        public Speed() : this(0)
        {
        }
#endif

        public Speed(double meterspersecond)
        {
            _metersPerSecond = Convert.ToDouble(meterspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Speed(long meterspersecond)
        {
            _metersPerSecond = Convert.ToDouble(meterspersecond);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Speed(decimal meterspersecond)
        {
            _metersPerSecond = Convert.ToDouble(meterspersecond);
        }

        #region Properties

        public static SpeedUnit BaseUnit
        {
            get { return SpeedUnit.MeterPerSecond; }
        }

        /// <summary>
        ///     Get Speed in CentimetersPerMinutes.
        /// </summary>
        public double CentimetersPerMinutes
        {
            get { return (_metersPerSecond*60) / 1e-2d; }
        }

        /// <summary>
        ///     Get Speed in CentimetersPerSecond.
        /// </summary>
        public double CentimetersPerSecond
        {
            get { return (_metersPerSecond) / 1e-2d; }
        }

        /// <summary>
        ///     Get Speed in DecimetersPerMinutes.
        /// </summary>
        public double DecimetersPerMinutes
        {
            get { return (_metersPerSecond*60) / 1e-1d; }
        }

        /// <summary>
        ///     Get Speed in DecimetersPerSecond.
        /// </summary>
        public double DecimetersPerSecond
        {
            get { return (_metersPerSecond) / 1e-1d; }
        }

        /// <summary>
        ///     Get Speed in FeetPerSecond.
        /// </summary>
        public double FeetPerSecond
        {
            get { return _metersPerSecond/0.3048; }
        }

        /// <summary>
        ///     Get Speed in KilometersPerHour.
        /// </summary>
        public double KilometersPerHour
        {
            get { return _metersPerSecond*3.6; }
        }

        /// <summary>
        ///     Get Speed in KilometersPerMinutes.
        /// </summary>
        public double KilometersPerMinutes
        {
            get { return (_metersPerSecond*60) / 1e3d; }
        }

        /// <summary>
        ///     Get Speed in KilometersPerSecond.
        /// </summary>
        public double KilometersPerSecond
        {
            get { return (_metersPerSecond) / 1e3d; }
        }

        /// <summary>
        ///     Get Speed in Knots.
        /// </summary>
        public double Knots
        {
            get { return _metersPerSecond/0.514444; }
        }

        /// <summary>
        ///     Get Speed in MetersPerHour.
        /// </summary>
        public double MetersPerHour
        {
            get { return _metersPerSecond*3600; }
        }

        /// <summary>
        ///     Get Speed in MetersPerMinutes.
        /// </summary>
        public double MetersPerMinutes
        {
            get { return _metersPerSecond*60; }
        }

        /// <summary>
        ///     Get Speed in MetersPerSecond.
        /// </summary>
        public double MetersPerSecond
        {
            get { return _metersPerSecond; }
        }

        /// <summary>
        ///     Get Speed in MicrometersPerMinutes.
        /// </summary>
        public double MicrometersPerMinutes
        {
            get { return (_metersPerSecond*60) / 1e-6d; }
        }

        /// <summary>
        ///     Get Speed in MicrometersPerSecond.
        /// </summary>
        public double MicrometersPerSecond
        {
            get { return (_metersPerSecond) / 1e-6d; }
        }

        /// <summary>
        ///     Get Speed in MilesPerHour.
        /// </summary>
        public double MilesPerHour
        {
            get { return _metersPerSecond/0.44704; }
        }

        /// <summary>
        ///     Get Speed in MillimetersPerMinutes.
        /// </summary>
        public double MillimetersPerMinutes
        {
            get { return (_metersPerSecond*60) / 1e-3d; }
        }

        /// <summary>
        ///     Get Speed in MillimetersPerSecond.
        /// </summary>
        public double MillimetersPerSecond
        {
            get { return (_metersPerSecond) / 1e-3d; }
        }

        /// <summary>
        ///     Get Speed in NanometersPerMinutes.
        /// </summary>
        public double NanometersPerMinutes
        {
            get { return (_metersPerSecond*60) / 1e-9d; }
        }

        /// <summary>
        ///     Get Speed in NanometersPerSecond.
        /// </summary>
        public double NanometersPerSecond
        {
            get { return (_metersPerSecond) / 1e-9d; }
        }

        #endregion

        #region Static

        public static Speed Zero
        {
            get { return new Speed(); }
        }

        /// <summary>
        ///     Get Speed from CentimetersPerMinutes.
        /// </summary>
        public static Speed FromCentimetersPerMinutes(double centimetersperminutes)
        {
            return new Speed((centimetersperminutes/60) * 1e-2d);
        }

        /// <summary>
        ///     Get Speed from CentimetersPerSecond.
        /// </summary>
        public static Speed FromCentimetersPerSecond(double centimeterspersecond)
        {
            return new Speed((centimeterspersecond) * 1e-2d);
        }

        /// <summary>
        ///     Get Speed from DecimetersPerMinutes.
        /// </summary>
        public static Speed FromDecimetersPerMinutes(double decimetersperminutes)
        {
            return new Speed((decimetersperminutes/60) * 1e-1d);
        }

        /// <summary>
        ///     Get Speed from DecimetersPerSecond.
        /// </summary>
        public static Speed FromDecimetersPerSecond(double decimeterspersecond)
        {
            return new Speed((decimeterspersecond) * 1e-1d);
        }

        /// <summary>
        ///     Get Speed from FeetPerSecond.
        /// </summary>
        public static Speed FromFeetPerSecond(double feetpersecond)
        {
            return new Speed(feetpersecond*0.3048);
        }

        /// <summary>
        ///     Get Speed from KilometersPerHour.
        /// </summary>
        public static Speed FromKilometersPerHour(double kilometersperhour)
        {
            return new Speed(kilometersperhour/3.6);
        }

        /// <summary>
        ///     Get Speed from KilometersPerMinutes.
        /// </summary>
        public static Speed FromKilometersPerMinutes(double kilometersperminutes)
        {
            return new Speed((kilometersperminutes/60) * 1e3d);
        }

        /// <summary>
        ///     Get Speed from KilometersPerSecond.
        /// </summary>
        public static Speed FromKilometersPerSecond(double kilometerspersecond)
        {
            return new Speed((kilometerspersecond) * 1e3d);
        }

        /// <summary>
        ///     Get Speed from Knots.
        /// </summary>
        public static Speed FromKnots(double knots)
        {
            return new Speed(knots*0.514444);
        }

        /// <summary>
        ///     Get Speed from MetersPerHour.
        /// </summary>
        public static Speed FromMetersPerHour(double metersperhour)
        {
            return new Speed(metersperhour/3600);
        }

        /// <summary>
        ///     Get Speed from MetersPerMinutes.
        /// </summary>
        public static Speed FromMetersPerMinutes(double metersperminutes)
        {
            return new Speed(metersperminutes/60);
        }

        /// <summary>
        ///     Get Speed from MetersPerSecond.
        /// </summary>
        public static Speed FromMetersPerSecond(double meterspersecond)
        {
            return new Speed(meterspersecond);
        }

        /// <summary>
        ///     Get Speed from MicrometersPerMinutes.
        /// </summary>
        public static Speed FromMicrometersPerMinutes(double micrometersperminutes)
        {
            return new Speed((micrometersperminutes/60) * 1e-6d);
        }

        /// <summary>
        ///     Get Speed from MicrometersPerSecond.
        /// </summary>
        public static Speed FromMicrometersPerSecond(double micrometerspersecond)
        {
            return new Speed((micrometerspersecond) * 1e-6d);
        }

        /// <summary>
        ///     Get Speed from MilesPerHour.
        /// </summary>
        public static Speed FromMilesPerHour(double milesperhour)
        {
            return new Speed(milesperhour*0.44704);
        }

        /// <summary>
        ///     Get Speed from MillimetersPerMinutes.
        /// </summary>
        public static Speed FromMillimetersPerMinutes(double millimetersperminutes)
        {
            return new Speed((millimetersperminutes/60) * 1e-3d);
        }

        /// <summary>
        ///     Get Speed from MillimetersPerSecond.
        /// </summary>
        public static Speed FromMillimetersPerSecond(double millimeterspersecond)
        {
            return new Speed((millimeterspersecond) * 1e-3d);
        }

        /// <summary>
        ///     Get Speed from NanometersPerMinutes.
        /// </summary>
        public static Speed FromNanometersPerMinutes(double nanometersperminutes)
        {
            return new Speed((nanometersperminutes/60) * 1e-9d);
        }

        /// <summary>
        ///     Get Speed from NanometersPerSecond.
        /// </summary>
        public static Speed FromNanometersPerSecond(double nanometerspersecond)
        {
            return new Speed((nanometerspersecond) * 1e-9d);
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Speed from nullable CentimetersPerMinutes.
        /// </summary>
        public static Speed? FromCentimetersPerMinutes(double? centimetersperminutes)
        {
            if (centimetersperminutes.HasValue)
            {
                return FromCentimetersPerMinutes(centimetersperminutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable CentimetersPerSecond.
        /// </summary>
        public static Speed? FromCentimetersPerSecond(double? centimeterspersecond)
        {
            if (centimeterspersecond.HasValue)
            {
                return FromCentimetersPerSecond(centimeterspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable DecimetersPerMinutes.
        /// </summary>
        public static Speed? FromDecimetersPerMinutes(double? decimetersperminutes)
        {
            if (decimetersperminutes.HasValue)
            {
                return FromDecimetersPerMinutes(decimetersperminutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable DecimetersPerSecond.
        /// </summary>
        public static Speed? FromDecimetersPerSecond(double? decimeterspersecond)
        {
            if (decimeterspersecond.HasValue)
            {
                return FromDecimetersPerSecond(decimeterspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable FeetPerSecond.
        /// </summary>
        public static Speed? FromFeetPerSecond(double? feetpersecond)
        {
            if (feetpersecond.HasValue)
            {
                return FromFeetPerSecond(feetpersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable KilometersPerHour.
        /// </summary>
        public static Speed? FromKilometersPerHour(double? kilometersperhour)
        {
            if (kilometersperhour.HasValue)
            {
                return FromKilometersPerHour(kilometersperhour.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable KilometersPerMinutes.
        /// </summary>
        public static Speed? FromKilometersPerMinutes(double? kilometersperminutes)
        {
            if (kilometersperminutes.HasValue)
            {
                return FromKilometersPerMinutes(kilometersperminutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable KilometersPerSecond.
        /// </summary>
        public static Speed? FromKilometersPerSecond(double? kilometerspersecond)
        {
            if (kilometerspersecond.HasValue)
            {
                return FromKilometersPerSecond(kilometerspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable Knots.
        /// </summary>
        public static Speed? FromKnots(double? knots)
        {
            if (knots.HasValue)
            {
                return FromKnots(knots.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MetersPerHour.
        /// </summary>
        public static Speed? FromMetersPerHour(double? metersperhour)
        {
            if (metersperhour.HasValue)
            {
                return FromMetersPerHour(metersperhour.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MetersPerMinutes.
        /// </summary>
        public static Speed? FromMetersPerMinutes(double? metersperminutes)
        {
            if (metersperminutes.HasValue)
            {
                return FromMetersPerMinutes(metersperminutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MetersPerSecond.
        /// </summary>
        public static Speed? FromMetersPerSecond(double? meterspersecond)
        {
            if (meterspersecond.HasValue)
            {
                return FromMetersPerSecond(meterspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MicrometersPerMinutes.
        /// </summary>
        public static Speed? FromMicrometersPerMinutes(double? micrometersperminutes)
        {
            if (micrometersperminutes.HasValue)
            {
                return FromMicrometersPerMinutes(micrometersperminutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MicrometersPerSecond.
        /// </summary>
        public static Speed? FromMicrometersPerSecond(double? micrometerspersecond)
        {
            if (micrometerspersecond.HasValue)
            {
                return FromMicrometersPerSecond(micrometerspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MilesPerHour.
        /// </summary>
        public static Speed? FromMilesPerHour(double? milesperhour)
        {
            if (milesperhour.HasValue)
            {
                return FromMilesPerHour(milesperhour.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MillimetersPerMinutes.
        /// </summary>
        public static Speed? FromMillimetersPerMinutes(double? millimetersperminutes)
        {
            if (millimetersperminutes.HasValue)
            {
                return FromMillimetersPerMinutes(millimetersperminutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable MillimetersPerSecond.
        /// </summary>
        public static Speed? FromMillimetersPerSecond(double? millimeterspersecond)
        {
            if (millimeterspersecond.HasValue)
            {
                return FromMillimetersPerSecond(millimeterspersecond.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable NanometersPerMinutes.
        /// </summary>
        public static Speed? FromNanometersPerMinutes(double? nanometersperminutes)
        {
            if (nanometersperminutes.HasValue)
            {
                return FromNanometersPerMinutes(nanometersperminutes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Speed from nullable NanometersPerSecond.
        /// </summary>
        public static Speed? FromNanometersPerSecond(double? nanometerspersecond)
        {
            if (nanometerspersecond.HasValue)
            {
                return FromNanometersPerSecond(nanometerspersecond.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpeedUnit" /> to <see cref="Speed" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Speed unit value.</returns>
        public static Speed From(double val, SpeedUnit fromUnit)
        {
            switch (fromUnit)
            {
                case SpeedUnit.CentimeterPerMinute:
                    return FromCentimetersPerMinutes(val);
                case SpeedUnit.CentimeterPerSecond:
                    return FromCentimetersPerSecond(val);
                case SpeedUnit.DecimeterPerMinute:
                    return FromDecimetersPerMinutes(val);
                case SpeedUnit.DecimeterPerSecond:
                    return FromDecimetersPerSecond(val);
                case SpeedUnit.FootPerSecond:
                    return FromFeetPerSecond(val);
                case SpeedUnit.KilometerPerHour:
                    return FromKilometersPerHour(val);
                case SpeedUnit.KilometerPerMinute:
                    return FromKilometersPerMinutes(val);
                case SpeedUnit.KilometerPerSecond:
                    return FromKilometersPerSecond(val);
                case SpeedUnit.Knot:
                    return FromKnots(val);
                case SpeedUnit.MeterPerHour:
                    return FromMetersPerHour(val);
                case SpeedUnit.MeterPerMinute:
                    return FromMetersPerMinutes(val);
                case SpeedUnit.MeterPerSecond:
                    return FromMetersPerSecond(val);
                case SpeedUnit.MicrometerPerMinute:
                    return FromMicrometersPerMinutes(val);
                case SpeedUnit.MicrometerPerSecond:
                    return FromMicrometersPerSecond(val);
                case SpeedUnit.MilePerHour:
                    return FromMilesPerHour(val);
                case SpeedUnit.MillimeterPerMinute:
                    return FromMillimetersPerMinutes(val);
                case SpeedUnit.MillimeterPerSecond:
                    return FromMillimetersPerSecond(val);
                case SpeedUnit.NanometerPerMinute:
                    return FromNanometersPerMinutes(val);
                case SpeedUnit.NanometerPerSecond:
                    return FromNanometersPerSecond(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpeedUnit" /> to <see cref="Speed" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Speed unit value.</returns>
        public static Speed? From(double? value, SpeedUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case SpeedUnit.CentimeterPerMinute:
                    return FromCentimetersPerMinutes(value.Value);
                case SpeedUnit.CentimeterPerSecond:
                    return FromCentimetersPerSecond(value.Value);
                case SpeedUnit.DecimeterPerMinute:
                    return FromDecimetersPerMinutes(value.Value);
                case SpeedUnit.DecimeterPerSecond:
                    return FromDecimetersPerSecond(value.Value);
                case SpeedUnit.FootPerSecond:
                    return FromFeetPerSecond(value.Value);
                case SpeedUnit.KilometerPerHour:
                    return FromKilometersPerHour(value.Value);
                case SpeedUnit.KilometerPerMinute:
                    return FromKilometersPerMinutes(value.Value);
                case SpeedUnit.KilometerPerSecond:
                    return FromKilometersPerSecond(value.Value);
                case SpeedUnit.Knot:
                    return FromKnots(value.Value);
                case SpeedUnit.MeterPerHour:
                    return FromMetersPerHour(value.Value);
                case SpeedUnit.MeterPerMinute:
                    return FromMetersPerMinutes(value.Value);
                case SpeedUnit.MeterPerSecond:
                    return FromMetersPerSecond(value.Value);
                case SpeedUnit.MicrometerPerMinute:
                    return FromMicrometersPerMinutes(value.Value);
                case SpeedUnit.MicrometerPerSecond:
                    return FromMicrometersPerSecond(value.Value);
                case SpeedUnit.MilePerHour:
                    return FromMilesPerHour(value.Value);
                case SpeedUnit.MillimeterPerMinute:
                    return FromMillimetersPerMinutes(value.Value);
                case SpeedUnit.MillimeterPerSecond:
                    return FromMillimetersPerSecond(value.Value);
                case SpeedUnit.NanometerPerMinute:
                    return FromNanometersPerMinutes(value.Value);
                case SpeedUnit.NanometerPerSecond:
                    return FromNanometersPerSecond(value.Value);

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
        public static string GetAbbreviation(SpeedUnit unit)
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
        public static string GetAbbreviation(SpeedUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
        public static Speed operator -(Speed right)
        {
            return new Speed(-right._metersPerSecond);
        }

        public static Speed operator +(Speed left, Speed right)
        {
            return new Speed(left._metersPerSecond + right._metersPerSecond);
        }

        public static Speed operator -(Speed left, Speed right)
        {
            return new Speed(left._metersPerSecond - right._metersPerSecond);
        }

        public static Speed operator *(double left, Speed right)
        {
            return new Speed(left*right._metersPerSecond);
        }

        public static Speed operator *(Speed left, double right)
        {
            return new Speed(left._metersPerSecond*(double)right);
        }

        public static Speed operator /(Speed left, double right)
        {
            return new Speed(left._metersPerSecond/(double)right);
        }

        public static double operator /(Speed left, Speed right)
        {
            return Convert.ToDouble(left._metersPerSecond/right._metersPerSecond);
        }
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Speed)) throw new ArgumentException("Expected type Speed.", "obj");
            return CompareTo((Speed) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Speed other)
        {
            return _metersPerSecond.CompareTo(other._metersPerSecond);
        }

#if !WINDOWS_UWP
        public static bool operator <=(Speed left, Speed right)
        {
            return left._metersPerSecond <= right._metersPerSecond;
        }

        public static bool operator >=(Speed left, Speed right)
        {
            return left._metersPerSecond >= right._metersPerSecond;
        }

        public static bool operator <(Speed left, Speed right)
        {
            return left._metersPerSecond < right._metersPerSecond;
        }

        public static bool operator >(Speed left, Speed right)
        {
            return left._metersPerSecond > right._metersPerSecond;
        }

        public static bool operator ==(Speed left, Speed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._metersPerSecond == right._metersPerSecond;
        }

        public static bool operator !=(Speed left, Speed right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._metersPerSecond != right._metersPerSecond;
        }
#endif

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _metersPerSecond.Equals(((Speed) obj)._metersPerSecond);
        }

        public override int GetHashCode()
        {
            return _metersPerSecond.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(SpeedUnit unit)
        {
            switch (unit)
            {
                case SpeedUnit.CentimeterPerMinute:
                    return CentimetersPerMinutes;
                case SpeedUnit.CentimeterPerSecond:
                    return CentimetersPerSecond;
                case SpeedUnit.DecimeterPerMinute:
                    return DecimetersPerMinutes;
                case SpeedUnit.DecimeterPerSecond:
                    return DecimetersPerSecond;
                case SpeedUnit.FootPerSecond:
                    return FeetPerSecond;
                case SpeedUnit.KilometerPerHour:
                    return KilometersPerHour;
                case SpeedUnit.KilometerPerMinute:
                    return KilometersPerMinutes;
                case SpeedUnit.KilometerPerSecond:
                    return KilometersPerSecond;
                case SpeedUnit.Knot:
                    return Knots;
                case SpeedUnit.MeterPerHour:
                    return MetersPerHour;
                case SpeedUnit.MeterPerMinute:
                    return MetersPerMinutes;
                case SpeedUnit.MeterPerSecond:
                    return MetersPerSecond;
                case SpeedUnit.MicrometerPerMinute:
                    return MicrometersPerMinutes;
                case SpeedUnit.MicrometerPerSecond:
                    return MicrometersPerSecond;
                case SpeedUnit.MilePerHour:
                    return MilesPerHour;
                case SpeedUnit.MillimeterPerMinute:
                    return MillimetersPerMinutes;
                case SpeedUnit.MillimeterPerSecond:
                    return MillimetersPerSecond;
                case SpeedUnit.NanometerPerMinute:
                    return NanometersPerMinutes;
                case SpeedUnit.NanometerPerSecond:
                    return NanometersPerSecond;

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
        public static Speed Parse(string str)
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
        public static Speed Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Speed.FromMetersPerSecond(x.MetersPerSecond + y.MetersPerSecond));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Speed> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Speed>();

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
                    SpeedUnit unit = ParseUnit(unitString, formatProvider);
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
        public static SpeedUnit ParseUnit(string str)
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
        public static SpeedUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static SpeedUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<SpeedUnit>(str.Trim());

            if (unit == SpeedUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized SpeedUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is MeterPerSecond
        /// </summary>
        public static SpeedUnit ToStringDefaultUnit { get; set; } = SpeedUnit.MeterPerSecond;

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
        public string ToString(SpeedUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(SpeedUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(SpeedUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(SpeedUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
