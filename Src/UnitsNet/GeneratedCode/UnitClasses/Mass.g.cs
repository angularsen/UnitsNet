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
    ///     In physics, mass (from Greek μᾶζα "barley cake, lump [of dough]") is a property of a physical system or body, giving rise to the phenomena of the body's resistance to being accelerated by a force and the strength of its mutual gravitational attraction with other bodies. Instruments such as mass balances or scales use those phenomena to measure mass. The SI unit of mass is the kilogram (kg).
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public partial struct Mass : IComparable, IComparable<Mass>
    {
        /// <summary>
        ///     Base unit of Mass.
        /// </summary>
        private readonly double _kilograms;

        public Mass(double kilograms) : this()
        {
            _kilograms = kilograms;
        }

        #region Properties

        /// <summary>
        ///     Get Mass in Centigrams.
        /// </summary>
        public double Centigrams
        {
            get { return (_kilograms*1e3) / 1e-2d; }
        }

        /// <summary>
        ///     Get Mass in Decagrams.
        /// </summary>
        public double Decagrams
        {
            get { return (_kilograms*1e3) / 1e1d; }
        }

        /// <summary>
        ///     Get Mass in Decigrams.
        /// </summary>
        public double Decigrams
        {
            get { return (_kilograms*1e3) / 1e-1d; }
        }

        /// <summary>
        ///     Get Mass in Grams.
        /// </summary>
        public double Grams
        {
            get { return _kilograms*1e3; }
        }

        /// <summary>
        ///     Get Mass in Hectograms.
        /// </summary>
        public double Hectograms
        {
            get { return (_kilograms*1e3) / 1e2d; }
        }

        /// <summary>
        ///     Get Mass in Kilograms.
        /// </summary>
        public double Kilograms
        {
            get { return (_kilograms*1e3) / 1e3d; }
        }

        /// <summary>
        ///     Get Mass in Kilotonnes.
        /// </summary>
        public double Kilotonnes
        {
            get { return (_kilograms/1e3) / 1e3d; }
        }

        /// <summary>
        ///     Get Mass in LongTons.
        /// </summary>
        public double LongTons
        {
            get { return _kilograms/1016.0469088; }
        }

        /// <summary>
        ///     Get Mass in Megatonnes.
        /// </summary>
        public double Megatonnes
        {
            get { return (_kilograms/1e3) / 1e6d; }
        }

        /// <summary>
        ///     Get Mass in Micrograms.
        /// </summary>
        public double Micrograms
        {
            get { return (_kilograms*1e3) / 1e-6d; }
        }

        /// <summary>
        ///     Get Mass in Milligrams.
        /// </summary>
        public double Milligrams
        {
            get { return (_kilograms*1e3) / 1e-3d; }
        }

        /// <summary>
        ///     Get Mass in Nanograms.
        /// </summary>
        public double Nanograms
        {
            get { return (_kilograms*1e3) / 1e-9d; }
        }

        /// <summary>
        ///     Get Mass in Pounds.
        /// </summary>
        public double Pounds
        {
            get { return _kilograms/0.45359237; }
        }

        /// <summary>
        ///     Get Mass in ShortTons.
        /// </summary>
        public double ShortTons
        {
            get { return _kilograms/907.18474; }
        }

        /// <summary>
        ///     Get Mass in Tonnes.
        /// </summary>
        public double Tonnes
        {
            get { return _kilograms/1e3; }
        }

        #endregion

        #region Static 

        public static Mass Zero
        {
            get { return new Mass(); }
        }

        /// <summary>
        ///     Get Mass from Centigrams.
        /// </summary>
        public static Mass FromCentigrams(double centigrams)
        {
            return new Mass((centigrams/1e3) * 1e-2d);
        }

        /// <summary>
        ///     Get Mass from Decagrams.
        /// </summary>
        public static Mass FromDecagrams(double decagrams)
        {
            return new Mass((decagrams/1e3) * 1e1d);
        }

        /// <summary>
        ///     Get Mass from Decigrams.
        /// </summary>
        public static Mass FromDecigrams(double decigrams)
        {
            return new Mass((decigrams/1e3) * 1e-1d);
        }

        /// <summary>
        ///     Get Mass from Grams.
        /// </summary>
        public static Mass FromGrams(double grams)
        {
            return new Mass(grams/1e3);
        }

        /// <summary>
        ///     Get Mass from Hectograms.
        /// </summary>
        public static Mass FromHectograms(double hectograms)
        {
            return new Mass((hectograms/1e3) * 1e2d);
        }

        /// <summary>
        ///     Get Mass from Kilograms.
        /// </summary>
        public static Mass FromKilograms(double kilograms)
        {
            return new Mass((kilograms/1e3) * 1e3d);
        }

        /// <summary>
        ///     Get Mass from Kilotonnes.
        /// </summary>
        public static Mass FromKilotonnes(double kilotonnes)
        {
            return new Mass((kilotonnes*1e3) * 1e3d);
        }

        /// <summary>
        ///     Get Mass from LongTons.
        /// </summary>
        public static Mass FromLongTons(double longtons)
        {
            return new Mass(longtons*1016.0469088);
        }

        /// <summary>
        ///     Get Mass from Megatonnes.
        /// </summary>
        public static Mass FromMegatonnes(double megatonnes)
        {
            return new Mass((megatonnes*1e3) * 1e6d);
        }

        /// <summary>
        ///     Get Mass from Micrograms.
        /// </summary>
        public static Mass FromMicrograms(double micrograms)
        {
            return new Mass((micrograms/1e3) * 1e-6d);
        }

        /// <summary>
        ///     Get Mass from Milligrams.
        /// </summary>
        public static Mass FromMilligrams(double milligrams)
        {
            return new Mass((milligrams/1e3) * 1e-3d);
        }

        /// <summary>
        ///     Get Mass from Nanograms.
        /// </summary>
        public static Mass FromNanograms(double nanograms)
        {
            return new Mass((nanograms/1e3) * 1e-9d);
        }

        /// <summary>
        ///     Get Mass from Pounds.
        /// </summary>
        public static Mass FromPounds(double pounds)
        {
            return new Mass(pounds*0.45359237);
        }

        /// <summary>
        ///     Get Mass from ShortTons.
        /// </summary>
        public static Mass FromShortTons(double shorttons)
        {
            return new Mass(shorttons*907.18474);
        }

        /// <summary>
        ///     Get Mass from Tonnes.
        /// </summary>
        public static Mass FromTonnes(double tonnes)
        {
            return new Mass(tonnes*1e3);
        }


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="MassUnit" /> to <see cref="Mass" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Mass unit value.</returns>
        public static Mass From(double value, MassUnit fromUnit)
        {
            switch (fromUnit)
            {
                case MassUnit.Centigram:
                    return FromCentigrams(value);
                case MassUnit.Decagram:
                    return FromDecagrams(value);
                case MassUnit.Decigram:
                    return FromDecigrams(value);
                case MassUnit.Gram:
                    return FromGrams(value);
                case MassUnit.Hectogram:
                    return FromHectograms(value);
                case MassUnit.Kilogram:
                    return FromKilograms(value);
                case MassUnit.Kilotonne:
                    return FromKilotonnes(value);
                case MassUnit.LongTon:
                    return FromLongTons(value);
                case MassUnit.Megatonne:
                    return FromMegatonnes(value);
                case MassUnit.Microgram:
                    return FromMicrograms(value);
                case MassUnit.Milligram:
                    return FromMilligrams(value);
                case MassUnit.Nanogram:
                    return FromNanograms(value);
                case MassUnit.Pound:
                    return FromPounds(value);
                case MassUnit.ShortTon:
                    return FromShortTons(value);
                case MassUnit.Tonne:
                    return FromTonnes(value);

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
        public static string GetAbbreviation(MassUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Mass operator -(Mass right)
        {
            return new Mass(-right._kilograms);
        }

        public static Mass operator +(Mass left, Mass right)
        {
            return new Mass(left._kilograms + right._kilograms);
        }

        public static Mass operator -(Mass left, Mass right)
        {
            return new Mass(left._kilograms - right._kilograms);
        }

        public static Mass operator *(double left, Mass right)
        {
            return new Mass(left*right._kilograms);
        }

        public static Mass operator *(Mass left, double right)
        {
            return new Mass(left._kilograms*(double)right);
        }

        public static Mass operator /(Mass left, double right)
        {
            return new Mass(left._kilograms/(double)right);
        }

        public static double operator /(Mass left, Mass right)
        {
            return Convert.ToDouble(left._kilograms/right._kilograms);
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
            return _kilograms.CompareTo(other._kilograms);
        }

        public static bool operator <=(Mass left, Mass right)
        {
            return left._kilograms <= right._kilograms;
        }

        public static bool operator >=(Mass left, Mass right)
        {
            return left._kilograms >= right._kilograms;
        }

        public static bool operator <(Mass left, Mass right)
        {
            return left._kilograms < right._kilograms;
        }

        public static bool operator >(Mass left, Mass right)
        {
            return left._kilograms > right._kilograms;
        }

        public static bool operator ==(Mass left, Mass right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilograms == right._kilograms;
        }

        public static bool operator !=(Mass left, Mass right)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return left._kilograms != right._kilograms;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return _kilograms.Equals(((Mass) obj)._kilograms);
        }

        public override int GetHashCode()
        {
            return _kilograms.GetHashCode();
        }

        #endregion

        #region Conversion

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value in new unit if successful, exception otherwise.</returns>
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(MassUnit unit)
        {
            switch (unit)
            {
                case MassUnit.Centigram:
                    return Centigrams;
                case MassUnit.Decagram:
                    return Decagrams;
                case MassUnit.Decigram:
                    return Decigrams;
                case MassUnit.Gram:
                    return Grams;
                case MassUnit.Hectogram:
                    return Hectograms;
                case MassUnit.Kilogram:
                    return Kilograms;
                case MassUnit.Kilotonne:
                    return Kilotonnes;
                case MassUnit.LongTon:
                    return LongTons;
                case MassUnit.Megatonne:
                    return Megatonnes;
                case MassUnit.Microgram:
                    return Micrograms;
                case MassUnit.Milligram:
                    return Milligrams;
                case MassUnit.Nanogram:
                    return Nanograms;
                case MassUnit.Pound:
                    return Pounds;
                case MassUnit.ShortTon:
                    return ShortTons;
                case MassUnit.Tonne:
                    return Tonnes;

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
        public string ToString(MassUnit unit, CultureInfo culture = null)
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
        public string ToString(MassUnit unit, CultureInfo culture, string format, params object[] args)
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
            return ToString(MassUnit.Kilogram);
        }
    }
}
