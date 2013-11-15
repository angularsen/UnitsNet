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

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// In physics, mass (from Greek μᾶζα "barley cake, lump [of dough]") is a property of a physical system or body, giving rise to the phenomena of the body's resistance to being accelerated by a force and the strength of its mutual gravitational attraction with other bodies. Instruments such as mass balances or scales use those phenomena to measure mass. The SI unit of mass is the kilogram (kg).
    /// </summary>
    public partial struct Mass : IComparable, IComparable<Mass>
    {
        /// <summary>
        /// Base unit of Mass in kilograms.
        /// </summary>
        public readonly double Kilograms;

        public Mass(double kilograms) : this()
        {
            Kilograms = kilograms;
        }

        #region Unit Properties

        public double Centigrams
        {
            get { return Kilograms/1E-05; }
        }

        public double Decagrams
        {
            get { return Kilograms/0.01; }
        }

        public double Decigrams
        {
            get { return Kilograms/0.0001; }
        }

        public double Grams
        {
            get { return Kilograms/0.001; }
        }

        public double Hectograms
        {
            get { return Kilograms/0.1; }
        }

        public double Kilotonnes
        {
            get { return Kilograms/1000000; }
        }

        public double LongTons
        {
            get { return Kilograms/1016.0469088; }
        }

        public double Megatonnes
        {
            get { return Kilograms/1000000000; }
        }

        public double Milligrams
        {
            get { return Kilograms/1E-06; }
        }

        public double ShortTons
        {
            get { return Kilograms/907.18474; }
        }

        public double Tonnes
        {
            get { return Kilograms/1000; }
        }

        #endregion

        #region Static 

        public static Mass Zero
        {
            get { return new Mass(); }
        }
        
        public static Mass FromCentigrams(double centigrams)
        {
            return new Mass(centigrams*1E-05);
        }

        public static Mass FromDecagrams(double decagrams)
        {
            return new Mass(decagrams*0.01);
        }

        public static Mass FromDecigrams(double decigrams)
        {
            return new Mass(decigrams*0.0001);
        }

        public static Mass FromGrams(double grams)
        {
            return new Mass(grams*0.001);
        }

        public static Mass FromHectograms(double hectograms)
        {
            return new Mass(hectograms*0.1);
        }

        public static Mass FromKilograms(double kilograms)
        {
            return new Mass(kilograms*1);
        }

        public static Mass FromKilotonnes(double kilotonnes)
        {
            return new Mass(kilotonnes*1000000);
        }

        public static Mass FromLongTons(double longtons)
        {
            return new Mass(longtons*1016.0469088);
        }

        public static Mass FromMegatonnes(double megatonnes)
        {
            return new Mass(megatonnes*1000000000);
        }

        public static Mass FromMilligrams(double milligrams)
        {
            return new Mass(milligrams*1E-06);
        }

        public static Mass FromShortTons(double shorttons)
        {
            return new Mass(shorttons*907.18474);
        }

        public static Mass FromTonnes(double tonnes)
        {
            return new Mass(tonnes*1000);
        }

        #endregion

        #region Arithmetic Operators

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

        public static Mass operator *(Mass left, double right)
        {
            return new Mass(left.Kilograms*right);
        }

        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left.Kilograms/right);
        }

        public static double operator /(Mass left, Mass right)
        {
            return left.Kilograms/right.Kilograms;
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

        public static bool operator ==(Mass left, Mass right)
        {
            return left.Kilograms == right.Kilograms;
        }

        public static bool operator !=(Mass left, Mass right)
        {
            return left.Kilograms != right.Kilograms;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Kilograms.Equals(((Mass) obj).Kilograms);
        }

        public override int GetHashCode()
        {
            return Kilograms.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Kilograms, UnitSystem.Create().GetDefaultAbbreviation(Unit.Kilogram));
        }
    }
} 
