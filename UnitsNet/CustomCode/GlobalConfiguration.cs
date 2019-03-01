// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Threading;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Global configuration for culture, used as default culture in methods like <see cref="Length.ToString()" /> and
    ///     <see cref="Length.Parse(string)" />.
    /// </summary>
    [Obsolete("The only property DefaultCulture is now deprecated. Manipulate Thread.CurrentThread.CurrentUICulture instead.")]
    public static class GlobalConfiguration
    {
        /// <summary>
        ///     Wrapper for <see cref="Thread.CurrentUICulture"/>.
        /// </summary>
        [Obsolete("Manipulate Thread.CurrentThread.CurrentUICulture instead, this property will be removed.")]
        public static IFormatProvider DefaultCulture
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set => Thread.CurrentThread.CurrentUICulture = (CultureInfo) value;
        }
    }
}
