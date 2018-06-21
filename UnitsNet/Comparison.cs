// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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

namespace UnitsNet
{
    public sealed class Comparison
    {
        /// <summary>
        ///     Checks if two values are equal with a given relative or absolute tolerance.
        ///     Relative tolerance is when the difference between the two values is not greater than referenceValue * tolerance.
        ///     Absolute tolerance is when the absolute difference between the two values is not greater than the tolerance value.
        /// </summary>
        /// <param name="referenceValue">The first value. If using relative tolerance, it is the value which the relative tolerance will be calculated against.</param>
        /// <param name="value">The value to compare to.</param>
        /// <param name="tolerance">The absolute or relative tolerance value.</param>
        /// <param name="comparisonType">Whether to use tolerance as an absolute or relative tolerance.</param>
        /// <returns></returns>
        public static bool Equals(double referenceValue, double value, double tolerance, ComparisonType comparisonType)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0");

            switch(comparisonType)
            {
                case ComparisonType.Relative:
                    return EqualsRelative(referenceValue, value, tolerance);
                case ComparisonType.Absolute:
                    return EqualsAbsolute(referenceValue, value, tolerance);
                default:
                    throw new InvalidOperationException("The given ComparisonType is not supported.");
            }
        }

        /// <summary>
        ///     Checks if two values are equal with a given relative tolerance. The relative tolerance is calculated against the referenceValue parameter.
        ///     Relative tolerance is when the difference between the two values is not greater than referenceValue * tolerance.
        /// </summary>
        /// <param name="referenceValue">The reference value which the tolerance will be calculated against.</param>
        /// <param name="value">The value to compare to.</param>
        /// <param name="tolerance"></param>
        /// <returns>True if the two values are equal within the given relative tolerance, otherwise false.</returns>
        public static bool EqualsRelative(double referenceValue, double value, double tolerance)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0");

            double maxVariation = Math.Abs(referenceValue * tolerance);
            return Math.Abs(referenceValue - value) <= maxVariation;
        }

        /// <summary>
        ///     Checks if two values are equal with a given absolute tolerance.
        ///     Absolute tolerance is when the absolute difference between the two values is not greater than the tolerance value.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="tolerance">The absolute tolerance. This is the maxinum allowable absolute difference between the two values. Must be greater than 0.</param>
        /// <returns>True if the two values are equal within the given absolute tolerance, otherwise false.</returns>
        public static bool EqualsAbsolute(double value1, double value2, double tolerance)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0");

            return Math.Abs(value1 - value2) <= tolerance;
        }
    }
}
