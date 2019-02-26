// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct HeatFlux
    {
        /// <summary>Get <see cref="Power"/> from <see cref="HeatFlux"/> times <see cref="Area"/>.</summary>
        public static Power operator *(HeatFlux heatFlux, Area area)
        {
            return Power.FromWatts(heatFlux.WattsPerSquareMeter * area.SquareMeters);
        }
    }
}
