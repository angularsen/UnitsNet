// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

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

        protected override double CubicMilesInOneCubicMeter => 2.399127585789277e-10;

        protected override double CubicMillimetersInOneCubicMeter => 1E9;

        protected override double CubicMicrometersInOneCubicMeter => 1E18;

        protected override double CubicYardsInOneCubicMeter => 1.30795062;

        protected override double DecilitersInOneCubicMeter => 1E4;
        protected override double HectocubicFeetInOneCubicMeter => 3.531472e-1;
        protected override double HectocubicMetersInOneCubicMeter => 0.01;

        protected override double HectolitersInOneCubicMeter => 1E1;

        protected override double ImperialGallonsInOneCubicMeter => 219.96924;

        protected override double ImperialOuncesInOneCubicMeter => 35195.07972;

        protected override double KilocubicFeetInOneCubicMeter => 3.531472e-2;
        protected override double KilocubicMetersInOneCubicMeter => 0.001;
        protected override double KiloimperialGallonsInOneCubicMeter => 2.1996924e-1;
        protected override double KilousGallonsInOneCubicMeter => 2.6417217e-1;

        protected override double LitersInOneCubicMeter => 1E3;
        protected override double KilolitersInOneCubicMeter => 1;

        protected override double MegacubicFeetInOneCubicMeter => 3.531472e-5;
        protected override double MegaimperialGallonsInOneCubicMeter => 2.1996924e-4;
        protected override double MegausGallonsInOneCubicMeter => 2.6417217e-4;

        protected override double MicrolitersInOneCubicMeter => 1E9;

        protected override double MillilitersInOneCubicMeter => 1E6;

        protected override double AuTablespoonsInOneCubicMeter => 50000;

        protected override double UsTablespoonsInOneCubicMeter => 67628.0454;

        protected override double MetricTeaspoonsInOneCubicMeter => 200000;

        protected override double UsTeaspoonsInOneCubicMeter => 202884.13621105801;

        protected override double ImperialBeerBarrelsInOneCubicMeter => 6.1102568972;

        protected override double UkTablespoonsInOneCubicMeter => 66666.6666667;

        protected override double UsBeerBarrelsInOneCubicMeter => 8.5216790723083;

        protected override double UsGallonsInOneCubicMeter => 264.17217;

        protected override double UsOuncesInOneCubicMeter => 33814.02270;

        protected override double MetricCupsInOneCubicMeter => 4000;

        protected override double UsCustomaryCupsInOneCubicMeter => 4226.75283773;

        protected override double UsLegalCupsInOneCubicMeter => 4166.666666667;

        protected override double OilBarrelsInOneCubicMeter => 6.2898107704321051280928552764086;

        protected override double UsPintsInOneCubicMeter => 2113.3764188652;

        protected override double UsQuartsInOneCubicMeter => 1056.6882094326;

        protected override double AcreFeetInOneCubicMeter => 0.000810714;

        protected override double MegalitersInOneCubicMeter => 0.001;

        protected override double ImperialPintsInOneCubicMeter => 1.7597539863927023e3;

        [ Fact]
        public void VolumeDividedByAreaEqualsLength()
        {
            Length length = Volume.FromCubicMeters(15)/Area.FromSquareMeters(5);
            Assert.Equal(length, Length.FromMeters(3));
        }

        [Fact]
        public void VolumeDividedByLengthEqualsArea()
        {
            Area area = Volume.FromCubicMeters(15)/Length.FromMeters(5);
            Assert.Equal(area, Area.FromSquareMeters(3));
        }

        [Fact]
        public void VolumeTimesDensityEqualsMass()
        {
            Mass mass = Volume.FromCubicMeters(2)*Density.FromKilogramsPerCubicMeter(3);
            Assert.Equal(mass, Mass.FromKilograms(6));
        }

        [Theory]
        [InlineData(20, 2, 10)]
        [InlineData(20, 80, 0.25)]
        public void VolumeDividedByTimeSpanEqualsVolumeFlow(double cubicMeters, double seconds, double expectedCubicMetersPerSecond)
        {
            VolumeFlow volumeFlow = Volume.FromCubicMeters(cubicMeters) / TimeSpan.FromSeconds(seconds);
            Assert.Equal(VolumeFlow.FromCubicMetersPerSecond(expectedCubicMetersPerSecond), volumeFlow);
        }

        [Fact]
        public void VolumeDividedByDurationEqualsVolumeFlow()
        {
            VolumeFlow volumeFlow = Volume.FromCubicMeters(20) / Duration.FromSeconds(2);
            Assert.Equal(VolumeFlow.FromCubicMetersPerSecond(10), volumeFlow);
        }

        [Fact]
        public void VolumeDividedByVolumeFlowEqualsTimeSpan()
        {
            TimeSpan timeSpan = Volume.FromCubicMeters(20) / VolumeFlow.FromCubicMetersPerSecond(2);
            Assert.Equal(TimeSpan.FromSeconds(10), timeSpan);
        }
    }
}
