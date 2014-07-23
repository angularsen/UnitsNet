// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.cod/InitialForce/UnitsNet
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
        protected override double BitsInOneBit
        {
            get { return 1d; }
        }

        protected override double BytesInOneBit
        {
            get { return 0.125d; }
        }

        protected override double ExabitsInOneBit
        {
            get { return 1e-18d; }
        }

        protected override double ExabytesInOneBit
        {
            get { return 0.125d*1e-18d; }
        }

        protected override double ExbibitsInOneBit
        {
            get { return 1d/Math.Pow(1024, 6); }
        }

        protected override double ExbibytesInOneBit
        {
            get { return 8d/Math.Pow(1024, 6); }
        }

        protected override double GibibitsInOneBit
        {
            get { return 1d/Math.Pow(1024, 3); }
        }

        protected override double GibibytesInOneBit
        {
            get { return 1d/8/Math.Pow(1024, 3); }
        }

        protected override double GigabitsInOneBit
        {
            get { return 1e-9d; }
        }

        protected override double GigabytesInOneBit
        {
            get { return 0.125d*1e-9d; }
        }

        protected override double KibibitsInOneBit
        {
            get { return 1d/1024d; }
        }

        protected override double KibibytesInOneBit
        {
            get { return 1d/8/1024d; }
        }

        protected override double KilobitsInOneBit
        {
            get { return 0.001d; }
        }

        protected override double KilobytesInOneBit
        {
            get { return 0.000125d; }
        }

        protected override double MebibitsInOneBit
        {
            get { return 1d/Math.Pow(1024, 2); }
        }

        protected override double MebibytesInOneBit
        {
            get { return 1d/8/Math.Pow(1024, 2); }
        }

        protected override double MegabitsInOneBit
        {
            get { return 1e-6d; }
        }

        protected override double MegabytesInOneBit
        {
            get { return 0.125d*1e-6d; }
        }

        protected override double PebibitsInOneBit
        {
            get { return 1d/Math.Pow(1024, 5); }
        }

        protected override double PebibytesInOneBit
        {
            get { return 1d/8/Math.Pow(1024, 5); }
        }

        protected override double PetabitsInOneBit
        {
            get { return 1e-15d; }
        }

        protected override double PetabytesInOneBit
        {
            get { return 0.125d*1e-15d; }
        }

        protected override double TebibitsInOneBit
        {
            get { return 1d/Math.Pow(1024, 4); }
        }

        protected override double TebibytesInOneBit
        {
            get { return 1d/8/Math.Pow(1024, 4); }
        }

        protected override double TerabitsInOneBit
        {
            get { return 1e-12d; }
        }

        protected override double TerabytesInOneBit
        {
            get { return 0.125d*1e-12d; }
        }

// ReSharper disable once InconsistentNaming
        [Test]
        public void OneKBHas1000Bytes()
        {
            Assert.AreEqual(1000, Information.FromKilobytes(1).Bytes);
        }
    }
}