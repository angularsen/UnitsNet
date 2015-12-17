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
    public class TorqueTests : TorqueTestsBase
    {
        [Test]
        public void TorqueDevidedByLengthEqualsForce()
        {
            var force = Torque.FromNewtonMeters(4) / Length.FromMeters(2);
            Assert.AreEqual(force, Force.FromNewtons(2));
        }

        protected override double KilogramForceCentimetersInOneNewtonMeter
        {
            get { return 10.1971621; }
        }

        protected override double KilogramForceMetersInOneNewtonMeter
        {
            get { return 0.101971621; }
        }

        protected override double KilogramForceMillimetersInOneNewtonMeter
        {
            get { return 101.971621; }
        }

        protected override double KilonewtonCentimetersInOneNewtonMeter
        {
            get { return 0.1; }
        }

        protected override double KilonewtonMetersInOneNewtonMeter
        {
            get { return 0.001; }
        }

        protected override double KilonewtonMillimetersInOneNewtonMeter
        {
            get { return 1; }
        }

        protected override double KilopoundForceFeetInOneNewtonMeter
        {
            get { return 7.376e-4; }
        }

        protected override double KilopoundForceInchesInOneNewtonMeter
        {
            get { return 0.008851; }
        }

        protected override double NewtonCentimetersInOneNewtonMeter
        {
            get { return 100; }
        }

        protected override double NewtonMetersInOneNewtonMeter
        {
            get { return 1; }
        }

        protected override double NewtonMillimetersInOneNewtonMeter
        {
            get { return 1000; }
        }

        protected override double PoundForceFeetInOneNewtonMeter
        {
            get { return 0.737562149277; }
        }

        protected override double PoundForceInchesInOneNewtonMeter
        {
            get { return 8.85074579; }
        }

        protected override double TonneForceCentimetersInOneNewtonMeter
        {
            get { return 1.01972e-2; }
        }

        protected override double TonneForceMetersInOneNewtonMeter
        {
            get { return 1.01972e-4; }
        }

        protected override double TonneForceMillimetersInOneNewtonMeter
        {
            get { return 1.01972e-1; }
        }
    }
}