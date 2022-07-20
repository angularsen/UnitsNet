// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Luminance
    {
        /// <summary>Get <see cref="LuminousIntensity"/> from <see cref="Luminance"/> times <see cref="Area"/>.</summary>
        public static LuminousIntensity operator *(Luminance luminance, Area area)
        {
            return LuminousIntensity.FromCandela(luminance.CandelasPerSquareMeter * area.SquareMeters);
        }
    }
}
