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
    public class VolumeTests : VolumeTestsBase
    {
        protected override double CentilitersInOneCubicMeter => 1E5;

        protected override double CubicCentimetersInOneCubicMeter => 1E6;

        protected override double CubicDecimetersInOneCubicMeter => 1E3;

        protected override double CubicFeetInOneCubicMeter => 35.31472;

        protected override double CubicInchesInOneCubicMeter => 61023.98242;

        protected override double CubicKilometersInOneCubicMeter => 1E-9;

        protected override double CubicMetersInOneCubicMeter => 1;

        protected override double CubicMilesInOneCubicMeter => 3.86102*1E-7;

        protected override double CubicMillimetersInOneCubicMeter => 1E9;

        protected override double CubicMicrometersInOneCubicMeter => 1E18;

        protected override double CubicYardsInOneCubicMeter => 1.30795062;

        protected override double DecilitersInOneCubicMeter => 1E4;

        protected override double HectolitersInOneCubicMeter => 1E1;

        protected override double ImperialGallonsInOneCubicMeter => 219.96924;

        protected override double ImperialOuncesInOneCubicMeter => 35195.07972;

        protected override double LitersInOneCubicMeter => 1E3;

        protected override double MicrolitersInOneCubicMeter => 1E9;

        protected override double MillilitersInOneCubicMeter => 1E6;

        protected override double AuTablespoonsInOneCubicMeter => 50000;

        protected override double UsTablespoonsInOneCubicMeter => 67628.0454;
        
        protected override double TablespoonsInOneCubicMeter => 67628.0454;

        protected override double TablespoonsTolerance => 1E-4;

        protected override double MetricTeaspoonsInOneCubicMeter => 200000;

        protected override double UsTeaspoonsInOneCubicMeter => 202884.13621105801;

        protected override double TeaspoonsInOneCubicMeter => 202884.13621105801;

        protected override double UkTablespoonsInOneCubicMeter => 66666.6666667;

        protected override double TeaspoonsTolerance => 1E-3;

        protected override double UsGallonsInOneCubicMeter => 264.17217;
        
        protected override double UsOuncesInOneCubicMeter => 33814.02270;

        protected override double MetricCupsInOneCubicMeter => 4000;

        protected override double UsCustomaryCupsInOneCubicMeter => 4226.75283773;

        protected override double UsLegalCupsInOneCubicMeter => 4166.666666667;

        [Test]
        public void VolumeDividedByAreaEqualsLength()
        {
            Length length = Volume.FromCubicMeters(15)/Area.FromSquareMeters(5);
            Assert.AreEqual(length, Length.FromMeters(3));
        }

        [Test]
        public void VolumeDividedByLengthEqualsArea()
        {
            Area area = Volume.FromCubicMeters(15)/Length.FromMeters(5);
            Assert.AreEqual(area, Area.FromSquareMeters(3));
        }

        [Test]
        public void VolumeTimesDensityEqualsMass()
        {
            Mass mass = Volume.FromCubicMeters(2)*Density.FromKilogramsPerCubicMeter(3);
            Assert.AreEqual(mass, Mass.FromKilograms(6));
        }
    }
}