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

namespace UnitsNet
{
    public partial struct Mass
    {
        public static Mass FromGravitationalForce(Force f)
        {
            return new Mass(f.KilogramsForce);
        }

        /// <summary>
        /// StonePounds related code makes it easier to work with Stone/Pound combination, which are customarily used in the UK
        /// to express body weight. For example, someone weighs 11 stone 4 pounds (about 72 kilograms).
        /// </summary>

        private const double StoneToPounds = 14;

        /// <summary>
        /// Converts the mass to a customary stone/pounds combination.
        /// </summary>
        public StonePounds StonePounds
        {
            get
            {
                double totalPounds = Pounds;
                double wholeStone = Math.Floor(totalPounds / StoneToPounds);
                double pounds = totalPounds % StoneToPounds;

                return new StonePounds(wholeStone, pounds);
            }
        }

        /// <summary>
        ///     Get Mass from combination of stone and pounds.
        /// </summary>
        public static Mass FromStonePounds(double stone, double pounds)
        {
            return FromPounds((StoneToPounds * stone) + pounds);
        }
    }

    public class StonePounds
    {
        public double Stone { get; private set; }
        public double Pounds { get; private set; }

        public StonePounds(double stone, double pounds)
        {
            Stone = stone;
            Pounds = pounds;
        }

        public override string ToString()
        {
            // Stone/pounds combos are only used in the UK. So should be safe to use English text
            // here.
            /// 
            // Note that it isn't customary to use fractions - one wouldn't say "I am 11 stone and 4.5 pounds".
            // So pounds are rounded here.
            return string.Format("{0} st {1} lb", Stone, Math.Round(Pounds));
        }
    }
}

