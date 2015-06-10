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

namespace UnitsNet.Tests.CustomCode
{
    public class EnergyTests : EnergyTestsBase
    {
        // TODO Override properties in base class here
        protected override double JoulesInOneJoule { get { return 1; } }
        protected override double KilojoulesInOneJoule { get { return 1E-3; } }
        protected override double MegajoulesInOneJoule { get { return 1E-6; } }

        protected override double BritishThermalUnitsInOneJoule
        {
            get { return 1/1055.05585262; }
        }

        protected override double CaloriesInOneJoule
        {
            get { return 1/4.184; }
        }

        protected override double ElectronVoltsInOneJoule
        {
            get { return 1/1.602176565e-19; }
        }

        protected override double ErgsInOneJoule
        {
            get { return 1/1e-7; }
        }

        protected override double FootPoundsInOneJoule
        {
            get { return 1/1.355817948; }
        }

        protected override double GigawattHoursInOneJoule
        {
            get { return 1 / (3600d * 1e9); }
        }

        protected override double KilocaloriesInOneJoule
        {
            get { return 1 / (4.184 * 1000); }
        }

        protected override double KilowattHoursInOneJoule
        {
            get { return 1 / (3600d * 1e3); }
        }

        protected override double MegawattHoursInOneJoule
        {
            get { return 1 / (3600d * 1e6); }
        }

        protected override double WattHoursInOneJoule
        {
            get { return 1 /3600d; }
        }
    }
}
