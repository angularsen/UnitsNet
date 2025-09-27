// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet;

/// <summary>
///     Provides functionality to select and configure quantities for use within the UnitsNet library.
/// </summary>
/// <remarks>
///     This class allows for the selection of default quantities, addition of custom quantities, and configuration of
///     specific quantities.
///     It supports lazy loading of quantities and can be used to build a collection of quantity information dynamically at
///     runtime.
/// </remarks>
public sealed class QuantitiesSelector
{
    private readonly Func<IEnumerable<QuantityInfo>> _defaultQuantitiesSelection;
    private IEnumerable<QuantityInfo>? _additionalQuantities;
    private QuantitiesInfoBuilder? _quantitiesInfoBuilder;

    internal QuantitiesSelector(Func<IEnumerable<QuantityInfo>> defaultQuantitiesSelection)
    {
        _defaultQuantitiesSelection = defaultQuantitiesSelection;
    }

    // internal Lazy<IEnumerable<QuantityInfo>> QuantitiesSelected { get; }

    /// <summary>
    ///     Adds additional quantities to the current selection.
    /// </summary>
    /// <param name="quantities">The quantities to be added.</param>
    /// <returns>The current <see cref="QuantitiesSelector" /> instance with the additional quantities included.</returns>
    /// <remarks>
    ///     This method allows for the dynamic addition of custom quantities to the existing selection of quantities.
    /// </remarks>
    public QuantitiesSelector WithAdditionalQuantities(IEnumerable<QuantityInfo> quantities)
    {
        _additionalQuantities = _additionalQuantities?.Concat(quantities) ?? quantities;
        return this;
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
        _quantitiesInfoBuilder ??= new QuantitiesInfoBuilder();
        _quantitiesInfoBuilder.ConfigureQuantity(createCustomConfigurationDelegate);
        return this;
    }

    /// <summary>
    ///     Retrieves the selected collection of <see cref="QuantityInfo" /> objects based on the current configuration.
    /// </summary>
    /// <remarks>
    ///     This method combines the default quantities, any additional quantities, and applies custom configurations
    ///     if a <see cref="QuantitiesInfoBuilder" /> is provided.
    /// </remarks>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> of <see cref="QuantityInfo" /> representing the selected quantities.
    /// </returns>
    internal IEnumerable<QuantityInfo> GetQuantityInfos()
    {
        if (_quantitiesInfoBuilder is null && _additionalQuantities is null)
        {
            return _defaultQuantitiesSelection();
        }

        IEnumerable<QuantityInfo> enumeration = _defaultQuantitiesSelection();
        if (_additionalQuantities is not null)
        {
            enumeration = enumeration.Concat(_additionalQuantities);
        }

        if (_quantitiesInfoBuilder is not null)
        {
            enumeration = enumeration.Select(_quantitiesInfoBuilder.CreateOrDefault);
        }

        return enumeration;
        // return enumeration.ToList();
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
        return _quantitiesInfoBuilder is null ? defaultConfiguration() : _quantitiesInfoBuilder.CreateOrDefault(defaultConfiguration);
    }
}

// /// <summary>
// ///     Provides functionality to select and configure quantities for use within the UnitsNet library.
// /// </summary>
// /// <remarks>
// ///     This class allows for the selection of default quantities, addition of custom quantities, and configuration of
// ///     specific quantities.
// ///     It supports lazy loading of quantities and can be used to build a collection of quantity information dynamically at
// ///     runtime.
// /// </remarks>
// public sealed class QuantitiesSelector
// {
//     private readonly Func<IReadOnlyCollection<QuantityInfo>> _defaultQuantitiesSelection;
//     private IEnumerable<QuantityInfo>? _additionalQuantities;
//     private QuantitiesInfoBuilder? _quantitiesInfoBuilder;
//
//     internal QuantitiesSelector(Func<IReadOnlyCollection<QuantityInfo>> defaultQuantitiesSelection)
//     {
//         _defaultQuantitiesSelection = defaultQuantitiesSelection;
//         QuantitiesSelected = new Lazy<IReadOnlyCollection<QuantityInfo>>(BuildSelection);
//     }
//
//     internal Lazy<IReadOnlyCollection<QuantityInfo>> QuantitiesSelected { get; }
//
//     /// <summary>
//     ///     Adds additional quantities to the current selection.
//     /// </summary>
//     /// <param name="quantities">The quantities to be added.</param>
//     /// <returns>The current <see cref="QuantitiesSelector" /> instance with the additional quantities included.</returns>
//     /// <remarks>
//     ///     This method allows for the dynamic addition of custom quantities to the existing selection of quantities.
//     /// </remarks>
//     public QuantitiesSelector WithAdditionalQuantities(IEnumerable<QuantityInfo> quantities)
//     {
//         _additionalQuantities = _additionalQuantities?.Concat(quantities) ?? quantities;
//         return this;
//     }
//
//     /// <summary>
//     ///     Configures a specific quantity with a custom configuration.
//     /// </summary>
//     /// <typeparam name="TQuantity">The type of the quantity to configure.</typeparam>
//     /// <typeparam name="TUnit">The type of the unit associated with the quantity.</typeparam>
//     /// <param name="createCustomConfigurationDelegate">
//     ///     A delegate that creates a custom configuration for the specified quantity.
//     /// </param>
//     /// <returns>The current instance of <see cref="QuantitiesSelector" /> to allow for method chaining.</returns>
//     /// <remarks>
//     ///     This method allows for the customization of a specific quantity by providing a delegate that creates
//     ///     a custom configuration. It initializes the <see cref="QuantitiesInfoBuilder" /> if it is not already initialized
//     ///     and uses it to configure the quantity.
//     /// </remarks>
//     public QuantitiesSelector Configure<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> createCustomConfigurationDelegate)
//         where TQuantity : IQuantity<TQuantity, TUnit>
//         where TUnit : struct, Enum
//     {
//         _quantitiesInfoBuilder ??= new QuantitiesInfoBuilder();
//         _quantitiesInfoBuilder.ConfigureQuantity(createCustomConfigurationDelegate);
//         return this;
//     }
//
//     private IReadOnlyCollection<QuantityInfo> BuildSelection()
//     {
//         if (_quantitiesInfoBuilder is null && _additionalQuantities is null)
//         {
//             return _defaultQuantitiesSelection();
//         }
//
//         IEnumerable<QuantityInfo> enumeration = _defaultQuantitiesSelection();
//         if (_additionalQuantities is not null)
//         {
//             enumeration = enumeration.Concat(_additionalQuantities);
//         }
//
//         if (_quantitiesInfoBuilder is not null)
//         {
//             enumeration = enumeration.Select(_quantitiesInfoBuilder.CreateOrDefault);
//         }
//
//         return enumeration.ToList();
//     }
//
//     /// <summary>
//     ///     Creates a quantity information instance using the provided default configuration or a custom configuration
//     ///     if available.
//     /// </summary>
//     /// <typeparam name="TQuantity">
//     ///     The type of the quantity, which must implement <see cref="IQuantity{TSelf, TUnitType}" />.
//     /// </typeparam>
//     /// <typeparam name="TUnit">
//     ///     The type of the unit, which must be a struct and an enumeration.
//     /// </typeparam>
//     /// <param name="defaultConfiguration">
//     ///     A delegate that provides the default configuration for creating the <see cref="QuantityInfo{TQuantity, TUnit}" />.
//     /// </param>
//     /// <returns>
//     ///     An instance of <see cref="QuantityInfo{TQuantity, TUnit}" /> created using either the default configuration
//     ///     or a custom configuration if available.
//     /// </returns>
//     /// <remarks>
//     ///     This method checks if a custom configuration is available through the <see cref="QuantitiesInfoBuilder" />.
//     ///     If no custom configuration is available, it falls back to the provided default configuration.
//     /// </remarks>
//     /// <exception cref="ArgumentNullException">
//     ///     Thrown if the <paramref name="defaultConfiguration" /> is <c>null</c>.
//     /// </exception>
//     internal QuantityInfo<TQuantity, TUnit> CreateOrDefault<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> defaultConfiguration)
//         where TQuantity : IQuantity<TQuantity, TUnit>
//         where TUnit : struct, Enum
//     {
//         return _quantitiesInfoBuilder is null ? defaultConfiguration() : _quantitiesInfoBuilder.CreateOrDefault(defaultConfiguration);
//     }
// }
