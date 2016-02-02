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
    public class PressureTests : PressureTestsBase
    {
        protected override double AtmospheresInOnePascal => 9.8692*1E-6;

        protected override double BarsInOnePascal => 1E-5;

        protected override double KilogramsForcePerSquareCentimeterInOnePascal => 0.101971621e-5;

        protected override double KilogramsForcePerSquareMeterInOnePascal => 0.101971621;

        protected override double KilogramsForcePerSquareMillimeterInOnePascal => 0.101971621e-7;

        protected override double KilonewtonsPerSquareCentimeterInOnePascal => 1e-7;

        protected override double KilonewtonsPerSquareMeterInOnePascal => 0.001;

        protected override double KilonewtonsPerSquareMillimeterInOnePascal => 1e-9;

        protected override double KilopascalsInOnePascal => 1e-3;

        protected override double KilopoundsForcePerSquareFootInOnePascal => 2.089e-5;

        protected override double KilopoundsForcePerSquareInchInOnePascal => 1.45e-7;

        protected override double MegapascalsInOnePascal => 1E-6;

        protected override double NewtonsPerSquareCentimeterInOnePascal => 1E-4;

        protected override double NewtonsPerSquareMeterInOnePascal => 1;

        protected override double NewtonsPerSquareMillimeterInOnePascal => 1E-6;

        protected override double PascalsInOnePascal => 1;

        protected override double PoundsForcePerSquareFootInOnePascal => 0.0208854342;

        protected override double PoundsForcePerSquareInchInOnePascal => 0.000145037738;

        protected override double PsiInOnePascal => 1.450377*1E-4;

        protected override double TechnicalAtmospheresInOnePascal => 1.0197*1E-5;

        protected override double TonnesForcePerSquareCentimeterInOnePascal => 1e-8;

        protected override double TonnesForcePerSquareMeterInOnePascal => 1e-4;

        protected override double TonnesForcePerSquareMillimeterInOnePascal => 1e-10;

        protected override double TorrsInOnePascal => 7.5006*1E-3;

        protected override double CentibarsInOnePascal => 1e-3;

        protected override double DecapascalsInOnePascal => 1e-1;

        protected override double DecibarsInOnePascal => 1e-4;

        protected override double GigapascalsInOnePascal => 1e-9;

        protected override double HectopascalsInOnePascal => 1e-2;

        protected override double KilobarsInOnePascal => 1e-8;

        protected override double MegabarsInOnePascal => 1e-11;

        protected override double MicropascalsInOnePascal => 1e6;

        protected override double MillibarsInOnePascal => 1e-2;

        [Test]
        public void AreaTimesPressureEqualsForce()
        {
            Force force = Area.FromSquareMeters(3)*Pressure.FromPascals(20);
            Assert.AreEqual(force, Force.FromNewtons(60));
        }

        [Test]
        public void PressureTimesAreaEqualsForce()
        {
            Force force = Pressure.FromPascals(20)*Area.FromSquareMeters(3);
            Assert.AreEqual(force, Force.FromNewtons(60));
        }
    }
}