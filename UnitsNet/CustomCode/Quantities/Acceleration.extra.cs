// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Acceleration<T>
    {
        /// <summary>
        /// Multiply <see cref="Acceleration{T}"/> and <see cref="Density{T}"/> to get <see cref="SpecificWeight{T}"/>.
        /// </summary>
        public static SpecificWeight<T> operator *(Acceleration<T> acceleration, Density<T> density)
        {
            return new SpecificWeight<T>(acceleration.MetersPerSecondSquared * density.KilogramsPerCubicMeter, UnitsNet.Units.SpecificWeightUnit.NewtonPerCubicMeter);
        }
    }
}
