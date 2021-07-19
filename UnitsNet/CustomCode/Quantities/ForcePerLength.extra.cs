// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct ForcePerLength
    {
        /// <summary>Get <see cref="Force"/> from <see cref="ForcePerLength"/> multiplied by <see cref="Length"/>.</summary>
        public static Force operator *(ForcePerLength forcePerLength, Length length)
        {
            return Force.FromNewtons(forcePerLength.NewtonsPerMeter * length.Meters);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Force"/> divided by <see cref="ForcePerLength"/>.</summary>
        public static Length operator /(Force force, ForcePerLength forcePerLength)
        {
            return Length.FromMeters(force.Newtons / forcePerLength.NewtonsPerMeter);
        }

        /// <summary>Get <see cref="Pressure"/> from <see cref="ForcePerLength"/> divided by <see cref="Length"/>.</summary>
        public static Pressure operator /(ForcePerLength forcePerLength, Length length)
        {
            return Pressure.FromNewtonsPerSquareMeter(forcePerLength.NewtonsPerMeter / length.Meters);
        }

        /// <summary>Get <see cref="Torque"/> from <see cref="ForcePerLength"/> multiplied by <see cref="Area"/>.</summary>
        public static Torque operator *(ForcePerLength forcePerLength, Area area)
        {
            return Torque.FromNewtonMeters(forcePerLength.NewtonsPerMeter * area.SquareMeters);
        }

        /// <summary>Get <see cref="Pressure"/> from <see cref="ForcePerLength"/> multiplied by <see cref="ReciprocalLength"/>.</summary>
        public static Pressure operator *(ForcePerLength forcePerLength, ReciprocalLength reciprocalLength)
        {
            return Pressure.FromNewtonsPerSquareMeter(forcePerLength.NewtonsPerMeter * reciprocalLength.InverseMeters);
        }

        /// <summary>Get <see cref="Force"/> from <see cref="ForcePerLength"/> divided by <see cref="ReciprocalLength"/>.</summary>
        public static Force operator /(ForcePerLength forcePerLength, ReciprocalLength reciprocalLength)
        {
            return Force.FromNewtons(forcePerLength.NewtonsPerMeter / reciprocalLength.InverseMeters);
        }
    }
}
