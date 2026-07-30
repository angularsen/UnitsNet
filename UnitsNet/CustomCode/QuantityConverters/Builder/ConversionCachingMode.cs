// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

/// <summary>
///     Specifies the caching modes available for unit conversions in the <see cref="UnitConverter" />.
/// </summary>
/// <summary>
///     No caching is applied.
/// </summary>
/// <summary>
///     Only base unit conversions are cached.
/// </summary>
/// <summary>
///     All unit conversions are cached.
/// </summary>
public enum ConversionCachingMode
{
    /// <summary>
    ///     No caching is applied.
    /// </summary>
    None,

    /// <summary>
    ///     Only base unit conversions are cached.
    /// </summary>
    BaseOnly,

    /// <summary>
    ///     All unit conversions are cached.
    /// </summary>
    All
}
