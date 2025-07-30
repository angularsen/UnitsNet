// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct Temperature
    {
        /// <summary>
        ///     Add a <see cref="Temperature" /> and a <see cref="TemperatureDelta" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator +(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins + right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Add a <see cref="TemperatureDelta" /> and a <see cref="Temperature" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator +(TemperatureDelta left, Temperature right)
        {
            return new Temperature(left.Kelvins + right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Subtract a <see cref="Temperature" /> by a <see cref="TemperatureDelta" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature operator -(Temperature left, TemperatureDelta right)
        {
            return new Temperature(left.Kelvins - right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Subtract a <see cref="Temperature" /> by a <see cref="TemperatureDelta" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The delta temperature (difference).</returns>
        public static TemperatureDelta operator -(Temperature left, Temperature right)
        {
            return new TemperatureDelta(left.Kelvins - right.Kelvins, TemperatureDeltaUnit.Kelvin);
        }
    }
}
