// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

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
        /// <returns>The resulting <see cref="Temperature" />.</returns>
        [Obsolete("Affine quantities, such as the Temperate, cannot be multiplied directly: consider using the TemperatureDelta type instead.")]
        public Temperature Multiply(QuantityValue factor, TemperatureUnit unit)
        {
            QuantityValue resultInUnit = this.As(unit) * factor;
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
        /// <returns>The resulting <see cref="Temperature" />.</returns>
        [Obsolete("Affine quantities, such as the Temperate, cannot be divided directly: consider using the TemperatureDelta type instead.")]
        public Temperature Divide(QuantityValue divisor, TemperatureUnit unit)
        {
            QuantityValue resultInUnit = this.As(unit) / divisor;
            return From(resultInUnit, unit);
        }

        // /// <inheritdoc />
        // public bool Equals(IQuantity? other, IQuantity tolerance)
        // {
        //     return Comparison.EqualsAbsolute<Temperature, TemperatureUnit>(this, other, tolerance);
        // }
        
        /// <inheritdoc cref="LinearQuantityExtensions.Equals{TQuantity,TOther,TTolerance}"/> />
        [Obsolete("Affine quantities, such as the Temperate, should use an offset-based tolerance: consider using the TemperatureDelta type instead.")]
        public bool Equals(Temperature other, Temperature tolerance)
        {
            if (QuantityValue.IsNegative(tolerance.Value))
            {
                throw ExceptionHelper.CreateArgumentOutOfRangeExceptionForNegativeTolerance(nameof(tolerance));
            }

            var unitKey = UnitKey.ForUnit(tolerance.Unit);
            return Comparison.EqualsAbsolute(this.GetValue(unitKey), other.GetValue(unitKey), tolerance.Value);
        }

        // /// <summary>
        // /// Determines whether the specified <see cref="Temperature"/> object is equal to the current instance within a given tolerance.
        // /// </summary>
        // /// <param name="other">The <see cref="Temperature"/> object to compare with the current instance.</param>
        // /// <param name="tolerance">The <see cref="TemperatureDelta"/> tolerance within which the two <see cref="Temperature"/> objects are considered equal.</param>
        // /// <returns>
        // /// <c>true</c> if the specified <see cref="Temperature"/> object is equal to the current instance within the given tolerance; otherwise, <c>false</c>.
        // /// </returns>
        // /// <remarks>
        // /// This method compares the absolute values of the temperatures and checks if the difference is within the specified tolerance.
        // /// </remarks>
        // public bool Equals(Temperature other, TemperatureDelta tolerance)
        // {
        //     return this.EqualsAbsolute(other, tolerance);
        //     // return AffineQuantityExtensions.Equals(this, other, tolerance);
        // }

    }
}
