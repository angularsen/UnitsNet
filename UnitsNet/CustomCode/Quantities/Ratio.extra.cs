// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Ratio
    {
        /// <summary>
        /// Convert a slope <see cref="Ratio"/> to an <see cref="Angle"/>.
        /// </summary>
        /// <returns>An <see cref="Angle"/> representing the slope.</returns>
        public Angle ToSlopeAngle()
        {
            var radians = Math.Atan(this.DecimalFractions);
            return Angle.FromRadians(radians);
        }
    }
}
