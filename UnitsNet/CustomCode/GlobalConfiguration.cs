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
    [Obsolete("The only property DefaultCulture is now deprecated. Manipulate CultureInfo.CurrentUICulture instead.")]
    public sealed class GlobalConfiguration
    {
        /// <summary>
        ///     Defaults to <see cref="CultureInfo.CurrentUICulture" /> when creating an instance with no culture provided.
        ///     Can be overridden, but note that this is static and will affect all subsequent usages.
        /// </summary>
        [Obsolete("Manipulate CultureInfo.CurrentUICulture instead, this property will be removed.")]
        public static IFormatProvider DefaultCulture { get; set; } = CultureInfo.CurrentUICulture;
    }
}
