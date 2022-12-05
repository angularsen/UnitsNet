// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class DensityTests : DensityTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;

        protected override double MilligramsPerCubicMeterInOneKilogramPerCubicMeter => 1e6;

        protected override double GramsPerCubicCentimeterInOneKilogramPerCubicMeter => 1e-3;

        protected override double GramsPerCubicMeterInOneKilogramPerCubicMeter => 1e3;

        protected override double GramsPerCubicMillimeterInOneKilogramPerCubicMeter => 1e-6;

        protected override double KilogramsPerCubicCentimeterInOneKilogramPerCubicMeter => 1e-6;

        protected override double KilogramsPerCubicMeterInOneKilogramPerCubicMeter => 1;

        protected override double KilogramsPerCubicMillimeterInOneKilogramPerCubicMeter => 1e-9;

        protected override double KilopoundsPerCubicFootInOneKilogramPerCubicMeter => 6.242796e-5;

        protected override double KilopoundsPerCubicInchInOneKilogramPerCubicMeter => 3.6127292e-8;

        protected override double PoundsPerCubicFootInOneKilogramPerCubicMeter => 6.242796e-2;

        protected override double PoundsPerCubicInchInOneKilogramPerCubicMeter => 3.61272923e-5;

        protected override double PoundsPerUSGallonInOneKilogramPerCubicMeter => 8.3454045e-3;

        protected override double PoundsPerImperialGallonInOneKilogramPerCubicMeter => 1.002241e-2;

        protected override double TonnesPerCubicCentimeterInOneKilogramPerCubicMeter => 1e-9;

        protected override double TonnesPerCubicMeterInOneKilogramPerCubicMeter => 1e-3;

        protected override double TonnesPerCubicMillimeterInOneKilogramPerCubicMeter => 1e-12;

        protected override double SlugsPerCubicFootInOneKilogramPerCubicMeter => 0.00194032;

        protected override double CentigramsPerDeciLiterInOneKilogramPerCubicMeter => 1e1;

        protected override double CentigramsPerLiterInOneKilogramPerCubicMeter => 1e2;

        protected override double CentigramsPerMilliliterInOneKilogramPerCubicMeter => 1e-1;

        protected override double DecigramsPerDeciLiterInOneKilogramPerCubicMeter => 1;

        protected override double DecigramsPerLiterInOneKilogramPerCubicMeter => 1e1;

        protected override double DecigramsPerMilliliterInOneKilogramPerCubicMeter => 1e-2;

        protected override double GramsPerDeciLiterInOneKilogramPerCubicMeter => 1e-1;

        protected override double GramsPerLiterInOneKilogramPerCubicMeter => 1;

        protected override double GramsPerMilliliterInOneKilogramPerCubicMeter => 1e-3;

        protected override double MicrogramsPerDeciLiterInOneKilogramPerCubicMeter => 1e5;

        protected override double MicrogramsPerLiterInOneKilogramPerCubicMeter => 1e6;

        protected override double MicrogramsPerMilliliterInOneKilogramPerCubicMeter => 1e3;

        protected override double MilligramsPerDeciLiterInOneKilogramPerCubicMeter => 1e2;

        protected override double MilligramsPerLiterInOneKilogramPerCubicMeter => 1e3;

        protected override double MilligramsPerMilliliterInOneKilogramPerCubicMeter => 1;

        protected override double NanogramsPerDeciLiterInOneKilogramPerCubicMeter => 1e8;

        protected override double NanogramsPerLiterInOneKilogramPerCubicMeter => 1e9;

        protected override double NanogramsPerMilliliterInOneKilogramPerCubicMeter => 1e6;

        protected override double PicogramsPerDeciLiterInOneKilogramPerCubicMeter => 1e11;

        protected override double PicogramsPerLiterInOneKilogramPerCubicMeter => 1e12;

        protected override double PicogramsPerMilliliterInOneKilogramPerCubicMeter => 1e9;

        protected override double MicrogramsPerCubicMeterInOneKilogramPerCubicMeter => 1e9;

        protected override double KilogramsPerLiterInOneKilogramPerCubicMeter => 1e-3;

        protected override double TonnesPerCubicFootInOneKilogramPerCubicMeter => 2.8316846591999996e-05;

        protected override double TonnesPerCubicInchInOneKilogramPerCubicMeter => 1.6387063999999997e-08;

        protected override double GramsPerCubicFootInOneKilogramPerCubicMeter => 28.316846591999994;

        protected override double GramsPerCubicInchInOneKilogramPerCubicMeter => 0.016387063999999996;

        protected override double PoundsPerCubicMeterInOneKilogramPerCubicMeter => 2.204622621848775;

        protected override double PoundsPerCubicCentimeterInOneKilogramPerCubicMeter => 2.204622621848775e-6;

        protected override double PoundsPerCubicMillimeterInOneKilogramPerCubicMeter => 2.204622621848775e-9;

        protected override double SlugsPerCubicMeterInOneKilogramPerCubicMeter => 0.068521765561961;

        protected override double SlugsPerCubicCentimeterInOneKilogramPerCubicMeter => 6.8521765561961e-8;

        protected override double SlugsPerCubicMillimeterInOneKilogramPerCubicMeter => 6.8521765561961e-11;

        protected override double SlugsPerCubicInchInOneKilogramPerCubicMeter => 1.1228705576569e-6;

        [Fact]
        public static void DensityTimesVolumeEqualsMass()
        {
            Mass mass = Density.FromKilogramsPerCubicMeter(2) * Volume.FromCubicMeters(3);
            Assert.Equal(mass, Mass.FromKilograms(6));
        }

        [Fact]
        public static void VolumeTimesDensityEqualsMass()
        {
            Mass mass = Volume.FromCubicMeters(3) * Density.FromKilogramsPerCubicMeter(2);
            Assert.Equal(mass, Mass.FromKilograms(6));
        }

        [Fact]
        public static void DensityTimesKinematicViscosityEqualsDynamicViscosity()
        {
            DynamicViscosity dynamicViscosity = Density.FromKilogramsPerCubicMeter(2) * KinematicViscosity.FromSquareMetersPerSecond(10);
            Assert.Equal(dynamicViscosity, DynamicViscosity.FromNewtonSecondsPerMeterSquared(20));
        }

        [Fact]
        public void DensityTimesSpeedEqualsMassFlux()
        {
            MassFlux massFlux = Density.FromKilogramsPerCubicMeter(20) * Speed.FromMetersPerSecond(2);
            Assert.Equal(massFlux, MassFlux.FromKilogramsPerSecondPerSquareMeter(40));
        }

        [Fact]
        public void DensityTimesAccelerationEqualsSpecificWeight()
        {
            SpecificWeight specificWeight = Density.FromKilogramsPerCubicMeter(10) * Acceleration.FromMetersPerSecondSquared(2);
            Assert.Equal(SpecificWeight.FromNewtonsPerCubicMeter(20), specificWeight);
        }

        [Fact]
        public void DensityTimesAreaEqualsLinearDensity()
        {
            LinearDensity linearDensity = Density.FromGramsPerCubicCentimeter(10) * Area.FromSquareCentimeters(2);
            Assert.Equal(20, linearDensity.GramsPerCentimeter);
        }
    }
}
