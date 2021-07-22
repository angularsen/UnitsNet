// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     The foot–pound–second system or FPS system is a system of units built on three fundamental units: the foot for length, the (avoirdupois) pound for either mass or force (see below), and the second for time.
    /// </summary>
    public partial class FPS : UnitSystem
    {
        /// <summary>
        ///     Construct a new instance of the foot–pound–second system unit system
        /// </summary>
        public FPS() : base(new Lazy<UnitSystemInfo?[]>(GetDefaultSystemUnits))
        {
        }
    }
}
