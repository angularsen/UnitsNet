// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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
using UnitsNet.Attributes;

namespace UnitsNet
{
    public enum Unit
    {
        Undefined = 0,

        

        // Pressure
        [Pressure(1e6, "NewtonsPerSquareMillimeter")]
        NewtonPerSquareMillimeter,
        [Pressure(1e4, "NewtonsPerSquareCentimeter")]
        NewtonPerSquareCentimeter,
        [Pressure(1, "NewtonsPerSquareMeter")]
        NewtonPerSquareMeter,
        [Pressure(9.80665 * 1e4, "KilogramForcePerSquareCentimeter")]
        KilogramForcePerSquareCentimeter,
        [Pressure(1.01325 * 1e5)]
        Atmosphere,
        [Pressure(9.80680592331 * 1e4)]
        TechnicalAtmosphere,
        [Pressure(6.89464975179 * 1e3, "Psi")]
        Psi,
        [Pressure(1.3332266752 * 1e2)]
        Torr,
        [Pressure(1e5)]
        Bar,
        [Pressure(1e6)]
        Megapascal,
        [Pressure(1e3)]
        Kilopascal,
        [Pressure(1)]
        Pascal, // Base unit

        // Metric
        [Force(1e3)]
        Kilonewton,
        [Force(Constants.Gravity, "KilogramsForce")]
        KilogramForce,
        [Force(1)]
        Newton, // Base unit
        [Force(1e-5, "Dyne")]
        Dyn,

        // US, imperial and other
        [Force(Constants.Gravity)]
        KiloPond,
        [Force(4.4482216152605095551842641431421)]
        PoundForce,
        [Force(0.13825502798973041652092282466083)]
        Poundal,

        // Metric
        [Area(1e6)]
        SquareKilometer,
        [Area(1)]
        SquareMeter, // Base unit
        [Area(1e-2)]
        SquareDecimeter,
        [Area(1e-4)]
        SquareCentimeter,
        [Area(1e-6)]
        SquareMillimeter,

        // US, imperial and other
        [Area(2.59 * 1e6)]
        SquareMile,
        [Area(0.836127)]
        SquareYard,
        [Area(0.092903, "SquareFeet")]
        SquareFoot,
        [Area(0.00064516, "SquareInches")]
        SquareInch,

        // Metric
        [Angle(180 / Math.PI)]
        Radian,
        [Angle(1)]
        Degree, // Base unit
        [Angle(0.9)]
        Gradian,

        // Metric
        [Volume(1e9)]
        CubicKilometer,
        [Volume(1)]
        CubicMeter,
        [Volume(1e-3)]
        CubicDecimeter,
        [Volume(1e-6)]
        CubicCentimeter,
        [Volume(1e-9)]
        CubicMillimeter,
        [Volume(1e-1)]
        Hectoliter,
        [Volume(1e-3)]
        Liter,
        [Volume(1e-4)]
        Deciliter,
        [Volume(1e-5)]
        Centiliter,
        [Volume(1e-6)]
        Milliliter,

        // US, imperial and other
        [Volume(4.16818183 * 1e9)]
        CubicMile,
        [Volume(0.764554858)]
        CubicYard,
        [Volume(0.0283168, "CubicFeet")]
        CubicFoot,
        [Volume(1.6387 * 1e-5, "CubicInches")]
        CubicInch,
        [Volume(0.00454609000000181429905810072407)]
        ImperialGallon,
        [Volume(0.00378541)]
        UsGallon,
        [Volume(2.957352956253760505068307980135 * 1e-5)]
        UsOunce,
        [Volume(2.8413062499962901241875439064617e-5)]
        ImperialOunce,

        // Metric
        [Torque(1)]
        Newtonmeter,

        // Generic / Other
        Piece,
        Percent,

        // Electric potential
        [ElectricPotential(1)]
        Volt,

        // Time
        /// <summary>
        ///     Do not use for accurate calculations. Does not take calendar into account and simply represents a year of 365 days.
        /// </summary>
        Year365Days,

        /// <summary>
        ///     Do not use for accurate calculations. Does not take calendar into account and simply represents a month of 30 days.
        /// </summary>
        Month30Days,
        Week,
        Day,
        Hour,
        Minute,
        Second,
        Millisecond,
        Microsecond,
        Nanosecond,

        // Cooking units
        Tablespoon,
        Teaspoon,

        // Metric
        [Flow(1, "CubicMetersPerSecond")]
        CubicMeterPerSecond,
        [Flow(1.0 / 3600, "CubicMetersPerHour")]
        CubicMeterPerHour,

        // Metric
        [RotationalSpeed(1, "RevolutionsPerSecond")]
        RevolutionPerSecond,
        [RotationalSpeed(1.0 / 60, "RevolutionsPerMinute")]
        RevolutionPerMinute,

        // Sources: http://en.wikipedia.org/wiki/Speed 
        [Speed(0.3048, "FeetPerSecond")]
        FootPerSecond,
        [Speed(1d / 3.6, "KilometersPerHour")]
        KilometerPerHour,
        [Speed(0.514444)]
        Knot,
        [Speed(1, "MetersPerSecond")]
        MeterPerSecond, // Base unit.
        [Speed(0.44704, "MilesPerHour")]
        MilePerHour,

        [Temperature(slope: 1, offset: 273.15, pluralName: "DegreesCelsius")]
        DegreeCelsius,
        [Temperature(slope: -2d / 3, offset: 373.15, pluralName: "DegreesDelisle")]
        DegreeDelisle,
        [Temperature(slope: 5d / 9, offset: 459.67 * 5d / 9, pluralName: "DegreesFahrenheit")]
        DegreeFahrenheit,
        [Temperature(1)]
        Kelvin, // Base unit
        [Temperature(slope: 100d / 33, offset: 273.15, pluralName: "DegreesNewton")]
        DegreeNewton,
        [Temperature(slope: 5d / 9, offset: 0, pluralName: "DegreesRankine")]
        DegreeRankine,
        [Temperature(slope: 5d / 4, offset: 273.15, pluralName: "DegreesReaumur")]
        DegreeReaumur,
        [Temperature(slope: 40d / 21, offset: 273.15 - 7.5 * 40d / 21, pluralName: "DegreesRoemer")]
        DegreeRoemer,
    }
}