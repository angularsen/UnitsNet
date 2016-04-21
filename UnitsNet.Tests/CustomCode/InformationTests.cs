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
    public class InformationTests : InformationTestsBase
    {
        protected override double BitsInOneBit => 1d;

        protected override double BytesInOneBit => 0.125d;

        protected override double ExabitsInOneBit => 1e-18d;

        protected override double ExabytesInOneBit => 0.125d*1e-18d;

        protected override double ExbibitsInOneBit => 1d/Math.Pow(1024, 6);

        protected override double ExbibytesInOneBit => 8d/Math.Pow(1024, 6);

        protected override double GibibitsInOneBit => 1d/Math.Pow(1024, 3);

        protected override double GibibytesInOneBit => 1d/8/Math.Pow(1024, 3);

        protected override double GigabitsInOneBit => 1e-9d;

        protected override double GigabytesInOneBit => 0.125d*1e-9d;

        protected override double KibibitsInOneBit => 1d/1024d;

        protected override double KibibytesInOneBit => 1d/8/1024d;

        protected override double KilobitsInOneBit => 0.001d;

        protected override double KilobytesInOneBit => 0.000125d;

        protected override double MebibitsInOneBit => 1d/Math.Pow(1024, 2);

        protected override double MebibytesInOneBit => 1d/8/Math.Pow(1024, 2);

        protected override double MegabitsInOneBit => 1e-6d;

        protected override double MegabytesInOneBit => 0.125d*1e-6d;

        protected override double PebibitsInOneBit => 1d/Math.Pow(1024, 5);

        protected override double PebibytesInOneBit => 1d/8/Math.Pow(1024, 5);

        protected override double PetabitsInOneBit => 1e-15d;

        protected override double PetabytesInOneBit => 0.125d*1e-15d;

        protected override double TebibitsInOneBit => 1d/Math.Pow(1024, 4);

        protected override double TebibytesInOneBit => 1d/8/Math.Pow(1024, 4);

        protected override double TerabitsInOneBit => 1e-12d;

        protected override double TerabytesInOneBit => 0.125d*1e-12d;

// ReSharper disable once InconsistentNaming
        [Test]
        public void OneKBHas1000Bytes()
        {
            Assert.AreEqual(1000, Information.FromKilobytes(1).Bytes);
        }

        [Test]
        public void MaxValueIsCorrectForUnitWithBaseTypeDecimal()
        {
            Assert.AreEqual(decimal.MaxValue, Information.MaxValue.Bits);
        }

        [Test]
        public void MinValueIsCorrectForUnitWithBaseTypeDecimal()
        {
            Assert.AreEqual(decimal.MinValue, Information.MinValue.Bits);
        }
    }
}