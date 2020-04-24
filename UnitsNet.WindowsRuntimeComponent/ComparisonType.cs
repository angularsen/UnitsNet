// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    /// <summary>
    /// Specifies if the comparison between numbers is absolute or relative.
    /// </summary>
    public enum ComparisonType
    {
        /// <summary>
        /// Error margin in relative size to a reference value.
        /// </summary>
        Relative,

        /// <summary>
        /// Error margin as absolute size.
        /// </summary>
        Absolute
    }
}
