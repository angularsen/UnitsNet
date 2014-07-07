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
    /// Area is a quantity that expresses the extent of a two-dimensional surface or shape, or planar lamina, in the plane. Area can be understood as the amount of material with a given thickness that would be necessary to fashion a model of the shape, or the amount of paint necessary to cover the surface with a single coat.[1] It is the two-dimensional analog of the length of a curve (a one-dimensional concept) or the volume of a solid (a three-dimensional concept).
    /// </summary>
    public partial struct Area : IComparable, IComparable<Area>
    {
        /// <summary>
        /// Base unit of Area.
        /// </summary>
        public readonly double SquareMeters;

        public Area(double squaremeters) : this()
        {
            SquareMeters = squaremeters;
        }

        #region Properties

        /// <summary>
        /// Get Area in SquareCentimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareCentimeters and y is value in base unit SquareMeters.</remarks>
        public double SquareCentimeters
        { 
            get { return SquareMeters / 0.0001; }
        }

        /// <summary>
        /// Get Area in SquareDecimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareDecimeters and y is value in base unit SquareMeters.</remarks>
        public double SquareDecimeters
        { 
            get { return SquareMeters / 0.01; }
        }

        /// <summary>
        /// Get Area in SquareFeet.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareFeet and y is value in base unit SquareMeters.</remarks>
        public double SquareFeet
        { 
            get { return SquareMeters / 0.092903; }
        }

        /// <summary>
        /// Get Area in SquareInches.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareInches and y is value in base unit SquareMeters.</remarks>
        public double SquareInches
        { 
            get { return SquareMeters / 0.00064516; }
        }

        /// <summary>
        /// Get Area in SquareInternationalNauticalMiles.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareInternationalNauticalMiles and y is value in base unit SquareMeters.</remarks>
        public double SquareInternationalNauticalMiles
        { 
            get { return SquareMeters / 3429904; }
        }

        /// <summary>
        /// Get Area in SquareKilometers.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareKilometers and y is value in base unit SquareMeters.</remarks>
        public double SquareKilometers
        { 
            get { return SquareMeters / 1000000; }
        }

        /// <summary>
        /// Get Area in SquareMiles.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareMiles and y is value in base unit SquareMeters.</remarks>
        public double SquareMiles
        { 
            get { return SquareMeters / 2590000; }
        }

        /// <summary>
        /// Get Area in SquareMillimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareMillimeters and y is value in base unit SquareMeters.</remarks>
        public double SquareMillimeters
        { 
            get { return SquareMeters / 1E-06; }
        }

        /// <summary>
        /// Get Area in SquareYards.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in SquareYards and y is value in base unit SquareMeters.</remarks>
        public double SquareYards
        { 
            get { return SquareMeters / 0.836127; }
        }

        #endregion

        #region Static 

        public static Area Zero
        {
            get { return new Area(); }
        }
        
        /// <summary>
        /// Get Area from SquareCentimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareCentimeters and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareCentimeters(double squarecentimeters)
        { 
            return new Area(0.0001 * squarecentimeters);
        }

        /// <summary>
        /// Get Area from SquareDecimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareDecimeters and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareDecimeters(double squaredecimeters)
        { 
            return new Area(0.01 * squaredecimeters);
        }

        /// <summary>
        /// Get Area from SquareFeet.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareFeet and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareFeet(double squarefeet)
        { 
            return new Area(0.092903 * squarefeet);
        }

        /// <summary>
        /// Get Area from SquareInches.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareInches and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareInches(double squareinches)
        { 
            return new Area(0.00064516 * squareinches);
        }

        /// <summary>
        /// Get Area from SquareInternationalNauticalMiles.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareInternationalNauticalMiles and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareInternationalNauticalMiles(double squareinternationalnauticalmiles)
        { 
            return new Area(3429904 * squareinternationalnauticalmiles);
        }

        /// <summary>
        /// Get Area from SquareKilometers.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareKilometers and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareKilometers(double squarekilometers)
        { 
            return new Area(1000000 * squarekilometers);
        }

        /// <summary>
        /// Get Area from SquareMeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareMeters and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareMeters(double squaremeters)
        { 
            return new Area(1 * squaremeters);
        }

        /// <summary>
        /// Get Area from SquareMiles.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareMiles and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareMiles(double squaremiles)
        { 
            return new Area(2590000 * squaremiles);
        }

        /// <summary>
        /// Get Area from SquareMillimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareMillimeters and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareMillimeters(double squaremillimeters)
        { 
            return new Area(1E-06 * squaremillimeters);
        }

        /// <summary>
        /// Get Area from SquareYards.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in SquareYards and y is value in base unit SquareMeters.</remarks>
        public static Area FromSquareYards(double squareyards)
        { 
            return new Area(0.836127 * squareyards);
        }

        /// <summary>
        /// Try to dynamically convert from Area to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Area unit value.</returns> 
        public static Area From(double value, AreaUnit fromUnit)
        {
            switch (fromUnit)
            {
                case AreaUnit.SquareCentimeter:
                    return FromSquareCentimeters(value);
                case AreaUnit.SquareDecimeter:
                    return FromSquareDecimeters(value);
                case AreaUnit.SquareFoot:
                    return FromSquareFeet(value);
                case AreaUnit.SquareInch:
                    return FromSquareInches(value);
                case AreaUnit.SquareInternationalNauticalMile:
                    return FromSquareInternationalNauticalMiles(value);
                case AreaUnit.SquareKilometer:
                    return FromSquareKilometers(value);
                case AreaUnit.SquareMeter:
                    return FromSquareMeters(value);
                case AreaUnit.SquareMile:
                    return FromSquareMiles(value);
                case AreaUnit.SquareMillimeter:
                    return FromSquareMillimeters(value);
                case AreaUnit.SquareYard:
                    return FromSquareYards(value);

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
        public static string GetAbbreviation(AreaUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Area operator -(Area right)
        {
            return new Area(-right.SquareMeters);
        }

        public static Area operator +(Area left, Area right)
        {
            return new Area(left.SquareMeters + right.SquareMeters);
        }

        public static Area operator -(Area left, Area right)
        {
            return new Area(left.SquareMeters - right.SquareMeters);
        }

        public static Area operator *(double left, Area right)
        {
            return new Area(left*right.SquareMeters);
        }

        public static Area operator *(Area left, double right)
        {
            return new Area(left.SquareMeters*right);
        }

        public static Area operator /(Area left, double right)
        {
            return new Area(left.SquareMeters/right);
        }

        public static double operator /(Area left, Area right)
        {
            return left.SquareMeters/right.SquareMeters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Area)) throw new ArgumentException("Expected type Area.", "obj");
            return CompareTo((Area) obj);
        }

        public int CompareTo(Area other)
        {
            return SquareMeters.CompareTo(other.SquareMeters);
        }

        public static bool operator <=(Area left, Area right)
        {
            return left.SquareMeters <= right.SquareMeters;
        }

        public static bool operator >=(Area left, Area right)
        {
            return left.SquareMeters >= right.SquareMeters;
        }

        public static bool operator <(Area left, Area right)
        {
            return left.SquareMeters < right.SquareMeters;
        }

        public static bool operator >(Area left, Area right)
        {
            return left.SquareMeters > right.SquareMeters;
        }

        public static bool operator ==(Area left, Area right)
        {
            return left.SquareMeters == right.SquareMeters;
        }

        public static bool operator !=(Area left, Area right)
        {
            return left.SquareMeters != right.SquareMeters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return SquareMeters.Equals(((Area) obj).SquareMeters);
        }

        public override int GetHashCode()
        {
            return SquareMeters.GetHashCode();
        }

        #endregion
        
        #region Conversion

        /// <summary>
        /// Convert to the unit representation in <paramref name="asUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double As(AreaUnit unit)
        {
            switch (unit)
            {
                case AreaUnit.SquareCentimeter:
                    return SquareCentimeters;
                case AreaUnit.SquareDecimeter:
                    return SquareDecimeters;
                case AreaUnit.SquareFoot:
                    return SquareFeet;
                case AreaUnit.SquareInch:
                    return SquareInches;
                case AreaUnit.SquareInternationalNauticalMile:
                    return SquareInternationalNauticalMiles;
                case AreaUnit.SquareKilometer:
                    return SquareKilometers;
                case AreaUnit.SquareMeter:
                    return SquareMeters;
                case AreaUnit.SquareMile:
                    return SquareMiles;
                case AreaUnit.SquareMillimeter:
                    return SquareMillimeters;
                case AreaUnit.SquareYard:
                    return SquareYards;

                default:
                    throw new NotImplementedException("unit: " + unit);
            }
        }

        #endregion

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <returns>String representation.</returns>
        public string ToString(AreaUnit unit, CultureInfo culture = null)
        {
            return ToString(unit, culture, "{0:0.##} {1}");
        }

        /// <summary>
        /// Get string representation of value and unit.
        /// </summary>
        /// <param name="culture">Culture to use for localization and number formatting.</param>
        /// <param name="unit">Unit representation to use.</param>
        /// <param name="format">String format to use. Default:  "{0:0.##} {1} for value and unit abbreviation respectively."</param>
        /// <param name="args">Arguments for string format. Value and unit are implictly included as arguments 0 and 1.</param>
        /// <returns>String representation.</returns>
        public string ToString(AreaUnit unit, CultureInfo culture, string format, params object[] args)
        {
            string abbreviation = UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {As(unit), abbreviation}
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
            return ToString(AreaUnit.SquareMeter);
        }
    }
} 
