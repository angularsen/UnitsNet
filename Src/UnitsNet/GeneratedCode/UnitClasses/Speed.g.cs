// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     In everyday use and in kinematics, the speed of an object is the magnitude of its velocity (the rate of change of its position); it is thus a scalar quantity.[1] The average speed of an object in an interval of time is the distance travelled by the object divided by the duration of the interval;[2] the instantaneous speed is the limit of the average speed as the duration of the time interval approaches zero.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Speed : IComparable, IComparable<Speed>
    {
        /// <summary>
        ///     Base unit of Speed.
        /// </summary>
        private readonly double _metersPerSecond;

        public Speed(double meterspersecond) : this()
        {
            _metersPerSecond = meterspersecond;
        }

        #region Properties

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
        ///     Get Speed in Knots.
        /// </summary>
        public double Knots
        {
            get { return _metersPerSecond/0.514444; }
        }

        /// <summary>
        ///     Get Speed in MetersPerSecond.
        /// </summary>
        public double MetersPerSecond
        {
            get { return _metersPerSecond; }
        }

        /// <summary>
        ///     Get Speed in MilesPerHour.
        /// </summary>
        public double MilesPerHour
        {
            get { return _metersPerSecond/0.44704; }
        }

        #endregion

        #region Static 

        public static Speed Zero
        {
            get { return new Speed(); }
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
        ///     Get Speed from Knots.
        /// </summary>
        public static Speed FromKnots(double knots)
        {
            return new Speed(knots*0.514444);
        }

        /// <summary>
        ///     Get Speed from MetersPerSecond.
        /// </summary>
        public static Speed FromMetersPerSecond(double meterspersecond)
        {
            return new Speed(meterspersecond);
        }

        /// <summary>
        ///     Get Speed from MilesPerHour.
        /// </summary>
        public static Speed FromMilesPerHour(double milesperhour)
        {
            return new Speed(milesperhour*0.44704);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpeedUnit" /> to <see cref="Speed" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Speed unit value.</returns>
        public static Speed From(double value, SpeedUnit fromUnit)
        {
            switch (fromUnit)
            {
                case SpeedUnit.FootPerSecond:
                    return FromFeetPerSecond(value);
                case SpeedUnit.KilometerPerHour:
                    return FromKilometersPerHour(value);
                case SpeedUnit.Knot:
                    return FromKnots(value);
                case SpeedUnit.MeterPerSecond:
                    return FromMetersPerSecond(value);
                case SpeedUnit.MilePerHour:
                    return FromMilesPerHour(value);

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
        public static string GetAbbreviation(SpeedUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

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

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Speed)) throw new ArgumentException("Expected type Speed.", "obj");
            return CompareTo((Speed) obj);
        }

        public int CompareTo(Speed other)
        {
            return _metersPerSecond.CompareTo(other._metersPerSecond);
        }

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
                case SpeedUnit.FootPerSecond:
                    return FeetPerSecond;
                case SpeedUnit.KilometerPerHour:
                    return KilometersPerHour;
                case SpeedUnit.Knot:
                    return Knots;
                case SpeedUnit.MeterPerSecond:
                    return MetersPerSecond;
                case SpeedUnit.MilePerHour:
                    return MilesPerHour;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(SpeedUnit.MeterPerSecond);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
		/// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(SpeedUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(SpeedUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
