// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    // Windows Runtime Component has constraints on public types: https://msdn.microsoft.com/en-us/library/br230301.aspx#Declaring types in Windows Runtime Components
    // Public structures can't have any members other than public fields, and those fields must be value types or strings.
    // Public classes must be sealed (NotInheritable in Visual Basic). If your programming model requires polymorphism, you can create a public interface and implement that interface on the classes that must be polymorphic.
    public sealed partial class Temperature
    {
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
        public Temperature Multiply(double factor, TemperatureUnit unit)
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
        /// <returns>The resulting <see cref="Temperature" />.</returns>
        public Temperature Divide(double divisor, TemperatureUnit unit)
        {
            double resultInUnit = As(unit) / divisor;
            return From(resultInUnit, unit);
        }
    }
}
