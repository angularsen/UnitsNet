// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.InternalHelpers
{
    internal static class UnitsNetMath
    {
        /// <summary>
        /// Clamps a numeric value to a min and max, similar to Math.Clamp.
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="val">The value to be clamped</param>
        /// <param name="min">The minimum value allowed</param>
        /// <param name="max">The maximum value allowed</param>
        /// <returns>The clamped value</returns>
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0)
                return min;
            else if (val.CompareTo(max) > 0)
                return max;
            else
                return val;
        }
    }
}
