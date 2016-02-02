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

using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    public class AreaTests : AreaTestsBase
    {

        protected override double SquareKilometersInOneSquareMeter => 1E-6;

        protected override double SquareMetersInOneSquareMeter => 1;
        protected override double SquareCentimetersInOneSquareMeter => 1E4;

        protected override double SquareDecimetersInOneSquareMeter => 1E2;

        protected override double SquareMillimetersInOneSquareMeter => 1E6;

        protected override double SquareFeetInOneSquareMeter => 10.76391;

        protected override double SquareMicrometersInOneSquareMeter
        {
            get { return 1E12; }
        }

        protected override double SquareInchesInOneSquareMeter => 1550.003100;

        protected override double SquareMilesInOneSquareMeter => 3.86102*1E-7;

        protected override double SquareYardsInOneSquareMeter => 1.19599;

        [Test]
        public void AreaDividedByLengthEqualsLength()
        {
            Length length = Area.FromSquareMeters(50)/Length.FromMeters(5);
            Assert.AreEqual(length, Length.FromMeters(10));
        }
    }
}
