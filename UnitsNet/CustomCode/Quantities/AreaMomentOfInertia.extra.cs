// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct AreaMomentOfInertia<T>
    {
        /// <summary>Get <see cref="Volume{T}"/> from <see cref="AreaMomentOfInertia{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static Volume<T> operator /(AreaMomentOfInertia<T> areaMomentOfInertia, Length<T> length )
        {
            return Volume<T>.FromCubicMeters(areaMomentOfInertia.MetersToTheFourth / length.Meters);
        }
    }
}
