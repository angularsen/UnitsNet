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
    public class VolumeTests : VolumeTestsBase
    {
        public override double CentilitersInOneCubicMeter
        {
            get { return 1E5; }
        }

        public override double CubicCentimetersInOneCubicMeter
        {
            get { return 1E6; }
        }

        public override double CubicDecimetersInOneCubicMeter
        {
            get { return 1E3; }
        }

        public override double CubicFeetInOneCubicMeter
        {
            get { return 35.31472; }
        }

        public override double CubicInchesInOneCubicMeter
        {
            get { return 61023.98242; }
        }

        public override double CubicKilometersInOneCubicMeter
        {
            get { return 1E-9; }
        }

        public override double CubicMetersInOneCubicMeter
        {
            get { return 1; }
        }

        public override double CubicMilesInOneCubicMeter
        {
            get { return 3.86102*1E-7; }
        }

        public override double CubicMillimetersInOneCubicMeter
        {
            get { return 1E9; }
        }

        public override double CubicYardsInOneCubicMeter
        {
            get { return 1.30795062; }
        }

        public override double DecilitersInOneCubicMeter
        {
            get { return 1E4; }
        }

        public override double HectolitersInOneCubicMeter
        {
            get { return 1E1; }
        }

        public override double ImperialGallonsInOneCubicMeter
        {
            get { return 219.96924; }
        }

        public override double ImperialOuncesInOneCubicMeter
        {
            get { return 35195.07972; }
        }

        public override double LitersInOneCubicMeter
        {
            get { return 1E3; }
        }

        public override double MillilitersInOneCubicMeter
        {
            get { return 1E6; }
        }

        public override double UsGallonsInOneCubicMeter
        {
            get { return 264.17217; }
        }

        public override double UsOuncesInOneCubicMeter
        {
            get { return 33814.02270; }
        }
    }
}