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
    public class MassTests : MassTestsBase
    {
        protected override double CentigramsInOneKilogram
        {
            get { return 1E5; }
        }

        protected override double DecagramsInOneKilogram
        {
            get { return 1E2; }
        }

        protected override double DecigramsInOneKilogram
        {
            get { return 1E4; }
        }

        protected override double GramsInOneKilogram
        {
            get { return 1E3; }
        }

        protected override double HectogramsInOneKilogram
        {
            get { return 10; }
        }

        protected override double KilogramsInOneKilogram
        {
            get { return 1; }
        }

        protected override double KilotonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        protected override double LongTonsInOneKilogram
        {
            get { return 0.000984207; }
        }

        protected override double MegatonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        protected override double MicrogramsInOneKilogram
        {
            get { return 1E9; }
        }

        protected override double MilligramsInOneKilogram
        {
            get { return 1E6; }
        }

        protected override double NanogramsInOneKilogram
        {
            get { return 1E12; }
        }

        protected override double ShortTonsInOneKilogram
        {
            get { return 0.00110231; }
        }

        protected override double PoundsInOneKilogram
        {
            get { return 2.2046226218487757d; }
        }

        protected override double TonnesInOneKilogram
        {
            get { return 1E-3; }
        }
    }
}