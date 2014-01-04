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
    public class ForceTests : ForceTestsBase
    {
        public override double DyneInOneNewton
        {
            get { return 1E5; }
        }

        public override double KilogramsForceInOneNewton
        {
            get { return 1/Constants.Gravity; }
        }

        public override double KilonewtonsInOneNewton
        {
            get { return 1E-3; }
        }

        public override double KiloPondsInOneNewton
        {
            get { return 1/Constants.Gravity; }
        }

        public override double NewtonsInOneNewton
        {
            get { return 1; }
        }

        public override double PoundalsInOneNewton
        {
            get { return 7.23301; }
        }

        public override double PoundForcesInOneNewton
        {
            get { return 0.22481; }
        }
    }
}