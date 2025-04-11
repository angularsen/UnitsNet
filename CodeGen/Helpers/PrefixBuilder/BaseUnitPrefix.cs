// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using CodeGen.JsonTypes;

namespace CodeGen.Helpers.PrefixBuilder;

/// <summary>
///     Represents a unique combination of a base unit and an optional prefix, used to identify a prefixed unit.
/// </summary>
/// <param name="BaseUnit">
///     The base unit associated with the prefix, such as "Gram".
/// </param>
/// <param name="Prefix">
///     The prefix applied to the base unit, such as <see cref="JsonTypes.Prefix.Kilo" />.
///     <para>If the prefix exponent value is 0, this parameter will be <c>null</c>.</para>
/// </param>
internal readonly record struct BaseUnitPrefix(string BaseUnit, Prefix? Prefix);
