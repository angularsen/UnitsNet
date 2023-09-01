// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct ForceChangeRate
    {
        /// <summary>Get <see cref="Force"/> from <see cref="ForcePerLength"/> multiplied by <see cref="Length"/>.</summary>
        public static Force operator *(ForceChangeRate forceChangeRate, Duration duration)
        {
            return new Force(forceChangeRate.NewtonsPerSecond * duration.Seconds, ForceUnit.Newton);
        }
    }
}
