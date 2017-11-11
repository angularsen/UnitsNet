// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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

#if !WINDOWS_UWP
// Extension methods/overloads not supported in Universal Windows Platform (WinRT Components)
using System;

namespace UnitsNet.Extensions.NumberToTimeSpan
{
    public static class NumberToTimeSpanExtensions
    {
        // ReSharper disable InconsistentNaming
        /// <summary>Shorthand for <see cref="TimeSpan.FromDays" />.</summary>
        public static TimeSpan d(this int days) => TimeSpan.FromDays(days);

        /// <summary>Shorthand for <see cref="TimeSpan.FromDays" />.</summary>
        public static TimeSpan d(this long days) => TimeSpan.FromDays(days);

        /// <summary>Shorthand for <see cref="TimeSpan.FromDays" />.</summary>
        public static TimeSpan d(this float days) => TimeSpan.FromDays(days);

        /// <summary>Shorthand for <see cref="TimeSpan.FromDays" />.</summary>
        public static TimeSpan d(this double days) => TimeSpan.FromDays(days);

        /// <summary>Shorthand for <see cref="TimeSpan.FromDays" />.</summary>
        public static TimeSpan d(this decimal days) => TimeSpan.FromDays(Convert.ToDouble(days));

        /// <summary>Shorthand for <see cref="TimeSpan.FromHours" />.</summary>
        public static TimeSpan h(this int hours) => TimeSpan.FromHours(hours);

        /// <summary>Shorthand for <see cref="TimeSpan.FromHours" />.</summary>
        public static TimeSpan h(this long hours) => TimeSpan.FromHours(hours);

        /// <summary>Shorthand for <see cref="TimeSpan.FromHours" />.</summary>
        public static TimeSpan h(this float hours) => TimeSpan.FromHours(hours);

        /// <summary>Shorthand for <see cref="TimeSpan.FromHours" />.</summary>
        public static TimeSpan h(this double hours) => TimeSpan.FromHours(hours);

        /// <summary>Shorthand for <see cref="TimeSpan.FromHours" />.</summary>
        public static TimeSpan h(this decimal hours) => TimeSpan.FromHours(Convert.ToDouble(hours));

        /// <summary>Shorthand for <see cref="TimeSpan.FromMinutes" />.</summary>
        public static TimeSpan m(this int minutes) => TimeSpan.FromMinutes(minutes);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMinutes" />.</summary>
        public static TimeSpan m(this long minutes) => TimeSpan.FromMinutes(minutes);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMinutes" />.</summary>
        public static TimeSpan m(this float minutes) => TimeSpan.FromMinutes(minutes);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMinutes" />.</summary>
        public static TimeSpan m(this double minutes) => TimeSpan.FromMinutes(minutes);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMinutes" />.</summary>
        public static TimeSpan m(this decimal minutes) => TimeSpan.FromMinutes(Convert.ToDouble(minutes));

        /// <summary>Shorthand for <see cref="TimeSpan.FromSeconds" />.</summary>
        public static TimeSpan s(this int seconds) => TimeSpan.FromSeconds(seconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromSeconds" />.</summary>
        public static TimeSpan s(this long seconds) => TimeSpan.FromSeconds(seconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromSeconds" />.</summary>
        public static TimeSpan s(this float seconds) => TimeSpan.FromSeconds(seconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromSeconds" />.</summary>
        public static TimeSpan s(this double seconds) => TimeSpan.FromSeconds(seconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromSeconds" />.</summary>
        public static TimeSpan s(this decimal seconds) => TimeSpan.FromSeconds(Convert.ToDouble(seconds));

        /// <summary>Shorthand for <see cref="TimeSpan.FromMilliseconds" />.</summary>
        public static TimeSpan ms(this int milliseconds) => TimeSpan.FromMilliseconds(milliseconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMilliseconds" />.</summary>
        public static TimeSpan ms(this long milliseconds) => TimeSpan.FromMilliseconds(milliseconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMilliseconds" />.</summary>
        public static TimeSpan ms(this float milliseconds) => TimeSpan.FromMilliseconds(milliseconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMilliseconds" />.</summary>
        public static TimeSpan ms(this double milliseconds) => TimeSpan.FromMilliseconds(milliseconds);

        /// <summary>Shorthand for <see cref="TimeSpan.FromMilliseconds" />.</summary>
        public static TimeSpan ms(this decimal milliseconds) => TimeSpan.FromMilliseconds(Convert.ToDouble(milliseconds));

        // ReSharper restore InconsistentNaming
    }
}

#endif