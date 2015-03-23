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
using System.Text.RegularExpressions;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace

namespace UnitsNet
{
    /// <summary>
    ///     A temperature is a numerical measure of hot or cold. Its measurement is by detection of heat radiation or particle velocity or kinetic energy, or by the bulk behavior of a thermometric material. It may be calibrated in any of various temperature scales, Celsius, Fahrenheit, Kelvin, etc. The fundamental physical definition of temperature is provided by thermodynamics.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Temperature : IComparable, IComparable<Temperature>
    {
        /// <summary>
        ///     Base unit of Temperature.
        /// </summary>
        private readonly double _kelvins;

        public Temperature(double kelvins) : this()
        {
            _kelvins = kelvins;
        }

        #region Properties

        /// <summary>
        ///     Get Temperature in DegreesCelsius.
        /// </summary>
        public double DegreesCelsius
        {
            get { return _kelvins - 273.15; }
        }

        /// <summary>
        ///     Get Temperature in DegreesDelisle.
        /// </summary>
        public double DegreesDelisle
        {
            get { return (_kelvins - 373.15)*-3/2; }
        }

        /// <summary>
        ///     Get Temperature in DegreesFahrenheit.
        /// </summary>
        public double DegreesFahrenheit
        {
            get { return (_kelvins - 459.67*5/9)*9/5; }
        }

        /// <summary>
        ///     Get Temperature in DegreesNewton.
        /// </summary>
        public double DegreesNewton
        {
            get { return (_kelvins - 273.15)*33/100; }
        }

        /// <summary>
        ///     Get Temperature in DegreesRankine.
        /// </summary>
        public double DegreesRankine
        {
            get { return _kelvins*9/5; }
        }

        /// <summary>
        ///     Get Temperature in DegreesReaumur.
        /// </summary>
        public double DegreesReaumur
        {
            get { return (_kelvins - 273.15)*4/5; }
        }

        /// <summary>
        ///     Get Temperature in DegreesRoemer.
        /// </summary>
        public double DegreesRoemer
        {
            get { return (_kelvins - (273.15 - 7.5*40d/21))*21/40; }
        }

        /// <summary>
        ///     Get Temperature in Kelvins.
        /// </summary>
        public double Kelvins
        {
            get { return _kelvins; }
        }

        #endregion

        #region Static 

        public static Temperature Zero
        {
            get { return new Temperature(); }
        }

        /// <summary>
        ///     Get Temperature from DegreesCelsius.
        /// </summary>
        public static Temperature FromDegreesCelsius(double degreescelsius)
        {
            return new Temperature(degreescelsius + 273.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesDelisle.
        /// </summary>
        public static Temperature FromDegreesDelisle(double degreesdelisle)
        {
            return new Temperature(degreesdelisle*-2/3 + 373.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesFahrenheit.
        /// </summary>
        public static Temperature FromDegreesFahrenheit(double degreesfahrenheit)
        {
            return new Temperature(degreesfahrenheit*5/9 + 459.67*5/9);
        }

        /// <summary>
        ///     Get Temperature from DegreesNewton.
        /// </summary>
        public static Temperature FromDegreesNewton(double degreesnewton)
        {
            return new Temperature(degreesnewton*100/33 + 273.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesRankine.
        /// </summary>
        public static Temperature FromDegreesRankine(double degreesrankine)
        {
            return new Temperature(degreesrankine*5/9);
        }

        /// <summary>
        ///     Get Temperature from DegreesReaumur.
        /// </summary>
        public static Temperature FromDegreesReaumur(double degreesreaumur)
        {
            return new Temperature(degreesreaumur*5/4 + 273.15);
        }

        /// <summary>
        ///     Get Temperature from DegreesRoemer.
        /// </summary>
        public static Temperature FromDegreesRoemer(double degreesroemer)
        {
            return new Temperature(degreesroemer*40/21 + 273.15 - 7.5*40d/21);
        }

        /// <summary>
        ///     Get Temperature from Kelvins.
        /// </summary>
        public static Temperature FromKelvins(double kelvins)
        {
            return new Temperature(kelvins);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureUnit" /> to <see cref="Temperature" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Temperature unit value.</returns>
        public static Temperature From(double value, TemperatureUnit fromUnit)
        {
            switch (fromUnit)
            {
                case TemperatureUnit.DegreeCelsius:
                    return FromDegreesCelsius(value);
                case TemperatureUnit.DegreeDelisle:
                    return FromDegreesDelisle(value);
                case TemperatureUnit.DegreeFahrenheit:
                    return FromDegreesFahrenheit(value);
                case TemperatureUnit.DegreeNewton:
                    return FromDegreesNewton(value);
                case TemperatureUnit.DegreeRankine:
                    return FromDegreesRankine(value);
                case TemperatureUnit.DegreeReaumur:
                    return FromDegreesReaumur(value);
                case TemperatureUnit.DegreeRoemer:
                    return FromDegreesRoemer(value);
                case TemperatureUnit.Kelvin:
                    return FromKelvins(value);

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
        public static string GetAbbreviation(TemperatureUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Temperature operator -(Temperature right)
        {
            return new Temperature(-right._kelvins);
        }

        public static Temperature operator +(Temperature left, Temperature right)
        {
            return new Temperature(left._kelvins + right._kelvins);
        }

        public static Temperature operator -(Temperature left, Temperature right)
        {
            return new Temperature(left._kelvins - right._kelvins);
        }

        public static Temperature operator *(double left, Temperature right)
        {
            return new Temperature(left*right._kelvins);
        }

        public static Temperature operator *(Temperature left, double right)
        {
            return new Temperature(left._kelvins*(double)right);
        }

        public static Temperature operator /(Temperature left, double right)
        {
            return new Temperature(left._kelvins/(double)right);
        }

        public static double operator /(Temperature left, Temperature right)
        {
            return Convert.ToDouble(left._kelvins/right._kelvins);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Temperature)) throw new ArgumentException("Expected type Temperature.", "obj");
            return CompareTo((Temperature) obj);
        }

        public int CompareTo(Temperature other)
        {
            return _kelvins.CompareTo(other._kelvins);
        }

        public static bool operator <=(Temperature left, Temperature right)
        {
            return left._kelvins <= right._kelvins;
        }

        public static bool operator >=(Temperature left, Temperature right)
        {
            return left._kelvins >= right._kelvins;
        }

        public static bool operator <(Temperature left, Temperature right)
        {
            return left._kelvins < right._kelvins;
        }

        public static bool operator >(Temperature left, Temperature right)
        {
            return left._kelvins > right._kelvins;
        }

        public static bool operator ==(Temperature left, Temperature right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kelvins == right._kelvins;
        }

        public static bool operator !=(Temperature left, Temperature right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kelvins != right._kelvins;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _kelvins.Equals(((Temperature) obj)._kelvins);
        }

        public override int GetHashCode()
        {
            return _kelvins.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(TemperatureUnit unit)
        {
            switch (unit)
            {
                case TemperatureUnit.DegreeCelsius:
                    return DegreesCelsius;
                case TemperatureUnit.DegreeDelisle:
                    return DegreesDelisle;
                case TemperatureUnit.DegreeFahrenheit:
                    return DegreesFahrenheit;
                case TemperatureUnit.DegreeNewton:
                    return DegreesNewton;
                case TemperatureUnit.DegreeRankine:
                    return DegreesRankine;
                case TemperatureUnit.DegreeReaumur:
                    return DegreesReaumur;
                case TemperatureUnit.DegreeRoemer:
                    return DegreesRoemer;
                case TemperatureUnit.Kelvin:
                    return Kelvins;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        #region Parsing

        /// <summary>
        ///     Parse a string of the format "&lt;quantity&gt; &lt;unit&gt;".
        /// </summary>
        /// <example>
        ///     Length.Parse("5.5 m", new CultureInfo("en-US"));
        /// </example>
        /// <exception cref="ArgumentNullException">The value of 'str' cannot be null. </exception>
        /// <exception cref="ArgumentException">
        ///     Expected 2 words. Input string needs to be in the format "&lt;quantity&gt; &lt;unit
        ///     &gt;".
        /// </exception>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        public static Temperature Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var numFormat = formatProvider != null ?
                (NumberFormatInfo) formatProvider.GetFormat(typeof (NumberFormatInfo)) :
                NumberFormatInfo.CurrentInfo;

            var numRegex = @"[\d., "                        // allows digits, dots, commas, and spaces in the number by default
                         + numFormat.NumberGroupSeparator   // adds provided (or current) culture's group separator
                         + numFormat.NumberDecimalSeparator // adds provided (or current) culture's decimal separator
                         + @"]*\d";                         // ensures quantity ends in digit
            var regexString = @"(?<value>[-+]?" + numRegex + @"(?:[eE][-+]?\d+)?)" // capture Quantity input
                            + @"\s?"                                               // ignore whitespace (allows both "1kg", "1 kg")
                            + @"(?<unit>\S+)";                                     // capture Unit (non-whitespace) input

            var regex = new Regex(regexString);
            GroupCollection groups = regex.Match(str.Trim()).Groups;

            var valueString = groups["value"].Value;
            var unitString = groups["unit"].Value;

            if (valueString == "" || unitString == "")
            {
                var ex = new ArgumentException(
                    "Expected valid quantity and unit. Input string needs to be in the format \"<quantity><unit> or <quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }

            try
            {
                TemperatureUnit unit = ParseUnit(unitString, formatProvider);
                double value = double.Parse(valueString, formatProvider);

                return From(value, unit);
            }
            catch (Exception e)
            {
                var newEx = new UnitsNetException("Error parsing string.", e);
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
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
        public static TemperatureUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            var unitSystem = UnitSystem.GetCached(formatProvider);

            var unit = unitSystem.Parse<TemperatureUnit>(str.Trim());

            if (unit == TemperatureUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized TemperatureUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(TemperatureUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(TemperatureUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
