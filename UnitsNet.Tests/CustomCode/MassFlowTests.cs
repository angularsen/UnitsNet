// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
using UnitsNet.Units;

namespace UnitsNet.Tests.CustomCode
{
    public class MassFlowTests : MassFlowTestsBase
    {
        // strange bug
        [Test]
        public void MassFlowTimesTimeSpanEqualsMass()
        {
            var mass = MassFlow.FromKilogramsPerSecond(20.0) * TimeSpan.FromSeconds(4.0);
            Assert.AreEqual(mass, Mass.FromKilograms(80.0));
        }
        [Test]
        public void TimeSpanTimesMassFlowEqualsMass()
        {
            var mass = TimeSpan.FromSeconds(4.0) * MassFlow.FromKilogramsPerSecond(20.0);
            Assert.AreEqual(mass, Mass.FromKilograms(80.0));
        }

        // TODO Override properties in base class here
        protected override double KilogramsPerSecondInOneKilogramPerSecond
        {
            get
            {
                return 1.0;
            }
        }

        protected override double TonnesPerDayInOneKilogramPerSecond
        {
            get
            {
                return (60.0 * 60 * 24 / 1000);
            }
        }
    }
}
