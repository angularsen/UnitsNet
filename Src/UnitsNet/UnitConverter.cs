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

namespace UnitsNet
{
    public static class UnitConverter
    {
        private const double CentimeterToInchRatio = 0.393700787;
        private const double CentimeterToFeetRatio = 0.032808399;

        /// <summary>
        ///     Returns the converted value
        /// </summary>
        /// <param name="from">A SIUnitDistance type</param>
        /// <param name="to">A ImperialUnitDistance type</param>
        /// <param name="value">The value to convert</param>
        /// <returns>The converted value</returns>
        public static double ConvertDistanceFromSIToImperial(double value, Unit from, ImperialUnitTypes to)
        {
            Length distance;

            switch (from)
            {
                case Unit.Meter:
                    distance = Length.FromMeters(value);
                    break;

                case Unit.Centimeter:
                    distance = Length.FromCentimeters(value);
                    break;

                case Unit.Millimeter:
                    distance = Length.FromMillimeters(value);
                    break;

                default:
                    throw new NotSupportedException("Unknown type to convert from: " + from);
            }

            switch (to)
            {
                case (ImperialUnitTypes.Inch):
                    return distance.Centimeters*CentimeterToInchRatio;

                case (ImperialUnitTypes.Feet):
                    return distance.Centimeters*CentimeterToFeetRatio;

                default:
                    throw new NotSupportedException("Unknown type to convert to: " + to);
            }
        }
    }
}