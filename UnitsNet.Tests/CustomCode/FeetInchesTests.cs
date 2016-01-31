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
    public class FeetInchesTests
    {
        private const double FeetInOneMeter = 3.28084;
        private const double InchesInOneMeter = 39.37007874;
        private const double FeetTolerance = 1e-5;
        private const double InchesTolerance = 1e-5;

        [Test]
        public void FeetInchesFrom()
        {
            Length meter = Length.FromFeetInches(2, 3);
            double expectedMeters = 2/FeetInOneMeter + 3/InchesInOneMeter;
            Assert.AreEqual(expectedMeters, meter.Meters, FeetTolerance);
        }

        [Test]
        public void FeetInchesRoundTrip()
        {
            Length meter = Length.FromFeetInches(2, 3);
            FeetInches feetInches = meter.FeetInches;
            Assert.AreEqual(2, feetInches.Feet, FeetTolerance);
            Assert.AreEqual(3, feetInches.Inches, InchesTolerance);
        }
    }
}