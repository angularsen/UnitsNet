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

using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    [TestFixture]
    public class StonePoundsTests
    {
        private const double StoneInOneKilogram = 0.1574731728702698;
        private const double PoundsInOneKilogram = 2.2046226218487757d;
        private const double StoneTolerance = 1e-4;
        private const double PoundsTolerance = 1e-4;

        [Test]
        public void StonePoundsFrom()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            double expectedKg = 2/StoneInOneKilogram + 3/PoundsInOneKilogram;
            Assert.AreEqual(expectedKg, m.Kilograms, StoneTolerance);
        }

        [Test]
        public void StonePoundsRoundTrip()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            StonePounds stonePounds = m.StonePounds;
            Assert.AreEqual(2, stonePounds.Stone, StoneTolerance);
            Assert.AreEqual(3, stonePounds.Pounds, PoundsTolerance);
        }
    }
}