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

namespace UnitsNet
{
    public enum Unit
    {
        Undefined = 0,

        // Length
        Kilometer,
        Meter,
        Decimeter,
        Centimeter,
        Millimeter,
        Micrometer,
        Nanometer,

        // Length (imperial)
        Mile,
        Yard,
        Foot,
        Inch,

        // Mass
        Megatonne,
        Kilotonne,
        Tonne,
        Kilogram,
        Hectogram,
        Decagram,
        Gram,
        Decigram,
        Centigram,
        Milligram,
        //Microgram,
        //Nanogram,

        // Pressure
        Pascal,
        KiloPascal,
        Psi,
        NewtonPerSquareCentimeter,
        NewtonPerSquareMillimeter,
        NewtonPerSquareMeter,
        Bar,
        TechnicalAtmosphere,
        Atmosphere,
        Torr, 

        // Force
        Kilonewton,
        Newton,
        KilogramForce,
        Dyn,

        // Force (imperial/other)
        KiloPond,
        PoundForce,
        Poundal,

        // Volume
        CubicMeter,
        CubicDecimeter,
        CubicCentimeter,
        CubicMillimeter,
        Liter,
        Deciliter,
        Centiliter,
        Milliliter,
        //Gallon,
        
        // Torque
        Newtonmeter,
        
        // Generic / Other
        Piece,
        Percent,

        // Electric potential
        Volt,

        // Time
        /// <summary>
        /// Do not use for accurate calculations. Does not take calendar into account and simply represents a year of 365 days.
        /// </summary>
        Year365Days,
        /// <summary>
        /// Do not use for accurate calculations. Does not take calendar into account and simply represents a month of 30 days.
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
    }
    //public enum LengthUnit
    //{ 
    //    Kilometer,
    //    Meter,
    //    Decimeter,
    //    Centimeter,
    //    Millimeter,

    //    Mile,
    //    Yard,
    //    Foot,
    //    Inch,
    //}

    //public enum MassUnit
    //{
    //    Megatonne,
    //    Kilotonne,
    //    Tonne,
    //    Kilogram,
    //    Hectogram,
    //    Decagram,
    //    Gram,
    //    Decigram,
    //    Centigram,
    //    Milligram,
    //    Microgram,
    //    Nanogram,
    //}

    //public enum PressureUnit
    //{
    //    Pascal,
    //    KiloPascal,
    //    Psi,
    //    NewtonPerSquareCentimeter,
    //    NewtonPerSquareMillimeter,
    //    NewtonPerSquareMeter,
    //    Bar,
    //    TechnicalAtmosphere,
    //    Atmosphere,
    //    Torr, 
    //}

    //public enum ForceUnit
    //{
    //    Kilonewton,
    //    Newton,
    //    KilogramForce,
    //    Dyn,

    //    KiloPond,
    //    PoundForce,
    //    Poundal,
    //}

    //public enum VolumeUnit
    //{
    //    Liter,
    //    Deciliter,
    //    Centiliter,
    //    Milliliter,

    //    //Gallon,

    //}

    //public enum TorqueUnit
    //{
    //    Newtonmeter,
    //}

    //public enum GenericUnit
    //{
    //    Piece,
    //    Percent,
    //}

    //public enum CookingUnit
    //{ 
    //    Tablespoon,
    //    Teaspoon,
    //} 
}