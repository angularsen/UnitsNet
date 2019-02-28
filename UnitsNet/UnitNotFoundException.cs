// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    /// <summary>
    ///     Unit was not found. This is typically thrown for dynamic conversions,
    ///     such as <see cref="UnitConverter.ConvertByName" />.
    /// </summary>
    public class UnitNotFoundException : UnitsNetException
    {
        /// <inheritdoc />
        public UnitNotFoundException()
        {
        }

        /// <inheritdoc />
        public UnitNotFoundException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public UnitNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
