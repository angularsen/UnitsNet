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
    public static class Comparison
    {
        /// <summary>
        ///     <para>
        ///     Checks if two values are equal with a given relative or absolute tolerance.
        ///     </para>
        ///     <para>
        ///     Relative tolerance is defined as the maximum allowable absolute difference between <paramref name="referenceValue"/> and
        ///     <paramref name="otherValue"/> as a percentage of <paramref name="referenceValue"/>. A relative tolerance of 0.01 means the
        ///     absolute difference of <paramref name="referenceValue"/> and <paramref name="otherValue"/> must be within +/- 1%.
        ///     <example>
        ///     In this example, the two values will be equal if the value of b is within +/- 1% of a.
        ///     <code>
        ///     Equals(a, b, 0.01, ComparisonType.Relative);
        ///     </code>
        ///     </example>
        ///     </para>
        ///     <para>
        ///     Absolute tolerance is defined as the maximum allowable absolute difference between <paramref name="referenceValue"/> and
        ///     <paramref name="otherValue"/> as a fixed number.
        ///     <example>
        ///     In this example, the two values will be equal if abs(<paramref name="referenceValue"/> - <paramref name="otherValue"/>) <= 0.01
        ///     <code>
        ///     Equals(a, b, 0.01, ComparisonType.Absolute);
        ///     </code>
        ///     </example>
        ///     </para>
        /// </summary>
        /// <param name="referenceValue">The reference value. If using relative tolerance, it is the value which the relative tolerance will be calculated against.</param>
        /// <param name="otherValue">The value to compare to.</param>
        /// <param name="tolerance">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
        /// <param name="comparisonType">Whether the tolerance is absolute or relative.</param>
        /// <returns></returns>
        public static bool Equals(double referenceValue, double otherValue, double tolerance, ComparisonType comparisonType)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0");

            switch(comparisonType)
            {
                case ComparisonType.Relative:
                    return EqualsRelative(referenceValue, otherValue, tolerance);
                case ComparisonType.Absolute:
                    return EqualsAbsolute(referenceValue, otherValue, tolerance);
                default:
                    throw new InvalidOperationException("The given ComparisonType is not supported.");
            }
        }

        /// <summary>
        ///     Checks if two values are equal with a given relative tolerance.
        ///     <para>
        ///     Relative tolerance is defined as the maximum allowable absolute difference between <paramref name="referenceValue"/> and
        ///     <paramref name="otherValue"/> as a percentage of <paramref name="referenceValue"/>. A relative tolerance of 0.01 means the
        ///     absolute difference of <paramref name="referenceValue"/> and <paramref name="otherValue"/> must be within +/- 1%.
        ///     <example>
        ///     In this example, the two values will be equal if the value of b is within +/- 1% of a.
        ///     <code>
        ///     EqualsRelative(a, b, 0.01);
        ///     </code>
        ///     </example>
        ///     </para>
        /// </summary>
        /// <param name="referenceValue">The reference value which the tolerance will be calculated against.</param>
        /// <param name="otherValue">The value to compare to.</param>
        /// <param name="tolerance">The relative tolerance. Must be greater than or equal to 0.</param>
        /// <returns>True if the two values are equal within the given relative tolerance, otherwise false.</returns>
        public static bool EqualsRelative(double referenceValue, double otherValue, double tolerance)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0");

            double maxVariation = Math.Abs(referenceValue * tolerance);
            return Math.Abs(referenceValue - otherValue) <= maxVariation;
        }

        /// <summary>
        ///     Checks if two values are equal with a given absolute tolerance.
        ///     <para>
        ///     Absolute tolerance is defined as the maximum allowable absolute difference between <paramref name="referenceValue"/> and
        ///     <paramref name="otherValue"/> as a fixed number.
        ///     <example>
        ///     In this example, the two values will be equal if abs(<paramref name="referenceValue"/> - <paramref name="otherValue"/>) <= 0.01
        ///     <code>
        ///     Equals(a, b, 0.01, ComparisonType.Absolute);
        ///     </code>
        ///     </example>
        ///     </para>
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="tolerance">The absolute tolerance. Must be greater than or equal to 0.</param>
        /// <returns>True if the two values are equal within the given absolute tolerance, otherwise false.</returns>
        public static bool EqualsAbsolute(double value1, double value2, double tolerance)
        {
            if(tolerance < 0)
                throw new ArgumentOutOfRangeException("tolerance", "Tolerance must be greater than or equal to 0");

            return Math.Abs(value1 - value2) <= tolerance;
        }
    }
}
