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
    public class MassTests : MassTestsBase
    {
        public override double CentigramsInOneKilogram
        {
            get { return 1E5; }
        }

        public override double DecagramsInOneKilogram
        {
            get { return 1E2; }
        }

        public override double DecigramsInOneKilogram
        {
            get { return 1E4; }
        }

        public override double GramsInOneKilogram
        {
            get { return 1E3; }
        }

        public override double HectogramsInOneKilogram
        {
            get { return 10; }
        }

        public override double KilogramsInOneKilogram
        {
            get { return 1; }
        }

        public override double KilotonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        public override double LongTonsInOneKilogram
        {
            get { return 0.000984207; }
        }

        public override double MegatonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        public override double MicrogramsInOneKilogram
        {
            get { return 1E9; }
        }

        public override double MilligramsInOneKilogram
        {
            get { return 1E6; }
        }

        public override double NanogramsInOneKilogram
        {
            get { return 1E12; }
        }

        public override double ShortTonsInOneKilogram
        {
            get { return 0.00110231; }
        }

        public override double PoundsInOneKilogram
        {
            get { return 2.2046226218487757d; }
        }

        public override double TonnesInOneKilogram
        {
            get { return 1E-3; }
        }
    }
}