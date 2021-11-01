// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct AreaMomentOfInertia
    {
        /// <summary>Get <see cref="Volume"/> from <see cref="AreaMomentOfInertia"/> divided by <see cref="Length"/>.</summary>
        public static Volume operator /(AreaMomentOfInertia areaMomentOfInertia, Length length)
        {
            return Volume.FromCubicMeters(areaMomentOfInertia.MetersToTheFourth / length.Meters);
        }
    }
}
