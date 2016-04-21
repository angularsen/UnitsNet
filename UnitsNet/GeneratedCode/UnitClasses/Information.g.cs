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
    ///     In computing and telecommunications, a unit of information is the capacity of some standard data storage system or communication channel, used to measure the capacities of other systems and channels. In information theory, units of information are also used to measure the information contents or entropy of random variables.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
#if WINDOWS_UWP
    public sealed partial class Information
#else
    public partial struct Information : IComparable, IComparable<Information>
#endif
    {
        /// <summary>
        ///     Base unit of Information.
        /// </summary>
        private readonly decimal _bits;

#if WINDOWS_UWP
        public Information() : this(0)
        {
        }
#endif

        public Information(double bits)
        {
            _bits = Convert.ToDecimal(bits);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Information(long bits)
        {
            _bits = Convert.ToDecimal(bits);
        }

        // Method overloads and with same number of parameters not supported in Universal Windows Platform (WinRT Components).
        // Decimal type not supported in Universal Windows Platform (WinRT Components).
#if WINDOWS_UWP
        private
#else
        public
#endif
        Information(decimal bits)
        {
            _bits = Convert.ToDecimal(bits);
        }

        #region Properties

        public static InformationUnit BaseUnit
        {
            get { return InformationUnit.Bit; }
        }

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

#if !WINDOWS_UWP
        /// <summary>
        ///     Get nullable Information from nullable Bits.
        /// </summary>
        public static Information? FromBits(double? bits)
        {
            if (bits.HasValue)
            {
                return FromBits(bits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Bytes.
        /// </summary>
        public static Information? FromBytes(double? bytes)
        {
            if (bytes.HasValue)
            {
                return FromBytes(bytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Exabits.
        /// </summary>
        public static Information? FromExabits(double? exabits)
        {
            if (exabits.HasValue)
            {
                return FromExabits(exabits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Exabytes.
        /// </summary>
        public static Information? FromExabytes(double? exabytes)
        {
            if (exabytes.HasValue)
            {
                return FromExabytes(exabytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Exbibits.
        /// </summary>
        public static Information? FromExbibits(double? exbibits)
        {
            if (exbibits.HasValue)
            {
                return FromExbibits(exbibits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Exbibytes.
        /// </summary>
        public static Information? FromExbibytes(double? exbibytes)
        {
            if (exbibytes.HasValue)
            {
                return FromExbibytes(exbibytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Gibibits.
        /// </summary>
        public static Information? FromGibibits(double? gibibits)
        {
            if (gibibits.HasValue)
            {
                return FromGibibits(gibibits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Gibibytes.
        /// </summary>
        public static Information? FromGibibytes(double? gibibytes)
        {
            if (gibibytes.HasValue)
            {
                return FromGibibytes(gibibytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Gigabits.
        /// </summary>
        public static Information? FromGigabits(double? gigabits)
        {
            if (gigabits.HasValue)
            {
                return FromGigabits(gigabits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Gigabytes.
        /// </summary>
        public static Information? FromGigabytes(double? gigabytes)
        {
            if (gigabytes.HasValue)
            {
                return FromGigabytes(gigabytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Kibibits.
        /// </summary>
        public static Information? FromKibibits(double? kibibits)
        {
            if (kibibits.HasValue)
            {
                return FromKibibits(kibibits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Kibibytes.
        /// </summary>
        public static Information? FromKibibytes(double? kibibytes)
        {
            if (kibibytes.HasValue)
            {
                return FromKibibytes(kibibytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Kilobits.
        /// </summary>
        public static Information? FromKilobits(double? kilobits)
        {
            if (kilobits.HasValue)
            {
                return FromKilobits(kilobits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Kilobytes.
        /// </summary>
        public static Information? FromKilobytes(double? kilobytes)
        {
            if (kilobytes.HasValue)
            {
                return FromKilobytes(kilobytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Mebibits.
        /// </summary>
        public static Information? FromMebibits(double? mebibits)
        {
            if (mebibits.HasValue)
            {
                return FromMebibits(mebibits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Mebibytes.
        /// </summary>
        public static Information? FromMebibytes(double? mebibytes)
        {
            if (mebibytes.HasValue)
            {
                return FromMebibytes(mebibytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Megabits.
        /// </summary>
        public static Information? FromMegabits(double? megabits)
        {
            if (megabits.HasValue)
            {
                return FromMegabits(megabits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Megabytes.
        /// </summary>
        public static Information? FromMegabytes(double? megabytes)
        {
            if (megabytes.HasValue)
            {
                return FromMegabytes(megabytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Pebibits.
        /// </summary>
        public static Information? FromPebibits(double? pebibits)
        {
            if (pebibits.HasValue)
            {
                return FromPebibits(pebibits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Pebibytes.
        /// </summary>
        public static Information? FromPebibytes(double? pebibytes)
        {
            if (pebibytes.HasValue)
            {
                return FromPebibytes(pebibytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Petabits.
        /// </summary>
        public static Information? FromPetabits(double? petabits)
        {
            if (petabits.HasValue)
            {
                return FromPetabits(petabits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Petabytes.
        /// </summary>
        public static Information? FromPetabytes(double? petabytes)
        {
            if (petabytes.HasValue)
            {
                return FromPetabytes(petabytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Tebibits.
        /// </summary>
        public static Information? FromTebibits(double? tebibits)
        {
            if (tebibits.HasValue)
            {
                return FromTebibits(tebibits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Tebibytes.
        /// </summary>
        public static Information? FromTebibytes(double? tebibytes)
        {
            if (tebibytes.HasValue)
            {
                return FromTebibytes(tebibytes.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Terabits.
        /// </summary>
        public static Information? FromTerabits(double? terabits)
        {
            if (terabits.HasValue)
            {
                return FromTerabits(terabits.Value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///     Get nullable Information from nullable Terabytes.
        /// </summary>
        public static Information? FromTerabytes(double? terabytes)
        {
            if (terabytes.HasValue)
            {
                return FromTerabytes(terabytes.Value);
            }
            else
            {
                return null;
            }
        }

#endif

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="InformationUnit" /> to <see cref="Information" />.
        /// </summary>
        /// <param name="val">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Information unit value.</returns>
        public static Information From(double val, InformationUnit fromUnit)
        {
            switch (fromUnit)
            {
                case InformationUnit.Bit:
                    return FromBits(val);
                case InformationUnit.Byte:
                    return FromBytes(val);
                case InformationUnit.Exabit:
                    return FromExabits(val);
                case InformationUnit.Exabyte:
                    return FromExabytes(val);
                case InformationUnit.Exbibit:
                    return FromExbibits(val);
                case InformationUnit.Exbibyte:
                    return FromExbibytes(val);
                case InformationUnit.Gibibit:
                    return FromGibibits(val);
                case InformationUnit.Gibibyte:
                    return FromGibibytes(val);
                case InformationUnit.Gigabit:
                    return FromGigabits(val);
                case InformationUnit.Gigabyte:
                    return FromGigabytes(val);
                case InformationUnit.Kibibit:
                    return FromKibibits(val);
                case InformationUnit.Kibibyte:
                    return FromKibibytes(val);
                case InformationUnit.Kilobit:
                    return FromKilobits(val);
                case InformationUnit.Kilobyte:
                    return FromKilobytes(val);
                case InformationUnit.Mebibit:
                    return FromMebibits(val);
                case InformationUnit.Mebibyte:
                    return FromMebibytes(val);
                case InformationUnit.Megabit:
                    return FromMegabits(val);
                case InformationUnit.Megabyte:
                    return FromMegabytes(val);
                case InformationUnit.Pebibit:
                    return FromPebibits(val);
                case InformationUnit.Pebibyte:
                    return FromPebibytes(val);
                case InformationUnit.Petabit:
                    return FromPetabits(val);
                case InformationUnit.Petabyte:
                    return FromPetabytes(val);
                case InformationUnit.Tebibit:
                    return FromTebibits(val);
                case InformationUnit.Tebibyte:
                    return FromTebibytes(val);
                case InformationUnit.Terabit:
                    return FromTerabits(val);
                case InformationUnit.Terabyte:
                    return FromTerabytes(val);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }

#if !WINDOWS_UWP
        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="InformationUnit" /> to <see cref="Information" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Information unit value.</returns>
        public static Information? From(double? value, InformationUnit fromUnit)
        {
            if (!value.HasValue)
            {
                return null;
            }
            switch (fromUnit)
            {
                case InformationUnit.Bit:
                    return FromBits(value.Value);
                case InformationUnit.Byte:
                    return FromBytes(value.Value);
                case InformationUnit.Exabit:
                    return FromExabits(value.Value);
                case InformationUnit.Exabyte:
                    return FromExabytes(value.Value);
                case InformationUnit.Exbibit:
                    return FromExbibits(value.Value);
                case InformationUnit.Exbibyte:
                    return FromExbibytes(value.Value);
                case InformationUnit.Gibibit:
                    return FromGibibits(value.Value);
                case InformationUnit.Gibibyte:
                    return FromGibibytes(value.Value);
                case InformationUnit.Gigabit:
                    return FromGigabits(value.Value);
                case InformationUnit.Gigabyte:
                    return FromGigabytes(value.Value);
                case InformationUnit.Kibibit:
                    return FromKibibits(value.Value);
                case InformationUnit.Kibibyte:
                    return FromKibibytes(value.Value);
                case InformationUnit.Kilobit:
                    return FromKilobits(value.Value);
                case InformationUnit.Kilobyte:
                    return FromKilobytes(value.Value);
                case InformationUnit.Mebibit:
                    return FromMebibits(value.Value);
                case InformationUnit.Mebibyte:
                    return FromMebibytes(value.Value);
                case InformationUnit.Megabit:
                    return FromMegabits(value.Value);
                case InformationUnit.Megabyte:
                    return FromMegabytes(value.Value);
                case InformationUnit.Pebibit:
                    return FromPebibits(value.Value);
                case InformationUnit.Pebibyte:
                    return FromPebibytes(value.Value);
                case InformationUnit.Petabit:
                    return FromPetabits(value.Value);
                case InformationUnit.Petabyte:
                    return FromPetabytes(value.Value);
                case InformationUnit.Tebibit:
                    return FromTebibits(value.Value);
                case InformationUnit.Tebibyte:
                    return FromTebibytes(value.Value);
                case InformationUnit.Terabit:
                    return FromTerabits(value.Value);
                case InformationUnit.Terabyte:
                    return FromTerabytes(value.Value);

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
        public static string GetAbbreviation(InformationUnit unit)
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
        public static string GetAbbreviation(InformationUnit unit, [CanBeNull] Culture culture)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

#if !WINDOWS_UWP
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
#endif

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Information)) throw new ArgumentException("Expected type Information.", "obj");
            return CompareTo((Information) obj);
        }

#if WINDOWS_UWP
        internal
#else
        public
#endif
        int CompareTo(Information other)
        {
            return _bits.CompareTo(other._bits);
        }

#if !WINDOWS_UWP
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
#endif

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
        public static Information Parse(string str)
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
        public static Information Parse(string str, [CanBeNull] Culture culture)
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
            return quantities.Aggregate((x, y) => Information.FromBits(x.Bits + y.Bits));
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<Information> ParseWithRegex(string regexString, string str, IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<Information>();

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
                    InformationUnit unit = ParseUnit(unitString, formatProvider);
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
        public static InformationUnit ParseUnit(string str)
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
        public static InformationUnit ParseUnit(string str, [CanBeNull] string cultureName)
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
        static InformationUnit ParseUnit(string str, IFormatProvider formatProvider = null)
        {
            if (str == null) throw new ArgumentNullException("str");

            var unitSystem = UnitSystem.GetCached(formatProvider);
            var unit = unitSystem.Parse<InformationUnit>(str.Trim());

            if (unit == InformationUnit.Undefined)
            {
                var newEx = new UnitsNetException("Error parsing string. The unit is not a recognized InformationUnit.");
                newEx.Data["input"] = str;
                newEx.Data["formatprovider"] = formatProvider?.ToString() ?? "(null)";
                throw newEx;
            }

            return unit;
        }

        #endregion

        /// <summary>
        ///     Set the default unit used by ToString(). Default is Bit
        /// </summary>
        public static InformationUnit ToStringDefaultUnit { get; set; } = InformationUnit.Bit;

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
        public string ToString(InformationUnit unit)
        {
            return ToString(unit, null, 2);
        }

        /// <summary>
        ///     Get string representation of value and unit. Using two significant digits after radix.
        /// </summary>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <returns>String representation.</returns>
        public string ToString(InformationUnit unit, [CanBeNull] Culture culture)
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
        public string ToString(InformationUnit unit, [CanBeNull] Culture culture, int significantDigitsAfterRadix)
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
        public string ToString(InformationUnit unit, [CanBeNull] Culture culture, [NotNull] string format,
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
        /// Represents the largest possible value of Information
        /// </summary>
        public static Information MaxValue
        {
            get
            {
                return new Information(decimal.MaxValue);
            }
        }

        /// <summary>
        /// Represents the smallest possible value of Information
        /// </summary>
        public static Information MinValue
        {
            get
            {
                return new Information(decimal.MinValue);
            }
        }
    }
}
