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

using UnitsNet.Attributes;

namespace UnitsNet.Units
{
    public enum VolumeUnit
    {
        Undefined = 0,

        // Metric

        [I18n("en-US", "cl")]
        [I18n("ru-RU", "сл")]
        [Volume(1e-5)]
        Centiliter,

        [I18n("en-US", "cm³")]
        [I18n("ru-RU", "см³")]
        [Volume(1e-6)]
        CubicCentimeter,

        [I18n("en-US", "dm³")]
        [I18n("ru-RU", "дм³")]
        [Volume(1e-3)]
        CubicDecimeter,

        [I18n("en-US", "ft³")]
        [I18n("ru-RU", "фут³")]
        [Volume(0.0283168, "CubicFeet")]
        CubicFoot,

        [I18n("en-US", "in³")]
        [I18n("ru-RU", "дюйм³")]
        [Volume(1.6387*1e-5, "CubicInches")]
        CubicInch,

        [I18n("en-US", "km³")]
        [I18n("ru-RU", "км³")]
        [Volume(1e9)]
        CubicKilometer,

        [I18n("en-US", "m³")]
        [I18n("ru-RU", "м³")]
        [Volume(1)]
        CubicMeter,

        [I18n("en-US", "mi³")]
        [I18n("ru-RU", "миля³")]
        [Volume(4.16818183*1e9)]
        CubicMile,
        
        [I18n("en-US", "mm³")]
        [I18n("ru-RU", "мм³")]
        [Volume(1e-9)]
        CubicMillimeter,

        [I18n("en-US", "yd³")]
        [I18n("ru-RU", "ярд³")]
        [Volume(0.764554858)]
        CubicYard,

        [I18n("en-US", "dl")]
        [I18n("ru-RU", "дл")]
        [Volume(1e-4)]
        Deciliter,

        [I18n("en-US", "hl")]
        [I18n("ru-RU", "гл")]
        [Volume(1e-1)]
        Hectoliter,

        [I18n("en-US", "gal (imp.)")]
        [I18n("ru-RU", "Английский галлон")]
        [Volume(0.00454609000000181429905810072407)]
        ImperialGallon,

        [I18n("en-US", "oz (imp.)")]
        [I18n("ru-RU", "Английская унция")]
        [Volume(2.8413062499962901241875439064617e-5)]
        ImperialOunce,

        [I18n("en-US", "l")]
        [I18n("ru-RU", "л")]
        [Volume(1e-3)]
        Liter,

        [I18n("en-US", "ml")]
        [I18n("ru-RU", "мл")]
        [Volume(1e-6)]
        Milliliter,

        [I18n("en-US", "gal (U.S.)")]
        [I18n("ru-RU", "Американский галлон")]
        [Volume(0.00378541)]
        UsGallon,

        [I18n("en-US", "oz (U.S.)")]
        [I18n("ru-RU", "Американская унция")]
        [Volume(2.957352956253760505068307980135*1e-5)]
        UsOunce,
    }
}