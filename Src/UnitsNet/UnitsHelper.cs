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
using System.Globalization;

namespace UnitsNet
{
    /// <summary>
    ///     Enumeration for all the SI units implemented.
    ///     This is used for converting between values in the same unit domain such as distance, electricity etc.
    /// </summary>
    public static class UnitsHelper
    {
        public const double Gravity = 9.80665;

        /// <summary>
        ///     Returns a SIUnit based on the string representation for that unit.
        ///     Example: Parse("kg"); or Parse("Kilogram");
        /// </summary>
        /// <returns>true if parse was successful</returns>
        public static bool TryParse(string unitText, out SiUnit result, SiUnit fallback, CultureInfo culture = null)
        {
            if (String.IsNullOrEmpty(unitText))
                throw new ArgumentException(
                    "Invalid unit description. Should for instance be kg or Kilogram to represent SIUnit.Kilogram type.");

            const StringComparison invariantIgnoreCase = StringComparison.OrdinalIgnoreCase;


            // Iterate over all the unit types and look for matching names or abbreviations
            foreach (SiUnit unitType in EnumUtils.GetEnumValues<SiUnit>())
            {
                if (
                    unitText.Equals(SiUnitSystem.Create(culture).GetDefaultAbbreviation(unitType), invariantIgnoreCase) ||
                    unitText.Equals(unitType.ToString(), invariantIgnoreCase))
                {
                    result = unitType;
                    return true;
                }
            }

            result = fallback;
            return false;
        }

        ///// <summary>
        ///// Returns the abbreviation string for this unit type, such as "kg" for kilogram.
        ///// </summary>
        ///// <param name="d"></param>
        ///// <returns></returns>
        //public static string GetDefaultAbbreviation(SIUnit d)
        //{
        //    try
        //    {
        //        return SiUnitSystem.Get(CultureInfo.CurrentCulture).GetDefaultAbbreviation(d); //StringEnum.GetStringValue(d).Split();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Could not get unit string for unit [" + d + "]. " + e);
        //    }
        //}

//        /// <summary>
//        /// A method for easier converting a metric distance value to meters.
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="fromUnit"></param>
//        /// <returns></returns>
//        public static double ToMeter(double value, SIUnit fromUnit)
//        {
//            const SIUnit toUnit = SIUnit.Meter;

////            if (!IsCompatible(fromUnit, toUnit))
////                throw new ArgumentException(String.Format("Can't convert from unit domain {0} to {1}.", fromUnit, toUnit), "fromUnit");

//            switch (fromUnit)
//            {
//                case toUnit:
//                    return value;

//                case SIUnit.Centimeter:
//                    return value/100.0;

//                case SIUnit.Millimeter:
//                    return value/1000;

//                default:
//                    throw new ArgumentException(String.Format("Conversion between {0} and {1} is not implemented", GetName(fromUnit), GetName(toUnit)));
//            }
//        }


//        /// <summary>
//        /// A method for easier converting a metric distance value to meters.
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="fromUnit"></param>
//        /// <returns></returns>
//        public static double ToCentimeter(double value, SIUnit fromUnit)
//        {
//            const SIUnit toUnit = SIUnit.Centimeter;

////            if (!IsCompatible(fromUnit, toUnit))
////                throw new ArgumentException(String.Format("Can't convert from unit domain {0} to {1}.", fromUnit, toUnit), "fromUnit");

//            switch (fromUnit)
//            {
//                case toUnit:
//                    return value;

//                case SIUnit.Meter:
//                    return value * 100.0;

//                case SIUnit.Millimeter:
//                    return value / 10;

//                default:
//                    throw new ArgumentException(String.Format("Conversion between {0} and {1} is not implemented", GetName(fromUnit), GetName(toUnit)));
//            }
//        }


//        /// <summary>
//        /// A method for easier converting a metric distance value to meters.
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="fromUnit"></param>
//        /// <returns></returns>
//        public static double ToMillimeter(double value, SIUnit fromUnit)
//        {
//            const SIUnit toUnit = SIUnit.Millimeter;

////            if (!IsCompatible(fromUnit, toUnit))
////                throw new ArgumentException(String.Format("Can't convert from unit domain {0} to {1}.", fromUnit, toUnit), "fromUnit");

//            switch (fromUnit)
//            {
//                case toUnit:
//                    return value;

//                case SIUnit.Meter:
//                    return value * 1000.0;

//                case SIUnit.Centimeter:
//                    return value * 10;

//                default:
//                    throw new ArgumentException(String.Format("Conversion between {0} and {1} is not implemented", GetName(fromUnit), GetName(toUnit)));
//            }
//        }

//        /// <summary>
//        /// Returns whether the two unit types are in the same unit domain, in other words if they can be
//        /// converted between.
//        /// Kilograms and Meters are for instance not compatible, while Meters and Centimeters are.
//        /// </summary>
//        /// <param name="unitA"></param>
//        /// <param name="unitB"></param>
//        /// <returns></returns>
//        public static bool IsCompatible(SIUnit unitA, SIUnit unitB)
//        {
//            // Force and mass are compatible because they are tied together by the gravitational constant 
//            // when considering vertical force. Not a good design but it works.
//            return (IsForce(unitA) && IsForce(unitB) ||
//                    IsForce(unitA) && IsMass(unitB) ||
//                    IsDistance(unitA) && IsDistance(unitB) ||
//                    IsMass(unitA) && IsMass(unitB) ||
//                    IsMass(unitA) && IsForce(unitB) ||
//                    IsVoltage(unitA) && IsVoltage(unitB) ||
//                    IsTorque(unitA) && IsTorque(unitB));
//        }

//        private static bool IsTorque(SIUnit type)
//        {
//            return (type == SIUnit.Newtonmeter);
//        }

//        private static bool IsVoltage(SIUnit type)
//        {
//            return (type == SIUnit.Volt);
//        }


//        /// <summary>
//        /// A general method for converting a value in a given metric unit domain to the respective value in a compatible unit domain,
//        /// such as converting from milimeters to meters.
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="fromUnit"></param>
//        /// <param name="toUnit"></param>
//        /// <returns></returns>
//        public static double ToUnit(double value, SIUnit fromUnit, SIUnit toUnit)
//        {
//            if (fromUnit == toUnit)
//                return value;

//            // Earlier reflection was used here for more elegant code, but reflections is dead slow 
//            // and the switch is not too much to maintain since the unit types don't change too often.
//            // An exception is thrown if a new unit is added but not implemented and this method is called with the 
//            // new type as argument.
//            switch (toUnit)
//            {
//                case SIUnit.KiloNewton:
//                    return ToKiloNewton(value, fromUnit);

//                case SIUnit.Kilogram:
//                    return ToKilogram(value, fromUnit);

//                case SIUnit.Newton:
//                    return ToNewton(value, fromUnit);

//                case SIUnit.Meter:
//                    return ToMeter(value, fromUnit);

//                case SIUnit.Centimeter:
//                    return ToCentimeter(value, fromUnit);

//                case SIUnit.Millimeter:
//                    return ToMillimeter(value, fromUnit);

//                case SIUnit.Volt:
//                    return ToVolt(value, fromUnit);

//                case SIUnit.Newtonmeter:
//                    return ToNewtonmeter(value, fromUnit);

//                case SIUnit.Undefined:
//                case SIUnit.Error:
//                case SIUnit.Generic:
//                    throw new Exception("Can't convert to generic and undefined units.");

//                default:
//                    throw new ArgumentException("Could not find conversion method for " + GetName(toUnit) + ", it may not be implemented yet.");
//            }
//        }

//        public static double ToNewtonmeter(double value, SIUnit fromUnit)
//        {
//            const SIUnit toUnit = SIUnit.Newtonmeter;

////            if (!IsCompatible(fromUnit, toUnit))
////                throw new ArgumentException(String.Format("Can't convert from unit domain {0} to {1}.", fromUnit, toUnit), "fromUnit");

//            switch (fromUnit)
//            {
//                case toUnit:
//                    return value;

//                default:
//                    throw new ArgumentException(String.Format("Conversion between {0} and {1} is not implemented", GetName(fromUnit), GetName(toUnit)));
//            }
//        }


//        public static double ToKilogram(double value, SIUnit fromUnit)
//        {
//            const SIUnit toUnit = SIUnit.Kilogram;

////            if (!IsCompatible(fromUnit, toUnit))
////                throw new ArgumentException(String.Format("Can't convert from unit domain {0} to {1}.", fromUnit, toUnit), "fromUnit");

//            switch (fromUnit)
//            {
//                case toUnit:
//                    return value;

//                case SIUnit.Newton:
//                    return value / Gravity;

//                case SIUnit.KiloNewton:
//                    return ToKilogram(ToNewton(value, fromUnit), SIUnit.Newton);

//                default:
//                    throw new ArgumentException(String.Format("Conversion between {0} and {1} is not implemented", GetName(fromUnit), GetName(toUnit)));
//            }
//        }


//        public static double ToVolt(double value, SIUnit fromUnit)
//        {
//            const SIUnit toUnit = SIUnit.Volt;

////            if (!IsCompatible(fromUnit, toUnit))
////                throw new ArgumentException(String.Format("Can't convert from unit domain {0} to {1}.", fromUnit, toUnit), "fromUnit");

//            switch (fromUnit)
//            {
//                case toUnit:
//                    return value;

//                default:
//                    throw new ArgumentException(String.Format("Conversion between {0} and {1} is not implemented", GetName(fromUnit), GetName(toUnit)));
//            }
//        }


//        public static double ToNewton(double value, SIUnit oldUnit)
//        {
//            switch (oldUnit)
//            {
//                case SIUnit.Generic:
//                    throw new Exception("Can't convert from a generic unit, there are no reference values to convert from");

//                case SIUnit.Kilogram:
//                    return value * Gravity;

//                case SIUnit.Newton:
//                    return value; // Already in newtons

//                case SIUnit.KiloNewton:
//                    return value * 1000;

//                default:
//                    throw new Exception("The unit you are trying to convert from [" + GetName(oldUnit) +
//                                        "], has not been implemented.");
//            }
//        }

//        /// <summary>
//        /// Do not delete this. It is used via reflection by the ToUnit() method.
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="oldUnit"></param>
//        /// <returns></returns>
//        // ReSharper disable UnusedPrivateMember
//        private static double ToKiloNewton(double value, SIUnit oldUnit)
//            // ReSharper restore UnusedPrivateMember
//        {
//            switch (oldUnit)
//            {
//                case SIUnit.Generic:
//                    throw new Exception("Can't convert from a generic unit, there are no reference values to convert from");

//                case SIUnit.Kilogram:
//                    return ToKilogram(ToNewton(value, oldUnit), SIUnit.Newton);

//                case SIUnit.Newton:
//                    return value / 1000.0;

//                case SIUnit.KiloNewton:
//                    return value; // Already in kilonewtons

//                default:
//                    throw new Exception("The unit you are trying to convert from [" + GetName(oldUnit) +
//                                        "], has not been implemented.");
//            }
//        }


//        public static bool IsMass(SIUnit type)
//        {
//            return (type == SIUnit.Kilogram);
//        }

//        public static bool IsForce(SIUnit u)
//        {
//            switch (u)
//            {
//                case SIUnit.Newton:
//                case SIUnit.KiloNewton:
//                    return true;
//            }

//            return false;
//        }


//        public static bool IsDistance(SIUnit u)
//        {
//            switch (u)
//            {
//                case SIUnit.Meter:
//                case SIUnit.Centimeter:
//                case SIUnit.Millimeter:
//                    return true;
//            }

//            return false;
//        }
    }
}