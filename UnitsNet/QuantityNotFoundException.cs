// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    /// <summary>
    ///     Quantity type was not found. This is typically thrown for dynamic conversions,
    ///     such as <see cref="UnitConverter.ConvertByName" />.
    /// </summary>
    [Obsolete("")]
    public class QuantityNotFoundException : UnitsNetException
    {
        /// <inheritdoc />
        public QuantityNotFoundException()
        {
        }

        /// <inheritdoc />
        public QuantityNotFoundException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public QuantityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
