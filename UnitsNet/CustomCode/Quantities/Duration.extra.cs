// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Duration<T>
    {
        /// <summary>
        ///     Convert a Duration to a TimeSpan.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throws if the TimeSpan can't represent the Duration exactly </exception>
        /// <returns>The TimeSpan with the same time as the duration</returns>
        public TimeSpan ToTimeSpan()
        {
            if( Seconds > TimeSpan.MaxValue.TotalSeconds ||
                Seconds < TimeSpan.MinValue.TotalSeconds )
                throw new ArgumentOutOfRangeException( nameof( Duration<T> ), "The duration is too large or small to fit in a TimeSpan" );
            return TimeSpan.FromSeconds( Seconds );
        }

        /// <summary>Get <see cref="DateTime"/> from <see cref="DateTime"/> plus <see cref="Duration{T}"/>.</summary>
        public static DateTime operator +(DateTime time, Duration<T> duration)
        {
            return time.AddSeconds(duration.Seconds);
        }

        /// <summary>Get <see cref="DateTime"/> from <see cref="DateTime"/> minus <see cref="Duration{T}"/>.</summary>
        public static DateTime operator -(DateTime time, Duration<T> duration)
        {
            return time.AddSeconds(-duration.Seconds);
        }

        /// <summary>Explicitly cast <see cref="Duration{T}"/> to <see cref="TimeSpan"/>.</summary>
        public static explicit operator TimeSpan(Duration<T> duration)
        {
            return duration.ToTimeSpan();
        }

        /// <summary>Explicitly cast <see cref="TimeSpan"/> to <see cref="Duration{T}"/>.</summary>
        public static explicit operator Duration<T>(TimeSpan duration)
        {
            return FromSeconds(duration.TotalSeconds);
        }

        /// <summary>True if <see cref="Duration{T}"/> is less than <see cref="TimeSpan"/>.</summary>
        public static bool operator <(Duration<T> duration, TimeSpan timeSpan)
        {
            return CompiledLambdas.LessThan(duration.Seconds, timeSpan.TotalSeconds);
        }

        /// <summary>True if <see cref="Duration{T}"/> is greater than <see cref="TimeSpan"/>.</summary>
        public static bool operator >(Duration<T> duration, TimeSpan timeSpan)
        {
            return CompiledLambdas.GreaterThan(duration.Seconds, timeSpan.TotalSeconds);
        }

        /// <summary>True if <see cref="Duration{T}"/> is less than or equal to <see cref="TimeSpan"/>.</summary>
        public static bool operator <=(Duration<T> duration, TimeSpan timeSpan)
        {
            return CompiledLambdas.LessThanOrEqual( duration.Seconds, timeSpan.TotalSeconds);
        }

        /// <summary>True if <see cref="Duration{T}"/> is greater than or equal to <see cref="TimeSpan"/>.</summary>
        public static bool operator >=(Duration<T> duration, TimeSpan timeSpan)
        {
            return CompiledLambdas.GreaterThanOrEqual(duration.Seconds, timeSpan.TotalSeconds);
        }

        /// <summary>True if <see cref="TimeSpan"/> is less than <see cref="Duration{T}"/>.</summary>
        public static bool operator <(TimeSpan timeSpan, Duration<T> duration )
        {
            return CompiledLambdas.LessThan(timeSpan.TotalSeconds, duration.Seconds);
        }

        /// <summary>True if <see cref="TimeSpan"/> is greater than <see cref="Duration{T}"/>.</summary>
        public static bool operator >(TimeSpan timeSpan, Duration<T> duration )
        {
            return CompiledLambdas.GreaterThan(timeSpan.TotalSeconds, duration.Seconds);
        }

        /// <summary>True if <see cref="TimeSpan"/> is less than or equal to <see cref="Duration{T}"/>.</summary>
        public static bool operator <=(TimeSpan timeSpan, Duration<T> duration )
        {
            return CompiledLambdas.LessThanOrEqual(timeSpan.TotalSeconds, duration.Seconds);
        }

        /// <summary>True if <see cref="TimeSpan"/> is greater than or equal to <see cref="Duration{T}"/>.</summary>
        public static bool operator >=(TimeSpan timeSpan, Duration<T> duration )
        {
            return CompiledLambdas.GreaterThanOrEqual(timeSpan.TotalSeconds, duration.Seconds);
        }

        /// <summary>Get <see cref="Volume{T}"/> from <see cref="Duration{T}"/> times <see cref="VolumeFlow{T}"/>.</summary>
        public static Volume<T> operator *(Duration<T> duration, VolumeFlow<T> volumeFlow )
        {
            var value = CompiledLambdas.Multiply(volumeFlow.CubicMetersPerSecond, duration.Seconds);
            return Volume<T>.FromCubicMeters(value);
        }
    }
}
