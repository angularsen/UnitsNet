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
    public class PressureTests : PressureTestsBase
    {
        protected override double AtmospheresInOnePascal
        {
            get { return 9.8692*1E-6; }
        }

        protected override double BarsInOnePascal
        {
            get { return 1E-5; }
        }

        protected override double KilogramsForcePerSquareCentimeterInOnePascal
        {
            get { return 1/98066.5; }
        }

        protected override double KilopascalsInOnePascal
        {
            get { return 1E-3; }
        }

        protected override double MegapascalsInOnePascal
        {
            get { return 1E-6; }
        }

        protected override double NewtonsPerSquareCentimeterInOnePascal
        {
            get { return 1E-4; }
        }

        protected override double NewtonsPerSquareMeterInOnePascal
        {
            get { return 1; }
        }

        protected override double NewtonsPerSquareMillimeterInOnePascal
        {
            get { return 1E-6; }
        }

        protected override double PascalsInOnePascal
        {
            get { return 1; }
        }

        protected override double PsiInOnePascal
        {
            get { return 1.450377*1E-4; }
        }

        protected override double TechnicalAtmospheresInOnePascal
        {
            get { return 1.0197*1E-5; }
        }

        protected override double TorrsInOnePascal
        {
            get { return 7.5006*1E-3; }
        }
    }
}