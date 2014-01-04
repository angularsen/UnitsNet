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

namespace UnitsNet.Tests.net35.CustomCode
{
    public class TemperatureTests : TemperatureTestsBase
    {
        public override double DegreesCelsiusInOneKelvin
        {
            get { return -272.15; }
        }

        public override double DegreesDelisleInOneKelvin
        {
            get { return 558.2249999999999; }
        }

        public override double DegreesFahrenheitInOneKelvin
        {
            get { return -457.87; }
        }

        public override double DegreesNewtonInOneKelvin
        {
            get { return -89.8095; }
        }

        public override double DegreesRankineInOneKelvin
        {
            get { return 1.8; }
        }

        public override double DegreesReaumurInOneKelvin
        {
            get { return -217.72; }
        }

        public override double DegreesRoemerInOneKelvin
        {
            get { return -135.378750000; }
        }

        public override double KelvinsInOneKelvin
        {
            get { return 1; }
        }
    }
}