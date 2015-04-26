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
            get { return 0.101971621e-5; }
        }

        protected override double KilogramsForcePerSquareMeterInOnePascal
        {
            get { return 0.101971621; }
        }

        protected override double KilogramsForcePerSquareMillimeterInOnePascal
        {
            get { return 0.101971621e-7; }
        }

        protected override double KilonewtonsPerSquareCentimeterInOnePascal
        {
            get { return 1e-7; }
        }

        protected override double KilonewtonsPerSquareMeterInOnePascal
        {
            get { return 0.001; }
        }

        protected override double KilonewtonsPerSquareMillimeterInOnePascal
        {
            get { return 1e-9; }
        }

        protected override double KilopascalsInOnePascal
        {
            get { return 1e-3; }
        }

        protected override double KilopoundsForcePerSquareFootInOnePascal
        {
            get { return 2.089e-5; }
        }

        protected override double KilopoundsForcePerSquareInchInOnePascal
        {
            get { return 1.45e-7; }
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

        protected override double PoundsForcePerSquareFootInOnePascal
        {
            get { return 0.0208854342; }
        }

        protected override double PoundsForcePerSquareInchInOnePascal
        {
            get { return 0.000145037738; }
        }

        protected override double PsiInOnePascal
        {
            get { return 1.450377*1E-4; }
        }

        protected override double TechnicalAtmospheresInOnePascal
        {
            get { return 1.0197*1E-5; }
        }

        protected override double TonnesForcePerSquareCentimeterInOnePascal
        {
            get { return 1e-8; }
        }

        protected override double TonnesForcePerSquareMeterInOnePascal
        {
            get { return 1e-4; }
        }

        protected override double TonnesForcePerSquareMillimeterInOnePascal
        {
            get { return 1e-10; }
        }

        protected override double TorrsInOnePascal
        {
            get { return 7.5006*1E-3; }
        }
    }
}