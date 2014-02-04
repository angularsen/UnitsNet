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
    /// In physics, a force is any influence that causes an object to undergo a certain change, either concerning its movement, direction, or geometrical construction. In other words, a force can cause an object with mass to change its velocity (which includes to begin moving from a state of rest), i.e., to accelerate, or a flexible object to deform, or both. Force can also be described by intuitive concepts such as a push or a pull. A force has both magnitude and direction, making it a vector quantity. It is measured in the SI unit of newtons and represented by the symbol F.
    /// </summary>
    public partial struct Force : IComparable, IComparable<Force>
    {
        /// <summary>
        /// Base unit of Force.
        /// </summary>
        public readonly double Newtons;

        public Force(double newtons) : this()
        {
            Newtons = newtons;
        }

        #region Properties

        /// <summary>
        /// Get Force in Dyne.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Dyne and y is value in base unit Newtons.</remarks>
        public double Dyne
        { 
            get { return Newtons / 1E-05; }
        }

        /// <summary>
        /// Get Force in KilogramsForce.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in KilogramsForce and y is value in base unit Newtons.</remarks>
        public double KilogramsForce
        { 
            get { return Newtons / 9.80665002864; }
        }

        /// <summary>
        /// Get Force in Kilonewtons.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Kilonewtons and y is value in base unit Newtons.</remarks>
        public double Kilonewtons
        { 
            get { return Newtons / 1000; }
        }

        /// <summary>
        /// Get Force in KiloPonds.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in KiloPonds and y is value in base unit Newtons.</remarks>
        public double KiloPonds
        { 
            get { return Newtons / 9.80665002864; }
        }

        /// <summary>
        /// Get Force in Poundals.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in Poundals and y is value in base unit Newtons.</remarks>
        public double Poundals
        { 
            get { return Newtons / 0.13825502798973; }
        }

        /// <summary>
        /// Get Force in PoundForces.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in PoundForces and y is value in base unit Newtons.</remarks>
        public double PoundForces
        { 
            get { return Newtons / 4.44822161526051; }
        }

        #endregion

        #region Static 

        public static Force Zero
        {
            get { return new Force(); }
        }
        
        /// <summary>
        /// Get Force from Dyne.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Dyne and y is value in base unit Newtons.</remarks>
        public static Force FromDyne(double dyne)
        { 
            return new Force(1E-05 * dyne);
        }

        /// <summary>
        /// Get Force from KilogramsForce.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in KilogramsForce and y is value in base unit Newtons.</remarks>
        public static Force FromKilogramsForce(double kilogramsforce)
        { 
            return new Force(9.80665002864 * kilogramsforce);
        }

        /// <summary>
        /// Get Force from Kilonewtons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Kilonewtons and y is value in base unit Newtons.</remarks>
        public static Force FromKilonewtons(double kilonewtons)
        { 
            return new Force(1000 * kilonewtons);
        }

        /// <summary>
        /// Get Force from KiloPonds.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in KiloPonds and y is value in base unit Newtons.</remarks>
        public static Force FromKiloPonds(double kiloponds)
        { 
            return new Force(9.80665002864 * kiloponds);
        }

        /// <summary>
        /// Get Force from Newtons.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Newtons and y is value in base unit Newtons.</remarks>
        public static Force FromNewtons(double newtons)
        { 
            return new Force(1 * newtons);
        }

        /// <summary>
        /// Get Force from Poundals.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Poundals and y is value in base unit Newtons.</remarks>
        public static Force FromPoundals(double poundals)
        { 
            return new Force(0.13825502798973 * poundals);
        }

        /// <summary>
        /// Get Force from PoundForces.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in PoundForces and y is value in base unit Newtons.</remarks>
        public static Force FromPoundForces(double poundforces)
        { 
            return new Force(4.44822161526051 * poundforces);
        }

        /// <summary>
        /// Try to dynamically convert from Force to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Force unit value.</returns> 
        public static Force From(double value, ForceUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ForceUnit.Dyn:
                    return FromDyne(value);
                case ForceUnit.KilogramForce:
                    return FromKilogramsForce(value);
                case ForceUnit.Kilonewton:
                    return FromKilonewtons(value);
                case ForceUnit.KiloPond:
                    return FromKiloPonds(value);
                case ForceUnit.Newton:
                    return FromNewtons(value);
                case ForceUnit.Poundal:
                    return FromPoundals(value);
                case ForceUnit.PoundForce:
                    return FromPoundForces(value);

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
        public static string GetAbbreviation(ForceUnit unit, CultureInfo culture = null)
        {
            return UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
        }

        #endregion

        #region Arithmetic Operators

        public static Force operator -(Force right)
        {
            return new Force(-right.Newtons);
        }

        public static Force operator +(Force left, Force right)
        {
            return new Force(left.Newtons + right.Newtons);
        }

        public static Force operator -(Force left, Force right)
        {
            return new Force(left.Newtons - right.Newtons);
        }

        public static Force operator *(double left, Force right)
        {
            return new Force(left*right.Newtons);
        }

        public static Force operator *(Force left, double right)
        {
            return new Force(left.Newtons*right);
        }

        public static Force operator /(Force left, double right)
        {
            return new Force(left.Newtons/right);
        }

        public static double operator /(Force left, Force right)
        {
            return left.Newtons/right.Newtons;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Force)) throw new ArgumentException("Expected type Force.", "obj");
            return CompareTo((Force) obj);
        }

        public int CompareTo(Force other)
        {
            return Newtons.CompareTo(other.Newtons);
        }

        public static bool operator <=(Force left, Force right)
        {
            return left.Newtons <= right.Newtons;
        }

        public static bool operator >=(Force left, Force right)
        {
            return left.Newtons >= right.Newtons;
        }

        public static bool operator <(Force left, Force right)
        {
            return left.Newtons < right.Newtons;
        }

        public static bool operator >(Force left, Force right)
        {
            return left.Newtons > right.Newtons;
        }

        public static bool operator ==(Force left, Force right)
        {
            return left.Newtons == right.Newtons;
        }

        public static bool operator !=(Force left, Force right)
        {
            return left.Newtons != right.Newtons;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Newtons.Equals(((Force) obj).Newtons);
        }

        public override int GetHashCode()
        {
            return Newtons.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Force to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(ForceUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case ForceUnit.Dyn:
                    newValue = Dyne;
                    return true;
                case ForceUnit.KilogramForce:
                    newValue = KilogramsForce;
                    return true;
                case ForceUnit.Kilonewton:
                    newValue = Kilonewtons;
                    return true;
                case ForceUnit.KiloPond:
                    newValue = KiloPonds;
                    return true;
                case ForceUnit.Newton:
                    newValue = Newtons;
                    return true;
                case ForceUnit.Poundal:
                    newValue = Poundals;
                    return true;
                case ForceUnit.PoundForce:
                    newValue = PoundForces;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Force to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(ForceUnit toUnit)
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
        public string ToString(ForceUnit unit, CultureInfo culture = null)
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
        public string ToString(ForceUnit unit, CultureInfo culture, string format, params object[] args)
        {
            string abbreviation = UnitSystem.Create(culture).GetDefaultAbbreviation(unit);
            var finalArgs = new object[] {Convert(unit), abbreviation}
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
            return ToString(ForceUnit.Newton);
        }
    }
} 
