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
    public class DensityTests : DensityTestsBase
    {
        protected override double KilogramsPerCubicCentimeterInOneKilogramPerCubicMeter => 1e-6;

        protected override double KilogramsPerCubicMeterInOneKilogramPerCubicMeter => 1;

        protected override double KilogramsPerCubicMillimeterInOneKilogramPerCubicMeter => 1e-9;

        protected override double KilopoundsPerCubicFootInOneKilogramPerCubicMeter => 6.242796e-5;

        protected override double KilopoundsPerCubicInchInOneKilogramPerCubicMeter => 3.6127292e-8;

        protected override double PoundsPerCubicFootInOneKilogramPerCubicMeter => 6.242796e-2;

        protected override double PoundsPerCubicInchInOneKilogramPerCubicMeter => 3.61272923e-5;

        protected override double TonnesPerCubicCentimeterInOneKilogramPerCubicMeter => 1e-9;

        protected override double TonnesPerCubicMeterInOneKilogramPerCubicMeter => 1e-3;

        protected override double TonnesPerCubicMillimeterInOneKilogramPerCubicMeter => 1e-12;

        [Test]
        public static void DensityTimesVolumeEqualsMass()
        {
            Mass mass = Density.FromKilogramsPerCubicMeter(2)*Volume.FromCubicMeters(3);
            Assert.AreEqual(mass, Mass.FromKilograms(6));
        }

        [Test]
        public static void VolumeTimesDensityEqualsMass()
        {
            Mass mass = Volume.FromCubicMeters(3)*Density.FromKilogramsPerCubicMeter(2);
            Assert.AreEqual(mass, Mass.FromKilograms(6));
        }

        [Test]
        public static void DensityTimesKinematicViscosityEqualsDynamicViscosity()
        {
            DynamicViscosity dynamicViscosity = Density.FromKilogramsPerCubicMeter(2) * KinematicViscosity.FromSquareMetersPerSecond(10);
            Assert.AreEqual(dynamicViscosity, DynamicViscosity.FromNewtonSecondsPerMeterSquared(20));
        }
    }
}