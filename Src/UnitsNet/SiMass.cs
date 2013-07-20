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
    ///     A class for representing mass, according to the International System of Units (SI).
    /// </summary>
    public class SiMass : IComparable, IComparable<SiMass>
    {
        /// <summary>
        ///     Returns a kilogram representation of the mass instance.
        /// </summary>
        public readonly double Kilograms;

        private SiMass(double kilograms)
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

        public double Decigrams
        {
            get { return Kilograms*1E2; }
        }

        public double Grams
        {
            get { return Kilograms*1E3; }
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

        public static SiMass FromMegatonnes(double megatonnes)
        {
            return new SiMass(megatonnes*1E9);
        }

        public static SiMass FromKilotonnes(double kt)
        {
            return new SiMass(kt*1E6);
        }

        public static SiMass FromTonnes(double t)
        {
            return new SiMass(t*1E3);
        }

        public static SiMass FromKilograms(double kilograms)
        {
            return new SiMass(kilograms);
        }

        public static SiMass FromHectograms(double value)
        {
            return new SiMass(value*1E-1);
        }

        public static SiMass FromDecigrams(double value)
        {
            return new SiMass(value*1E-2);
        }

        public static SiMass FromGrams(double value)
        {
            return new SiMass(value*1E-3);
        }

        public static SiMass FromCentigrams(double value)
        {
            return new SiMass(value*1E-5);
        }

        public static SiMass FromMilligrams(double value)
        {
            return new SiMass(value*1E-6);
        }

        #endregion

        #region Arithmetic operators

        /// <summary>
        ///     This operator overload is only intended to be used like -MyDistance, and will
        ///     throw an exception if left side is anything but zero.
        /// </summary>
        /// <param name="right">The SIMass to negativize.</param>
        /// <returns></returns>
        public static SiMass operator -(SiMass right)
        {
            return new SiMass(-right.Kilograms);
        }

        public static SiMass operator +(SiMass left, SiMass right)
        {
            return new SiMass(left.Kilograms + right.Kilograms);
        }

        public static SiMass operator -(SiMass left, SiMass right)
        {
            return new SiMass(left.Kilograms - right.Kilograms);
        }

        public static SiMass operator *(double left, SiMass right)
        {
            return new SiMass(left*right.Kilograms);
        }

        public static SiMass operator /(SiMass left, double right)
        {
            return new SiMass(left.Kilograms/right);
        }

        #region Equality / IComparable

        #endregion

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is SiMass)) throw new ArgumentException("Expected type SiMass.", "obj");
            return CompareTo((SiMass) obj);
        }

        public int CompareTo(SiMass other)
        {
            return Kilograms.CompareTo(other.Kilograms);
        }

        public static bool operator <=(SiMass left, SiMass right)
        {
            return left.Kilograms <= right.Kilograms;
        }

        public static bool operator >=(SiMass left, SiMass right)
        {
            return left.Kilograms >= right.Kilograms;
        }

        public static bool operator <(SiMass left, SiMass right)
        {
            return left.Kilograms < right.Kilograms;
        }

        public static bool operator >(SiMass left, SiMass right)
        {
            return left.Kilograms > right.Kilograms;
        }

        #endregion

        public override string ToString()
        {
            return Kilograms.ToString("#0.0") + " " +
                   SiUnitSystem.Create(CultureInfo.CurrentCulture).GetDefaultAbbreviation(SiUnit.Kilogram);
        }
    }
}