// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Energy
    {
        /// <summary>Get <see cref="Power"/> from <see cref="Energy"/> divided by <see cref="TimeSpan"/>.</summary>
        public static Power operator /(Energy energy, TimeSpan time)
        {
            return Power.FromWatts(energy.Joules / time.TotalSeconds);
        }

        /// <summary>Get <see cref="Power"/> from <see cref="Energy"/> divided by <see cref="Duration"/>.</summary>
        public static Power operator /(Energy energy, Duration duration)
        {
            return Power.FromWatts(energy.Joules / duration.Seconds);
        }
    }
}
