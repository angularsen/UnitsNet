// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Temperature<T>
    {
        /// <summary>
        ///     Add a <see cref="Temperature{T}" /> and a <see cref="TemperatureDelta{T}" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature<T> operator +(Temperature<T> left, TemperatureDelta<T> right )
        {
            return new Temperature<T>( left.Kelvins + right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Add a <see cref="TemperatureDelta{T}" /> and a <see cref="Temperature{T}" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature<T> operator +(TemperatureDelta<T> left, Temperature<T> right )
        {
            return new Temperature<T>( left.Kelvins + right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Subtract a <see cref="Temperature{T}" /> by a <see cref="TemperatureDelta{T}" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The new temperature.</returns>
        public static Temperature<T> operator -(Temperature<T> left, TemperatureDelta<T> right )
        {
            return new Temperature<T>( left.Kelvins - right.Kelvins, TemperatureUnit.Kelvin);
        }

        /// <summary>
        ///     Subtract a <see cref="Temperature{T}" /> by a <see cref="TemperatureDelta{T}" />.
        /// </summary>
        /// <remarks>Due to temperature units having different scales, the arithmetic must be performed on the same scale.</remarks>
        /// <returns>The delta temperature (difference).</returns>
        public static TemperatureDelta<T> operator -(Temperature<T> left, Temperature<T> right )
        {
            return new TemperatureDelta<T>( left.Kelvins - right.Kelvins, TemperatureDeltaUnit.Kelvin);
        }

        /// <summary>
        ///     Multiply temperature with a <paramref name="factor" /> in a given <paramref name="unit" />.
        /// </summary>
        /// <remarks>
        ///     Due to different temperature units having different zero points, we cannot simply
        ///     multiply or divide a temperature by a factor. We must first convert to the desired unit, then perform the
        ///     calculation.
        /// </remarks>
        /// <param name="factor">Factor to multiply by.</param>
        /// <param name="unit">Unit to perform multiplication in.</param>
        /// <returns>The resulting <see cref="Temperature{T}" />.</returns>
        public Temperature<T> Multiply(double factor, TemperatureUnit unit)
        {
            double resultInUnit = As(unit) * factor;
            return From(resultInUnit, unit);
        }


        /// <summary>
        ///     Divide temperature by a <paramref name="divisor" /> in a given <paramref name="unit" />.
        /// </summary>
        /// <remarks>
        ///     Due to different temperature units having different zero points, we cannot simply
        ///     multiply or divide a temperature by a factor. We must first convert to the desired unit, then perform the
        ///     calculation.
        /// </remarks>
        /// <param name="divisor">Factor to multiply by.</param>
        /// <param name="unit">Unit to perform multiplication in.</param>
        /// <returns>The resulting <see cref="Temperature{T}" />.</returns>
        public Temperature<T> Divide(double divisor, TemperatureUnit unit)
        {
            double resultInUnit = As(unit) / divisor;
            return From(resultInUnit, unit);
        }
    }
}
