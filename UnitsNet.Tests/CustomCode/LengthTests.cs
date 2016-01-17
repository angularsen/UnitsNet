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

namespace UnitsNet.Tests.CustomCode
{
    public class LengthTests : LengthTestsBase
    {
        [Test]
        public void LengthTimesLengthEqualsArea()
        {
            var area = Length.FromMeters(10) * Length.FromMeters(2);
            Assert.AreEqual(area, Area.FromSquareMeters(20));
        }

        [Test]
        public void AreaTimesLengthEqualsArea()
        {
            var volume = Area.FromSquareMeters(10) * Length.FromMeters(3);
            Assert.AreEqual(volume, Volume.FromCubicMeters(30));
        }
        [Test]
        public void LengthTimesAreaEqualsArea()
        {
            var volume = Length.FromMeters(3) * Area.FromSquareMeters(9);
            Assert.AreEqual(volume, Volume.FromCubicMeters(27));
        }

        [Test]
        public void ForceTimesLengthEqualsTorque()
        {
            var volume = Length.FromMeters(3) * Area.FromSquareMeters(9);
            Assert.AreEqual(volume, Volume.FromCubicMeters(27));
        }

        protected override double CentimetersInOneMeter
        {
            get { return 100; }
        }

        protected override double DecimetersInOneMeter
        {
            get { return 10; }
        }

        protected override double FeetInOneMeter
        {
            get { return 3.28084; }
        }

        protected override double InchesInOneMeter
        {
            get { return 39.37007874; }
        }

        protected override double KilometersInOneMeter
        {
            get { return 1E-3; }
        }

        protected override double MetersInOneMeter
        {
            get { return 1; }
        }

        protected override double MicroinchesInOneMeter
        {
            get { return 39370078.74015748; }
        }

        protected override double MicrometersInOneMeter
        {
            get { return 1E6; }
        }

        protected override double MilsInOneMeter
        {
            get { return 39370.07874015; }
        }

        protected override double MilesInOneMeter
        {
            get { return 0.000621371; }
        }

        protected override double MillimetersInOneMeter
        {
            get { return 1E3; }
        }

        protected override double NanometersInOneMeter
        {
            get { return 1E9; }
        }

        protected override double YardsInOneMeter
        {
            get { return 1.09361; }
        }


        protected override double NauticalMilesInOneMeter
        {
            get
            { return 1.0/1852.0; }
        }

    }
}