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
namespace UnitsNet.ThirdParty
{
    /// <summary>
    /// Dynamically convert between compatible units only known at runtime.
    /// </summary>
    public static class UnitConverter
    {
        /// <summary>
        /// Dynamically convert between two compatible units only known at runtime, such as converting from millimeters to meters.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit.</returns> 
        /// <exception cref="Exception">If the two units are not compatible.</exception>
        public static double Convert(double value, FooUnit fromUnit, FooUnit toUnit)
        {
            if (fromUnit == toUnit)
                return value;

            double newValue;
            if (TryConvertFromFoo(value, fromUnit, toUnit, out newValue)) return newValue;

            throw new Exception(
                string.Format("Conversion from unit [{0}] to [{1}] is either not valid or not yet implemented.",
                              fromUnit, toUnit));
        }

        /// <summary>
        /// Dynamically convert between two compatible units only known at runtime, such as converting from millimeters to meters.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public static bool TryConvert(double value, FooUnit fromUnit, FooUnit toUnit, out double newValue)
        {
            if (fromUnit == toUnit)
            {
                newValue = value;
                return true;
            }
 
            if (TryConvertFromFoo(value, fromUnit, toUnit, out newValue)) return true;

            return false;
        }

        #region Private


        /// <summary>
        /// Try to dynamically convert from Foo to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvertFromFoo(double value, FooUnit fromUnit, FooUnit toUnit, out double newValue)
        {
            switch (fromUnit)
            {
                case FooUnit.Bar:
                    return TryConvert(Foo.FromBars(value), toUnit, out newValue);
                case FooUnit.TwiceThanBar:
                    return TryConvert(Foo.FromTwiceThanBars(value), toUnit, out newValue);
                case FooUnit.BarPlus1:
                    return TryConvert(Foo.FromBarPlusOnes(value), toUnit, out newValue);
                case FooUnit.BarTripled:
                    return TryConvert(Foo.FromBarsTripled(value), toUnit, out newValue);

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Try to dynamically convert from Foo to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        private static bool TryConvert(Foo value, FooUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case FooUnit.Bar:
                    newValue = value.Bars;
                    return true;
                case FooUnit.TwiceThanBar:
                    newValue = value.TwiceThanBars;
                    return true;
                case FooUnit.BarPlus1:
                    newValue = value.BarPlusOnes;
                    return true;
                case FooUnit.BarTripled:
                    newValue = value.BarsTripled;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

 
        #endregion
    }
}

