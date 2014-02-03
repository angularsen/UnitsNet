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
    public enum PressureUnit
    {
        Undefined = 0,

        [I18n("en-US", "atm")]
        [I18n("ru-RU", "атм")]
        [Pressure(1.01325*1e5)]
        Atmosphere,

        [I18n("en-US", "bar")]
        [I18n("ru-RU", "бар")]
        [Pressure(1e5)]
        Bar,

        [I18n("en-US", "kgf/cm²")]
        [I18n("ru-RU", "кгс/см²")]
        [Pressure(9.80665*1e4, "KilogramForcePerSquareCentimeter")]
        KilogramForcePerSquareCentimeter,

        [I18n("en-US", "kPa")]
        [I18n("ru-RU", "кПа")]
        [Pressure(1e3)]
        Kilopascal,

        [I18n("en-US", "MPa")]
        [I18n("ru-RU", "МПа")]
        [Pressure(1e6)]
        Megapascal,

        [I18n("en-US", "N/cm²")]
        [I18n("ru-RU", "Н/см²")]
        [Pressure(1e4, "NewtonsPerSquareCentimeter")]
        NewtonPerSquareCentimeter,

        [I18n("en-US", "N/m²")]
        [I18n("ru-RU", "Н/м²")]
        [Pressure(1, "NewtonsPerSquareMeter")]
        NewtonPerSquareMeter,

        [I18n("en-US", "N/mm²")]
        [I18n("ru-RU", "Н/мм²")]
        [Pressure(1e6, "NewtonsPerSquareMillimeter")]
        NewtonPerSquareMillimeter,

        [I18n("en-US", "Pa")]
        [I18n("ru-RU", "Па")]
        [Pressure(1)]
        Pascal, // Base unit

        [I18n("en-US", "psi")]
        [I18n("ru-RU", "psi")]
        [Pressure(6.89464975179*1e3, "Psi")]
        Psi,

        [I18n("en-US", "at")]
        [I18n("ru-RU", "ат")]
        [Pressure(9.80680592331*1e4)]
        TechnicalAtmosphere,

        [I18n("en-US", "torr")]
        [I18n("ru-RU", "торр")]
        [Pressure(1.3332266752*1e2)]
        Torr,
    }
}