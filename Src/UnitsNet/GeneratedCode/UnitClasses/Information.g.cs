// Copyright ?2007 by Initial Force AS.  All rights reserved.
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
    ///     In computing and telecommunications, a unit of information is the capacity of some standard data storage system or communication channel, used to measure the capacities of other systems and channels. In information theory, units of information are also used to measure the information contents or entropy of random variables.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Information : IComparable, IComparable<Information>
    {
        /// <summary>
        ///     Base unit of Information.
        /// </summary>
        private readonly decimal _bits;

        public Information(decimal bits) : this()
        {
            _bits = bits;
        }

        #region Properties

        /// <summary>
        ///     Get Information in Bits.
        /// </summary>
        public double Bits
        {
            get { return Convert.ToDouble(_bits); }
        }

        /// <summary>
        ///     Get Information in Bytes.
        /// </summary>
        public double Bytes
        {
            get { return Convert.ToDouble(_bits/8m); }
        }

        /// <summary>
        ///     Get Information in Exabits.
        /// </summary>
        public double Exabits
        {
            get { return Convert.ToDouble((_bits) / 1e18m); }
        }

        /// <summary>
        ///     Get Information in Exabytes.
        /// </summary>
        public double Exabytes
        {
            get { return Convert.ToDouble((_bits/8m) / 1e18m); }
        }

        /// <summary>
        ///     Get Information in Exbibits.
        /// </summary>
        public double Exbibits
        {
            get { return Convert.ToDouble((_bits) / (1024m * 1024 * 1024 * 1024 * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Exbibytes.
        /// </summary>
        public double Exbibytes
        {
            get { return Convert.ToDouble((_bits/8m) / (1024m * 1024 * 1024 * 1024 * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Gibibits.
        /// </summary>
        public double Gibibits
        {
            get { return Convert.ToDouble((_bits) / (1024m * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Gibibytes.
        /// </summary>
        public double Gibibytes
        {
            get { return Convert.ToDouble((_bits/8m) / (1024m * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Gigabits.
        /// </summary>
        public double Gigabits
        {
            get { return Convert.ToDouble((_bits) / 1e9m); }
        }

        /// <summary>
        ///     Get Information in Gigabytes.
        /// </summary>
        public double Gigabytes
        {
            get { return Convert.ToDouble((_bits/8m) / 1e9m); }
        }

        /// <summary>
        ///     Get Information in Kibibits.
        /// </summary>
        public double Kibibits
        {
            get { return Convert.ToDouble((_bits) / 1024m); }
        }

        /// <summary>
        ///     Get Information in Kibibytes.
        /// </summary>
        public double Kibibytes
        {
            get { return Convert.ToDouble((_bits/8m) / 1024m); }
        }

        /// <summary>
        ///     Get Information in Kilobits.
        /// </summary>
        public double Kilobits
        {
            get { return Convert.ToDouble((_bits) / 1e3m); }
        }

        /// <summary>
        ///     Get Information in Kilobytes.
        /// </summary>
        public double Kilobytes
        {
            get { return Convert.ToDouble((_bits/8m) / 1e3m); }
        }

        /// <summary>
        ///     Get Information in Mebibits.
        /// </summary>
        public double Mebibits
        {
            get { return Convert.ToDouble((_bits) / (1024m * 1024)); }
        }

        /// <summary>
        ///     Get Information in Mebibytes.
        /// </summary>
        public double Mebibytes
        {
            get { return Convert.ToDouble((_bits/8m) / (1024m * 1024)); }
        }

        /// <summary>
        ///     Get Information in Megabits.
        /// </summary>
        public double Megabits
        {
            get { return Convert.ToDouble((_bits) / 1e6m); }
        }

        /// <summary>
        ///     Get Information in Megabytes.
        /// </summary>
        public double Megabytes
        {
            get { return Convert.ToDouble((_bits/8m) / 1e6m); }
        }

        /// <summary>
        ///     Get Information in Pebibits.
        /// </summary>
        public double Pebibits
        {
            get { return Convert.ToDouble((_bits) / (1024m * 1024 * 1024 * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Pebibytes.
        /// </summary>
        public double Pebibytes
        {
            get { return Convert.ToDouble((_bits/8m) / (1024m * 1024 * 1024 * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Petabits.
        /// </summary>
        public double Petabits
        {
            get { return Convert.ToDouble((_bits) / 1e15m); }
        }

        /// <summary>
        ///     Get Information in Petabytes.
        /// </summary>
        public double Petabytes
        {
            get { return Convert.ToDouble((_bits/8m) / 1e15m); }
        }

        /// <summary>
        ///     Get Information in Tebibits.
        /// </summary>
        public double Tebibits
        {
            get { return Convert.ToDouble((_bits) / (1024m * 1024 * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Tebibytes.
        /// </summary>
        public double Tebibytes
        {
            get { return Convert.ToDouble((_bits/8m) / (1024m * 1024 * 1024 * 1024)); }
        }

        /// <summary>
        ///     Get Information in Terabits.
        /// </summary>
        public double Terabits
        {
            get { return Convert.ToDouble((_bits) / 1e12m); }
        }

        /// <summary>
        ///     Get Information in Terabytes.
        /// </summary>
        public double Terabytes
        {
            get { return Convert.ToDouble((_bits/8m) / 1e12m); }
        }

        #endregion

        #region Static 

        public static Information Zero
        {
            get { return new Information(); }
        }

        /// <summary>
        ///     Get Information from Bits.
        /// </summary>
        public static Information FromBits(double bits)
        {
            return new Information(Convert.ToDecimal(bits));
        }

        /// <summary>
        ///     Get Information from Bytes.
        /// </summary>
        public static Information FromBytes(double bytes)
        {
            return new Information(Convert.ToDecimal(bytes*8d));
        }

        /// <summary>
        ///     Get Information from Exabits.
        /// </summary>
        public static Information FromExabits(double exabits)
        {
            return new Information(Convert.ToDecimal((exabits) * 1e18d));
        }

        /// <summary>
        ///     Get Information from Exabytes.
        /// </summary>
        public static Information FromExabytes(double exabytes)
        {
            return new Information(Convert.ToDecimal((exabytes*8d) * 1e18d));
        }

        /// <summary>
        ///     Get Information from Exbibits.
        /// </summary>
        public static Information FromExbibits(double exbibits)
        {
            return new Information(Convert.ToDecimal((exbibits) * (1024d * 1024 * 1024 * 1024 * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Exbibytes.
        /// </summary>
        public static Information FromExbibytes(double exbibytes)
        {
            return new Information(Convert.ToDecimal((exbibytes*8d) * (1024d * 1024 * 1024 * 1024 * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Gibibits.
        /// </summary>
        public static Information FromGibibits(double gibibits)
        {
            return new Information(Convert.ToDecimal((gibibits) * (1024d * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Gibibytes.
        /// </summary>
        public static Information FromGibibytes(double gibibytes)
        {
            return new Information(Convert.ToDecimal((gibibytes*8d) * (1024d * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Gigabits.
        /// </summary>
        public static Information FromGigabits(double gigabits)
        {
            return new Information(Convert.ToDecimal((gigabits) * 1e9d));
        }

        /// <summary>
        ///     Get Information from Gigabytes.
        /// </summary>
        public static Information FromGigabytes(double gigabytes)
        {
            return new Information(Convert.ToDecimal((gigabytes*8d) * 1e9d));
        }

        /// <summary>
        ///     Get Information from Kibibits.
        /// </summary>
        public static Information FromKibibits(double kibibits)
        {
            return new Information(Convert.ToDecimal((kibibits) * 1024d));
        }

        /// <summary>
        ///     Get Information from Kibibytes.
        /// </summary>
        public static Information FromKibibytes(double kibibytes)
        {
            return new Information(Convert.ToDecimal((kibibytes*8d) * 1024d));
        }

        /// <summary>
        ///     Get Information from Kilobits.
        /// </summary>
        public static Information FromKilobits(double kilobits)
        {
            return new Information(Convert.ToDecimal((kilobits) * 1e3d));
        }

        /// <summary>
        ///     Get Information from Kilobytes.
        /// </summary>
        public static Information FromKilobytes(double kilobytes)
        {
            return new Information(Convert.ToDecimal((kilobytes*8d) * 1e3d));
        }

        /// <summary>
        ///     Get Information from Mebibits.
        /// </summary>
        public static Information FromMebibits(double mebibits)
        {
            return new Information(Convert.ToDecimal((mebibits) * (1024d * 1024)));
        }

        /// <summary>
        ///     Get Information from Mebibytes.
        /// </summary>
        public static Information FromMebibytes(double mebibytes)
        {
            return new Information(Convert.ToDecimal((mebibytes*8d) * (1024d * 1024)));
        }

        /// <summary>
        ///     Get Information from Megabits.
        /// </summary>
        public static Information FromMegabits(double megabits)
        {
            return new Information(Convert.ToDecimal((megabits) * 1e6d));
        }

        /// <summary>
        ///     Get Information from Megabytes.
        /// </summary>
        public static Information FromMegabytes(double megabytes)
        {
            return new Information(Convert.ToDecimal((megabytes*8d) * 1e6d));
        }

        /// <summary>
        ///     Get Information from Pebibits.
        /// </summary>
        public static Information FromPebibits(double pebibits)
        {
            return new Information(Convert.ToDecimal((pebibits) * (1024d * 1024 * 1024 * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Pebibytes.
        /// </summary>
        public static Information FromPebibytes(double pebibytes)
        {
            return new Information(Convert.ToDecimal((pebibytes*8d) * (1024d * 1024 * 1024 * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Petabits.
        /// </summary>
        public static Information FromPetabits(double petabits)
        {
            return new Information(Convert.ToDecimal((petabits) * 1e15d));
        }

        /// <summary>
        ///     Get Information from Petabytes.
        /// </summary>
        public static Information FromPetabytes(double petabytes)
        {
            return new Information(Convert.ToDecimal((petabytes*8d) * 1e15d));
        }

        /// <summary>
        ///     Get Information from Tebibits.
        /// </summary>
        public static Information FromTebibits(double tebibits)
        {
            return new Information(Convert.ToDecimal((tebibits) * (1024d * 1024 * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Tebibytes.
        /// </summary>
        public static Information FromTebibytes(double tebibytes)
        {
            return new Information(Convert.ToDecimal((tebibytes*8d) * (1024d * 1024 * 1024 * 1024)));
        }

        /// <summary>
        ///     Get Information from Terabits.
        /// </summary>
        public static Information FromTerabits(double terabits)
        {
            return new Information(Convert.ToDecimal((terabits) * 1e12d));
        }

        /// <summary>
        ///     Get Information from Terabytes.
        /// </summary>
        public static Information FromTerabytes(double terabytes)
        {
            return new Information(Convert.ToDecimal((terabytes*8d) * 1e12d));
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="InformationUnit" /> to <see cref="Information" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Information unit value.</returns>
        public static Information From(double value, InformationUnit fromUnit)
        {
            switch (fromUnit)
            {
                case InformationUnit.Bit:
                    return FromBits(value);
                case InformationUnit.Byte:
                    return FromBytes(value);
                case InformationUnit.Exabit:
                    return FromExabits(value);
                case InformationUnit.Exabyte:
                    return FromExabytes(value);
                case InformationUnit.Exbibit:
                    return FromExbibits(value);
                case InformationUnit.Exbibyte:
                    return FromExbibytes(value);
                case InformationUnit.Gibibit:
                    return FromGibibits(value);
                case InformationUnit.Gibibyte:
                    return FromGibibytes(value);
                case InformationUnit.Gigabit:
                    return FromGigabits(value);
                case InformationUnit.Gigabyte:
                    return FromGigabytes(value);
                case InformationUnit.Kibibit:
                    return FromKibibits(value);
                case InformationUnit.Kibibyte:
                    return FromKibibytes(value);
                case InformationUnit.Kilobit:
                    return FromKilobits(value);
                case InformationUnit.Kilobyte:
                    return FromKilobytes(value);
                case InformationUnit.Mebibit:
                    return FromMebibits(value);
                case InformationUnit.Mebibyte:
                    return FromMebibytes(value);
                case InformationUnit.Megabit:
                    return FromMegabits(value);
                case InformationUnit.Megabyte:
                    return FromMegabytes(value);
                case InformationUnit.Pebibit:
                    return FromPebibits(value);
                case InformationUnit.Pebibyte:
                    return FromPebibytes(value);
                case InformationUnit.Petabit:
                    return FromPetabits(value);
                case InformationUnit.Petabyte:
                    return FromPetabytes(value);
                case InformationUnit.Tebibit:
                    return FromTebibits(value);
                case InformationUnit.Tebibyte:
                    return FromTebibytes(value);
                case InformationUnit.Terabit:
                    return FromTerabits(value);
                case InformationUnit.Terabyte:
                    return FromTerabytes(value);

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
        public static string GetAbbreviation(InformationUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Information operator -(Information right)
        {
            return new Information(-right._bits);
        }

        public static Information operator +(Information left, Information right)
        {
            return new Information(left._bits + right._bits);
        }

        public static Information operator -(Information left, Information right)
        {
            return new Information(left._bits - right._bits);
        }

        public static Information operator *(decimal left, Information right)
        {
            return new Information(left*right._bits);
        }

        public static Information operator *(Information left, double right)
        {
            return new Information(left._bits*(decimal)right);
        }

        public static Information operator /(Information left, double right)
        {
            return new Information(left._bits/(decimal)right);
        }

        public static double operator /(Information left, Information right)
        {
            return Convert.ToDouble(left._bits/right._bits);
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Information)) throw new ArgumentException("Expected type Information.", "obj");
            return CompareTo((Information) obj);
        }

        public int CompareTo(Information other)
        {
            return _bits.CompareTo(other._bits);
        }

        public static bool operator <=(Information left, Information right)
        {
            return left._bits <= right._bits;
        }

        public static bool operator >=(Information left, Information right)
        {
            return left._bits >= right._bits;
        }

        public static bool operator <(Information left, Information right)
        {
            return left._bits < right._bits;
        }

        public static bool operator >(Information left, Information right)
        {
            return left._bits > right._bits;
        }

        public static bool operator ==(Information left, Information right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._bits == right._bits;
        }

        public static bool operator !=(Information left, Information right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._bits != right._bits;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _bits.Equals(((Information) obj)._bits);
        }

        public override int GetHashCode()
        {
            return _bits.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(InformationUnit unit)
        {
            switch (unit)
            {
                case InformationUnit.Bit:
                    return Bits;
                case InformationUnit.Byte:
                    return Bytes;
                case InformationUnit.Exabit:
                    return Exabits;
                case InformationUnit.Exabyte:
                    return Exabytes;
                case InformationUnit.Exbibit:
                    return Exbibits;
                case InformationUnit.Exbibyte:
                    return Exbibytes;
                case InformationUnit.Gibibit:
                    return Gibibits;
                case InformationUnit.Gibibyte:
                    return Gibibytes;
                case InformationUnit.Gigabit:
                    return Gigabits;
                case InformationUnit.Gigabyte:
                    return Gigabytes;
                case InformationUnit.Kibibit:
                    return Kibibits;
                case InformationUnit.Kibibyte:
                    return Kibibytes;
                case InformationUnit.Kilobit:
                    return Kilobits;
                case InformationUnit.Kilobyte:
                    return Kilobytes;
                case InformationUnit.Mebibit:
                    return Mebibits;
                case InformationUnit.Mebibyte:
                    return Mebibytes;
                case InformationUnit.Megabit:
                    return Megabits;
                case InformationUnit.Megabyte:
                    return Megabytes;
                case InformationUnit.Pebibit:
                    return Pebibits;
                case InformationUnit.Pebibyte:
                    return Pebibytes;
                case InformationUnit.Petabit:
                    return Petabits;
                case InformationUnit.Petabyte:
                    return Petabytes;
                case InformationUnit.Tebibit:
                    return Tebibits;
                case InformationUnit.Tebibyte:
                    return Tebibytes;
                case InformationUnit.Terabit:
                    return Terabits;
                case InformationUnit.Terabyte:
                    return Terabytes;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        ///     Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        [UsedImplicitly]
        public string ToString(InformationUnit unit, CultureInfo culture = null)
        {
            return ToString(unit, culture, "{0:0.##} {1}");
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
        public string ToString(InformationUnit unit, CultureInfo culture, string format, params object[] args)
        {
            string abbreviation = UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
            object[] finalArgs = new object[] {As(unit), abbreviation}
                .Concat(args)
                .ToArray();

            return string.Format(culture, format, finalArgs);
        }

        /// <summary>
        ///     Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(InformationUnit.Bit);
        }
    }
}
