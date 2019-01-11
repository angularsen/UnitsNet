using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitsNet.Samples.UnitConverter.Wpf
{
    /// <summary>
    ///     TODO Move me into the UnitsNet library. This will solve a pain point in generically enumerating units for a quantity.
    /// </summary>
    public static class UnitHelper
    {
        /// <summary>
        ///     Look up and cache all unit enum types once with reflection, such as LengthUnit and MassUnit.
        /// </summary>
        private static readonly Type[] UnitEnumTypes =
            Assembly.GetAssembly(typeof(Length)).ExportedTypes.Where(t => t.IsEnum && t.Namespace == "UnitsNet.Units").ToArray();

        public static IReadOnlyList<object> GetUnits(QuantityType quantity)
        {
            // Ex: Find unit enum type UnitsNet.Units.LengthUnit from quantity enum name QuantityType.Length
            Type unitEnumType = UnitEnumTypes.First(t => t.FullName == $"UnitsNet.Units.{quantity}Unit");
            return Enum.GetValues(unitEnumType).Cast<object>().Skip(1).ToArray();
        }
    }
}