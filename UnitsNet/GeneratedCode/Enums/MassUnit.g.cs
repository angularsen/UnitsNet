// Copyright © 2007 by Initial Force AS.  All rights reserved.
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

// ReSharper disable once CheckNamespace
namespace UnitsNet.Units
{
    public enum MassUnit
    {
        Undefined = 0,
        Centigram,
        Decagram,
        Decigram,
        Gram,
        Hectogram,
        Kilogram,
        Kilotonne,

        /// <summary>
        ///     Long ton (weight ton or Imperial ton) is a unit of mass equal to 2,240 pounds (1,016 kg) and is the name for the unit called the "ton" in the avoirdupois or Imperial system of measurements that was used in the United Kingdom and several other Commonwealth countries before metrication.
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Long_ton</remarks>
        LongTon,
        Megatonne,
        Microgram,
        Milligram,
        Nanogram,

        /// <summary>
        ///     An ounce (abbreviated oz) is usually the international avoirdupois ounce as used in the United States customary and British imperial systems, which is equal to one-sixteenth of a pound or approximately 28 grams. The abbreviation 'oz' derives from the Italian word onza (now spelled oncia).
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Ounce</remarks>
        Ounce,

        /// <summary>
        ///     The pound or pound-mass (abbreviations: lb, lbm) is a unit of mass used in the imperial, United States customary and other systems of measurement. A number of different definitions have been used, the most common today being the international avoirdupois pound which is legally defined as exactly 0.45359237 kilograms, and which is divided into 16 avoirdupois ounces.
        /// </summary>
        Pound,

        /// <summary>
        ///     The short ton is a unit of mass equal to 2,000 pounds (907.18474 kg), that is most commonly used in the United States – known there simply as the ton.
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Short_ton</remarks>
        ShortTon,

        /// <summary>
        ///     The stone (abbreviation st) is a unit of mass equal to 14 pounds avoirdupois (about 6.35 kilograms) used in Great Britain and Ireland for measuring human body weight.
        /// </summary>
        /// <remarks>http://en.wikipedia.org/wiki/Stone_(unit)</remarks>
        Stone,
        Tonne,
    }
}
