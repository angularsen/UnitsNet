// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Core;

namespace UnitsNet.Modular;

/// <summary>
/// A generated Modular quantity that exposes its canonical immutable runtime description.
/// </summary>
/// <remarks>
/// The quantity type owns value operations such as construction and conversion. <see cref="Info" />
/// reifies descriptive metadata so the same object can be used through both strongly typed code and
/// the generated discovery registry. Quantity instances do not carry a metadata property.
/// </remarks>
/// <typeparam name="TSelf">The generated quantity type.</typeparam>
/// <typeparam name="TUnit">The generated unit enum type.</typeparam>
public interface IModularQuantity<TSelf, TUnit> : IQuantity<TSelf, TUnit, double>
    where TSelf : struct, IModularQuantity<TSelf, TUnit>, IParsable<TSelf>
    where TUnit : struct, Enum
{
    /// <summary>Gets the canonical immutable description of this generated quantity type.</summary>
    static abstract QuantityInfo<TSelf, TUnit> Info { get; }
}
