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
namespace UnitsNet.Extensions.NumberToMassFlow
{
    public static class NumberToMassFlowExtensions
    {
        #region CentigramPerSecond

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double)"/>
        public static MassFlow CentigramsPerSecond(this int value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double?)"/>
        public static MassFlow? CentigramsPerSecond(this int? value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double)"/>
        public static MassFlow CentigramsPerSecond(this long value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double?)"/>
        public static MassFlow? CentigramsPerSecond(this long? value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double)"/>
        public static MassFlow CentigramsPerSecond(this double value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double?)"/>
        public static MassFlow? CentigramsPerSecond(this double? value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double)"/>
        public static MassFlow CentigramsPerSecond(this float value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double?)"/>
        public static MassFlow? CentigramsPerSecond(this float? value) => MassFlow.FromCentigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double)"/>
        public static MassFlow CentigramsPerSecond(this decimal value) => MassFlow.FromCentigramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromCentigramsPerSecond(double?)"/>
        public static MassFlow? CentigramsPerSecond(this decimal? value) => MassFlow.FromCentigramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region DecagramPerSecond

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double)"/>
        public static MassFlow DecagramsPerSecond(this int value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double?)"/>
        public static MassFlow? DecagramsPerSecond(this int? value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double)"/>
        public static MassFlow DecagramsPerSecond(this long value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double?)"/>
        public static MassFlow? DecagramsPerSecond(this long? value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double)"/>
        public static MassFlow DecagramsPerSecond(this double value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double?)"/>
        public static MassFlow? DecagramsPerSecond(this double? value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double)"/>
        public static MassFlow DecagramsPerSecond(this float value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double?)"/>
        public static MassFlow? DecagramsPerSecond(this float? value) => MassFlow.FromDecagramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double)"/>
        public static MassFlow DecagramsPerSecond(this decimal value) => MassFlow.FromDecagramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromDecagramsPerSecond(double?)"/>
        public static MassFlow? DecagramsPerSecond(this decimal? value) => MassFlow.FromDecagramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region DecigramPerSecond

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double)"/>
        public static MassFlow DecigramsPerSecond(this int value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double?)"/>
        public static MassFlow? DecigramsPerSecond(this int? value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double)"/>
        public static MassFlow DecigramsPerSecond(this long value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double?)"/>
        public static MassFlow? DecigramsPerSecond(this long? value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double)"/>
        public static MassFlow DecigramsPerSecond(this double value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double?)"/>
        public static MassFlow? DecigramsPerSecond(this double? value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double)"/>
        public static MassFlow DecigramsPerSecond(this float value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double?)"/>
        public static MassFlow? DecigramsPerSecond(this float? value) => MassFlow.FromDecigramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double)"/>
        public static MassFlow DecigramsPerSecond(this decimal value) => MassFlow.FromDecigramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromDecigramsPerSecond(double?)"/>
        public static MassFlow? DecigramsPerSecond(this decimal? value) => MassFlow.FromDecigramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region GramPerSecond

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double)"/>
        public static MassFlow GramsPerSecond(this int value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double?)"/>
        public static MassFlow? GramsPerSecond(this int? value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double)"/>
        public static MassFlow GramsPerSecond(this long value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double?)"/>
        public static MassFlow? GramsPerSecond(this long? value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double)"/>
        public static MassFlow GramsPerSecond(this double value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double?)"/>
        public static MassFlow? GramsPerSecond(this double? value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double)"/>
        public static MassFlow GramsPerSecond(this float value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double?)"/>
        public static MassFlow? GramsPerSecond(this float? value) => MassFlow.FromGramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double)"/>
        public static MassFlow GramsPerSecond(this decimal value) => MassFlow.FromGramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromGramsPerSecond(double?)"/>
        public static MassFlow? GramsPerSecond(this decimal? value) => MassFlow.FromGramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region HectogramPerSecond

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double)"/>
        public static MassFlow HectogramsPerSecond(this int value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double?)"/>
        public static MassFlow? HectogramsPerSecond(this int? value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double)"/>
        public static MassFlow HectogramsPerSecond(this long value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double?)"/>
        public static MassFlow? HectogramsPerSecond(this long? value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double)"/>
        public static MassFlow HectogramsPerSecond(this double value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double?)"/>
        public static MassFlow? HectogramsPerSecond(this double? value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double)"/>
        public static MassFlow HectogramsPerSecond(this float value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double?)"/>
        public static MassFlow? HectogramsPerSecond(this float? value) => MassFlow.FromHectogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double)"/>
        public static MassFlow HectogramsPerSecond(this decimal value) => MassFlow.FromHectogramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromHectogramsPerSecond(double?)"/>
        public static MassFlow? HectogramsPerSecond(this decimal? value) => MassFlow.FromHectogramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilogramPerHour

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double)"/>
        public static MassFlow KilogramsPerHour(this int value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double?)"/>
        public static MassFlow? KilogramsPerHour(this int? value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double)"/>
        public static MassFlow KilogramsPerHour(this long value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double?)"/>
        public static MassFlow? KilogramsPerHour(this long? value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double)"/>
        public static MassFlow KilogramsPerHour(this double value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double?)"/>
        public static MassFlow? KilogramsPerHour(this double? value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double)"/>
        public static MassFlow KilogramsPerHour(this float value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double?)"/>
        public static MassFlow? KilogramsPerHour(this float? value) => MassFlow.FromKilogramsPerHour(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double)"/>
        public static MassFlow KilogramsPerHour(this decimal value) => MassFlow.FromKilogramsPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromKilogramsPerHour(double?)"/>
        public static MassFlow? KilogramsPerHour(this decimal? value) => MassFlow.FromKilogramsPerHour(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region KilogramPerSecond

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double)"/>
        public static MassFlow KilogramsPerSecond(this int value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double?)"/>
        public static MassFlow? KilogramsPerSecond(this int? value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double)"/>
        public static MassFlow KilogramsPerSecond(this long value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double?)"/>
        public static MassFlow? KilogramsPerSecond(this long? value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double)"/>
        public static MassFlow KilogramsPerSecond(this double value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double?)"/>
        public static MassFlow? KilogramsPerSecond(this double? value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double)"/>
        public static MassFlow KilogramsPerSecond(this float value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double?)"/>
        public static MassFlow? KilogramsPerSecond(this float? value) => MassFlow.FromKilogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double)"/>
        public static MassFlow KilogramsPerSecond(this decimal value) => MassFlow.FromKilogramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromKilogramsPerSecond(double?)"/>
        public static MassFlow? KilogramsPerSecond(this decimal? value) => MassFlow.FromKilogramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region MicrogramPerSecond

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double)"/>
        public static MassFlow MicrogramsPerSecond(this int value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double?)"/>
        public static MassFlow? MicrogramsPerSecond(this int? value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double)"/>
        public static MassFlow MicrogramsPerSecond(this long value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double?)"/>
        public static MassFlow? MicrogramsPerSecond(this long? value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double)"/>
        public static MassFlow MicrogramsPerSecond(this double value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double?)"/>
        public static MassFlow? MicrogramsPerSecond(this double? value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double)"/>
        public static MassFlow MicrogramsPerSecond(this float value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double?)"/>
        public static MassFlow? MicrogramsPerSecond(this float? value) => MassFlow.FromMicrogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double)"/>
        public static MassFlow MicrogramsPerSecond(this decimal value) => MassFlow.FromMicrogramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromMicrogramsPerSecond(double?)"/>
        public static MassFlow? MicrogramsPerSecond(this decimal? value) => MassFlow.FromMicrogramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region MilligramPerSecond

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double)"/>
        public static MassFlow MilligramsPerSecond(this int value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double?)"/>
        public static MassFlow? MilligramsPerSecond(this int? value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double)"/>
        public static MassFlow MilligramsPerSecond(this long value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double?)"/>
        public static MassFlow? MilligramsPerSecond(this long? value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double)"/>
        public static MassFlow MilligramsPerSecond(this double value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double?)"/>
        public static MassFlow? MilligramsPerSecond(this double? value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double)"/>
        public static MassFlow MilligramsPerSecond(this float value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double?)"/>
        public static MassFlow? MilligramsPerSecond(this float? value) => MassFlow.FromMilligramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double)"/>
        public static MassFlow MilligramsPerSecond(this decimal value) => MassFlow.FromMilligramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromMilligramsPerSecond(double?)"/>
        public static MassFlow? MilligramsPerSecond(this decimal? value) => MassFlow.FromMilligramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region NanogramPerSecond

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double)"/>
        public static MassFlow NanogramsPerSecond(this int value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double?)"/>
        public static MassFlow? NanogramsPerSecond(this int? value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double)"/>
        public static MassFlow NanogramsPerSecond(this long value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double?)"/>
        public static MassFlow? NanogramsPerSecond(this long? value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double)"/>
        public static MassFlow NanogramsPerSecond(this double value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double?)"/>
        public static MassFlow? NanogramsPerSecond(this double? value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double)"/>
        public static MassFlow NanogramsPerSecond(this float value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double?)"/>
        public static MassFlow? NanogramsPerSecond(this float? value) => MassFlow.FromNanogramsPerSecond(value);

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double)"/>
        public static MassFlow NanogramsPerSecond(this decimal value) => MassFlow.FromNanogramsPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromNanogramsPerSecond(double?)"/>
        public static MassFlow? NanogramsPerSecond(this decimal? value) => MassFlow.FromNanogramsPerSecond(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

        #region TonnePerDay

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double)"/>
        public static MassFlow TonnesPerDay(this int value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double?)"/>
        public static MassFlow? TonnesPerDay(this int? value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double)"/>
        public static MassFlow TonnesPerDay(this long value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double?)"/>
        public static MassFlow? TonnesPerDay(this long? value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double)"/>
        public static MassFlow TonnesPerDay(this double value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double?)"/>
        public static MassFlow? TonnesPerDay(this double? value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double)"/>
        public static MassFlow TonnesPerDay(this float value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double?)"/>
        public static MassFlow? TonnesPerDay(this float? value) => MassFlow.FromTonnesPerDay(value);

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double)"/>
        public static MassFlow TonnesPerDay(this decimal value) => MassFlow.FromTonnesPerDay(Convert.ToDouble(value));

        /// <inheritdoc cref="MassFlow.FromTonnesPerDay(double?)"/>
        public static MassFlow? TonnesPerDay(this decimal? value) => MassFlow.FromTonnesPerDay(value == null ? (double?)null : Convert.ToDouble(value.Value));

        #endregion

    }
}
#endif
