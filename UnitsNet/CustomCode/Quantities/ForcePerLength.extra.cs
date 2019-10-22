// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct ForcePerLength<T>
    {
        /// <summary>Get <see cref="Force{T}"/> from <see cref="ForcePerLength{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static Force<T> operator *(ForcePerLength<T> forcePerLength, Length<T> length )
        {
            return Force<T>.FromNewtons(forcePerLength.NewtonsPerMeter * length.Meters);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Force{T}"/> divided by <see cref="ForcePerLength{T}"/>.</summary>
        public static Length<T> operator /(Force<T> force, ForcePerLength<T> forcePerLength )
        {
            return Length<T>.FromMeters(force.Newtons / forcePerLength.NewtonsPerMeter);
        }

        /// <summary>Get <see cref="Pressure{T}"/> from <see cref="ForcePerLength{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static Pressure<T> operator /(ForcePerLength<T> forcePerLength, Length<T> length )
        {
            return Pressure<T>.FromNewtonsPerSquareMeter(forcePerLength.NewtonsPerMeter / length.Meters);
        }
    }
}
