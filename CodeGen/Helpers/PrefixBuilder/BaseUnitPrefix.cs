// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using CodeGen.JsonTypes;

namespace CodeGen.Helpers.PrefixBuilder;

/// <summary>
///     Represents a unique key that combines a base unit and a prefix.
/// </summary>
/// <param name="BaseUnit">
///     The base unit associated with the prefix. For example, "Gram".
/// </param>
/// <param name="Prefix">
///     The prefix applied to the base unit. For example, <see cref="JsonTypes.Prefix.Kilo" />.
/// </param>
internal readonly record struct BaseUnitPrefix(string BaseUnit, Prefix Prefix);
