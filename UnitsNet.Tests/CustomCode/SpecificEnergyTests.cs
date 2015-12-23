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
    public class SpecificEnergyTests : SpecificEnergyTestsBase
    {

        // TODO Override properties in base class here
        protected override double JoulesPerKilogramInOneJoulePerKilogram
        {
            get
            {
                return 1.0;
            }
        }

        protected override double CaloriesPerGramInOneJoulePerKilogram
        {
            get
            {
                return 1.0 / (4.184E3);
            }
        }
        protected override double KilocaloriesPerGramInOneJoulePerKilogram
        {
            get
            {
                return 1.0 / (4.184E6);
            }
        }

        protected override double KilojoulesPerKilogramInOneJoulePerKilogram
        {
            get
            {
                return 1.0E-3;
            }
        }

        protected override double KilowattHoursPerKilogramInOneJoulePerKilogram
        {
            get
            {
                return 2.77777778e-7;
            }
        }

        protected override double MegajoulesPerKilogramInOneJoulePerKilogram
        {
            get
            {
                return 1.0E-6;
            }
        }

        protected override double MegawattHoursPerKilogramInOneJoulePerKilogram
        {
            get
            {
                return 2.77777778E-10;
            }
        }

        protected override double WattHoursPerKilogramInOneJoulePerKilogram
        {
            get
            {
                return 1.0 / 3.6e3;
            }
        }

    }
}
