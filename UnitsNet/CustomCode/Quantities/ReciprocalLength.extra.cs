// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct ReciprocalLength
    {
        /// <summary>
        /// Calculates the inverse or <see cref="Length"/> of this unit.
        /// </summary>
        /// <returns>The inverse or <see cref="Length"/> of this unit.</returns>
        public Length Inverse()
        {
            if (InverseMeter == 0.0)
                return new Length(0.0, LengthUnit.Meter);

            return new Length(1 / InverseMeter, LengthUnit.Meter);
        }
    }
}
