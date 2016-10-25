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
namespace UnitsNet.Extensions.NumberToAcPotential
{
    public static class NumberToAcPotentialExtensions
    {
        #region VoltPeak

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double)"/>
        public static AcPotential VoltsPeak(this int value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double?)"/>
        public static AcPotential? VoltsPeak(this int? value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double)"/>
        public static AcPotential VoltsPeak(this long value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double?)"/>
        public static AcPotential? VoltsPeak(this long? value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double)"/>
        public static AcPotential VoltsPeak(this double value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double?)"/>
        public static AcPotential? VoltsPeak(this double? value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double)"/>
        public static AcPotential VoltsPeak(this float value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double?)"/>
        public static AcPotential? VoltsPeak(this float? value) => AcPotential.FromVoltsPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double)"/>
        public static AcPotential VoltsPeak(this decimal value) => AcPotential.FromVoltsPeak(Convert.ToDouble(value));

        /// <inheritdoc cref="AcPotential.FromVoltsPeak(double?)"/>
        public static AcPotential? VoltsPeak(this decimal? value) => AcPotential.FromVoltsPeak(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region VoltPeakToPeak

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double)"/>
        public static AcPotential VoltsPeakToPeak(this int value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double?)"/>
        public static AcPotential? VoltsPeakToPeak(this int? value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double)"/>
        public static AcPotential VoltsPeakToPeak(this long value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double?)"/>
        public static AcPotential? VoltsPeakToPeak(this long? value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double)"/>
        public static AcPotential VoltsPeakToPeak(this double value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double?)"/>
        public static AcPotential? VoltsPeakToPeak(this double? value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double)"/>
        public static AcPotential VoltsPeakToPeak(this float value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double?)"/>
        public static AcPotential? VoltsPeakToPeak(this float? value) => AcPotential.FromVoltsPeakToPeak(value);

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double)"/>
        public static AcPotential VoltsPeakToPeak(this decimal value) => AcPotential.FromVoltsPeakToPeak(Convert.ToDouble(value));

        /// <inheritdoc cref="AcPotential.FromVoltsPeakToPeak(double?)"/>
        public static AcPotential? VoltsPeakToPeak(this decimal? value) => AcPotential.FromVoltsPeakToPeak(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region VoltRMS

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double)"/>
        public static AcPotential VoltsRMS(this int value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double?)"/>
        public static AcPotential? VoltsRMS(this int? value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double)"/>
        public static AcPotential VoltsRMS(this long value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double?)"/>
        public static AcPotential? VoltsRMS(this long? value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double)"/>
        public static AcPotential VoltsRMS(this double value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double?)"/>
        public static AcPotential? VoltsRMS(this double? value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double)"/>
        public static AcPotential VoltsRMS(this float value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double?)"/>
        public static AcPotential? VoltsRMS(this float? value) => AcPotential.FromVoltsRMS(value);

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double)"/>
        public static AcPotential VoltsRMS(this decimal value) => AcPotential.FromVoltsRMS(Convert.ToDouble(value));

        /// <inheritdoc cref="AcPotential.FromVoltsRMS(double?)"/>
        public static AcPotential? VoltsRMS(this decimal? value) => AcPotential.FromVoltsRMS(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

    }
}
#endif
