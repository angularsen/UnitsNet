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
    ///     The joule, symbol J, is a derived unit of energy, work, or amount of heat in the International System of Units. It is equal to the energy transferred (or work done) when applying a force of one newton through a distance of one metre (1 newton metre or N·m), or in passing an electric current of one ampere through a resistance of one ohm for one second
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Energy : IComparable, IComparable<Energy>
    {
        /// <summary>
        ///     Base unit of Energy.
        /// </summary>
        private readonly double _joules;

        public Energy(double joules) : this()
        {
            _joules = joules;
        }

        #region Properties

        /// <summary>
        ///     Get Energy in Joules.
        /// </summary>
        public double Joules
        {
            get { return _joules; }
        }

        /// <summary>
        ///     Get Energy in Kilojoules.
        /// </summary>
        public double Kilojoules
        {
            get { return (_joules) / 1e3d; }
        }

        /// <summary>
        ///     Get Energy in Megajoules.
        /// </summary>
        public double Megajoules
        {
            get { return (_joules) / 1e6d; }
        }

        #endregion

        #region Static 

        public static Energy Zero
        {
            get { return new Energy(); }
        }

        /// <summary>
        ///     Get Energy from Joules.
        /// </summary>
        public static Energy FromJoules(double joules)
        {
            return new Energy(joules);
        }

        /// <summary>
        ///     Get Energy from Kilojoules.
        /// </summary>
        public static Energy FromKilojoules(double kilojoules)
        {
            return new Energy((kilojoules) * 1e3d);
        }

        /// <summary>
        ///     Get Energy from Megajoules.
        /// </summary>
        public static Energy FromMegajoules(double megajoules)
        {
            return new Energy((megajoules) * 1e6d);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="EnergyUnit" /> to <see cref="Energy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Energy unit value.</returns>
        public static Energy From(double value, EnergyUnit fromUnit)
        {
            switch (fromUnit)
            {
                case EnergyUnit.Joule:
                    return FromJoules(value);
                case EnergyUnit.Kilojoule:
                    return FromKilojoules(value);
                case EnergyUnit.Megajoule:
                    return FromMegajoules(value);

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
        public static string GetAbbreviation(EnergyUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Energy operator -(Energy right)
        {
            return new Energy(-right._joules);
        }

        public static Energy operator +(Energy left, Energy right)
        {
            return new Energy(left._joules + right._joules);
        }

        public static Energy operator -(Energy left, Energy right)
        {
            return new Energy(left._joules - right._joules);
        }

        public static Energy operator *(double left, Energy right)
        {
            return new Energy(left*right._joules);
        }

        public static Energy operator *(Energy left, double right)
        {
            return new Energy(left._joules*(double)right);
        }

        public static Energy operator /(Energy left, double right)
        {
            return new Energy(left._joules/(double)right);
        }

        public static double operator /(Energy left, Energy right)
        {
            return Convert.ToDouble(left._joules/right._joules);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Energy)) throw new ArgumentException("Expected type Energy.", "obj");
            return CompareTo((Energy) obj);
        }

        public int CompareTo(Energy other)
        {
            return _joules.CompareTo(other._joules);
        }

        public static bool operator <=(Energy left, Energy right)
        {
            return left._joules <= right._joules;
        }

        public static bool operator >=(Energy left, Energy right)
        {
            return left._joules >= right._joules;
        }

        public static bool operator <(Energy left, Energy right)
        {
            return left._joules < right._joules;
        }

        public static bool operator >(Energy left, Energy right)
        {
            return left._joules > right._joules;
        }

        public static bool operator ==(Energy left, Energy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joules == right._joules;
        }

        public static bool operator !=(Energy left, Energy right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._joules != right._joules;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _joules.Equals(((Energy) obj)._joules);
        }

        public override int GetHashCode()
        {
            return _joules.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(EnergyUnit unit)
        {
            switch (unit)
            {
                case EnergyUnit.Joule:
                    return Joules;
                case EnergyUnit.Kilojoule:
                    return Kilojoules;
                case EnergyUnit.Megajoule:
                    return Megajoules;

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
        public static Energy Parse(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");
            string[] words = str.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 2)
            {
                var ex = new ArgumentException(
                    "Expected two or more words. Input string needs to be in the format \"<quantity> <unit>\".", "str");
                ex.Data["input"] = str;
                ex.Data["formatprovider"] = formatProvider == null ? null : formatProvider.ToString();
                throw ex;
            }

            try
            {
                // Unit string is the last word, since units added so far don't contain spaces.
                // Value string is everything else since number formatting can contain spaces.
                string[] allWordsButLast = words.Take(words.Length - 1).ToArray();
                string lastWord = words[words.Length - 1];

                string unitString = lastWord;
                string valueString = string.Join(" ", allWordsButLast);

                var unitSystem = UnitSystem.GetCached(formatProvider);

                EnergyUnit unit = unitSystem.Parse<EnergyUnit>(unitString);
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

        #endregion

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(EnergyUnit.Joule);
        }

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="significantDigitsAfterRadix">The number of significant digits after the radix point.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(EnergyUnit unit, CultureInfo culture = null, int significantDigitsAfterRadix = 2)
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
        public string ToString(EnergyUnit unit, CultureInfo culture, string format, params object[] args)
        {
            return string.Format(culture, format, UnitFormatter.GetFormatArgs(unit, As(unit), culture, args));
        }
    }
}
