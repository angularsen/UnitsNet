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
using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    public class LevelTests : LevelTestsBase
    {
        protected override double DecibelsInOneDecibel => 1;

        protected override double NepersInOneDecibel => 0.115129254;

        protected override void AssertLogarithmicAddition()
        {
            Level v = Level.FromDecibels(40);
            Assert.AreEqual(43.0102999566, (v + v).Decibels, DecibelsTolerance);
        }

        protected override void AssertLogarithmicSubtraction()
        {
            Level v = Level.FromDecibels(40);
            Assert.AreEqual(49.5424250944, (Level.FromDecibels(50) - v).Decibels, DecibelsTolerance);
        }

        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        public void InvalidQuantity_ExpectArgumentOutOfRangeException(double quantity, double reference)
        {
            // quantity can't be zero or less than zero if reference is positive.
            Assert.Throws<ArgumentOutOfRangeException>(() => new Level(quantity, reference));
        }

        [TestCase(1, 0)]
        [TestCase(10, -1)]
        public void InvalidReference_ExpectArgumentOutOfRangeException(double quantity, double reference)
        {
            // reference can't be zero or less than zero if quantity is postive.
            Assert.Throws<ArgumentOutOfRangeException>(() => new Level(quantity, reference));
        }
    }
}