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
using System.Linq;
using UnitsNet.Units;

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

        #region Properties

        /// <summary>
        /// Get Mass in Centigrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Centigrams and y is value in base unit Kilograms.</remarks>
        public double Centigrams
        { 
            get { return Kilograms / 1E-05; }
        }

        /// <summary>
        /// Get Mass in Decagrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Decagrams and y is value in base unit Kilograms.</remarks>
        public double Decagrams
        { 
            get { return Kilograms / 0.01; }
        }

        /// <summary>
        /// Get Mass in Decigrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Decigrams and y is value in base unit Kilograms.</remarks>
        public double Decigrams
        { 
            get { return Kilograms / 0.0001; }
        }

        /// <summary>
        /// Get Mass in Grams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Grams and y is value in base unit Kilograms.</remarks>
        public double Grams
        { 
            get { return Kilograms / 0.001; }
        }

        /// <summary>
        /// Get Mass in Hectograms.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Hectograms and y is value in base unit Kilograms.</remarks>
        public double Hectograms
        { 
            get { return Kilograms / 0.1; }
        }

        /// <summary>
        /// Get Mass in Kilotonnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Kilotonnes and y is value in base unit Kilograms.</remarks>
        public double Kilotonnes
        { 
            get { return Kilograms / 1000000; }
        }

        /// <summary>
        /// Get Mass in LongTons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in LongTons and y is value in base unit Kilograms.</remarks>
        public double LongTons
        { 
            get { return Kilograms / 1016.0469088; }
        }

        /// <summary>
        /// Get Mass in Megatonnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Megatonnes and y is value in base unit Kilograms.</remarks>
        public double Megatonnes
        { 
            get { return Kilograms / 1000000000; }
        }

        /// <summary>
        /// Get Mass in Micrograms.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Micrograms and y is value in base unit Kilograms.</remarks>
        public double Micrograms
        { 
            get { return Kilograms / 1E-09; }
        }

        /// <summary>
        /// Get Mass in Milligrams.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Milligrams and y is value in base unit Kilograms.</remarks>
        public double Milligrams
        { 
            get { return Kilograms / 1E-06; }
        }

        /// <summary>
        /// Get Mass in Nanograms.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Nanograms and y is value in base unit Kilograms.</remarks>
        public double Nanograms
        { 
            get { return Kilograms / 1E-12; }
        }

        /// <summary>
        /// Get Mass in Pounds.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Pounds and y is value in base unit Kilograms.</remarks>
        public double Pounds
        { 
            get { return Kilograms / 0.45359237; }
        }

        /// <summary>
        /// Get Mass in ShortTons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in ShortTons and y is value in base unit Kilograms.</remarks>
        public double ShortTons
        { 
            get { return Kilograms / 907.18474; }
        }

        /// <summary>
        /// Get Mass in Tonnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Tonnes and y is value in base unit Kilograms.</remarks>
        public double Tonnes
        { 
            get { return Kilograms / 1000; }
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
            return new Mass(1E-05 * centigrams);
        }

        /// <summary>
        /// Get Mass from Decagrams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Decagrams and y is value in base unit Kilograms.</remarks>
        public static Mass FromDecagrams(double decagrams)
        { 
            return new Mass(0.01 * decagrams);
        }

        /// <summary>
        /// Get Mass from Decigrams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Decigrams and y is value in base unit Kilograms.</remarks>
        public static Mass FromDecigrams(double decigrams)
        { 
            return new Mass(0.0001 * decigrams);
        }

        /// <summary>
        /// Get Mass from Grams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Grams and y is value in base unit Kilograms.</remarks>
        public static Mass FromGrams(double grams)
        { 
            return new Mass(0.001 * grams);
        }

        /// <summary>
        /// Get Mass from Hectograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Hectograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromHectograms(double hectograms)
        { 
            return new Mass(0.1 * hectograms);
        }

        /// <summary>
        /// Get Mass from Kilograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kilograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromKilograms(double kilograms)
        { 
            return new Mass(1 * kilograms);
        }

        /// <summary>
        /// Get Mass from Kilotonnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kilotonnes and y is value in base unit Kilograms.</remarks>
        public static Mass FromKilotonnes(double kilotonnes)
        { 
            return new Mass(1000000 * kilotonnes);
        }

        /// <summary>
        /// Get Mass from LongTons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in LongTons and y is value in base unit Kilograms.</remarks>
        public static Mass FromLongTons(double longtons)
        { 
            return new Mass(1016.0469088 * longtons);
        }

        /// <summary>
        /// Get Mass from Megatonnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Megatonnes and y is value in base unit Kilograms.</remarks>
        public static Mass FromMegatonnes(double megatonnes)
        { 
            return new Mass(1000000000 * megatonnes);
        }

        /// <summary>
        /// Get Mass from Micrograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Micrograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromMicrograms(double micrograms)
        { 
            return new Mass(1E-09 * micrograms);
        }

        /// <summary>
        /// Get Mass from Milligrams.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Milligrams and y is value in base unit Kilograms.</remarks>
        public static Mass FromMilligrams(double milligrams)
        { 
            return new Mass(1E-06 * milligrams);
        }

        /// <summary>
        /// Get Mass from Nanograms.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Nanograms and y is value in base unit Kilograms.</remarks>
        public static Mass FromNanograms(double nanograms)
        { 
            return new Mass(1E-12 * nanograms);
        }

        /// <summary>
        /// Get Mass from Pounds.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Pounds and y is value in base unit Kilograms.</remarks>
        public static Mass FromPounds(double pounds)
        { 
            return new Mass(0.45359237 * pounds);
        }

        /// <summary>
        /// Get Mass from ShortTons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in ShortTons and y is value in base unit Kilograms.</remarks>
        public static Mass FromShortTons(double shorttons)
        { 
            return new Mass(907.18474 * shorttons);
        }

        /// <summary>
        /// Get Mass from Tonnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Tonnes and y is value in base unit Kilograms.</remarks>
        public static Mass FromTonnes(double tonnes)
        { 
            return new Mass(1000 * tonnes);
        }

        /// <summary>
        /// Try to dynamically convert from Mass to <paramref name="toUnit"/>.
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
        /// Get unit abbreviation string.
        /// </summary>
        /// <param name="unit">Unit to get abbreviation for.</param>
        /// <param name="culture">Culture to use for localization. Defaults to Thread.CurrentUICulture.</param>
        /// <returns>Unit abbreviation string.</returns>
        public static string GetAbbreviation(MassUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
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
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Mass to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(MassUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case MassUnit.Centigram:
                    newValue = Centigrams;
                    return true;
                case MassUnit.Decagram:
                    newValue = Decagrams;
                    return true;
                case MassUnit.Decigram:
                    newValue = Decigrams;
                    return true;
                case MassUnit.Gram:
                    newValue = Grams;
                    return true;
                case MassUnit.Hectogram:
                    newValue = Hectograms;
                    return true;
                case MassUnit.Kilogram:
                    newValue = Kilograms;
                    return true;
                case MassUnit.Kilotonne:
                    newValue = Kilotonnes;
                    return true;
                case MassUnit.LongTon:
                    newValue = LongTons;
                    return true;
                case MassUnit.Megatonne:
                    newValue = Megatonnes;
                    return true;
                case MassUnit.Microgram:
                    newValue = Micrograms;
                    return true;
                case MassUnit.Milligram:
                    newValue = Milligrams;
                    return true;
                case MassUnit.Nanogram:
                    newValue = Nanograms;
                    return true;
                case MassUnit.Pound:
                    newValue = Pounds;
                    return true;
                case MassUnit.ShortTon:
                    newValue = ShortTons;
                    return true;
                case MassUnit.Tonne:
                    newValue = Tonnes;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Mass to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(MassUnit toUnit)
        {
            double newValue;
            if (!TryConvert(toUnit, out newValue))
                throw new NotImplementedException("toUnit: " + toUnit);

            return newValue;
        }

        #endregion

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(MassUnit unit, CultureInfo culture = null)
        {
            return ToString(culture, unit, "{0:0.##} {1}", Kilograms);
        }

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        public string ToString(CultureInfo culture, MassUnit unit, string format, params object[] args)
        {
            string abbreviation = UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {Kilograms, abbreviation}
                .Concat(args)
                .ToArray();

            return string.Format(culture, format, finalArgs);
        }

        /// <summary>
        /// Get default string representation of value and unit.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return ToString(MassUnit.Kilogram);
        }
    }
} 
