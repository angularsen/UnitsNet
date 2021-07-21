// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct ReciprocalLength
    {
        /// <summary>
        /// Calculates the inverse of this quantity.
        /// </summary>
        /// <returns>The corresponding inverse quantity, <see cref="Length"/>.</returns>
        public Length Inverse()
        {
            if (InverseMeters == 0.0)
                return new Length(0.0, LengthUnit.Meter);

            return new Length(1 / InverseMeters, LengthUnit.Meter);
        }

        /// <summary>Get <see cref="Pressure"/> from <see cref="ReciprocalLength"/> multiplied by <see cref="ForcePerLength"/>.</summary>
        public static Pressure operator *(ReciprocalLength reciprocalLength, ForcePerLength forcePerLength)
        {
            return Pressure.FromNewtonsPerSquareMeter(reciprocalLength.InverseMeters * forcePerLength.NewtonsPerMeter);
        }

        /// <summary>Get <see cref="ForcePerLength"/> from <see cref="ReciprocalLength"/> times <see cref="Force"/>.</summary>
        public static ForcePerLength operator *(ReciprocalLength reciprocalLength, Force force)
        {
            return ForcePerLength.FromNewtonsPerMeter(reciprocalLength.InverseMeters * force.Newtons);
        }

        /// <summary>Get <see cref="ReciprocalArea"/> from <see cref="ReciprocalLength"/> times <see cref="ReciprocalLength"/>.</summary>
        public static ReciprocalArea operator *(ReciprocalLength reciprocalLength, ReciprocalLength other)
        {
            return ReciprocalArea.FromInverseSquareMeters(reciprocalLength.InverseMeters * other.InverseMeters);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="ReciprocalLength"/> times <see cref="ReciprocalArea"/>.</summary>
        public static Length operator /(ReciprocalLength reciprocalLength, ReciprocalArea reciprocalArea)
        {
            return Length.FromMeters(reciprocalLength.InverseMeters / reciprocalArea.InverseSquareMeters);
        }
    }
}
