// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Information about the unit, such as its name and value.
    ///     This is useful to enumerate units and present names with quantities and units
    ///     chosen dynamically at runtime, such as unit conversion apps or allowing the user to change the
    ///     unit representation.
    /// </summary>
    /// <remarks>
    ///     Typically you obtain this by looking it up via <see cref="QuantityInfo.UnitInfos" />.
    /// </remarks>
    public class UnitInfo
    {
        /// <summary>Creates an instance from a unit enum value.</summary>
        /// <param name="value">The unit enum value.</param>
        /// <example>new UnitInfo(LengthUnit.Meter)</example>
        public UnitInfo(Enum value)
        {
            Value = value;
            Name = value.ToString();
        }

        /// <summary>
        /// The enum value of the unit, such as [<see cref="LengthUnit.Centimeter" />,
        /// <see cref="LengthUnit.Decimeter" />, <see cref="LengthUnit.Meter" />, ...].
        /// </summary>
        public Enum Value { get; }

        /// <summary>
        /// The name of the unit, such as ["Centimeter", "Decimeter", "Meter", ...].
        /// </summary>
        public string Name { get; }
    }

    /// <inheritdoc cref="UnitInfo" />
    /// <remarks>
    ///     This is a specialization of <see cref="UnitInfo" />, for when the unit type is known.
    ///     Typically you obtain this by looking it up statically from <see cref="QuantityInfo{LengthUnit}.UnitInfos" /> or
    ///     or dynamically via <see cref="IQuantity{TUnitType}.QuantityInfo" />.
    /// </remarks>
    /// <typeparam name="TUnit">The unit enum type, such as <see cref="LengthUnit" />. </typeparam>
    public class UnitInfo<TUnit> : UnitInfo
        where TUnit : Enum
    {
        /// <inheritdoc />
        public UnitInfo(TUnit value) : base(value)
        {
            Value = value;
        }

        /// <inheritdoc cref="UnitInfo.Value"/>
        public new TUnit Value { get; }
    }
}
