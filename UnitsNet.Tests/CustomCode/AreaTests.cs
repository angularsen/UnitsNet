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
    public class AreaTests : AreaTestsBase
    {

        protected override double SquareKilometersInOneSquareMeter => 1E-6;

        protected override double SquareMetersInOneSquareMeter => 1;

        protected override double AcresInOneSquareMeter => 2.471053816137*1E-4;

        protected override double HectaresInOneSquareMeter => 1E-4;

        protected override double SquareCentimetersInOneSquareMeter => 1E4;

        protected override double SquareDecimetersInOneSquareMeter => 1E2;

        protected override double SquareMillimetersInOneSquareMeter => 1E6;

        protected override double SquareFeetInOneSquareMeter => 10.76391;

        protected override double SquareMicrometersInOneSquareMeter => 1E12;

        protected override double SquareInchesInOneSquareMeter => 1550.003100;

        protected override double SquareMilesInOneSquareMeter => 3.86102*1E-7;

        protected override double SquareYardsInOneSquareMeter => 1.19599;

        protected override double UsSurveySquareFeetInOneSquareMeter => 10.76386736111121;

        [Fact]
        public void AreaDividedByLengthEqualsLength()
        {
            Length length = Area.FromSquareMeters(50)/Length.FromMeters(5);
            Assert.Equal(length, Length.FromMeters(10));
        }

        [Fact]
        public void AreaTimesMassFluxEqualsMassFlow()
        {
            MassFlow massFlow = Area.FromSquareMeters(20) * MassFlux.FromKilogramsPerSecondPerSquareMeter(2);
            Assert.Equal(massFlow, MassFlow.FromKilogramsPerSecond(40));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.5, 0.19634954084936208)]
        [InlineData(1, 0.7853981633974483)]
        [InlineData(2, 3.141592653589793)]
        public void AreaFromCicleDiameterCalculatedCorrectly(double diameterMeters, double expected)
        {
            Length diameter = Length.FromMeters(diameterMeters);

            double actual = Area.FromCircleDiameter(diameter).SquareMeters;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0.5, 0.7853981633974483)]
        [InlineData(1, 3.141592653589793)]
        [InlineData(2, 12.566370614359173)]
        public void AreaFromCicleRadiusCalculatedCorrectly(double radiusMeters, double expected)
        {
            Length radius = Length.FromMeters(radiusMeters);

            double actual = Area.FromCircleRadius(radius).SquareMeters;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AreaTimesSpeedEqualsVolumeFlow()
        {
            VolumeFlow volumeFlow = Area.FromSquareMeters(20) * Speed.FromMetersPerSecond(2);
            Assert.Equal(VolumeFlow.FromCubicMetersPerSecond(40), volumeFlow);
        }
    }
}
