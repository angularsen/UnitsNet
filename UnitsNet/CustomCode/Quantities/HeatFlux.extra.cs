// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct HeatFlux<T>
    {
        /// <summary>Get <see cref="Power{T}"/> from <see cref="HeatFlux{T}"/> times <see cref="Area{T}"/>.</summary>
        public static Power<T> operator *(HeatFlux<T> heatFlux, Area<T> area )
        {
            return Power<T>.FromWatts(heatFlux.WattsPerSquareMeter * area.SquareMeters);
        }
    }
}
