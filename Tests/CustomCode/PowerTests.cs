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
    public class PowerTests : PowerTestsBase
    {
        protected override double FemtowattsInOneWatt
        {
            get { return 1e15; }
        }

        protected override double PicowattsInOneWatt
        {
            get { return 1e12; }
        }

        protected override double NanowattsInOneWatt
        {
            get { return 1e9; }
        }

        protected override double MicrowattsInOneWatt
        {
            get { return 1e6; }
        }

        protected override double MilliwattsInOneWatt
        {
            get { return 1e3; }
        }

        protected override double WattsInOneWatt
        {
            get { return 1; }
        }

        protected override double KilowattsInOneWatt
        {
            get { return 1e-3; }
        }

        protected override double MegawattsInOneWatt
        {
            get { return 1e-6; }
        }

        protected override double GigawattsInOneWatt
        {
            get { return 1e-9; }
        }

        protected override double TerawattsInOneWatt
        {
            get { return 1e-12; }
        }

        protected override double PetawattsInOneWatt
        {
            get { return 1e-15; }
        }
    }
}
