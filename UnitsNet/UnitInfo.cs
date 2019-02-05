// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Information about the unit, such as its name and value.
    ///     This is useful to enumerate units and present names with quantities and units
    ///     chose dynamically at runtime, such as unit conversion apps or allowing the user to change the
    ///     unit representation.
    /// </summary>
    /// <remarks>
    ///     Typically you obtain this by looking it up via <see cref="QuantityInfo.UnitInfos" />.
    /// </remarks>
#if WINDOWS_UWP
    internal
#else
    public
#endif
    class UnitInfo
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

#if !WINDOWS_UWP
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
        public UnitInfo(TUnit value) : base(value)
        {
            Value = value;
        }

        public new TUnit Value { get; }
    }
#endif
}
