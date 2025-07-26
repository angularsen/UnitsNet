// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using UnitsNet.Units;

namespace UnitsNet;

/// <summary>
///     UnitsNet setup of quantities, units, unit abbreviations and conversion functions.<br />
///     <br />
///     For normal use, <see cref="Default" /> is used and can be manipulated to add new units or change default unit
///     abbreviations.<br />
///     Alternatively, a setup instance may be provided for most static methods, such as
///     <see cref="Quantity.Parse(System.Type,string)" /> and
///     <see cref="QuantityFormatter.Format{TQuantity}(TQuantity,string?,IFormatProvider?)" />.
/// </summary>
public sealed class UnitsNetSetup
{
    private static readonly DefaultConfigurationBuilder ConfigurationBuilder = new();
    internal static readonly Lazy<UnitsNetSetup> DefaultConfiguration = new(ConfigurationBuilder.Build);
    
    /// <summary>
    ///     Builder for configuring the default setup of UnitsNet, including quantities, units, unit abbreviations, and
    ///     conversion functions.<br />
    ///     <br />
    ///     This builder allows for customization of the default configuration by specifying which quantities to use,
    ///     adding additional quantities, and enabling or disabling the quantity converter feature.<br />
    ///     <br />
    ///     Once the configuration is built, it cannot be changed.
    /// </summary>
    public sealed class DefaultConfigurationBuilder
    {
        private QuantitiesSelector? _quantitiesSelector;

        private QuantityConverterBuildOptions _quantityConverterOptions = new();
        
        // TODO see about allowing eager loading
        // private AbbreviationsCachingMode AbbreviationsCaching { get; set; } = AbbreviationsCachingMode.Lazy;
        // TODO see about caching the regex associated with the UnitParser
        // private UnitsCachingMode UnitParserCaching { get; set; } = UnitsCachingMode.Lazy;
        

        /// <summary>
        ///     Specifies the quantities to be used in the default configuration.
        /// </summary>
        /// <param name="quantities">A collection of quantities to use.</param>
        /// <returns>The current instance of <see cref="DefaultConfigurationBuilder" /> for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list of quantities to use is already specified.</exception>
        public DefaultConfigurationBuilder WithQuantities(IEnumerable<QuantityInfo> quantities)
        {
            return WithQuantities(() => quantities);
        }

        /// <summary>
        ///     Specifies the quantities to be used in the default configuration.
        /// </summary>
        /// <param name="quantities">A function that returns a collection of quantities to use.</param>
        /// <returns>The current instance of <see cref="UnitsNet.UnitsNetSetup.DefaultConfigurationBuilder" /> for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list of quantities to use is already specified.</exception>
        public DefaultConfigurationBuilder WithQuantities(Func<IEnumerable<QuantityInfo>> quantities)
        {
            if (_quantitiesSelector != null)
            {
                throw new InvalidOperationException("The list of quantities to use is already specified");
            }

            _quantitiesSelector = new QuantitiesSelector(quantities);
            return this;
        }

        /// <summary>
        ///     Specifies the quantities to be used in the default configuration and allows further configuration of these
        ///     quantities.
        /// </summary>
        /// <param name="quantities">A collection of quantities to use.</param>
        /// <param name="configureQuantities">An action to configure the selected quantities.</param>
        /// <returns>The current instance of <see cref="UnitsNet.UnitsNetSetup.DefaultConfigurationBuilder" /> for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list of quantities to use is already specified.</exception>
        public DefaultConfigurationBuilder WithQuantities(IEnumerable<QuantityInfo> quantities, Action<QuantitiesSelector> configureQuantities)
        {
            return WithQuantities(() => quantities, configureQuantities);
        }

        /// <summary>
        ///     Specifies the quantities to be used in the default configuration and allows further configuration of these
        ///     quantities.
        /// </summary>
        /// <param name="quantities">A collection of quantities to use.</param>
        /// <param name="configureQuantities">An action to configure the selected quantities.</param>
        /// <returns>The current instance of <see cref="UnitsNet.UnitsNetSetup.DefaultConfigurationBuilder" /> for method chaining.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the list of quantities to use is already specified.</exception>
        public DefaultConfigurationBuilder WithQuantities(Func<IEnumerable<QuantityInfo>> quantities, Action<QuantitiesSelector> configureQuantities)
        {
            if (_quantitiesSelector != null)
            {
                throw new InvalidOperationException("The list of quantities to use is already specified");
            }

            _quantitiesSelector = new QuantitiesSelector(quantities);
            configureQuantities(_quantitiesSelector);
            return this;
        }

        /// <summary>
        ///     Appends the list of default quantities with a custom set of definitions.
        ///     Adds additional quantities to the default configuration. These quantities are not part of the library by default
        ///     and are appended to the default list of quantities.
        /// </summary>
        /// <param name="quantities">The quantities to add to the default configuration.</param>
        /// <returns>
        ///     The <see cref="UnitsNet.UnitsNetSetup.DefaultConfigurationBuilder" /> instance with the additional quantities
        ///     added.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Thrown if the list of quantities to use is already specified.</exception>
        public DefaultConfigurationBuilder WithAdditionalQuantities(IEnumerable<QuantityInfo> quantities)
        {
            _quantitiesSelector ??= new QuantitiesSelector(() => Quantity.DefaultProvider.Quantities);
            _quantitiesSelector.WithAdditionalQuantities(quantities);
            return this;
        }

        /// <summary>
        ///     Appends the list of default quantities with a custom set of definitions.
        ///     Adds additional quantities to the default configuration. These quantities are not part of the library by default
        ///     and are appended to the default list of quantities.
        /// </summary>
        /// <param name="quantities">The quantities to add to the default configuration.</param>
        /// <param name="configureQuantities">An action to configure the selected quantities.</param>
        /// <returns>
        ///     The <see cref="UnitsNet.UnitsNetSetup.DefaultConfigurationBuilder" /> instance with the additional quantities
        ///     added.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Thrown if the list of quantities to use is already specified.</exception>
        public DefaultConfigurationBuilder WithAdditionalQuantities(IEnumerable<QuantityInfo> quantities, Action<QuantitiesSelector> configureQuantities)
        {
            _quantitiesSelector ??= new QuantitiesSelector(() => Quantity.DefaultProvider.Quantities);
            configureQuantities(_quantitiesSelector.WithAdditionalQuantities(quantities));
            return this;
        }
        
        /// <summary>
        ///     Configures a custom quantity for the default configuration.
        /// </summary>
        /// <typeparam name="TQuantity">The type of the quantity to configure.</typeparam>
        /// <typeparam name="TUnit">The type of the unit associated with the quantity, which must be an enumeration.</typeparam>
        /// <param name="createCustomConfigurationDelegate">
        ///     A delegate that creates a custom configuration for the quantity.
        /// </param>
        /// <returns>The current instance of <see cref="UnitsNet.UnitsNetSetup.DefaultConfigurationBuilder" /> for method chaining.</returns>
        public DefaultConfigurationBuilder ConfigureQuantity<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> createCustomConfigurationDelegate)
            where TQuantity : IQuantity<TQuantity, TUnit>
            where TUnit : struct, Enum
        {
            _quantitiesSelector ??= new QuantitiesSelector(() => Quantity.DefaultProvider.Quantities);
            _quantitiesSelector.Configure(createCustomConfigurationDelegate);
            return this;
        }

        /// <summary>
        ///     Configures the quantity converter options for the UnitsNet setup.
        /// </summary>
        /// <param name="converterBuildOptions">
        ///     The options to use for building the quantity converter, including settings for caching,
        ///     constants reduction, and custom quantity options.
        /// </param>
        /// <returns>
        ///     The <see cref="UnitsNetSetup.DefaultConfigurationBuilder" /> instance for chaining further configuration.
        /// </returns>
        public DefaultConfigurationBuilder WithConverterOptions(QuantityConverterBuildOptions converterBuildOptions)
        {
            _quantityConverterOptions = converterBuildOptions;
            return this;
        }

        internal QuantityInfo<TQuantity, TUnit> CreateQuantityInfoOrDefault<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> defaultConfiguration)
            where TQuantity : IQuantity<TQuantity, TUnit>
            where TUnit : struct, Enum
        {
            return _quantitiesSelector is null ? defaultConfiguration() : _quantitiesSelector.CreateOrDefault(defaultConfiguration);
        }
        
        internal UnitsNetSetup Build()
        {
            QuantityInfoLookup quantitiesLookup = _quantitiesSelector is null
                ? new QuantityInfoLookup(Quantity.DefaultProvider.Quantities)
                : QuantityInfoLookup.Create(_quantitiesSelector);
            
            var unitAbbreviations = new UnitAbbreviationsCache(quantitiesLookup);
            var formatter = new QuantityFormatter(unitAbbreviations);
            var unitParser = new UnitParser(unitAbbreviations);
            var quantityParser = new QuantityParser(unitParser);
            var unitConverter = UnitConverter.Create(unitParser, _quantityConverterOptions);
            return new UnitsNetSetup(quantitiesLookup, unitAbbreviations, formatter, unitParser, quantityParser, unitConverter);
        }
    }

    /// <summary>
    ///     Initializes the default (static) quantity information, such as <see cref="Length.Info" />.
    ///     This method is only called by the static initializer of the generated quantities.
    ///     It allows for optional customizations to the default configuration.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity.</typeparam>
    /// <typeparam name="TUnit">The type of the unit, which must be a struct and an enumeration.</typeparam>
    /// <param name="defaultConfiguration">A function that returns the default configuration for the quantity info.</param>
    /// <returns>A <see cref="QuantityInfo{TQuantity, TUnit}" /> instance configured with the provided default configuration.</returns>
    /// <remarks>
    ///     By using this method, any customizations to the default unit definitions are taken into account by the unit
    ///     converter, parser, formatter, the debug proxy, etc.
    /// </remarks>
    internal static QuantityInfo<TQuantity, TUnit> CreateQuantityInfo<TQuantity, TUnit>(Func<QuantityInfo<TQuantity, TUnit>> defaultConfiguration)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        return ConfigurationBuilder.CreateQuantityInfoOrDefault(defaultConfiguration);
    }

    /// <summary>
    ///     Configures the default setup of UnitsNet, including quantities, units, unit abbreviations, and conversion functions.<br />
    ///     <br />
    ///     This method returns a <see cref="DefaultConfigurationBuilder"/> that allows for customization of the default configuration
    ///     by specifying which quantities to use, adding additional quantities, and enabling or disabling the quantity converter feature.<br />
    ///     <br />
    ///     Note that once the default configuration is built, it cannot be changed.
    /// </summary>
    /// <returns>
    ///     A <see cref="DefaultConfigurationBuilder"/> instance for configuring the default setup.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if the default configuration has already been built.
    /// </exception>
    public static UnitsNetSetup ConfigureDefaults(Action<DefaultConfigurationBuilder> configuration)
    {
        if (DefaultConfiguration.IsValueCreated)
        {
            throw new InvalidOperationException("You cannot change the default configuration once it is build.");
        }

        configuration(ConfigurationBuilder);
        
        if (DefaultConfiguration.IsValueCreated)
        {
            throw new InvalidOperationException("You cannot change the default configuration once it is build.");
        }
        
        return DefaultConfiguration.Value;
    }

    /// <summary>
    ///     Creates a new instance of <see cref="UnitsNetSetup" />, independent of the <see cref="Default" /> configuration.
    /// </summary>
    /// <param name="configuration">
    ///     An action that configures the <see cref="DefaultConfigurationBuilder" /> to set up quantities, units, unit
    ///     abbreviations,
    ///     and conversion functions.
    /// </param>
    /// <returns>
    ///     A configured instance of <see cref="UnitsNetSetup" />.
    /// </returns>
    /// <remarks>
    ///     This method allows for customization of the UnitsNet setup by specifying which quantities to use, adding additional
    ///     quantities, and enabling or disabling the quantity converter feature.
    /// </remarks>
    public static UnitsNetSetup Create(Action<DefaultConfigurationBuilder> configuration)
    {
        var builder = new DefaultConfigurationBuilder();

        configuration(builder);

        return builder.Build();
    }
    
    private UnitsNetSetup(QuantityInfoLookup quantitiesLookup, UnitAbbreviationsCache unitAbbreviations, QuantityFormatter formatter, UnitParser unitParser,
        QuantityParser quantityParser, UnitConverter unitConverter)
    {
        QuantityInfoLookup = quantitiesLookup ?? throw new ArgumentNullException(nameof(quantitiesLookup));
        UnitAbbreviations = unitAbbreviations ?? throw new ArgumentNullException(nameof(unitAbbreviations));
        Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        UnitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
        QuantityParser = quantityParser ?? throw new ArgumentNullException(nameof(quantityParser));
        UnitConverter = unitConverter ?? throw new ArgumentNullException(nameof(unitConverter));
    }

    /// <summary>
    ///     The global default UnitsNet setup of quantities, units, unit abbreviations and conversion functions.
    ///     This setup is used by default in static Parse and ToString methods of quantities unless a setup instance is
    ///     provided.
    /// </summary>
    /// <remarks>
    ///     Manipulating this instance, such as adding new units or changing default unit abbreviations, will affect most
    ///     usages of UnitsNet in the
    ///     current AppDomain since the typical use is via static members and not providing a setup instance.
    /// </remarks>
    public static UnitsNetSetup Default => DefaultConfiguration.Value;

    /// <summary>
    ///     Converts between units of a quantity, such as from meters to centimeters of a given length.
    /// </summary>
    public UnitConverter UnitConverter { get; }

    /// <summary>
    ///     Maps unit enums to unit abbreviation strings for one or more cultures, used by the <see cref="UnitParser"/>, <see cref="QuantityParser"/> and the <see cref="Formatter"/>.
    /// </summary>
    public UnitAbbreviationsCache UnitAbbreviations { get; }
    
    /// <summary>
    ///     Converts a quantity to string using the specified format strings and culture-specific format providers.
    /// </summary>
    public QuantityFormatter Formatter { get; }

    /// <summary>
    ///     Parses units from strings, such as <see cref="LengthUnit.Centimeter" /> from "cm".
    /// </summary>
    public UnitParser UnitParser { get; }

    /// <summary>
    ///     Parses quantities from strings, such as parsing <see cref="Mass" /> from "1.2 kg".
    /// </summary>
    public QuantityParser QuantityParser { get; }

    /// <summary>
    ///     The quantities and units that are loaded.
    /// </summary>
    /// <remarks>
    ///     Access type is <c>internal</c> until this class is matured and ready for external use.
    /// </remarks>
    public QuantityInfoLookup QuantityInfoLookup { get; }
}
