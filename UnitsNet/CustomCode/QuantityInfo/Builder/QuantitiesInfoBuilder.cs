// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;

namespace UnitsNet;

/// <summary>
///     Represents a builder for configuring and creating custom quantity information.
/// </summary>
/// <remarks>
///     This class provides methods to configure specific quantities with custom configurations
///     and to create or retrieve quantity information based on the provided configurations.
///     It is primarily used internally to manage and customize quantity information.
/// </remarks>
internal sealed class QuantitiesInfoBuilder
{
    private readonly Dictionary<Type, IQuantityInfoBuilder> _quantityCustomizations = new();

    /// <summary>
    ///     Configures a custom quantity by associating it with a delegate that creates its custom configuration.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity to configure. Must implement
    ///     <see cref="IQuantity{TQuantity, TUnit}" />.
    /// </typeparam>
    /// <typeparam name="TUnit">The type of the unit associated with the quantity. Must be an enumeration.</typeparam>
    /// <param name="createCustomConfigurationDelegate">
    ///     A delegate that creates and returns a custom configuration for the specified quantity.
    /// </param>
    /// <returns>The current instance of <see cref="QuantitiesInfoBuilder" /> to allow method chaining.</returns>
    /// <remarks>
    ///     This method is used to define custom configurations for specific quantities, enabling fine-grained control
    ///     over their behavior and properties. The provided delegate is invoked to generate the configuration.
    /// </remarks>
    internal QuantitiesInfoBuilder ConfigureQuantity<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> createCustomConfigurationDelegate)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        _quantityCustomizations.Add(typeof(TQuantity), new QuantityInfoBuilder<TQuantity, TUnit>(createCustomConfigurationDelegate));
        return this;
    }

    /// <summary>
    ///     Creates a <see cref="QuantityInfo" /> instance based on the provided default configuration or returns the default
    ///     configuration
    ///     if no customizations are available for the specified quantity type.
    /// </summary>
    /// <param name="defaultConfiguration">
    ///     The default <see cref="QuantityInfo" /> configuration to use if no customizations are found.
    /// </param>
    /// <returns>
    ///     A <see cref="QuantityInfo" /> instance representing either the customized configuration or the provided default
    ///     configuration.
    /// </returns>
    /// <remarks>
    ///     This method checks if a custom configuration exists for the quantity type specified in the
    ///     <paramref name="defaultConfiguration" />.
    ///     If a customization is found, it builds and returns the customized <see cref="QuantityInfo" />.
    ///     Otherwise, it returns the provided <paramref name="defaultConfiguration" />.
    /// </remarks>
    public QuantityInfo CreateOrDefault(QuantityInfo defaultConfiguration)
    {
        return _quantityCustomizations.TryGetValue(defaultConfiguration.QuantityType, out IQuantityInfoBuilder? builder)
            ? builder.Build()
            : defaultConfiguration;
    }

    /// <summary>
    ///     Creates or retrieves a <see cref="QuantityInfo{TQuantity, TUnit}" /> instance based on the provided default
    ///     configuration
    ///     or any custom configuration previously defined for the specified quantity type.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity for which the <see cref="QuantityInfo{TQuantity, TUnit}" /> is being created or retrieved.
    /// </typeparam>
    /// <typeparam name="TUnit">
    ///     The type of the unit associated with the quantity. Must be an enumeration.
    /// </typeparam>
    /// <param name="defaultConfiguration">
    ///     A delegate that provides the default configuration for the <see cref="QuantityInfo{TQuantity, TUnit}" />
    ///     if no custom configuration is available.
    /// </param>
    /// <returns>
    ///     A <see cref="QuantityInfo{TQuantity, TUnit}" /> instance, either from a custom configuration if available,
    ///     or from the provided default configuration.
    /// </returns>
    /// <remarks>
    ///     This method checks if a custom configuration exists for the specified quantity type. If found, it uses the custom
    ///     configuration to create the <see cref="QuantityInfo{TQuantity, TUnit}" />. Otherwise, it falls back to the
    ///     <paramref name="defaultConfiguration" /> delegate to create the default configuration.
    /// </remarks>
    public QuantityInfo<TQuantity, TUnit> CreateOrDefault<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> defaultConfiguration)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (_quantityCustomizations.TryGetValue(typeof(TQuantity), out IQuantityInfoBuilder? builder) &&
            builder is QuantityInfoBuilder<TQuantity, TUnit> specificBuilder)
        {
            return specificBuilder.Build();
        }
        
        return defaultConfiguration();
    }
}
