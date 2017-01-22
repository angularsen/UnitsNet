// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
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

#if !WINDOWS_UWP
// Operator overloads not supported in Universal Windows Platform (WinRT Components)
using System;

namespace UnitsNet
{
    public partial struct Temperature
    {
        public static Temperature operator +(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins + right.KelvinsDelta);
        }

        public static Temperature operator +(TemperatureDelta left, Temperature right)
        {
            return new Temperature(left.KelvinsDelta + right.Kelvins);
        }

        public static Temperature operator -(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins - right.KelvinsDelta);
        }

        public static TemperatureDelta operator -(Temperature left, Temperature right)
        {
            return new TemperatureDelta(left.Kelvins - right.Kelvins);
        }

//        public static Temperature operator *(double left, Temperature right)
//        {
//            return new Temperature(left * right.Kelvins);
//        }
//
//        public static Temperature operator *(Temperature left, double right)
//        {
//            return new Temperature(left.Kelvins * right);
//        }
//
//        public static Temperature operator /(Temperature left, double right)
//        {
//            return new Temperature(left.Kelvins / right);
//        }
//
//        public static double operator /(Temperature left, Temperature right)
//        {
//            return Convert.ToDouble(left.Kelvins / right.Kelvins);
//        }
    }
}

#endif