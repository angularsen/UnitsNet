// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
    // Lazy<T> synchronizes value creation; this lock also makes the builder swap and creation checks atomic with it.
    private static readonly object DefaultConfigurationLock = new();
    private static DefaultConfigurationBuilder _defaultConfigurationBuilder = new();
    private static readonly Lazy<UnitsNetSetup> DefaultConfiguration = new(BuildDefault);

    /// <summary>
    ///     Builds a UnitsNet setup by selecting built-in or external quantity definitions.
    /// </summary>
    public sealed class DefaultConfigurationBuilder
    {
        private QuantitiesSelector? _quantitiesSelector;

        /// <summary>
        ///     Uses the specified quantities as the setup's base catalog.
        /// </summary>
        /// <param name="quantities">The quantity definitions to use.</param>
        /// <returns>This builder, for method chaining.</returns>
        public DefaultConfigurationBuilder WithQuantities(IEnumerable<QuantityInfo> quantities)
        {
            if (quantities is null) throw new ArgumentNullException(nameof(quantities));
            return WithQuantities(() => quantities);
        }

        /// <summary>
        ///     Uses quantities returned by <paramref name="quantities" /> as the setup's base catalog.
        /// </summary>
        /// <param name="quantities">Provides the quantity definitions to use.</param>
        /// <returns>This builder, for method chaining.</returns>
        public DefaultConfigurationBuilder WithQuantities(Func<IEnumerable<QuantityInfo>> quantities)
        {
            if (quantities is null) throw new ArgumentNullException(nameof(quantities));
            if (_quantitiesSelector is not null) throw new InvalidOperationException("The base quantity selection is already configured.");

            _quantitiesSelector = new QuantitiesSelector(quantities);
            return this;
        }

        /// <summary>
        ///     Uses the specified quantities as the setup's base catalog and configures that selection.
        /// </summary>
        /// <param name="quantities">The quantity definitions to use.</param>
        /// <param name="configureQuantities">Configures the selected quantities.</param>
        /// <returns>This builder, for method chaining.</returns>
        public DefaultConfigurationBuilder WithQuantities(IEnumerable<QuantityInfo> quantities, Action<QuantitiesSelector> configureQuantities)
        {
            if (quantities is null) throw new ArgumentNullException(nameof(quantities));
            return WithQuantities(() => quantities, configureQuantities);
        }

        /// <summary>
        ///     Uses quantities returned by <paramref name="quantities" /> as the setup's base catalog and configures that selection.
        /// </summary>
        /// <param name="quantities">Provides the quantity definitions to use.</param>
        /// <param name="configureQuantities">Configures the selected quantities.</param>
        /// <returns>This builder, for method chaining.</returns>
        public DefaultConfigurationBuilder WithQuantities(Func<IEnumerable<QuantityInfo>> quantities, Action<QuantitiesSelector> configureQuantities)
        {
            if (configureQuantities is null) throw new ArgumentNullException(nameof(configureQuantities));

            WithQuantities(quantities);
            configureQuantities(_quantitiesSelector!);
            return this;
        }

        /// <summary>
        ///     Appends external quantity definitions to the current selection.
        /// </summary>
        /// <param name="quantities">The quantity definitions to append.</param>
        /// <returns>This builder, for method chaining.</returns>
        public DefaultConfigurationBuilder WithAdditionalQuantities(IEnumerable<QuantityInfo> quantities)
        {
            _quantitiesSelector ??= new QuantitiesSelector(() => Quantity.DefaultProvider.Quantities);
            _quantitiesSelector.WithAdditionalQuantities(quantities);
            return this;
        }

        internal UnitsNetSetup Build()
        {
            IEnumerable<QuantityInfo> quantities = _quantitiesSelector?.GetQuantityInfos() ?? Quantity.DefaultProvider.Quantities;
            return new UnitsNetSetup(quantities, UnitConverter.CreateDefault());
        }
    }

    private static UnitsNetSetup BuildDefault()
    {
        lock (DefaultConfigurationLock)
        {
            return _defaultConfigurationBuilder.Build();
        }
    }

    /// <summary>
    ///     Creates an isolated setup without changing <see cref="Default" />.
    /// </summary>
    /// <param name="configuration">Configures the quantities included in the setup.</param>
    /// <returns>A configured UnitsNet setup.</returns>
    public static UnitsNetSetup Create(Action<DefaultConfigurationBuilder> configuration)
    {
        if (configuration is null) throw new ArgumentNullException(nameof(configuration));

        var builder = new DefaultConfigurationBuilder();
        configuration(builder);
        return builder.Build();
    }

    /// <summary>
    ///     Configures and creates the global default setup before its first use.
    /// </summary>
    /// <param name="configuration">Configures the quantities included in the default setup.</param>
    /// <returns>The configured global default setup.</returns>
    /// <exception cref="InvalidOperationException">The default setup has already been created.</exception>
    /// <seealso cref="Default" />
    public static UnitsNetSetup ConfigureDefaults(Action<DefaultConfigurationBuilder> configuration)
    {
        if (configuration is null) throw new ArgumentNullException(nameof(configuration));

        lock (DefaultConfigurationLock)
        {
            if (DefaultConfiguration.IsValueCreated)
            {
                throw new InvalidOperationException("The default configuration cannot be changed after it has been created.");
            }

            var builder = new DefaultConfigurationBuilder();
            configuration(builder);

            if (DefaultConfiguration.IsValueCreated)
            {
                throw new InvalidOperationException("The default configuration was created while it was being configured.");
            }

            _defaultConfigurationBuilder = builder;
            return DefaultConfiguration.Value;
        }
    }

    /// <summary>
    ///     Create a new UnitsNet setup with the given quantities, their units and unit conversion functions between units.
    /// </summary>
    /// <param name="quantityInfos">The quantities and their units to support for unit conversions, Parse() and ToString().</param>
    /// <param name="unitConverter">The unit converter instance.</param>
    public UnitsNetSetup(IEnumerable<QuantityInfo> quantityInfos, UnitConverter unitConverter)
    {
        var quantityInfoLookup = new QuantityInfoLookup(quantityInfos);
        var unitAbbreviations = new UnitAbbreviationsCache(quantityInfoLookup);

        UnitConverter = unitConverter;
        UnitAbbreviations = unitAbbreviations;
        Formatter = new QuantityFormatter(unitAbbreviations);
        UnitParser = new UnitParser(unitAbbreviations);
        QuantityParser = new QuantityParser(unitAbbreviations);
        Quantities = quantityInfoLookup;
    }

    /// <summary>
    ///     The global default UnitsNet setup of quantities, units, unit abbreviations and conversion functions.
    ///     This setup is used by default in static Parse and ToString methods of quantities unless a setup instance is
    ///     provided.
    /// </summary>
    /// <remarks>
    ///     Call <see cref="ConfigureDefaults" /> before first accessing this property to select a different quantity catalog.<br />
    ///     <br />
    ///     Manipulating this instance, such as adding new units or changing default unit abbreviations, will affect most
    ///     usages of UnitsNet in the
    ///     current AppDomain since the typical use is via static members and not providing a setup instance.
    /// </remarks>
    /// <seealso cref="ConfigureDefaults" />
    public static UnitsNetSetup Default => DefaultConfiguration.Value;

    /// <summary>
    ///     Converts between units of a quantity, such as from meters to centimeters of a given length.
    /// </summary>
    public UnitConverter UnitConverter { get; }

    /// <summary>
    ///     Maps unit enums to unit abbreviation strings for one or more cultures, used by ToString() and Parse() methods of
    ///     quantities.
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
    public QuantityInfoLookup Quantities { get; }
}
