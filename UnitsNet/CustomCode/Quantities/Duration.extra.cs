// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Duration
    {
        /// <summary>
        ///     Convert a Duration to a TimeSpan.
        /// </summary>
        /// <returns>The TimeSpan with the same time as the duration</returns>
        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromSeconds(Seconds);
        }

        /// <summary>Get <see cref="DateTime"/> from <see cref="DateTime"/> plus <see cref="Duration"/>.</summary>
        public static DateTime operator +(DateTime time, Duration duration)
        {
            return time.AddSeconds(duration.Seconds);
        }

        /// <summary>Get <see cref="DateTime"/> from <see cref="DateTime"/> minus <see cref="Duration"/>.</summary>
        public static DateTime operator -(DateTime time, Duration duration)
        {
            return time.AddSeconds(-duration.Seconds);
        }

        /// <summary>Implicitly cast <see cref="Duration"/> to <see cref="TimeSpan"/>.</summary>
        public static implicit operator TimeSpan(Duration duration)
        {
            return duration.ToTimeSpan();
        }

        /// <summary>Implicitly cast <see cref="TimeSpan"/> to <see cref="Duration"/>.</summary>
        public static implicit operator Duration(TimeSpan duration)
        {
            return FromSeconds(duration.TotalSeconds);
        }

        /// <summary>True if <see cref="Duration"/> is less than <see cref="TimeSpan"/>.</summary>
        public static bool operator <(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds < timeSpan.TotalSeconds;
        }

        /// <summary>True if <see cref="Duration"/> is greater than <see cref="TimeSpan"/>.</summary>
        public static bool operator >(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds > timeSpan.TotalSeconds;
        }

        /// <summary>True if <see cref="Duration"/> is less than or equal to <see cref="TimeSpan"/>.</summary>
        public static bool operator <=(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds <= timeSpan.TotalSeconds;
        }

        /// <summary>True if <see cref="Duration"/> is greater than or equal to <see cref="TimeSpan"/>.</summary>
        public static bool operator >=(Duration duration, TimeSpan timeSpan)
        {
            return duration.Seconds >= timeSpan.TotalSeconds;
        }

        /// <summary>True if <see cref="TimeSpan"/> is less than <see cref="Duration"/>.</summary>
        public static bool operator <(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds < duration.Seconds;
        }

        /// <summary>True if <see cref="TimeSpan"/> is greater than <see cref="Duration"/>.</summary>
        public static bool operator >(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds > duration.Seconds;
        }

        /// <summary>True if <see cref="TimeSpan"/> is less than or equal to <see cref="Duration"/>.</summary>
        public static bool operator <=(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds <= duration.Seconds;
        }

        /// <summary>True if <see cref="TimeSpan"/> is greater than or equal to <see cref="Duration"/>.</summary>
        public static bool operator >=(TimeSpan timeSpan, Duration duration)
        {
            return timeSpan.TotalSeconds >= duration.Seconds;
        }
    }
}
