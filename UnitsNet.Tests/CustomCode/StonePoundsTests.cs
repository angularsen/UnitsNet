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

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class StonePoundsTests
    {
        private const double StoneInOneKilogram = 0.1574731728702698;
        private const double PoundsInOneKilogram = 2.2046226218487757d;
        private const double StoneTolerance = 1e-4;
        private const double PoundsTolerance = 1e-4;

        [Fact]
        public void StonePoundsFrom()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            double expectedKg = 2/StoneInOneKilogram + 3/PoundsInOneKilogram;
            AssertEx.EqualTolerance(expectedKg, m.Kilograms, StoneTolerance);
        }

        [Fact]
        public void StonePoundsRoundTrip()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            StonePounds stonePounds = m.StonePounds;
            AssertEx.EqualTolerance(2, stonePounds.Stone, StoneTolerance);
            AssertEx.EqualTolerance(3, stonePounds.Pounds, PoundsTolerance);
        }
    }
}