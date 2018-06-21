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
        public static bool Equals( double value1, double value2, double tolerance, ComparisonType comparisonType)
        {
            if(comparisonType == ComparisonType.Relative)
                return EqualsRelative(value1, value2, tolerance);
            else if(comparisonType == ComparisonType.Absolute)
                return EqualsAbsolute(value1, value2, tolerance);
            else
                throw new InvalidOperationException("The ComparisonType is unsupported.");
        }

        public static bool EqualsRelative( double value1, double value2, double tolerance)
        {
            double maxVariation = Math.Abs( value1 * tolerance );
            return Math.Abs( value1 - value2 ) <= maxVariation;
        }

        public static bool EqualsAbsolute( double value1, double value2, double tolerance)
        {
            return Math.Abs( value1 - value2 ) <= tolerance;
        }
    }
}
