// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

/// <summary>
///     Represents a builder interface for constructing instances of <see cref="QuantityInfo" />.
/// </summary>
/// <remarks>
///     This interface defines a contract for creating <see cref="QuantityInfo" /> objects, allowing for customization
///     and configuration of quantity metadata. It is primarily used in scenarios where quantity information needs to
///     be dynamically constructed or overridden.
/// </remarks>
internal interface IQuantityInfoBuilder
{
    /// <summary>
    ///     Builds and returns an instance of <see cref="QuantityInfo" />.
    /// </summary>
    /// <returns>
    ///     A constructed <see cref="QuantityInfo" /> instance containing metadata about a specific quantity.
    /// </returns>
    /// <remarks>
    ///     This method is used to finalize the construction of a <see cref="QuantityInfo" /> object,
    ///     encapsulating all configured properties and metadata. It is typically invoked after setting up
    ///     the desired configuration for a quantity.
    /// </remarks>
    QuantityInfo Build();
}
