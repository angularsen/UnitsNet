// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct ReciprocalArea
    {
        /// <summary>
        /// Calculates the inverse of this quantity.
        /// </summary>
        /// <returns>The corresponding inverse quantity, <see cref="Area"/>.</returns>
        public Area Inverse()
        {
            if (InverseSquareMeters == 0.0)
                return new Area(0.0, AreaUnit.SquareMeter);

            return new Area(1 / InverseSquareMeters, AreaUnit.SquareMeter);
        }
    }
}
