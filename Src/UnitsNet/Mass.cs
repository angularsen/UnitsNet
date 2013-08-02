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
    public struct Mass : IComparable, IComparable<Mass>
    {
        private const double ShortTonToKilogramsRatio = 907.18474;
        private const double LongTonToKilogramRatio = 1016.0469088;

        /// <summary>
        ///     Returns a kilogram representation of the mass instance.
        /// </summary>
        public readonly double Kilograms;

        private Mass(double kilograms)
        {
            Kilograms = kilograms;
        }

        /// <summary>
        /// The short ton is a unit of mass equal to 2,000 pounds (907.18474 kg), that is most commonly used in the United States – known there simply as the ton. 
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Short_ton</remarks>
        public double ShortTons
        {
            get { return Kilograms/ShortTonToKilogramsRatio; }
        }

        /// <summary>
        /// Long ton (weight ton or Imperial ton) is a unit of mass equal to 2,240 pounds (1,016 kg) and is the name for the unit called the "ton" in the avoirdupois or Imperial system of measurements that was used in the United Kingdom and several other Commonwealth countries before metrication.
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Long_ton</remarks>
        public double LongTons
        {
            get { return Kilograms/LongTonToKilogramRatio; }
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

        /// <summary>
        ///     The maximum representable distance in kilograms.
        /// </summary>
        public static Mass Max
        {
            get { return new Mass(double.MaxValue); }
        }

        /// <summary>
        ///     The smallest representable distance in kilograms.
        /// </summary>
        public static Mass Min
        {
            get { return new Mass(double.MinValue); }
        }

        public static Mass Zero
        {
            get { return new Mass(); }
        }


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

        public static Mass FromGravitationalForce(Force f)
        {
            return new Mass(f.KilogramForce);
        }

        /// <summary>
        /// Long ton (weight ton or Imperial ton) is a unit of mass equal to 2,240 pounds (1,016 kg) and is the name for the unit called the "ton" in the avoirdupois or Imperial system of measurements that was used in the United Kingdom and several other Commonwealth countries before metrication.
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Long_ton</remarks>
        public static Mass FromLongTons(double value)
        {
            return new Mass(value*LongTonToKilogramRatio);
        }

        /// <summary>
        /// The short ton is a unit of mass equal to 2,000 pounds (907.18474 kg), that is most commonly used in the United States – known there simply as the ton. 
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Short_ton</remarks>
        public static Mass FromShortTons(double value)
        {
            return new Mass(value*ShortTonToKilogramsRatio);
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

        public static Mass operator *(Mass left, double right)
        {
            return new Mass(left.Kilograms*right);
        }

        public static Mass operator *(double left, Mass right)
        {
            return new Mass(left*right.Kilograms);
        }

        public static Mass operator *(Mass left, Mass right)
        {
            return new Mass(left.Kilograms*right.Kilograms);
        }

        public static Mass operator /(Mass left, Mass right)
        {
            return new Mass(left.Kilograms/right.Kilograms);
        }

        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left.Kilograms/right);
        }

        #endregion

        #region Comparison / Equality Operators

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

        public static bool operator !=(Mass left, Mass right)
        {
            return left.Kilograms != right.Kilograms;
        }

        public static bool operator ==(Mass left, Mass right)
        {
            return left.Kilograms == right.Kilograms;
        }

        #endregion

        #region Equality / IComparable

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

        public bool Equals(Mass other)
        {
            return Kilograms.Equals(other.Kilograms);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Mass && ((Mass) obj).Kilograms.Equals(Kilograms);
        }

        public override int GetHashCode()
        {
            return Kilograms.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return Kilograms.ToString("#0.0") + " " +
                   UnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(Unit.Kilogram);
        }
    }
}