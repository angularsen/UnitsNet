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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    /// This class helps enumerating quantities and units at runtime.
    /// </summary>
    /// <seealso cref="QuantityInfo" />
    public static class UnitsHelper
    {
        private static readonly string UnitEnumNamespace = typeof(LengthUnit).Namespace;

        private static readonly Type[] UnitEnumTypes = Assembly.GetAssembly(typeof(Length))
            .GetExportedTypes()
            .Where(t => t.IsEnum && t.Namespace == UnitEnumNamespace)
            .ToArray();

        static UnitsHelper()
        {
            var quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().ToArray();
            Quantities = quantityTypes;
            QuantityNames = Enum.GetNames(typeof(QuantityType));
        }

        /// <summary>
        /// All enum values of <see cref="QuantityType"/>, such as <see cref="QuantityType.Length"/> and <see cref="QuantityType.Mass"/>.
        /// </summary>
        public static QuantityType[] Quantities { get; }

        /// <summary>
        /// All enum value names of <see cref="QuantityType"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] QuantityNames { get; }

        /// <summary>
        /// Returns the enum values for the given <paramref name="quantity"/>, excluding the Undefined=0 value.
        /// You can then use this for dynamic parsing in <see cref="UnitParser.Parse"/>.
        /// If you only need the unit names, use <see cref="GetUnitNamesForQuantity"/> instead.
        /// </summary>
        /// <example>
        /// Given <see cref="QuantityType.Length"/> it will return all enum values of <see cref="LengthUnit"/>,
        /// such as <see cref="LengthUnit.Centimeter"/> and <see cref="LengthUnit.Meter"/>.
        /// </example>
        /// <param name="quantity">The quantity type.</param>
        /// <returns>Unit enum values.</returns>
        public static IEnumerable<object> GetUnitEnumValuesForQuantity(QuantityType quantity)
        {
            // QuantityType.Length => "UnitsNet.Units.LengthUnit"
            Type unitEnumType = GetUnitType(quantity);

            // Skip Undefined, which is only really used to help catch uninitialized values
            return Enum.GetValues(unitEnumType).Cast<object>().Skip(1).ToArray();
        }

        /// <summary>
        /// Returns the enum value names for the given <paramref name="quantity"/>.
        /// For example, given <see cref="QuantityType.Length"/> it will return the names
        /// of all enum values of <see cref="LengthUnit"/>, such as "Centimeter" and "Meter".
        /// </summary>
        /// <param name="quantity">The quantity type.</param>
        /// <returns>Unit enum values.</returns>
        public static IEnumerable<string> GetUnitNamesForQuantity(QuantityType quantity)
        {
            return GetUnitEnumValuesForQuantity(quantity).Select(unitEnumValue => unitEnumValue.ToString());
        }

        /// <summary>
        /// Returns the enum type for the given <paramref name="quantity"/>.
        /// </summary>
        /// <example>
        /// Given <see cref="QuantityType.Length"/> it will return <see cref="LengthUnit"/>.
        /// </example>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static Type GetUnitType(QuantityType quantity)
        {
            return UnitEnumTypes
                .First(t => t.FullName == $"{UnitEnumNamespace}.{quantity}Unit");
        }
    }
}
