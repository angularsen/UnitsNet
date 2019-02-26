// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Global configuration for culture, used as default culture in methods like <see cref="Length.ToString()" /> and
    ///     <see cref="Length.Parse(string)" />.
    /// </summary>
    public static class GlobalConfiguration
    {
        /// <summary>
        ///     Defaults to <see cref="CultureInfo.CurrentUICulture" /> when creating an instance with no culture provided.
        ///     Can be overridden, but note that this is static and will affect all subsequent usages.
        /// </summary>
        public static IFormatProvider DefaultCulture { get; set; } = CultureInfo.CurrentUICulture;
    }
}
