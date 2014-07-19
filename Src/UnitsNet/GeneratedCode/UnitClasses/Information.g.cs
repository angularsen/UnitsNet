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
using UnitsNet.Annotations;
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
        [UsedImplicitly] public readonly double Bits;

        public Information(double bits) : this()
        {
            Bits = bits;
        }

        #region Properties

        /// <summary>
        ///     Get Information in Bytes.
        /// </summary>
        public double Bytes
        {
            get { return Bits/8; }
        }

        /// <summary>
        ///     Get Information in Exabytes.
        /// </summary>
        public double Exabytes
        {
            get { return (Bits/8) / 1e18; }
        }

        /// <summary>
        ///     Get Information in Gigabytes.
        /// </summary>
        public double Gigabytes
        {
            get { return (Bits/8) / 1e9; }
        }

        /// <summary>
        ///     Get Information in Kilobytes.
        /// </summary>
        public double Kilobytes
        {
            get { return (Bits/8) / 1e3; }
        }

        /// <summary>
        ///     Get Information in Megabytes.
        /// </summary>
        public double Megabytes
        {
            get { return (Bits/8) / 1e6; }
        }

        /// <summary>
        ///     Get Information in Petabytes.
        /// </summary>
        public double Petabytes
        {
            get { return (Bits/8) / 1e15; }
        }

        /// <summary>
        ///     Get Information in Terabytes.
        /// </summary>
        public double Terabytes
        {
            get { return (Bits/8) / 1e12; }
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
            return new Information(bits);
        }

        /// <summary>
        ///     Get Information from Bytes.
        /// </summary>
        public static Information FromBytes(double bytes)
        {
            return new Information(bytes*8);
        }

        /// <summary>
        ///     Get Information from Exabytes.
        /// </summary>
        public static Information FromExabytes(double exabytes)
        {
            return new Information((exabytes*8) * 1e18);
        }

        /// <summary>
        ///     Get Information from Gigabytes.
        /// </summary>
        public static Information FromGigabytes(double gigabytes)
        {
            return new Information((gigabytes*8) * 1e9);
        }

        /// <summary>
        ///     Get Information from Kilobytes.
        /// </summary>
        public static Information FromKilobytes(double kilobytes)
        {
            return new Information((kilobytes*8) * 1e3);
        }

        /// <summary>
        ///     Get Information from Megabytes.
        /// </summary>
        public static Information FromMegabytes(double megabytes)
        {
            return new Information((megabytes*8) * 1e6);
        }

        /// <summary>
        ///     Get Information from Petabytes.
        /// </summary>
        public static Information FromPetabytes(double petabytes)
        {
            return new Information((petabytes*8) * 1e15);
        }

        /// <summary>
        ///     Get Information from Terabytes.
        /// </summary>
        public static Information FromTerabytes(double terabytes)
        {
            return new Information((terabytes*8) * 1e12);
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
                case InformationUnit.Exabyte:
                    return FromExabytes(value);
                case InformationUnit.Gigabyte:
                    return FromGigabytes(value);
                case InformationUnit.Kilobyte:
                    return FromKilobytes(value);
                case InformationUnit.Megabyte:
                    return FromMegabytes(value);
                case InformationUnit.Petabyte:
                    return FromPetabytes(value);
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
            return new Information(-right.Bits);
        }

        public static Information operator +(Information left, Information right)
        {
            return new Information(left.Bits + right.Bits);
        }

        public static Information operator -(Information left, Information right)
        {
            return new Information(left.Bits - right.Bits);
        }

        public static Information operator *(double left, Information right)
        {
            return new Information(left*right.Bits);
        }

        public static Information operator *(Information left, double right)
        {
            return new Information(left.Bits*right);
        }

        public static Information operator /(Information left, double right)
        {
            return new Information(left.Bits/right);
        }

        public static double operator /(Information left, Information right)
        {
            return left.Bits/right.Bits;
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
            return Bits.CompareTo(other.Bits);
        }

        public static bool operator <=(Information left, Information right)
        {
            return left.Bits <= right.Bits;
        }

        public static bool operator >=(Information left, Information right)
        {
            return left.Bits >= right.Bits;
        }

        public static bool operator <(Information left, Information right)
        {
            return left.Bits < right.Bits;
        }

        public static bool operator >(Information left, Information right)
        {
            return left.Bits > right.Bits;
        }

        public static bool operator ==(Information left, Information right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Bits == right.Bits;
        }

        public static bool operator !=(Information left, Information right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left.Bits != right.Bits;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Bits.Equals(((Information) obj).Bits);
        }

        public override int GetHashCode()
        {
            return Bits.GetHashCode();
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
                case InformationUnit.Exabyte:
                    return Exabytes;
                case InformationUnit.Gigabyte:
                    return Gigabytes;
                case InformationUnit.Kilobyte:
                    return Kilobytes;
                case InformationUnit.Megabyte:
                    return Megabytes;
                case InformationUnit.Petabyte:
                    return Petabytes;
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
