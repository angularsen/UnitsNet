// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Numerics;

namespace UnitsNet;

public partial struct Duration
{
    /// <summary>
    ///     Convert a Duration to a TimeSpan.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Throws if the duration exceeds the <see cref="TimeSpan" />.<see cref="TimeSpan.MaxValue" /> or
    ///     <see cref="TimeSpan.MinValue" />, which would cause it to roll over from positive to negative and vice versa.
    /// </exception>
    /// <returns>The TimeSpan with the same time as the duration</returns>
    public TimeSpan ToTimeSpan()
    {
        var ticks = (BigInteger)(Seconds * TimeSpan.TicksPerSecond);
        if (ticks > TimeSpan.MaxValue.Ticks)
        {
            throw new ArgumentOutOfRangeException(nameof(ticks),
                "The duration is too large for a TimeSpan, which would roll over from positive to negative.");
        }

        if (ticks < TimeSpan.MinValue.Ticks)
        {
            throw new ArgumentOutOfRangeException(nameof(ticks),
                "The duration is too small for a TimeSpan, which would roll over from negative to positive.");
        }

        return TimeSpan.FromTicks((long)ticks);
    }

    /// <summary>Get <see cref="DateTime" /> from <see cref="DateTime" /> plus <see cref="Duration" />.</summary>
    public static DateTime operator +(DateTime time, Duration duration)
    {
        return time + duration.ToTimeSpan();
    }

    /// <summary>Get <see cref="DateTime" /> from <see cref="DateTime" /> minus <see cref="Duration" />.</summary>
    public static DateTime operator -(DateTime time, Duration duration)
    {
        return time - duration.ToTimeSpan();
    }

    /// <summary>Implicitly cast <see cref="Duration" /> to <see cref="TimeSpan" />.</summary>
    public static implicit operator TimeSpan(Duration duration)
    {
        return duration.ToTimeSpan();
    }

    /// <summary>Implicitly cast <see cref="TimeSpan" /> to <see cref="Duration" />.</summary>
    public static implicit operator Duration(TimeSpan duration)
    {
        return FromSeconds(new QuantityValue(duration.Ticks, TimeSpan.TicksPerSecond));
    }

    /// <summary>True if <see cref="Duration" /> is less than <see cref="TimeSpan" />.</summary>
    public static bool operator <(Duration duration, TimeSpan timeSpan)
    {
        return duration.Seconds * TimeSpan.TicksPerSecond < timeSpan.Ticks;
    }

    /// <summary>True if <see cref="Duration" /> is greater than <see cref="TimeSpan" />.</summary>
    public static bool operator >(Duration duration, TimeSpan timeSpan)
    {
        return duration.Seconds * TimeSpan.TicksPerSecond > timeSpan.Ticks;
    }

    /// <summary>True if <see cref="Duration" /> is less than or equal to <see cref="TimeSpan" />.</summary>
    public static bool operator <=(Duration duration, TimeSpan timeSpan)
    {
        return duration.Seconds * TimeSpan.TicksPerSecond <= timeSpan.Ticks;
    }

    /// <summary>True if <see cref="Duration" /> is greater than or equal to <see cref="TimeSpan" />.</summary>
    public static bool operator >=(Duration duration, TimeSpan timeSpan)
    {
        return duration.Seconds * TimeSpan.TicksPerSecond >= timeSpan.Ticks;
    }

    /// <summary>True if <see cref="TimeSpan" /> is less than <see cref="Duration" />.</summary>
    public static bool operator <(TimeSpan timeSpan, Duration duration)
    {
        return timeSpan.Ticks < duration.Seconds * TimeSpan.TicksPerSecond;
    }

    /// <summary>True if <see cref="TimeSpan" /> is greater than <see cref="Duration" />.</summary>
    public static bool operator >(TimeSpan timeSpan, Duration duration)
    {
        return timeSpan.Ticks > duration.Seconds * TimeSpan.TicksPerSecond;
    }

    /// <summary>True if <see cref="TimeSpan" /> is less than or equal to <see cref="Duration" />.</summary>
    public static bool operator <=(TimeSpan timeSpan, Duration duration)
    {
        return timeSpan.Ticks <= duration.Seconds * TimeSpan.TicksPerSecond;
    }

    /// <summary>True if <see cref="TimeSpan" /> is greater than or equal to <see cref="Duration" />.</summary>
    public static bool operator >=(TimeSpan timeSpan, Duration duration)
    {
        return timeSpan.Ticks >= duration.Seconds * TimeSpan.TicksPerSecond;
    }
}
