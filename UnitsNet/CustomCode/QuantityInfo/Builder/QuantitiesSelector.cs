// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Linq;

namespace UnitsNet;

/// <summary>
///     Selects the quantities used to construct an isolated UnitsNet component or setup.
/// </summary>
public sealed class QuantitiesSelector
{
    private readonly Func<IEnumerable<QuantityInfo>> _defaultQuantities;
    private IEnumerable<QuantityInfo>? _additionalQuantities;
    private QuantitiesInfoBuilder? _quantitiesInfoBuilder;

    internal QuantitiesSelector(Func<IEnumerable<QuantityInfo>> defaultQuantities)
    {
        _defaultQuantities = defaultQuantities ?? throw new ArgumentNullException(nameof(defaultQuantities));
    }

    /// <summary>
    ///     Appends external quantity definitions to the current selection.
    /// </summary>
    /// <param name="quantities">The quantity definitions to append.</param>
    /// <returns>This selector, for method chaining.</returns>
    public QuantitiesSelector WithAdditionalQuantities(IEnumerable<QuantityInfo> quantities)
    {
        if (quantities is null) throw new ArgumentNullException(nameof(quantities));

        _additionalQuantities = _additionalQuantities?.Concat(quantities) ?? quantities;
        return this;
    }

    internal IEnumerable<QuantityInfo> GetQuantityInfos()
    {
        IEnumerable<QuantityInfo> quantities = _defaultQuantities();
        if (_additionalQuantities is not null)
        {
            quantities = quantities.Concat(_additionalQuantities);
        }

        if (_quantitiesInfoBuilder is not null)
        {
            quantities = quantities.Select(_quantitiesInfoBuilder.CreateOrDefault);
        }

        return quantities;
    }

    /// <summary>
    ///     Configures a specific quantity with a custom configuration.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity to configure.</typeparam>
    /// <typeparam name="TUnit">The type of the unit associated with the quantity.</typeparam>
    /// <param name="createCustomConfigurationDelegate">
    ///     A delegate that creates a custom configuration for the specified quantity.
    /// </param>
    /// <returns>The current instance of <see cref="QuantitiesSelector" /> to allow for method chaining.</returns>
    /// <remarks>
    ///     This method allows for the customization of a specific quantity by providing a delegate that creates
    ///     a custom configuration. It initializes the <see cref="QuantitiesInfoBuilder" /> if it is not already initialized
    ///     and uses it to configure the quantity.
    /// </remarks>
    public QuantitiesSelector Configure<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> createCustomConfigurationDelegate)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (createCustomConfigurationDelegate is null) throw new ArgumentNullException(nameof(createCustomConfigurationDelegate));

        _quantitiesInfoBuilder ??= new QuantitiesInfoBuilder();
        _quantitiesInfoBuilder.ConfigureQuantity(createCustomConfigurationDelegate);
        return this;
    }

    /// <summary>
    ///     Creates a quantity information instance using the provided default configuration or a custom configuration
    ///     if available.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity, which must implement <see cref="IQuantity{TSelf, TUnitType}" />.
    /// </typeparam>
    /// <typeparam name="TUnit">
    ///     The type of the unit, which must be a struct and an enumeration.
    /// </typeparam>
    /// <param name="defaultConfiguration">
    ///     A delegate that provides the default configuration for creating the <see cref="QuantityInfo{TQuantity, TUnit}" />.
    /// </param>
    /// <returns>
    ///     An instance of <see cref="QuantityInfo{TQuantity, TUnit}" /> created using either the default configuration
    ///     or a custom configuration if available.
    /// </returns>
    /// <remarks>
    ///     This method checks if a custom configuration is available through the <see cref="QuantitiesInfoBuilder" />.
    ///     If no custom configuration is available, it falls back to the provided default configuration.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if the <paramref name="defaultConfiguration" /> is <c>null</c>.
    /// </exception>
    internal QuantityInfo<TQuantity, TUnit> CreateOrDefault<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> defaultConfiguration)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (defaultConfiguration is null) throw new ArgumentNullException(nameof(defaultConfiguration));

        return _quantitiesInfoBuilder is null ? defaultConfiguration() : _quantitiesInfoBuilder.CreateOrDefault(defaultConfiguration);
    }
}
