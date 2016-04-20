// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
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
#if WINDOWS_UWP
    public sealed partial class Level
#else
    public partial struct Level
#endif
    {
        /// <summary>
        ///     Initializes a new instance of the logarithmic <see cref="Level" /> struct which is the ratio of a quantity Q to a
        ///     reference value of that quantity Q0.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <param name="reference">The reference value that <paramref name="quantity" /> is compared to.</param>
        public Level(double quantity, double reference)
            : this()
        {
            string errorMessage =
                $"The base-10 logarithm of a number ≤ 0 is undefined ({quantity}/{reference}).";

            if (quantity == 0 || (quantity < 0 && reference > 0))
                throw new ArgumentOutOfRangeException(nameof(quantity), errorMessage);
            if (reference == 0 || quantity > 0 && reference < 0)
                throw new ArgumentOutOfRangeException(nameof(reference), errorMessage);

            _decibels = 10*Math.Log10(quantity/reference);
        }
    }
}