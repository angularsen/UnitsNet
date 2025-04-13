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

    /// <summary>
    ///     Gets the conversion expression used to convert from the base unit to this unit.
    /// </summary>
    /// <value>
    ///     The conversion expression, represented as a <see cref="ConversionExpression" />.
    /// </value>
    /// <remarks>
    ///     The conversion expression is defined as an equation of the form:
    ///     <code>
    /// f(x) = a * g(x)^n + b
    /// </code>
    ///     where:
    ///     <list type="bullet">
    ///         <item>
    ///             <description><c>a</c> and <c>b</c> are constants of type <see cref="QuantityValue" />.</description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <c>g(x)</c> is an optional custom function applied to the input <c>x</c> (of type
    ///                 <see cref="QuantityValue" />).
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description><c>n</c> is an integer exponent.</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    ConversionExpression ConversionFromBase { get; }

    /// <summary>
    ///     Gets the conversion expression used to convert a unit to its base unit.
    /// </summary>
    /// <remarks>
    ///     The conversion is defined as a function of the form:
    ///     <code>
    /// f(x) = a * g(x)^n + b
    /// </code>
    ///     where:
    ///     <list type="bullet">
    ///         <item>
    ///             <description><c>a</c> and <c>b</c> are constants of type <see cref="QuantityValue" />.</description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <c>g(x)</c> is an optional custom function applied to the input <c>x</c> (of type
    ///                 <see cref="QuantityValue" />).
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description><c>n</c> is an integer exponent.</description>
    ///         </item>
    ///     </list>
    /// </remarks>
    ConversionExpression ConversionToBase { get; }
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
