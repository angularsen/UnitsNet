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

using UnitsNet.Extensions;
using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// Many different units of length have been used around the world. The main units in modern use are U.S. customary units in the United States and the Metric system elsewhere. British Imperial units are still used for some purposes in the United Kingdom and some other countries. The metric system is sub-divided into SI and non-SI units.
    /// </summary>
    public partial struct Length : IComparable, IComparable<Length>
    {
        /// <summary>
        /// Base unit of Length.
        /// </summary>
        public readonly double Meters;

        public Length(double meters) : this()
        {
            Meters = meters;
        }

        #region Properties

        /// <summary>
        /// Get Length in Centimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Centimeters and y is value in base unit Meters.</remarks>
        public double Centimeters
        { 
            get { return Meters / 0.01; }
        }

        /// <summary>
        /// Get Length in Decimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Decimeters and y is value in base unit Meters.</remarks>
        public double Decimeters
        { 
            get { return Meters / 0.1; }
        }

        /// <summary>
        /// Get Length in Kilometers.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Kilometers and y is value in base unit Meters.</remarks>
        public double Kilometers
        { 
            get { return Meters / 1000; }
        }

        /// <summary>
        /// Get Length in Micrometers.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Micrometers and y is value in base unit Meters.</remarks>
        public double Micrometers
        { 
            get { return Meters / 1E-06; }
        }

        /// <summary>
        /// Get Length in Millimeters.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Millimeters and y is value in base unit Meters.</remarks>
        public double Millimeters
        { 
            get { return Meters / 0.001; }
        }

        /// <summary>
        /// Get Length in Nanometers.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Nanometers and y is value in base unit Meters.</remarks>
        public double Nanometers
        { 
            get { return Meters / 1E-09; }
        }

        #endregion

        #region Static 

        public static Length Zero
        {
            get { return new Length(); }
        }
        
        /// <summary>
        /// Get Length from Centimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Centimeters and y is value in base unit Meters.</remarks>
        public static Length FromCentimeters(double centimeters)
        { 
            return new Length(0.01 * centimeters);
        }

        /// <summary>
        /// Get Length from Decimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Decimeters and y is value in base unit Meters.</remarks>
        public static Length FromDecimeters(double decimeters)
        { 
            return new Length(0.1 * decimeters);
        }

        /// <summary>
        /// Get Length from Kilometers.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kilometers and y is value in base unit Meters.</remarks>
        public static Length FromKilometers(double kilometers)
        { 
            return new Length(1000 * kilometers);
        }

        /// <summary>
        /// Get Length from Meters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Meters and y is value in base unit Meters.</remarks>
        public static Length FromMeters(double meters)
        { 
            return new Length(1 * meters);
        }

        /// <summary>
        /// Get Length from Micrometers.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Micrometers and y is value in base unit Meters.</remarks>
        public static Length FromMicrometers(double micrometers)
        { 
            return new Length(1E-06 * micrometers);
        }

        /// <summary>
        /// Get Length from Millimeters.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Millimeters and y is value in base unit Meters.</remarks>
        public static Length FromMillimeters(double millimeters)
        { 
            return new Length(0.001 * millimeters);
        }

        /// <summary>
        /// Get Length from Nanometers.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Nanometers and y is value in base unit Meters.</remarks>
        public static Length FromNanometers(double nanometers)
        { 
            return new Length(1E-09 * nanometers);
        }

        /// <summary>
        /// Try to dynamically convert from Length to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Length unit value.</returns> 
        public static Length From(double value, LengthUnit fromUnit)
        {
            switch (fromUnit)
            {
                case LengthUnit.Centimeter:
                    return FromCentimeters(value);
                case LengthUnit.Decimeter:
                    return FromDecimeters(value);
                case LengthUnit.Kilometer:
                    return FromKilometers(value);
                case LengthUnit.Micrometer:
                    return FromMicrometers(value);
                case LengthUnit.Millimeter:
                    return FromMillimeters(value);
                case LengthUnit.Nanometer:
                    return FromNanometers(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
        #endregion

        #region Arithmetic Operators

        public static Length operator -(Length right)
        {
            return new Length(-right.Meters);
        }

        public static Length operator +(Length left, Length right)
        {
            return new Length(left.Meters + right.Meters);
        }

        public static Length operator -(Length left, Length right)
        {
            return new Length(left.Meters - right.Meters);
        }

        public static Length operator *(double left, Length right)
        {
            return new Length(left*right.Meters);
        }

        public static Length operator *(Length left, double right)
        {
            return new Length(left.Meters*right);
        }

        public static Length operator /(Length left, double right)
        {
            return new Length(left.Meters/right);
        }

        public static double operator /(Length left, Length right)
        {
            return left.Meters/right.Meters;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Length)) throw new ArgumentException("Expected type Length.", "obj");
            return CompareTo((Length) obj);
        }

        public int CompareTo(Length other)
        {
            return Meters.CompareTo(other.Meters);
        }

        public static bool operator <=(Length left, Length right)
        {
            return left.Meters <= right.Meters;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left.Meters >= right.Meters;
        }

        public static bool operator <(Length left, Length right)
        {
            return left.Meters < right.Meters;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.Meters > right.Meters;
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.Meters == right.Meters;
        }

        public static bool operator !=(Length left, Length right)
        {
            return left.Meters != right.Meters;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Meters.Equals(((Length) obj).Meters);
        }

        public override int GetHashCode()
        {
            return Meters.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Length to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(LengthUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case LengthUnit.Centimeter:
                    newValue = Centimeters;
                    return true;
                case LengthUnit.Decimeter:
                    newValue = Decimeters;
                    return true;
                case LengthUnit.Kilometer:
                    newValue = Kilometers;
                    return true;
                case LengthUnit.Micrometer:
                    newValue = Micrometers;
                    return true;
                case LengthUnit.Millimeter:
                    newValue = Millimeters;
                    return true;
                case LengthUnit.Nanometer:
                    newValue = Nanometers;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Length to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(LengthUnit toUnit)
        {
            double newValue;
            if (!TryConvert(toUnit, out newValue))
                throw new NotImplementedException("toUnit: " + toUnit);

            return newValue;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Meters, UnitSystem.Create().GetDefaultAbbreviation(LengthUnit.Meter));
        }
    }
} 
