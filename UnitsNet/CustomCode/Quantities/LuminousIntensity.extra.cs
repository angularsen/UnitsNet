// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct LuminousIntensity
    {
        /// <summary>Get <see cref="Luminance"/> from <see cref="LuminousIntensity"/> divided by <see cref="Area"/>.</summary>
        public static Luminance operator /(LuminousIntensity luminousIntensity, Area area)
        {
            return Luminance.FromCandelasPerSquareMeter(luminousIntensity.Candela / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="LuminousIntensity"/> divided by <see cref="Luminance"/>.</summary>
        public static Area operator /(LuminousIntensity luminousIntensity, Luminance luminance)
        {
            return Area.FromSquareMeters(luminousIntensity.Candela / luminance.CandelasPerSquareMeter);
        }
    }
}
