// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet;

/// <summary>
///     Defines the configuration for mapping units, including their name, plural name, base units,
///     and conversion expressions to and from the base units.
/// </summary>
public interface IUnitDefinition
{
    /// <summary>
    ///     The singular name of the unit, such as "Centimeter".
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     The plural name of the unit, such as "Centimeters".
    /// </summary>
    string PluralName { get; }

    /// <summary>
    ///     Gets the <see cref="BaseUnits" /> for this unit.
    /// </summary>
    BaseUnits BaseUnits { get; }
}

/// <summary>
///     Defines the configuration for mapping units, including their value, name, plural name, and base units.
/// </summary>
/// <typeparam name="TUnit">The type of the unit enumeration.</typeparam>
public interface IUnitDefinition<out TUnit> : IUnitDefinition
    where TUnit : struct, Enum
{
    /// <summary>
    ///     The enum value of the unit, such as <see cref="LengthUnit.Centimeter" />.
    /// </summary>
    TUnit Value { get; }
}
