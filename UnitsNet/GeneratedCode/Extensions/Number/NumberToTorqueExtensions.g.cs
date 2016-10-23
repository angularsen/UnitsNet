// Copyright (c) 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
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

using System;

#if !WINDOWS_UWP
// Extension methods/overloads not supported in Universal Windows Platform (WinRT Components)
namespace UnitsNet.Extensions.NumberToTorque
{
    public static class NumberToTorqueExtensions
    {
        #region KilogramForceCentimeter

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double)"/>
        public static Torque KilogramForceCentimeters(this int value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double?)"/>
        public static Torque? KilogramForceCentimeters(this int? value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double)"/>
        public static Torque KilogramForceCentimeters(this long value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double?)"/>
        public static Torque? KilogramForceCentimeters(this long? value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double)"/>
        public static Torque KilogramForceCentimeters(this double value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double?)"/>
        public static Torque? KilogramForceCentimeters(this double? value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double)"/>
        public static Torque KilogramForceCentimeters(this float value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double?)"/>
        public static Torque? KilogramForceCentimeters(this float? value) => Torque.FromKilogramForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double)"/>
        public static Torque KilogramForceCentimeters(this decimal value) => Torque.FromKilogramForceCentimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilogramForceCentimeters(double?)"/>
        public static Torque? KilogramForceCentimeters(this decimal? value) => Torque.FromKilogramForceCentimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilogramForceMeter

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double)"/>
        public static Torque KilogramForceMeters(this int value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double?)"/>
        public static Torque? KilogramForceMeters(this int? value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double)"/>
        public static Torque KilogramForceMeters(this long value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double?)"/>
        public static Torque? KilogramForceMeters(this long? value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double)"/>
        public static Torque KilogramForceMeters(this double value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double?)"/>
        public static Torque? KilogramForceMeters(this double? value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double)"/>
        public static Torque KilogramForceMeters(this float value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double?)"/>
        public static Torque? KilogramForceMeters(this float? value) => Torque.FromKilogramForceMeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double)"/>
        public static Torque KilogramForceMeters(this decimal value) => Torque.FromKilogramForceMeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilogramForceMeters(double?)"/>
        public static Torque? KilogramForceMeters(this decimal? value) => Torque.FromKilogramForceMeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilogramForceMillimeter

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double)"/>
        public static Torque KilogramForceMillimeters(this int value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double?)"/>
        public static Torque? KilogramForceMillimeters(this int? value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double)"/>
        public static Torque KilogramForceMillimeters(this long value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double?)"/>
        public static Torque? KilogramForceMillimeters(this long? value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double)"/>
        public static Torque KilogramForceMillimeters(this double value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double?)"/>
        public static Torque? KilogramForceMillimeters(this double? value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double)"/>
        public static Torque KilogramForceMillimeters(this float value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double?)"/>
        public static Torque? KilogramForceMillimeters(this float? value) => Torque.FromKilogramForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double)"/>
        public static Torque KilogramForceMillimeters(this decimal value) => Torque.FromKilogramForceMillimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilogramForceMillimeters(double?)"/>
        public static Torque? KilogramForceMillimeters(this decimal? value) => Torque.FromKilogramForceMillimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilonewtonCentimeter

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double)"/>
        public static Torque KilonewtonCentimeters(this int value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double?)"/>
        public static Torque? KilonewtonCentimeters(this int? value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double)"/>
        public static Torque KilonewtonCentimeters(this long value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double?)"/>
        public static Torque? KilonewtonCentimeters(this long? value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double)"/>
        public static Torque KilonewtonCentimeters(this double value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double?)"/>
        public static Torque? KilonewtonCentimeters(this double? value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double)"/>
        public static Torque KilonewtonCentimeters(this float value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double?)"/>
        public static Torque? KilonewtonCentimeters(this float? value) => Torque.FromKilonewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double)"/>
        public static Torque KilonewtonCentimeters(this decimal value) => Torque.FromKilonewtonCentimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilonewtonCentimeters(double?)"/>
        public static Torque? KilonewtonCentimeters(this decimal? value) => Torque.FromKilonewtonCentimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilonewtonMeter

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double)"/>
        public static Torque KilonewtonMeters(this int value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double?)"/>
        public static Torque? KilonewtonMeters(this int? value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double)"/>
        public static Torque KilonewtonMeters(this long value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double?)"/>
        public static Torque? KilonewtonMeters(this long? value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double)"/>
        public static Torque KilonewtonMeters(this double value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double?)"/>
        public static Torque? KilonewtonMeters(this double? value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double)"/>
        public static Torque KilonewtonMeters(this float value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double?)"/>
        public static Torque? KilonewtonMeters(this float? value) => Torque.FromKilonewtonMeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double)"/>
        public static Torque KilonewtonMeters(this decimal value) => Torque.FromKilonewtonMeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilonewtonMeters(double?)"/>
        public static Torque? KilonewtonMeters(this decimal? value) => Torque.FromKilonewtonMeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilonewtonMillimeter

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double)"/>
        public static Torque KilonewtonMillimeters(this int value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double?)"/>
        public static Torque? KilonewtonMillimeters(this int? value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double)"/>
        public static Torque KilonewtonMillimeters(this long value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double?)"/>
        public static Torque? KilonewtonMillimeters(this long? value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double)"/>
        public static Torque KilonewtonMillimeters(this double value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double?)"/>
        public static Torque? KilonewtonMillimeters(this double? value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double)"/>
        public static Torque KilonewtonMillimeters(this float value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double?)"/>
        public static Torque? KilonewtonMillimeters(this float? value) => Torque.FromKilonewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double)"/>
        public static Torque KilonewtonMillimeters(this decimal value) => Torque.FromKilonewtonMillimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilonewtonMillimeters(double?)"/>
        public static Torque? KilonewtonMillimeters(this decimal? value) => Torque.FromKilonewtonMillimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilopoundForceFoot

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double)"/>
        public static Torque KilopoundForceFeet(this int value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double?)"/>
        public static Torque? KilopoundForceFeet(this int? value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double)"/>
        public static Torque KilopoundForceFeet(this long value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double?)"/>
        public static Torque? KilopoundForceFeet(this long? value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double)"/>
        public static Torque KilopoundForceFeet(this double value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double?)"/>
        public static Torque? KilopoundForceFeet(this double? value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double)"/>
        public static Torque KilopoundForceFeet(this float value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double?)"/>
        public static Torque? KilopoundForceFeet(this float? value) => Torque.FromKilopoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double)"/>
        public static Torque KilopoundForceFeet(this decimal value) => Torque.FromKilopoundForceFeet(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilopoundForceFeet(double?)"/>
        public static Torque? KilopoundForceFeet(this decimal? value) => Torque.FromKilopoundForceFeet(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilopoundForceInch

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double)"/>
        public static Torque KilopoundForceInches(this int value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double?)"/>
        public static Torque? KilopoundForceInches(this int? value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double)"/>
        public static Torque KilopoundForceInches(this long value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double?)"/>
        public static Torque? KilopoundForceInches(this long? value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double)"/>
        public static Torque KilopoundForceInches(this double value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double?)"/>
        public static Torque? KilopoundForceInches(this double? value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double)"/>
        public static Torque KilopoundForceInches(this float value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double?)"/>
        public static Torque? KilopoundForceInches(this float? value) => Torque.FromKilopoundForceInches(value);

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double)"/>
        public static Torque KilopoundForceInches(this decimal value) => Torque.FromKilopoundForceInches(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromKilopoundForceInches(double?)"/>
        public static Torque? KilopoundForceInches(this decimal? value) => Torque.FromKilopoundForceInches(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region NewtonCentimeter

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double)"/>
        public static Torque NewtonCentimeters(this int value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double?)"/>
        public static Torque? NewtonCentimeters(this int? value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double)"/>
        public static Torque NewtonCentimeters(this long value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double?)"/>
        public static Torque? NewtonCentimeters(this long? value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double)"/>
        public static Torque NewtonCentimeters(this double value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double?)"/>
        public static Torque? NewtonCentimeters(this double? value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double)"/>
        public static Torque NewtonCentimeters(this float value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double?)"/>
        public static Torque? NewtonCentimeters(this float? value) => Torque.FromNewtonCentimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double)"/>
        public static Torque NewtonCentimeters(this decimal value) => Torque.FromNewtonCentimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromNewtonCentimeters(double?)"/>
        public static Torque? NewtonCentimeters(this decimal? value) => Torque.FromNewtonCentimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region NewtonMeter

        /// <inheritdoc cref="Torque.FromNewtonMeters(double)"/>
        public static Torque NewtonMeters(this int value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double?)"/>
        public static Torque? NewtonMeters(this int? value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double)"/>
        public static Torque NewtonMeters(this long value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double?)"/>
        public static Torque? NewtonMeters(this long? value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double)"/>
        public static Torque NewtonMeters(this double value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double?)"/>
        public static Torque? NewtonMeters(this double? value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double)"/>
        public static Torque NewtonMeters(this float value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double?)"/>
        public static Torque? NewtonMeters(this float? value) => Torque.FromNewtonMeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMeters(double)"/>
        public static Torque NewtonMeters(this decimal value) => Torque.FromNewtonMeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromNewtonMeters(double?)"/>
        public static Torque? NewtonMeters(this decimal? value) => Torque.FromNewtonMeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region NewtonMillimeter

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double)"/>
        public static Torque NewtonMillimeters(this int value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double?)"/>
        public static Torque? NewtonMillimeters(this int? value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double)"/>
        public static Torque NewtonMillimeters(this long value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double?)"/>
        public static Torque? NewtonMillimeters(this long? value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double)"/>
        public static Torque NewtonMillimeters(this double value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double?)"/>
        public static Torque? NewtonMillimeters(this double? value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double)"/>
        public static Torque NewtonMillimeters(this float value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double?)"/>
        public static Torque? NewtonMillimeters(this float? value) => Torque.FromNewtonMillimeters(value);

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double)"/>
        public static Torque NewtonMillimeters(this decimal value) => Torque.FromNewtonMillimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromNewtonMillimeters(double?)"/>
        public static Torque? NewtonMillimeters(this decimal? value) => Torque.FromNewtonMillimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region PoundForceFoot

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double)"/>
        public static Torque PoundForceFeet(this int value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double?)"/>
        public static Torque? PoundForceFeet(this int? value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double)"/>
        public static Torque PoundForceFeet(this long value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double?)"/>
        public static Torque? PoundForceFeet(this long? value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double)"/>
        public static Torque PoundForceFeet(this double value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double?)"/>
        public static Torque? PoundForceFeet(this double? value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double)"/>
        public static Torque PoundForceFeet(this float value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double?)"/>
        public static Torque? PoundForceFeet(this float? value) => Torque.FromPoundForceFeet(value);

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double)"/>
        public static Torque PoundForceFeet(this decimal value) => Torque.FromPoundForceFeet(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromPoundForceFeet(double?)"/>
        public static Torque? PoundForceFeet(this decimal? value) => Torque.FromPoundForceFeet(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region PoundForceInch

        /// <inheritdoc cref="Torque.FromPoundForceInches(double)"/>
        public static Torque PoundForceInches(this int value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double?)"/>
        public static Torque? PoundForceInches(this int? value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double)"/>
        public static Torque PoundForceInches(this long value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double?)"/>
        public static Torque? PoundForceInches(this long? value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double)"/>
        public static Torque PoundForceInches(this double value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double?)"/>
        public static Torque? PoundForceInches(this double? value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double)"/>
        public static Torque PoundForceInches(this float value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double?)"/>
        public static Torque? PoundForceInches(this float? value) => Torque.FromPoundForceInches(value);

        /// <inheritdoc cref="Torque.FromPoundForceInches(double)"/>
        public static Torque PoundForceInches(this decimal value) => Torque.FromPoundForceInches(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromPoundForceInches(double?)"/>
        public static Torque? PoundForceInches(this decimal? value) => Torque.FromPoundForceInches(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region TonneForceCentimeter

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double)"/>
        public static Torque TonneForceCentimeters(this int value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double?)"/>
        public static Torque? TonneForceCentimeters(this int? value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double)"/>
        public static Torque TonneForceCentimeters(this long value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double?)"/>
        public static Torque? TonneForceCentimeters(this long? value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double)"/>
        public static Torque TonneForceCentimeters(this double value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double?)"/>
        public static Torque? TonneForceCentimeters(this double? value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double)"/>
        public static Torque TonneForceCentimeters(this float value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double?)"/>
        public static Torque? TonneForceCentimeters(this float? value) => Torque.FromTonneForceCentimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double)"/>
        public static Torque TonneForceCentimeters(this decimal value) => Torque.FromTonneForceCentimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromTonneForceCentimeters(double?)"/>
        public static Torque? TonneForceCentimeters(this decimal? value) => Torque.FromTonneForceCentimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region TonneForceMeter

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double)"/>
        public static Torque TonneForceMeters(this int value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double?)"/>
        public static Torque? TonneForceMeters(this int? value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double)"/>
        public static Torque TonneForceMeters(this long value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double?)"/>
        public static Torque? TonneForceMeters(this long? value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double)"/>
        public static Torque TonneForceMeters(this double value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double?)"/>
        public static Torque? TonneForceMeters(this double? value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double)"/>
        public static Torque TonneForceMeters(this float value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double?)"/>
        public static Torque? TonneForceMeters(this float? value) => Torque.FromTonneForceMeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double)"/>
        public static Torque TonneForceMeters(this decimal value) => Torque.FromTonneForceMeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromTonneForceMeters(double?)"/>
        public static Torque? TonneForceMeters(this decimal? value) => Torque.FromTonneForceMeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region TonneForceMillimeter

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double)"/>
        public static Torque TonneForceMillimeters(this int value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double?)"/>
        public static Torque? TonneForceMillimeters(this int? value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double)"/>
        public static Torque TonneForceMillimeters(this long value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double?)"/>
        public static Torque? TonneForceMillimeters(this long? value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double)"/>
        public static Torque TonneForceMillimeters(this double value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double?)"/>
        public static Torque? TonneForceMillimeters(this double? value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double)"/>
        public static Torque TonneForceMillimeters(this float value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double?)"/>
        public static Torque? TonneForceMillimeters(this float? value) => Torque.FromTonneForceMillimeters(value);

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double)"/>
        public static Torque TonneForceMillimeters(this decimal value) => Torque.FromTonneForceMillimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Torque.FromTonneForceMillimeters(double?)"/>
        public static Torque? TonneForceMillimeters(this decimal? value) => Torque.FromTonneForceMillimeters(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

    }
}
#endif
