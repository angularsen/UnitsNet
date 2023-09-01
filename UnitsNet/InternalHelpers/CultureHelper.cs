// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Concurrent;
using System.Globalization;

namespace UnitsNet.InternalHelpers;

/// <summary>
///     Helper class for <see cref="CultureInfo"/> and related operations.
/// </summary>
internal static class CultureHelper
{
    private static readonly ConcurrentDictionary<string, CultureInfo> CultureCache = new();

    /// <summary>
    ///     Attempts to get the culture by name, with fallback to invariant culture if not found.<br/>
    ///     <br/>
    ///     This is particularly useful for Linux and Raspberry PI environments, where cultures may not always be installed.
    ///     To simulate the behavior, set environment variable DOTNET_SYSTEM_GLOBALIZATION_INVARIANT='1' when running the application.
    /// </summary>
    /// <param name="cultureName">The culture name.</param>
    /// <returns><see cref="CultureInfo.CurrentCulture"/> if given <c>null</c>, or the culture with the given name if the culture is available, otherwise <see cref="CultureInfo.InvariantCulture"/>.</returns>
    internal static CultureInfo GetCultureOrInvariant(string? cultureName)
    {
        if (cultureName is null) return CultureInfo.CurrentCulture;

        try
        {
            // Use cache to avoid exception and diagnostic log events every time.
            return CultureCache.GetOrAdd(cultureName, CultureInfo.GetCultureInfo);
        }
        catch (CultureNotFoundException)
        {
            Console.Error.WriteLine($"Failed to get culture '{cultureName}', falling back to invariant culture.");
            System.Diagnostics.Debug.WriteLine($"Failed to get culture '{cultureName}', falling back to invariant culture.");

            // Cache it, to avoid exception next time.
            CultureCache.TryAdd(cultureName, CultureInfo.InvariantCulture);

            return CultureInfo.InvariantCulture;
        }
    }
}
