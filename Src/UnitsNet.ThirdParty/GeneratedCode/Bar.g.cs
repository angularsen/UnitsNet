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
using UnitsNet.ThirdParty.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// Example unit to illustrate adding third party units to Units.NET.
    /// </summary>
    public partial struct Bar : IComparable, IComparable<Bar>
    {
        /// <summary>
        /// Base unit of Bar.
        /// </summary>
        public readonly double Bars;

        public Bar(double bars) : this()
        {
            Bars = bars;
        }

        #region Properties

        /// <summary>
        /// Get Bar in BarPlusOnes.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in BarPlusOnes and y is value in base unit Bars.</remarks>
        public double BarPlusOnes
        {            
            get { return (Bars - 1) / 1; }
        }

        /// <summary>
        /// Get Bar in BarsTripled.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in BarsTripled and y is value in base unit Bars.</remarks>
        public double BarsTripled
        { 
            get { return Bars / 3; }
        }

        /// <summary>
        /// Get Bar in TwiceThanBars.
        /// </summary>
        /// <remarks>Example: x = (y - b) / a where x is value in TwiceThanBars and y is value in base unit Bars.</remarks>
        public double TwiceThanBars
        { 
            get { return Bars / 2; }
        }

        #endregion

        #region Static 

        public static Bar Zero
        {
            get { return new Bar(); }
        }
        
        /// <summary>
        /// Get Bar from Bars.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Bars and y is value in base unit Bars.</remarks>
        public static Bar FromBars(double bars)
        { 
            return new Bar(1 * bars);
        }

        /// <summary>
        /// Get Bar from BarPlusOnes.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in BarPlusOnes and y is value in base unit Bars.</remarks>
        public static Bar FromBarPlusOnes(double barplusones)
        {            
            return new Bar(1 * barplusones + 1);
        }

        /// <summary>
        /// Get Bar from BarsTripled.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in BarsTripled and y is value in base unit Bars.</remarks>
        public static Bar FromBarsTripled(double barstripled)
        { 
            return new Bar(3 * barstripled);
        }

        /// <summary>
        /// Get Bar from TwiceThanBars.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in TwiceThanBars and y is value in base unit Bars.</remarks>
        public static Bar FromTwiceThanBars(double twicethanbars)
        { 
            return new Bar(2 * twicethanbars);
        }

        /// <summary>
        /// Try to dynamically convert from Bar to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Bar unit value.</returns> 
        public static Bar From(double value, BarUnit fromUnit)
        {
            switch (fromUnit)
            {
                case BarUnit.Bar:
                    return FromBars(value);
                case BarUnit.BarPlus1:
                    return FromBarPlusOnes(value);
                case BarUnit.BarTripled:
                    return FromBarsTripled(value);
                case BarUnit.TwiceThanBar:
                    return FromTwiceThanBars(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
        #endregion

        #region Arithmetic Operators

        public static Bar operator -(Bar right)
        {
            return new Bar(-right.Bars);
        }

        public static Bar operator +(Bar left, Bar right)
        {
            return new Bar(left.Bars + right.Bars);
        }

        public static Bar operator -(Bar left, Bar right)
        {
            return new Bar(left.Bars - right.Bars);
        }

        public static Bar operator *(double left, Bar right)
        {
            return new Bar(left*right.Bars);
        }

        public static Bar operator *(Bar left, double right)
        {
            return new Bar(left.Bars*right);
        }

        public static Bar operator /(Bar left, double right)
        {
            return new Bar(left.Bars/right);
        }

        public static double operator /(Bar left, Bar right)
        {
            return left.Bars/right.Bars;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is Bar)) throw new ArgumentException("Expected type Bar.", "obj");
            return CompareTo((Bar) obj);
        }

        public int CompareTo(Bar other)
        {
            return Bars.CompareTo(other.Bars);
        }

        public static bool operator <=(Bar left, Bar right)
        {
            return left.Bars <= right.Bars;
        }

        public static bool operator >=(Bar left, Bar right)
        {
            return left.Bars >= right.Bars;
        }

        public static bool operator <(Bar left, Bar right)
        {
            return left.Bars < right.Bars;
        }

        public static bool operator >(Bar left, Bar right)
        {
            return left.Bars > right.Bars;
        }

        public static bool operator ==(Bar left, Bar right)
        {
            return left.Bars == right.Bars;
        }

        public static bool operator !=(Bar left, Bar right)
        {
            return left.Bars != right.Bars;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Bars.Equals(((Bar) obj).Bars);
        }

        public override int GetHashCode()
        {
            return Bars.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from Bar to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(BarUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case BarUnit.Bar:
                    newValue = Bars;
                    return true;
                case BarUnit.BarPlus1:
                    newValue = BarPlusOnes;
                    return true;
                case BarUnit.BarTripled:
                    newValue = BarsTripled;
                    return true;
                case BarUnit.TwiceThanBar:
                    newValue = TwiceThanBars;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from Bar to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(BarUnit toUnit)
        {
            double newValue;
            if (!TryConvert(toUnit, out newValue))
                throw new NotImplementedException("toUnit: " + toUnit);

            return newValue;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Bars, UnitSystem.Create().GetDefaultAbbreviation(BarUnit.Bar));
        }
    }
} 
