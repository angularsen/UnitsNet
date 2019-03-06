// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public sealed class GlobalConfiguration
    {
        /// <summary>
        ///     Defaults to <see cref="CultureInfo.CurrentUICulture" /> when creating an instance with no culture provided.
        ///     Can be overridden, but note that this is static and will affect all subsequent usages.
        /// </summary>
        // Windows Runtime Component does not support exposing the IFormatProvider type in public API
        internal static IFormatProvider DefaultCulture { get; set; } = CultureInfo.CurrentUICulture;
    }
}
