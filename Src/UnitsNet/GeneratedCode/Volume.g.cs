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
    /// Volume is the quantity of three-dimensional space enclosed by some closed boundary, for example, the space that a substance (solid, liquid, gas, or plasma) or shape occupies or contains.[1] Volume is often quantified numerically using the SI derived unit, the cubic metre. The volume of a container is generally understood to be the capacity of the container, i. e. the amount of fluid (gas or liquid) that the container could hold, rather than the amount of space the container itself displaces.
    /// </summary>
    public partial struct Volume : IComparable, IComparable<Volume>
    {
        /// <summary>
        /// Base unit of Volume.
        /// </summary>
        public readonly double CubicMeters;

        public Volume(double cubicmeters) : this()
        {
            CubicMeters = cubicmeters;
        }

        #region Properties

        /// <summary>
        /// Get Volume in Centiliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Centiliters and y is value in base unit CubicMeters.</remarks>
        public double Centiliters
        { 
            get { return CubicMeters / 1E-05; }
        }

        /// <summary>
        /// Get Volume in CubicCentimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicCentimeters and y is value in base unit CubicMeters.</remarks>
        public double CubicCentimeters
        { 
            get { return CubicMeters / 1E-06; }
        }

        /// <summary>
        /// Get Volume in CubicDecimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicDecimeters and y is value in base unit CubicMeters.</remarks>
        public double CubicDecimeters
        { 
            get { return CubicMeters / 0.001; }
        }

        /// <summary>
        /// Get Volume in CubicFeet.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicFeet and y is value in base unit CubicMeters.</remarks>
        public double CubicFeet
        { 
            get { return CubicMeters / 0.0283168; }
        }

        /// <summary>
        /// Get Volume in CubicInches.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicInches and y is value in base unit CubicMeters.</remarks>
        public double CubicInches
        { 
            get { return CubicMeters / 1.6387E-05; }
        }

        /// <summary>
        /// Get Volume in CubicKilometers.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicKilometers and y is value in base unit CubicMeters.</remarks>
        public double CubicKilometers
        { 
            get { return CubicMeters / 1000000000; }
        }

        /// <summary>
        /// Get Volume in CubicMiles.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicMiles and y is value in base unit CubicMeters.</remarks>
        public double CubicMiles
        { 
            get { return CubicMeters / 4168181830; }
        }

        /// <summary>
        /// Get Volume in CubicMillimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicMillimeters and y is value in base unit CubicMeters.</remarks>
        public double CubicMillimeters
        { 
            get { return CubicMeters / 1E-09; }
        }

        /// <summary>
        /// Get Volume in CubicYards.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in CubicYards and y is value in base unit CubicMeters.</remarks>
        public double CubicYards
        { 
            get { return CubicMeters / 0.764554858; }
        }

        /// <summary>
        /// Get Volume in Deciliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Deciliters and y is value in base unit CubicMeters.</remarks>
        public double Deciliters
        { 
            get { return CubicMeters / 0.0001; }
        }

        /// <summary>
        /// Get Volume in Hectoliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Hectoliters and y is value in base unit CubicMeters.</remarks>
        public double Hectoliters
        { 
            get { return CubicMeters / 0.1; }
        }

        /// <summary>
        /// Get Volume in ImperialGallons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in ImperialGallons and y is value in base unit CubicMeters.</remarks>
        public double ImperialGallons
        { 
            get { return CubicMeters / 0.00454609000000181; }
        }

        /// <summary>
        /// Get Volume in ImperialOunces.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in ImperialOunces and y is value in base unit CubicMeters.</remarks>
        public double ImperialOunces
        { 
            get { return CubicMeters / 2.84130624999629E-05; }
        }

        /// <summary>
        /// Get Volume in Liters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Liters and y is value in base unit CubicMeters.</remarks>
        public double Liters
        { 
            get { return CubicMeters / 0.001; }
        }

        /// <summary>
        /// Get Volume in Milliliters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Milliliters and y is value in base unit CubicMeters.</remarks>
        public double Milliliters
        { 
            get { return CubicMeters / 1E-06; }
        }

        /// <summary>
        /// Get Volume in UsGallons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in UsGallons and y is value in base unit CubicMeters.</remarks>
        public double UsGallons
        { 
            get { return CubicMeters / 0.00378541; }
        }

        /// <summary>
        /// Get Volume in UsOunces.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in UsOunces and y is value in base unit CubicMeters.</remarks>
        public double UsOunces
        { 
            get { return CubicMeters / 2.95735295625376E-05; }
        }

        #endregion

        #region Static 

        public static Volume Zero
        {
            get { return new Volume(); }
        }
        
        /// <summary>
        /// Get Volume from Centiliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Centiliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCentiliters(double centiliters)
        { 
            return new Volume(1E-05 * centiliters);
        }

        /// <summary>
        /// Get Volume from CubicCentimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicCentimeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicCentimeters(double cubiccentimeters)
        { 
            return new Volume(1E-06 * cubiccentimeters);
        }

        /// <summary>
        /// Get Volume from CubicDecimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicDecimeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicDecimeters(double cubicdecimeters)
        { 
            return new Volume(0.001 * cubicdecimeters);
        }

        /// <summary>
        /// Get Volume from CubicFeet.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicFeet and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicFeet(double cubicfeet)
        { 
            return new Volume(0.0283168 * cubicfeet);
        }

        /// <summary>
        /// Get Volume from CubicInches.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicInches and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicInches(double cubicinches)
        { 
            return new Volume(1.6387E-05 * cubicinches);
        }

        /// <summary>
        /// Get Volume from CubicKilometers.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicKilometers and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicKilometers(double cubickilometers)
        { 
            return new Volume(1000000000 * cubickilometers);
        }

        /// <summary>
        /// Get Volume from CubicMeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicMeters(double cubicmeters)
        { 
            return new Volume(1 * cubicmeters);
        }

        /// <summary>
        /// Get Volume from CubicMiles.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMiles and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicMiles(double cubicmiles)
        { 
            return new Volume(4168181830 * cubicmiles);
        }

        /// <summary>
        /// Get Volume from CubicMillimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicMillimeters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicMillimeters(double cubicmillimeters)
        { 
            return new Volume(1E-09 * cubicmillimeters);
        }

        /// <summary>
        /// Get Volume from CubicYards.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in CubicYards and y is value in base unit CubicMeters.</remarks>
        public static Volume FromCubicYards(double cubicyards)
        { 
            return new Volume(0.764554858 * cubicyards);
        }

        /// <summary>
        /// Get Volume from Deciliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Deciliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromDeciliters(double deciliters)
        { 
            return new Volume(0.0001 * deciliters);
        }

        /// <summary>
        /// Get Volume from Hectoliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Hectoliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromHectoliters(double hectoliters)
        { 
            return new Volume(0.1 * hectoliters);
        }

        /// <summary>
        /// Get Volume from ImperialGallons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in ImperialGallons and y is value in base unit CubicMeters.</remarks>
        public static Volume FromImperialGallons(double imperialgallons)
        { 
            return new Volume(0.00454609000000181 * imperialgallons);
        }

        /// <summary>
        /// Get Volume from ImperialOunces.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in ImperialOunces and y is value in base unit CubicMeters.</remarks>
        public static Volume FromImperialOunces(double imperialounces)
        { 
            return new Volume(2.84130624999629E-05 * imperialounces);
        }

        /// <summary>
        /// Get Volume from Liters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Liters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromLiters(double liters)
        { 
            return new Volume(0.001 * liters);
        }

        /// <summary>
        /// Get Volume from Milliliters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Milliliters and y is value in base unit CubicMeters.</remarks>
        public static Volume FromMilliliters(double milliliters)
        { 
            return new Volume(1E-06 * milliliters);
        }

        /// <summary>
        /// Get Volume from UsGallons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in UsGallons and y is value in base unit CubicMeters.</remarks>
        public static Volume FromUsGallons(double usgallons)
        { 
            return new Volume(0.00378541 * usgallons);
        }

        /// <summary>
        /// Get Volume from UsOunces.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in UsOunces and y is value in base unit CubicMeters.</remarks>
        public static Volume FromUsOunces(double usounces)
        { 
            return new Volume(2.95735295625376E-05 * usounces);
        }

        /// <summary>
        /// Try to dynamically convert from Volume to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Volume unit value.</returns> 
        public static Volume From(double value, VolumeUnit fromUnit)
        {
            switch (fromUnit)
            {
                case VolumeUnit.Centiliter:
                    return FromCentiliters(value);
                case VolumeUnit.CubicCentimeter:
                    return FromCubicCentimeters(value);
                case VolumeUnit.CubicDecimeter:
                    return FromCubicDecimeters(value);
                case VolumeUnit.CubicFoot:
                    return FromCubicFeet(value);
                case VolumeUnit.CubicInch:
                    return FromCubicInches(value);
                case VolumeUnit.CubicKilometer:
                    return FromCubicKilometers(value);
                case VolumeUnit.CubicMeter:
                    return FromCubicMeters(value);
                case VolumeUnit.CubicMile:
                    return FromCubicMiles(value);
                case VolumeUnit.CubicMillimeter:
                    return FromCubicMillimeters(value);
                case VolumeUnit.CubicYard:
                    return FromCubicYards(value);
                case VolumeUnit.Deciliter:
                    return FromDeciliters(value);
                case VolumeUnit.Hectoliter:
                    return FromHectoliters(value);
                case VolumeUnit.ImperialGallon:
                    return FromImperialGallons(value);
                case VolumeUnit.ImperialOunce:
                    return FromImperialOunces(value);
                case VolumeUnit.Liter:
                    return FromLiters(value);
                case VolumeUnit.Milliliter:
                    return FromMilliliters(value);
                case VolumeUnit.UsGallon:
                    return FromUsGallons(value);
                case VolumeUnit.UsOunce:
                    return FromUsOunces(value);

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
        public static string GetAbbreviation(VolumeUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Volume operator -(Volume right)
        {
            return new Volume(-right.CubicMeters);
        }

        public static Volume operator +(Volume left, Volume right)
        {
            return new Volume(left.CubicMeters + right.CubicMeters);
        }

        public static Volume operator -(Volume left, Volume right)
        {
            return new Volume(left.CubicMeters - right.CubicMeters);
        }

        public static Volume operator *(double left, Volume right)
        {
            return new Volume(left*right.CubicMeters);
        }

        public static Volume operator *(Volume left, double right)
        {
            return new Volume(left.CubicMeters*right);
        }

        public static Volume operator /(Volume left, double right)
        {
            return new Volume(left.CubicMeters/right);
        }

        public static double operator /(Volume left, Volume right)
        {
            return left.CubicMeters/right.CubicMeters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Volume)) throw new ArgumentException("Expected type Volume.", "obj");
            return CompareTo((Volume) obj);
        }

        public int CompareTo(Volume other)
        {
            return CubicMeters.CompareTo(other.CubicMeters);
        }

        public static bool operator <=(Volume left, Volume right)
        {
            return left.CubicMeters <= right.CubicMeters;
        }

        public static bool operator >=(Volume left, Volume right)
        {
            return left.CubicMeters >= right.CubicMeters;
        }

        public static bool operator <(Volume left, Volume right)
        {
            return left.CubicMeters < right.CubicMeters;
        }

        public static bool operator >(Volume left, Volume right)
        {
            return left.CubicMeters > right.CubicMeters;
        }

        public static bool operator ==(Volume left, Volume right)
        {
            return left.CubicMeters == right.CubicMeters;
        }

        public static bool operator !=(Volume left, Volume right)
        {
            return left.CubicMeters != right.CubicMeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return CubicMeters.Equals(((Volume) obj).CubicMeters);
        }

        public override int GetHashCode()
        {
            return CubicMeters.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Volume to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(VolumeUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case VolumeUnit.Centiliter:
                    newValue = Centiliters;
                    return true;
                case VolumeUnit.CubicCentimeter:
                    newValue = CubicCentimeters;
                    return true;
                case VolumeUnit.CubicDecimeter:
                    newValue = CubicDecimeters;
                    return true;
                case VolumeUnit.CubicFoot:
                    newValue = CubicFeet;
                    return true;
                case VolumeUnit.CubicInch:
                    newValue = CubicInches;
                    return true;
                case VolumeUnit.CubicKilometer:
                    newValue = CubicKilometers;
                    return true;
                case VolumeUnit.CubicMeter:
                    newValue = CubicMeters;
                    return true;
                case VolumeUnit.CubicMile:
                    newValue = CubicMiles;
                    return true;
                case VolumeUnit.CubicMillimeter:
                    newValue = CubicMillimeters;
                    return true;
                case VolumeUnit.CubicYard:
                    newValue = CubicYards;
                    return true;
                case VolumeUnit.Deciliter:
                    newValue = Deciliters;
                    return true;
                case VolumeUnit.Hectoliter:
                    newValue = Hectoliters;
                    return true;
                case VolumeUnit.ImperialGallon:
                    newValue = ImperialGallons;
                    return true;
                case VolumeUnit.ImperialOunce:
                    newValue = ImperialOunces;
                    return true;
                case VolumeUnit.Liter:
                    newValue = Liters;
                    return true;
                case VolumeUnit.Milliliter:
                    newValue = Milliliters;
                    return true;
                case VolumeUnit.UsGallon:
                    newValue = UsGallons;
                    return true;
                case VolumeUnit.UsOunce:
                    newValue = UsOunces;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Volume to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(VolumeUnit toUnit)
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
        public string ToString(VolumeUnit unit, CultureInfo culture = null)
        {
            return ToString(culture, unit, "{0:0.##} {1}", CubicMeters);
        }

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        public string ToString(CultureInfo culture, VolumeUnit unit, string format, params object[] args)
        {
            string abbreviation = UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {CubicMeters, abbreviation}
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
            return ToString(VolumeUnit.CubicMeter);
        }
    }
} 
