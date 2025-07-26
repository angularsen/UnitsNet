// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;

namespace UnitsNet;

/// <summary>
///     Provides options for building a <see cref="UnitConverter" /> instance.
/// </summary>
/// <remarks>
///     This class allows configuring various settings related to unit conversion, such as caching modes,
///     constant reduction, and custom caching options for specific quantity types.
/// </remarks>
public sealed class QuantityConverterBuildOptions
{
    private readonly Dictionary<Type, ConversionCacheOptions> _customQuantityOptions = [];

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityConverterBuildOptions" /> class.
    /// </summary>
    /// <param name="freeze">Indicates whether the build options should be frozen, preventing further modifications.</param>
    /// <param name="defaultCachingMode">Specifies the default caching mode for unit conversions.</param>
    /// <param name="reduceConstants">Indicates whether constant reduction should be applied during unit conversions.</param>
    public QuantityConverterBuildOptions(bool freeze = false, ConversionCachingMode defaultCachingMode = ConversionCachingMode.None,
        bool reduceConstants = true)
    {
        Freeze = freeze;
        DefaultCachingMode = defaultCachingMode;
        ReduceConstants = reduceConstants;
    }

    /// <summary>
    ///     Gets a value indicating whether the quantity converter is frozen, preventing any further modifications.
    /// </summary>
    public bool Freeze { get; private set; }

    /// <summary>
    ///     Gets the default caching mode for unit conversions.
    /// </summary>
    /// <value>
    ///     The default caching mode, which determines how unit conversions are cached.
    /// </value>
    public ConversionCachingMode DefaultCachingMode { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether constant values should be reduced during unit conversions.
    /// </summary>
    /// <remarks>
    ///     When set to <c>true</c>, constant values in unit conversions are reduced to their simplest form.
    ///     This can help improve performance and reduce memory usage.
    /// </remarks>
    public bool ReduceConstants { get; private set; }

    internal IReadOnlyDictionary<Type, ConversionCacheOptions> CustomQuantityOptions
    {
        get => _customQuantityOptions;
    }

    internal QuantityConversionOptions? QuantityConversionOptions { get; private set; }

#if OPTIONS_ACCEPTED
// TODO add tests for  these
    /// <summary>
    ///     Enables or disables dynamic caching for unit conversions.
    /// </summary>
    /// <param name="dynamicCachingEnabled">If set to <c>true</c>, dynamic caching is enabled; otherwise, it is disabled.</param>
    /// <returns>
    ///     The current <see cref="QuantityConverterBuildOptions" /> instance with the updated dynamic
    ///     caching setting.
    /// </returns>
    public QuantityConverterBuildOptions WithDynamicCachingEnabled(bool dynamicCachingEnabled = true)
    {
        Freeze = !dynamicCachingEnabled;
        return this;
    }

    /// <summary>
    ///     Sets the default caching mode for unit conversions.
    /// </summary>
    /// <param name="defaultCachingMode">The default caching mode to be used for unit conversions.</param>
    /// <returns>
    ///     The current <see cref="QuantityConverterBuildOptions" /> instance with the updated default
    ///     caching mode.
    /// </returns>
    public QuantityConverterBuildOptions WithDefaultCachingMode(ConversionCachingMode defaultCachingMode)
    {
        DefaultCachingMode = defaultCachingMode;
        return this;
    }

    /// <summary>
    ///     Enables or disables the reduction of constants during unit conversions.
    /// </summary>
    /// <param name="reduceConstants">
    ///     If set to <c>true</c>, constants will be reduced during conversions; otherwise, they will
    ///     not be reduced.
    /// </param>
    /// <returns>
    ///     The current <see cref="QuantityConverterBuildOptions" /> instance with the updated constant
    ///     reduction setting.
    /// </returns>
    public QuantityConverterBuildOptions WithConstantsReduction(bool reduceConstants = true)
    {
        ReduceConstants = reduceConstants;
        return this;
    }
#endif

    /// <summary>
    ///     Configures custom caching options for a specific quantity type.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity for which to set custom caching options.</typeparam>
    /// <param name="quantityCacheOptions">The caching options to be applied to the specified quantity type.</param>
    /// <returns>
    ///     The current <see cref="QuantityConverterBuildOptions" /> instance with the updated custom
    ///     caching options.
    /// </returns>
    public QuantityConverterBuildOptions WithCustomCachingOptions<TQuantity>(ConversionCacheOptions quantityCacheOptions)
        where TQuantity : IQuantity
    {
        _customQuantityOptions.Add(typeof(TQuantity), quantityCacheOptions);
        return this;
    }

    /// <summary>
    ///     Configures the implicit conversion options for the <see cref="QuantityConverterBuildOptions" /> instance.
    /// </summary>
    /// <param name="quantityConversionOptions">
    ///     The <see cref="QuantityConversionOptions" /> instance that specifies the implicit conversion settings.
    /// </param>
    /// <returns>
    ///     The current <see cref="QuantityConverterBuildOptions" /> instance with the updated implicit conversion options.
    /// </returns>
    /// <remarks>
    ///     This method allows setting custom implicit conversion rules and units to be used during quantity conversions.
    /// </remarks>
    public QuantityConverterBuildOptions WithImplicitConversionOptions(QuantityConversionOptions quantityConversionOptions)
    {
        QuantityConversionOptions = quantityConversionOptions;
        return this;
    }

    /// <summary>
    ///     Configures implicit conversion options for the <see cref="QuantityConverterBuildOptions" />.
    /// </summary>
    /// <param name="implicitConversions">
    ///     An action to configure the <see cref="QuantityConversionOptions" />.
    /// </param>
    /// <returns>
    ///     The current instance of <see cref="QuantityConverterBuildOptions" /> with the updated implicit conversion options.
    /// </returns>
    /// <remarks>
    ///     This method allows you to specify custom implicit conversions between different quantities and units.
    ///     It initializes the <see cref="QuantityConversionOptions" /> if it is not already set and applies the provided
    ///     configuration action to it.
    /// </remarks>
    public QuantityConverterBuildOptions WithImplicitConversionOptions(Action<QuantityConversionOptions> implicitConversions)
    {
        QuantityConversionOptions ??= new QuantityConversionOptions();
        implicitConversions(QuantityConversionOptions);
        return this;
    }
}
