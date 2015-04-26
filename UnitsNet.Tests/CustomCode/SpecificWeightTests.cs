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
    public class SpecificWeightTests : SpecificWeightTestsBase
    {
        protected override double KilogramsForcePerCubicCentimeterInOneNewtonPerCubicMeter
        {
            get { return 0.101971621e-7; }
        }

        protected override double KilogramsForcePerCubicMeterInOneNewtonPerCubicMeter
        {
            get { return 0.101971621; }
        }

        protected override double KilogramsForcePerCubicMillimeterInOneNewtonPerCubicMeter
        {
            get { return 0.101971621e-10; }
        }

        protected override double KilonewtonsPerCubicCentimeterInOneNewtonPerCubicMeter
        {
            get { return 1e-9; }
        }

        protected override double KilonewtonsPerCubicMeterInOneNewtonPerCubicMeter
        {
            get { return 1e-3; }
        }

        protected override double KilonewtonsPerCubicMillimeterInOneNewtonPerCubicMeter
        {
            get { return 1e-12; }
        }

        protected override double KilopoundsForcePerCubicFootInOneNewtonPerCubicMeter
        {
            get { return 6.366e-6; }
        }

        protected override double KilopoundsForcePerCubicInchInOneNewtonPerCubicMeter
        {
            get { return 3.684e-9; }
        }

        protected override double NewtonsPerCubicCentimeterInOneNewtonPerCubicMeter
        {
            get { return 1e-6; }
        }

        protected override double NewtonsPerCubicMeterInOneNewtonPerCubicMeter
        {
            get { return 1; }
        }

        protected override double NewtonsPerCubicMillimeterInOneNewtonPerCubicMeter
        {
            get { return 1e-9; }
        }

        protected override double PoundsForcePerCubicFootInOneNewtonPerCubicMeter
        {
            get { return 0.006366; }
        }

        protected override double PoundsForcePerCubicInchInOneNewtonPerCubicMeter
        {
            get { return 3.684e-6; }
        }

        protected override double TonnesForcePerCubicCentimeterInOneNewtonPerCubicMeter
        {
            get { return 1.02e-13; }
        }

        protected override double TonnesForcePerCubicMeterInOneNewtonPerCubicMeter
        {
            get { return 1.02e-4; }
        }

        protected override double TonnesForcePerCubicMillimeterInOneNewtonPerCubicMeter
        {
            get { return 1.02e-10; }
        }
    }
}