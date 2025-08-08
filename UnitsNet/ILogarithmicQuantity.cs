// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

namespace UnitsNet;

/// <inheritdoc cref="ILogarithmicQuantity{TSelf}"/>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
public interface ILogarithmicQuantity<TSelf, TUnitType> : IQuantity<TSelf, TUnitType>, ILogarithmicQuantity<TSelf>
#if NET7_0_OR_GREATER
    , IAdditionOperators<TSelf, TSelf, TSelf>
    , ISubtractionOperators<TSelf, TSelf, TSelf>
    , IMultiplyOperators<TSelf, double, TSelf>
    , IDivisionOperators<TSelf, double, TSelf>
    , IUnaryNegationOperators<TSelf, TSelf>
#endif
    where TSelf : ILogarithmicQuantity<TSelf, TUnitType>
    where TUnitType : struct, Enum
{
}

/// <summary>
///     Represents a logarithmic quantity that supports arithmetic operations and implements generic math interfaces 
///     (in .NET 7+). This interface is designed for quantities that are logarithmic in nature, such as decibels.
/// </summary>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <remarks>
///     Logarithmic quantities are different from linear quantities in that they represent values on a logarithmic scale.
///     This interface extends <see cref="IQuantity{TSelf, TUnitType}" /> and provides additional functionality specific 
///     to logarithmic quantities, including arithmetic operations and a logarithmic scaling factor.
///     The logarithmic scale assumed here is base-10.
/// </remarks>
public interface ILogarithmicQuantity<TSelf> : IQuantityOfType<TSelf>
#if NET7_0_OR_GREATER
    , IMultiplicativeIdentity<TSelf, TSelf>
#endif
    where TSelf : ILogarithmicQuantity<TSelf>
{
#if NET7_0_OR_GREATER
    /// <summary>
    ///     Gets the logarithmic scaling factor used to convert between linear and logarithmic units.
    ///     This factor is typically 10, but there are exceptions such as the PowerRatio, which uses 20.
    /// </summary>
    /// <value>
    ///     The logarithmic scaling factor.
    /// </value>
    static abstract double LogarithmicScalingFactor { get; }

    /// <summary>
    ///     The zero value of this quantity.
    /// </summary>
    static abstract TSelf Zero { get; }

    static TSelf IMultiplicativeIdentity<TSelf, TSelf>.MultiplicativeIdentity => TSelf.Zero;
#else
        /// <summary>
        ///     Gets the logarithmic scaling factor used to convert between linear and logarithmic units.
        ///     This factor is typically 10, but there are exceptions such as the PowerRatio, which uses 20.
        /// </summary>
        /// <value>
        ///     The logarithmic scaling factor.
        /// </value>
        double LogarithmicScalingFactor { get; }
#endif
}
