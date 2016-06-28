// Copyright(c) 2007 Andreas Gullberg Larsen
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

namespace UnitsNet
{
#if WINDOWS_UWP
    public sealed partial class Duration
#else
    public partial struct Duration
#endif
    {
        // Operator overloads not supported in Universal Windows Platform (WinRT Components)
#if !WINDOWS_UWP
        public static DateTime operator +(DateTime time, Duration duration)
        {
            return time.AddSeconds(duration.Seconds);
        }

        public static DateTime operator -(DateTime time, Duration duration)
        {
            return time.AddSeconds(-duration.Seconds);
        }

        public static explicit operator TimeSpan(Duration duration)
        {
            return duration.ToTimeSpan();
        }

        public static explicit operator Duration(TimeSpan duration)
        {
            return FromSeconds(duration.TotalSeconds);
        }

        public static bool operator <(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds < timeSpan.TotalSeconds;
        }

        public static bool operator >(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds > timeSpan.TotalSeconds;
        }

        public static bool operator <=(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds <= timeSpan.TotalSeconds;
        }

        public static bool operator >=(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds >= timeSpan.TotalSeconds;
        }

        public static bool operator ==(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds == timeSpan.TotalSeconds;
        }

        public static bool operator !=(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds != timeSpan.TotalSeconds;
        }

        public static bool operator <(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds < duration.Seconds;
        }

        public static bool operator >(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds > duration.Seconds;
        }

        public static bool operator <=(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds <= duration.Seconds;
        }

        public static bool operator >=(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds >= duration.Seconds;
        }

        public static bool operator ==(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds == duration.Seconds;
        }

        public static bool operator !=(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds != duration.Seconds;
        }
#endif

        /// <summary>
        /// Convert a Duration to a TimeSpan.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the TimeSpan can't represent the Duration exactly </exception>
        /// <returns>The TimeSpan with the same time as the duration</returns>
        public TimeSpan ToTimeSpan()
        {
            if (Seconds > TimeSpan.MaxValue.TotalSeconds ||
                Seconds < TimeSpan.MinValue.TotalSeconds)
            {
                throw new ArgumentOutOfRangeException(nameof(Duration), "The duration is too large or small to fit in a TimeSpan");
            }
            return TimeSpan.FromSeconds(Seconds);
        }
    }
}