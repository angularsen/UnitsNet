// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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

namespace UnitsNet
{
    /// <summary>
    ///     A class for representing mass.
    /// </summary>
    public class Mass : IComparable, IComparable<Mass>
    {
        /// <summary>
        ///     Returns a kilogram representation of the mass instance.
        /// </summary>
        public readonly double Kilograms;

        private Mass(double kilograms)
        {
            Kilograms = kilograms;
        }

        public double Megatonnes
        {
            get { return Kilograms*1E-9; }
        }

        public double Kilotonnes
        {
            get { return Kilograms*1E-6; }
        }

        public double Tonnes
        {
            get { return Kilograms*1E-3; }
        }

        public double Hectograms
        {
            get { return Kilograms*1E1; }
        }

        public double Decagrams
        {
            get { return Kilograms*1E2; }
        }

        public double Grams
        {
            get { return Kilograms*1E3; }
        }

        public double Decigrams
        {
            get { return Kilograms*1E4; }
        }

        public double Centigrams
        {
            get { return Kilograms*1E5; }
        }

        public double Milligrams
        {
            get { return Kilograms*1E6; }
        }

        #region Static 

        public static Mass FromMegatonnes(double megatonnes)
        {
            return new Mass(megatonnes*1E9);
        }

        public static Mass FromKilotonnes(double kt)
        {
            return new Mass(kt*1E6);
        }

        public static Mass FromTonnes(double t)
        {
            return new Mass(t*1E3);
        }

        public static Mass FromKilograms(double kilograms)
        {
            return new Mass(kilograms);
        }

        public static Mass FromHectograms(double value)
        {
            return new Mass(value*1E-1);
        }

        public static Mass FromDecagrams(double value)
        {
            return new Mass(value*1E-2);
        }

        public static Mass FromGrams(double value)
        {
            return new Mass(value*1E-3);
        }

        public static Mass FromDecigrams(double value)
        {
            return new Mass(value*1E-4);
        }

        public static Mass FromCentigrams(double value)
        {
            return new Mass(value*1E-5);
        }

        public static Mass FromMilligrams(double value)
        {
            return new Mass(value*1E-6);
        }

        #endregion

        #region Arithmetic operators

        /// <summary>
        ///     This operator overload is only intended to be used like -MyDistance, and will
        ///     throw an exception if left side is anything but zero.
        /// </summary>
        /// <param name="right">The SIMass to negativize.</param>
        /// <returns></returns>
        public static Mass operator -(Mass right)
        {
            return new Mass(-right.Kilograms);
        }

        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left.Kilograms + right.Kilograms);
        }

        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left.Kilograms - right.Kilograms);
        }

        public static Mass operator *(double left, Mass right)
        {
            return new Mass(left*right.Kilograms);
        }

        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left.Kilograms/right);
        }

        #region Equality / IComparable

        #endregion

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Mass)) throw new ArgumentException("Expected type Mass.", "obj");
            return CompareTo((Mass) obj);
        }

        public int CompareTo(Mass other)
        {
            return Kilograms.CompareTo(other.Kilograms);
        }

        public static bool operator <=(Mass left, Mass right)
        {
            return left.Kilograms <= right.Kilograms;
        }

        public static bool operator >=(Mass left, Mass right)
        {
            return left.Kilograms >= right.Kilograms;
        }

        public static bool operator <(Mass left, Mass right)
        {
            return left.Kilograms < right.Kilograms;
        }

        public static bool operator >(Mass left, Mass right)
        {
            return left.Kilograms > right.Kilograms;
        }

        #endregion

        public override string ToString()
        {
            return Kilograms.ToString("#0.0") + " " +
                   UnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(Unit.Kilogram);
        }
    }
}