// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

/// <summary>
///     Provides options for configuring the caching behavior of unit conversions in the <see cref="UnitConverter" />.
/// </summary>
public sealed record ConversionCacheOptions
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ConversionCacheOptions" /> class.
    /// </summary>
    /// <param name="cachingMode">
    ///     The caching mode to be used for unit conversions. Default is
    ///     <see cref="ConversionCachingMode.All" />.
    /// </param>
    /// <param name="reduceConstants">Indicates whether to reduce constants during conversions. Default is <c>true</c>.</param>
    public ConversionCacheOptions(ConversionCachingMode cachingMode = ConversionCachingMode.All, bool reduceConstants = true)
    {
        CachingMode = cachingMode;
        ReduceConstants = reduceConstants;
    }

    /// <summary>
    ///     Gets the caching mode for unit conversions with this quantity.
    /// </summary>
    /// <value>
    ///     The caching mode determines how unit conversions are cached.
    /// </value>
    public ConversionCachingMode CachingMode { get; }

    /// <summary>
    ///     Gets a value indicating whether constant values should be reduced when initializing the unit conversions.
    /// </summary>
    /// <remarks>
    ///     When set to <c>true</c>, constant values in unit conversions are reduced to their simplest form.
    ///     This can help improve performance and reduce memory usage.
    /// </remarks>
    public bool ReduceConstants { get; }
}
