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


namespace UnitsNet.Tests.CustomCode
{
    public class LengthTests : LengthTestsBase
    {
        public override double CentimetersInOneMeter
        {
            get { return 100; }
        }

        public override double DecimetersInOneMeter
        {
            get { return 10; }
        }

        public override double FeetInOneMeter
        {
            get { return 3.28084; }
        }

        public override double InchesInOneMeter
        {
            get { return 39.37007874; }
        }

        public override double KilometersInOneMeter
        {
            get { return 1E-3; }
        }

        public override double MetersInOneMeter
        {
            get { return 1; }
        }

        public override double MicroinchesInOneMeter
        {
            get { return 39370078.74015748; }
        }

        public override double MicrometersInOneMeter
        {
            get { return 1E6; }
        }

        public override double MilsInOneMeter
        {
            get { return 39370.07874015; }
        }

        public override double MilesInOneMeter
        {
            get { return 0.000621371; }
        }

        public override double MillimetersInOneMeter
        {
            get { return 1E3; }
        }

        public override double NanometersInOneMeter
        {
            get { return 1E9; }
        }

        public override double YardsInOneMeter
        {
            get { return 1.09361; }
        }
    }
}