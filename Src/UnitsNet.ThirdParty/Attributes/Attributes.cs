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

using System;

namespace UnitsNet.ThirdParty.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class FooAttribute : ThirdPartyUnitAttribute, IUnitAttribute<FooUnit> 
    {
        /// <summary>
        /// Defines a polynomial function by the coefficients of increasing 'n'.
        /// Example: [5, 0, 4, 0, 3] would represent the function 5 + 0*x + 4*x² + 0*x³ + 3*x⁴ = 3x⁴+4x²+5
        /// </summary>
        /// <param name="constant">Constant 'b' of function y = ax + b, where x is base unit.</param>
        /// <param name="pluralName">Name of unit in pluralt. If null, appends 's' to the name of the unit.</param>
        /// <param name="slope">Slope 'a' of function y = ax + b, where x is base unit.</param>
        public FooAttribute(double slope, double constant = 0, string pluralName = (string)null)
            : base(slope, constant, pluralName)
        {
        }

        public FooUnit BaseUnit
        {
            get { return FooUnit.Bar; }
        }

        public string XmlDocSummary
        {
            get { return "Example unit to illustrate adding third party units to Units.NET."; }
        }

    }
}