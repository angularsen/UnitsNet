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
        /// Base unit of Mass.
        /// </summary>
        public readonly double Kilograms;

        public Mass(double kilograms) : this()
        {
            Kilograms = kilograms;
        }

        #region Unit Properties

        /// <summary>
        /// Get Mass in Centigrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Centigrams and y is value in base unit Kilograms.</remarks>
        public double Centigrams
        {
            get { return (Kilograms - (0)) / 1E-05; }
        }

        /// <summary>
        /// Get Mass in Decagrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Decagrams and y is value in base unit Kilograms.</remarks>
        public double Decagrams
        {
            get { return (Kilograms - (0)) / 0.01; }
        }

        /// <summary>
        /// Get Mass in Decigrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Decigrams and y is value in base unit Kilograms.</remarks>
        public double Decigrams
        {
            get { return (Kilograms - (0)) / 0.0001; }
        }

        /// <summary>
        /// Get Mass in Grams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Grams and y is value in base unit Kilograms.</remarks>
        public double Grams
        {
            get { return (Kilograms - (0)) / 0.001; }
        }

        /// <summary>
        /// Get Mass in Hectograms.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Hectograms and y is value in base unit Kilograms.</remarks>
        public double Hectograms
        {
            get { return (Kilograms - (0)) / 0.1; }
        }

        /// <summary>
        /// Get Mass in Kilotonnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Kilotonnes and y is value in base unit Kilograms.</remarks>
        public double Kilotonnes
        {
            get { return (Kilograms - (0)) / 1000000; }
        }

        /// <summary>
        /// Get Mass in LongTons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in LongTons and y is value in base unit Kilograms.</remarks>
        public double LongTons
        {
            get { return (Kilograms - (0)) / 1016.0469088; }
        }

        /// <summary>
        /// Get Mass in Megatonnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Megatonnes and y is value in base unit Kilograms.</remarks>
        public double Megatonnes
        {
            get { return (Kilograms - (0)) / 1000000000; }
        }

        /// <summary>
        /// Get Mass in Micrograms.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Micrograms and y is value in base unit Kilograms.</remarks>
        public double Micrograms
        {
            get { return (Kilograms - (0)) / 1E-09; }
        }

        /// <summary>
        /// Get Mass in Milligrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Milligrams and y is value in base unit Kilograms.</remarks>
        public double Milligrams
        {
            get { return (Kilograms - (0)) / 1E-06; }
        }

        /// <summary>
        /// Get Mass in Nanograms.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Nanograms and y is value in base unit Kilograms.</remarks>
        public double Nanograms
        {
            get { return (Kilograms - (0)) / 1E-12; }
        }

        /// <summary>
        /// Get Mass in Pounds.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Pounds and y is value in base unit Kilograms.</remarks>
        public double Pounds
        {
            get { return (Kilograms - (0)) / 0.45359237; }
        }

        /// <summary>
        /// Get Mass in ShortTons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in ShortTons and y is value in base unit Kilograms.</remarks>
        public double ShortTons
        {
            get { return (Kilograms - (0)) / 907.18474; }
        }

        /// <summary>
        /// Get Mass in Tonnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Tonnes and y is value in base unit Kilograms.</remarks>
        public double Tonnes
        {
            get { return (Kilograms - (0)) / 1000; }
        }

        #endregion

        #region Static 

        public static Mass Zero
        {
            get { return new Mass(); }
        }
        
        /// <summary>
        /// Get Mass from Centigrams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Centigrams and y is value in base unit Kilograms.</remarks>
        public static Mass FromCentigrams(double centigrams)
        {
            return new Mass(1E-05 * centigrams + 0);
        }

        /// <summary>
        /// Get Mass from Decagrams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Decagrams and y is value in base unit Kilograms.</remarks>
        public static Mass FromDecagrams(double decagrams)
        {
            return new Mass(0.01 * decagrams + 0);
        }

        /// <summary>
        /// Get Mass from Decigrams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Decigrams and y is value in base unit Kilograms.</remarks>
        public static Mass FromDecigrams(double decigrams)
        {
            return new Mass(0.0001 * decigrams + 0);
        }

        /// <summary>
        /// Get Mass from Grams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Grams and y is value in base unit Kilograms.</remarks>
        public static Mass FromGrams(double grams)
        {
            return new Mass(0.001 * grams + 0);
        }

        /// <summary>
        /// Get Mass from Hectograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Hectograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromHectograms(double hectograms)
        {
            return new Mass(0.1 * hectograms + 0);
        }

        /// <summary>
        /// Get Mass from Kilograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kilograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromKilograms(double kilograms)
        {
            return new Mass(1 * kilograms + 0);
        }

        /// <summary>
        /// Get Mass from Kilotonnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kilotonnes and y is value in base unit Kilograms.</remarks>
        public static Mass FromKilotonnes(double kilotonnes)
        {
            return new Mass(1000000 * kilotonnes + 0);
        }

        /// <summary>
        /// Get Mass from LongTons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in LongTons and y is value in base unit Kilograms.</remarks>
        public static Mass FromLongTons(double longtons)
        {
            return new Mass(1016.0469088 * longtons + 0);
        }

        /// <summary>
        /// Get Mass from Megatonnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Megatonnes and y is value in base unit Kilograms.</remarks>
        public static Mass FromMegatonnes(double megatonnes)
        {
            return new Mass(1000000000 * megatonnes + 0);
        }

        /// <summary>
        /// Get Mass from Micrograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Micrograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromMicrograms(double micrograms)
        {
            return new Mass(1E-09 * micrograms + 0);
        }

        /// <summary>
        /// Get Mass from Milligrams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Milligrams and y is value in base unit Kilograms.</remarks>
        public static Mass FromMilligrams(double milligrams)
        {
            return new Mass(1E-06 * milligrams + 0);
        }

        /// <summary>
        /// Get Mass from Nanograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Nanograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromNanograms(double nanograms)
        {
            return new Mass(1E-12 * nanograms + 0);
        }

        /// <summary>
        /// Get Mass from Pounds.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Pounds and y is value in base unit Kilograms.</remarks>
        public static Mass FromPounds(double pounds)
        {
            return new Mass(0.45359237 * pounds + 0);
        }

        /// <summary>
        /// Get Mass from ShortTons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in ShortTons and y is value in base unit Kilograms.</remarks>
        public static Mass FromShortTons(double shorttons)
        {
            return new Mass(907.18474 * shorttons + 0);
        }

        /// <summary>
        /// Get Mass from Tonnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Tonnes and y is value in base unit Kilograms.</remarks>
        public static Mass FromTonnes(double tonnes)
        {
            return new Mass(1000 * tonnes + 0);
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
