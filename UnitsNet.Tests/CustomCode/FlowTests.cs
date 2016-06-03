// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
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
    public class FlowTests : FlowTestsBase
    {
        protected override double CubicMetersPerHourInOneCubicMeterPerSecond => 3600.0;

        protected override double CubicDecimetersPerMinuteInOneCubicMeterPerSecond => 60000.00000;

        protected override double CubicFeetPerSecondInOneCubicMeterPerSecond => 35.314666213;

        protected override double MillionUsGallonsPerDayInOneCubicMeterPerSecond => 22.824465227;

        protected override double CubicMetersPerSecondInOneCubicMeterPerSecond => 1;
        
        protected override double UsGallonsPerMinuteInOneCubicMeterPerSecond => 15850.323141489;

        protected override double LitersPerMinuteInOneCubicMeterPerSecond => 60000.00000;

        protected override double NanolitersPerMinuteInOneCubicMeterPerSecond => 60000000000000.00000;

        protected override double MicrolitersPerMinuteInOneCubicMeterPerSecond => 60000000000.00000;

        protected override double MillilitersPerMinuteInOneCubicMeterPerSecond => 60000000.00000;

        protected override double CentilitersPerMinuteInOneCubicMeterPerSecond => 6000000.00000;

        protected override double DecilitersPerMinuteInOneCubicMeterPerSecond => 600000.00000;

        protected override double KilolitersPerMinuteInOneCubicMeterPerSecond => 60.00000;
    }
}