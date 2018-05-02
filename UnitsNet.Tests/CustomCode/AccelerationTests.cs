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

namespace UnitsNet.Tests.CustomCode
{
    public class AccelerationTests : AccelerationTestsBase
    {
        protected override double KilometersPerSecondSquaredInOneMetersPerSecondSquared => 1E-3;

        protected override double MetersPerSecondSquaredInOneMetersPerSecondSquared => 1;

        protected override double DecimetersPerSecondSquaredInOneMetersPerSecondSquared => 1E1;

        protected override double CentimetersPerSecondSquaredInOneMetersPerSecondSquared => 1E2;

        protected override double MillimetersPerSecondSquaredInOneMetersPerSecondSquared => 1E3;

        protected override double MicrometersPerSecondSquaredInOneMetersPerSecondSquared => 1E6;

        protected override double NanometersPerSecondSquaredInOneMetersPerSecondSquared => 1E9;

        protected override double StandardGravityInOneMetersPerSecondSquared => 0.1019727;

        protected override double InchesPerSecondSquaredInOneMetersPerSecondSquared => 39.3700787;

        protected override double FeetPerSecondSquaredInOneMetersPerSecondSquared => 3.28084;

        protected override double KnotsPerHourInOneMetersPerSecondSquared => 6.99784017278618E3;

        protected override double KnotsPerMinuteInOneMetersPerSecondSquared => 1.16630669546436E2;

        protected override double KnotsPerSecondInOneMetersPerSecondSquared => 1.94384449244060;
    }
}
