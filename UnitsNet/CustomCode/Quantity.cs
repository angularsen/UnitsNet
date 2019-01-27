using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial class Quantity
    {
        private static readonly string UnitEnumNamespace = typeof(LengthUnit).Namespace;

        private static readonly Type[] UnitEnumTypes = Assembly.GetAssembly(typeof(Length))
            .GetExportedTypes()
            .Where(t => t.IsEnum && t.Namespace == UnitEnumNamespace && t.Name.EndsWith("Unit"))
            .ToArray();


        static Quantity()
        {
            var quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().ToArray();
            Types = quantityTypes;
            Names = Enum.GetNames(typeof(QuantityType));

            // A bunch of reflection to enumerate quantity types, instantiate with the default constructor and return its QuantityInfo property
            Infos = Assembly.GetAssembly(typeof(Length))
                .GetExportedTypes()
                .Where(typeof(IQuantity).IsAssignableFrom)
                .Where(t => t.IsClass() || t.IsValueType()) // Future-proofing: Considering changing quantities from struct to class
                .Select(Activator.CreateInstance)
                .Cast<IQuantity>()
                .Select(quantity => quantity.QuantityInfo)
                .ToArray();
        }

        /// <summary>
        /// All enum values of <see cref="QuantityType"/>, such as <see cref="QuantityType.Length"/> and <see cref="QuantityType.Mass"/>.
        /// </summary>
        public static QuantityType[] Types { get; }

        /// <summary>
        /// All enum value names of <see cref="QuantityType"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names { get; }

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static QuantityInfo[] Infos { get; }

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
        public static IEnumerable<Enum> GetUnitEnumValuesForQuantity(QuantityType quantity)
        {
            // QuantityType.Length => "UnitsNet.Units.LengthUnit"
            Type unitEnumType = GetUnitType(quantity);

            // Skip Undefined, which is only really used to help catch uninitialized values
            return Enum.GetValues(unitEnumType).Cast<Enum>().Skip(1).ToArray();
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
            return UnitEnumTypes.First(t => t.Name == $"{quantity}Unit");
        }
    }
}
