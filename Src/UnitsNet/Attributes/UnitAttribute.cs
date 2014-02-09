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

namespace UnitsNet.Attributes
{
    public struct LinearFunction
    {
        /// <summary>
        ///     Slope of function, a, in y(x) = ax + b.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public readonly double a;

        /// <summary>
        ///     Y-intercept of function, b, in y(x) = ax + b.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public readonly double b;

        /// <summary>
        ///     Create linear function by its slope and y-intercept constants.
        /// </summary>
        /// <param name="a">Slope of function, a, in y(x) = ax + b.</param>
        /// <param name="b">Y-intercept of function, b, in y(x) = ax + b.</param>
        public LinearFunction(double a, double b)
        {
            this.b = b;
            this.a = a;
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public abstract class UnitAttribute : Attribute
    {
        protected UnitAttribute(string pluralName, double slope, double offset)
        {
            // Example: Kilometer has slope 1000, meaning for every kilometer the base unit increases with 1000 meters.
            // a: 1000
            // b: 0
            // y: base unit value in meters
            // x: unit value in kilometers
            // new Length(2000).Kilometers => (y - b) / a = (2000 - 0) / 1000 = 2km
            // Length.FromKilometers(2) => y = ax + b = 1000*2 + 0 = 2000m
            double a = slope;
            double b = offset;
            LinearFunction = new LinearFunction(a, b);
            PluralName = pluralName;
        }

        /// <summary>
        ///     Name of unit in plural form. Will be used as property name such as Force.FromNewtonmeters().
        /// </summary>
        public string PluralName { get; private set; }

        /// <summary>
        ///     Ratio of unit to base unit. For example, <see cref="Unit.Kilometer" /> is 1000:1 of the base unit
        ///     <see cref="Unit.Meter" />.
        /// </summary>
        public LinearFunction LinearFunction { get; private set; }
    }
}