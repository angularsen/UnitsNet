// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Level
    {
        /// <summary>
        ///     Initializes a new instance of the logarithmic <see cref="Level" /> struct which is the ratio of a quantity Q to a
        ///     reference value of that quantity Q0.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <param name="reference">The reference value that <paramref name="quantity" /> is compared to.</param>
        /// <param name="significantDigits">The number of significant digits to use in the calculation. Default is 15.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     Thrown when the number of significant digits is less than 1 or greater than 17.
        /// </exception>
        public Level(double quantity, double reference, byte significantDigits = 15)
            : this()
        {
            var errorMessage = $"The base-10 logarithm of a number ≤ 0 is undefined ({quantity}/{reference}).";

            if (quantity == 0 || (quantity < 0 && reference > 0))
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), errorMessage);
            }

            if (reference == 0 || (quantity > 0 && reference < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(reference), errorMessage);
            }

            _value = QuantityValue.FromDoubleRounded(10 * Math.Log10(quantity / reference), significantDigits);
            _unit = LevelUnit.Decibel;
        }
    }
}
