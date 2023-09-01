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
        /// <exception cref="ArgumentOutOfRangeException">Throws if the TimeSpan can't represent the Duration exactly </exception>
        /// <returns>The TimeSpan with the same time as the duration</returns>
        public TimeSpan ToTimeSpan()
        {
            if ( Seconds > TimeSpan.MaxValue.TotalSeconds ||
                Seconds < TimeSpan.MinValue.TotalSeconds )
                throw new ArgumentOutOfRangeException( nameof( Duration ), "The duration is too large or small to fit in a TimeSpan" );
            return TimeSpan.FromTicks((long)(Seconds * TimeSpan.TicksPerSecond));
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

        /// <summary>Explicitly cast <see cref="Duration"/> to <see cref="TimeSpan"/>.</summary>
        public static explicit operator TimeSpan(Duration duration)
        {
            return duration.ToTimeSpan();
        }

        /// <summary>Explicitly cast <see cref="TimeSpan"/> to <see cref="Duration"/>.</summary>
        public static explicit operator Duration(TimeSpan duration)
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

        /// <summary>Get <see cref="Volume"/> from <see cref="Duration"/> multiplied by <see cref="VolumeFlow"/>.</summary>
        public static Volume operator *(Duration duration, VolumeFlow volumeFlow)
        {
            return Volume.FromCubicMeters(volumeFlow.CubicMetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="ElectricCharge"/> from <see cref="Duration"/> multiplied by <see cref="ElectricCurrent"/>.</summary>
        public static ElectricCharge operator *(Duration time, ElectricCurrent current)
        {
            return ElectricCharge.FromAmpereHours(current.Amperes * time.Hours);
        }

        /// <summary>Get <see cref="Speed"/> from <see cref="Duration"/> multiplied by <see cref="Acceleration"/>.</summary>
        public static Speed operator *(Duration duration, Acceleration acceleration)
        {
            return new Speed(acceleration.MetersPerSecondSquared * duration.Seconds, SpeedUnit.MeterPerSecond);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="Duration"/> multiplied by <see cref="ForceChangeRate"/>.</summary>
        public static Force operator *(Duration duration, ForceChangeRate forceChangeRate)
        {
            return new Force(forceChangeRate.NewtonsPerSecond * duration.Seconds, ForceUnit.Newton);
        }
    }
}
