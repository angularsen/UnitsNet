﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class VolumeTests : VolumeTestsBase
    {
        protected override double CentilitersInOneCubicMeter => 1E5;

        protected override double CubicCentimetersInOneCubicMeter => 1E6;

        protected override double CubicDecimetersInOneCubicMeter => 1E3;

        protected override double CubicFeetInOneCubicMeter => 35.314666721488590250438010354003;

        protected override double CubicInchesInOneCubicMeter => 61_023.744094732283952756881891717;

        protected override double CubicKilometersInOneCubicMeter => 1E-9;

        protected override double CubicHectometersInOneCubicMeter => 1E-6;

        protected override double CubicMetersInOneCubicMeter => 1;

        protected override double CubicMilesInOneCubicMeter => 2.399127585789277e-10;

        protected override double CubicMillimetersInOneCubicMeter => 1E9;

        protected override double CubicMicrometersInOneCubicMeter => 1E18;

        protected override double CubicYardsInOneCubicMeter => 1.30795062;

        protected override double DecausGallonsInOneCubicMeter => 2.6417217e+1;

        protected override double DecilitersInOneCubicMeter => 1E4;
        protected override double DeciusGallonsInOneCubicMeter => 2.6417217e+3;
        protected override double HectocubicFeetInOneCubicMeter => 3.531472e-1;
        protected override double HectocubicMetersInOneCubicMeter => 0.01;

        protected override double HectolitersInOneCubicMeter => 1E1;

        protected override double HectousGallonsInOneCubicMeter => 2.6417217;

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

        protected override double NanolitersInOneCubicMeter => 1E12;

        protected override double AuTablespoonsInOneCubicMeter => 50000;

        protected override double UsTablespoonsInOneCubicMeter => 67628.0454;

        protected override double MetricTeaspoonsInOneCubicMeter => 200000;

        protected override double UsTeaspoonsInOneCubicMeter => 202884.13621105801;

        protected override double ImperialBeerBarrelsInOneCubicMeter => 6.1102568972;

        protected override double UkTablespoonsInOneCubicMeter => 66666.6666667;

        protected override double MetricTablespoonsInOneCubicMeter => 66666.6666667;

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

        protected override double BoardFeetInOneCubicMeter => 423.7760007;

        protected override double DecalitersInOneCubicMeter => 1e2;

        /// <summary>
        /// https://www.legislation.gov.uk/uksi/1995/1804/made
        /// </summary>
        protected override double ImperialQuartsInOneCubicMeter => 879.876993196;

        [Fact]
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
            Duration duration = Volume.FromCubicMeters(20) / VolumeFlow.FromCubicMetersPerSecond(2);
            Assert.Equal(Duration.FromSeconds(10), duration);
        }

        [Theory]
        [InlineData(50, VolumeUnit.CubicMeter,
            5, SpecificVolumeUnit.CubicMeterPerKilogram,
            10, MassUnit.Kilogram)]
        public void Dividing_Volume_By_SpecificVolume_ReturnsMass(double volumeValue, VolumeUnit volumeUnit, double specificVolumeValue,
            SpecificVolumeUnit specificVolumeUnit, double expectedMassValue, MassUnit expectedMassUnit)
        {
            var mass = new Mass(expectedMassValue, expectedMassUnit);
            var specificVolume = new SpecificVolume(specificVolumeValue, specificVolumeUnit);
            var expectedVolume = new Volume(volumeValue, volumeUnit);

            Mass massFromVolume = expectedVolume / specificVolume;

            Assert.Equal(mass, massFromVolume);
        }
    }
}
