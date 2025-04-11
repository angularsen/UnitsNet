// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet;

/// <summary>
///     Represents an exception that is thrown when a quantity is not found.
/// </summary>
/// <remarks>
///     This exception is typically encountered during dynamic conversions, such as when using
///     <see cref="UnitConverter.ConvertByName" /> to convert units by their names.
/// </remarks>
public class QuantityNotFoundException : UnitsNetException
{
    /// <inheritdoc />
    public QuantityNotFoundException()
    {
    }

    /// <inheritdoc />
    public QuantityNotFoundException(string message)
        : base(message)
    {
    }

    /// <inheritdoc />
    public QuantityNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
