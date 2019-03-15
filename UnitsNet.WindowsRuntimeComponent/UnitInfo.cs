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
    internal class UnitInfo
    {
        public UnitInfo(Enum value)
        {
            Value = value;
            Name = value.ToString();
        }

        /// <summary>
        /// The enum value of the unit, such as [<see cref="LengthUnit.Centimeter" />,
        /// <see cref="LengthUnit.Decimeter" />, <see cref="LengthUnit.Meter" />, ...].
        /// </summary>
        public Enum Value;

        /// <summary>
        /// The name of the unit, such as ["Centimeter", "Decimeter", "Meter", ...].
        /// </summary>
        public string Name { get; }
    }
}
