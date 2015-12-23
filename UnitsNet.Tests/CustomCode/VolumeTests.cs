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

using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    public class VolumeTests : VolumeTestsBase
    {
        [Test]
        public void VolumeDividedByLengthEqualsArea()
        {
            var area = Volume.FromCubicMeters(15) / Length.FromMeters(5);
            Assert.AreEqual(area, Area.FromSquareMeters(3));
        }
        [Test]
        public void VolumeDividedByAreaEqualsLength()
        {
            var length= Volume.FromCubicMeters(15) / Area.FromSquareMeters(5);
            Assert.AreEqual(length, Length.FromMeters(3));
        }
        [Test]
        public void VolumeTimesDensityEqualsMass()
        {
            var mass = Volume.FromCubicMeters(2) * Density.FromKilogramsPerCubicMeter(3);
            Assert.AreEqual(mass, Mass.FromKilograms(6));
        }
        
        protected override double CentilitersInOneCubicMeter
        {
            get { return 1E5; }
        }

        protected override double CubicCentimetersInOneCubicMeter
        {
            get { return 1E6; }
        }

        protected override double CubicDecimetersInOneCubicMeter
        {
            get { return 1E3; }
        }

        protected override double CubicFeetInOneCubicMeter
        {
            get { return 35.31472; }
        }

        protected override double CubicInchesInOneCubicMeter
        {
            get { return 61023.98242; }
        }

        protected override double CubicKilometersInOneCubicMeter
        {
            get { return 1E-9; }
        }

        protected override double CubicMetersInOneCubicMeter
        {
            get { return 1; }
        }

        protected override double CubicMilesInOneCubicMeter
        {
            get { return 3.86102*1E-7; }
        }

        protected override double CubicMillimetersInOneCubicMeter
        {
            get { return 1E9; }
        }

        protected override double CubicYardsInOneCubicMeter
        {
            get { return 1.30795062; }
        }

        protected override double DecilitersInOneCubicMeter
        {
            get { return 1E4; }
        }

        protected override double HectolitersInOneCubicMeter
        {
            get { return 1E1; }
        }

        protected override double ImperialGallonsInOneCubicMeter
        {
            get { return 219.96924; }
        }

        protected override double ImperialOuncesInOneCubicMeter
        {
            get { return 35195.07972; }
        }

        protected override double LitersInOneCubicMeter
        {
            get { return 1E3; }
        }

        protected override double MillilitersInOneCubicMeter
        {
            get { return 1E6; }
        }

        protected override double TablespoonsInOneCubicMeter
        {
            get { return 67628.0454; }
        }

        protected override double TablespoonsTolerance
        {
            get { return 1E-4; }
        }

        protected override double TeaspoonsInOneCubicMeter
        {
            get { return 202884.136; }
        }

        protected override double TeaspoonsTolerance
        {
            get { return 1E-3; }
        }

        protected override double UsGallonsInOneCubicMeter
        {
            get { return 264.17217; }
        }

        protected override double UsOuncesInOneCubicMeter
        {
            get { return 33814.02270; }
        }
    }
}