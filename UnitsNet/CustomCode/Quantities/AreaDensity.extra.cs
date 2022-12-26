// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct AreaDensity
    {
        /// <summary>Get <see cref="Mass"/> from <see cref="AreaDensity"/> times <see cref="Area"/>.</summary>
        public static Mass operator *(AreaDensity areaDensity, Area area)
        {
            return Mass.FromKilograms(areaDensity.KilogramsPerSquareMeter * area.SquareMeters);
        }
    }
}
