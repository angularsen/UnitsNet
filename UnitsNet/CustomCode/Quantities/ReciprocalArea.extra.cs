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

        /// <summary>Get <see cref="Pressure"/> from <see cref="ReciprocalArea"/> multiplied by <see cref="Force"/>.</summary>
        public static Pressure operator *(ReciprocalArea reciprocalArea, Force force)
        {
            return Pressure.FromNewtonsPerSquareMeter(reciprocalArea.InverseSquareMeters * force.Newtons);
        }

        /// <summary>Get <see cref="Ratio"/> from <see cref="ReciprocalArea"/> multiplied by <see cref="Area"/>.</summary>
        public static Ratio operator *(ReciprocalArea reciprocalArea, Area area)
        {
            return new Ratio(reciprocalArea.InverseSquareMeters * area.SquareMeters, RatioUnit.DecimalFraction);
        }

        /// <summary>Get <see cref="ReciprocalLength"/> from <see cref="ReciprocalArea"/> divided by <see cref="ReciprocalLength"/>.</summary>
        public static ReciprocalLength operator /(ReciprocalArea reciprocalArea, ReciprocalLength reciprocalLength)
        {
            return ReciprocalLength.FromInverseMeters(reciprocalArea.InverseSquareMeters / reciprocalLength.InverseMeters);
        }
    }
}
