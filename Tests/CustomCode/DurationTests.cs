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
    public class DurationTests : DurationTestsBase
    {
        public override double DaysInOneSecond
        {
            get { return 1.15741e-5; }
        }

        public override double HoursInOneSecond
        {
            get { return 0.0002777784; }
        }

        public override double MicrosecondsInOneSecond
        {
            get { return 1e+6; }
        }

        public override double MillisecondsInOneSecond
        {
            get { return 1000; }
        }

        public override double MinutesInOneSecond
        {
            get { return 0.0166667; }
        }

        public override double Month30DayssInOneSecond
        {
            get { return 3.8027e-7; }
        }

        public override double NanosecondsInOneSecond
        {
            get { return 1e+9; }
        }

        public override double SecondsInOneSecond
        {
            get { return 1; }
        }

        public override double WeeksInOneSecond
        {
            get { return 1.6534e-6; }
        }

        public override double Year365DayssInOneSecond
        {
            get { return 3.1689e-8; }
        }
    }
}