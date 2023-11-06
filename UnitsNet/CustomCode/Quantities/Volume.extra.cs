// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Volume
    {
        /// <summary>Get <see cref="TimeSpan"/> from <see cref="Volume"/> divided by <see cref="VolumeFlow"/>.</summary>
        public static TimeSpan operator /(Volume volume, VolumeFlow volumeFlow)
        {
            return TimeSpan.FromSeconds(volume.CubicMeters / volumeFlow.CubicMetersPerSecond);
        }
    }
}
