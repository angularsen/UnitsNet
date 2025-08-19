// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet;

/// <summary>
///     Represents a builder for creating instances of <see cref="QuantityInfo{TQuantity, TUnit}" />.
/// </summary>
/// <typeparam name="TQuantity">
///     The type of the quantity being built, which must implement <see cref="IQuantity{TQuantity, TUnit}" />.
/// </typeparam>
/// <typeparam name="TUnit">
///     The type of the unit associated with the quantity, which must be an enumeration.
/// </typeparam>
/// <remarks>
///     This class provides a mechanism to lazily construct a <see cref="QuantityInfo{TQuantity, TUnit}" /> instance
///     using a factory method. It is primarily used to configure and retrieve quantity metadata.
/// </remarks>
internal sealed class QuantityInfoBuilder<TQuantity, TUnit> : IQuantityInfoBuilder
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    private readonly Lazy<QuantityInfo<TQuantity, TUnit>> _quantityInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuantityInfoBuilder{TQuantity, TUnit}" /> class.
    /// </summary>
    /// <param name="factory">
    /// A factory method that lazily creates an instance of <see cref="QuantityInfo{TQuantity, TUnit}" />.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="factory" /> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This constructor allows for the deferred creation of a <see cref="QuantityInfo{TQuantity, TUnit}" /> instance,
    /// enabling efficient configuration and retrieval of quantity metadata.
    /// </remarks>
    public QuantityInfoBuilder(Func<QuantityInfo<TQuantity, TUnit>> factory)
    {
        _quantityInfo = new Lazy<QuantityInfo<TQuantity, TUnit>>(factory);
    }

    QuantityInfo IQuantityInfoBuilder.Build()
    {
        return Build();
    }

    /// <inheritdoc cref="IQuantityInfoBuilder.Build"/>
    public QuantityInfo<TQuantity, TUnit> Build()
    {
        return _quantityInfo.Value;
    }
}
