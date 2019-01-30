using System;
using System.Linq;
using System.Reflection;
using UnitsNet.InternalHelpers;

#if WINDOWS_UWP
using Culture = System.String;
using FromValue = System.Double;
#else
using Culture = System.IFormatProvider;
using FromValue = UnitsNet.QuantityValue;
#endif

namespace UnitsNet
{
#if WINDOWS_UWP
        internal
#else
        public
#endif
    partial class Quantity
    {
        private static readonly Lazy<QuantityInfo[]> InfosLazy;

        static Quantity()
        {
            var quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().Except(new[] {QuantityType.Undefined}).ToArray();
            Types = quantityTypes;
            Names = quantityTypes.Select(qt => qt.ToString()).ToArray();

#if !WINDOWS_UWP
            // A bunch of reflection to enumerate quantity types, instantiate with the default constructor and return its QuantityInfo property
            InfosLazy = new Lazy<QuantityInfo[]>(() => typeof(Length)
                .Wrap()
                .Assembly
                .GetExportedTypes()
                .Where(typeof(IQuantity).IsAssignableFrom)
                .Where(t => t.Wrap().IsClass || t.Wrap().IsValueType) // Future-proofing: Considering changing quantities from struct to class
                .Select(Activator.CreateInstance)
                .Cast<IQuantity>()
                .Select(q => q.QuantityInfo)
                .OrderBy(q => q.Name)
                .ToArray());
#endif
        }

        /// <summary>
        /// All enum values of <see cref="QuantityType"/>, such as <see cref="QuantityType.Length"/> and <see cref="QuantityType.Mass"/>.
        /// </summary>
        public static QuantityType[] Types { get; }

        /// <summary>
        /// All enum value names of <see cref="QuantityType"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names { get; }

#if !WINDOWS_UWP
        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static QuantityInfo[] Infos => InfosLazy.Value;
#endif

        /// <summary>
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
#if WINDOWS_UWP
        internal static IQuantity From(FromValue value, Enum unit)
#else
        public static IQuantity From(FromValue value, Enum unit)
#endif
        {
            if (TryFrom(value, unit, out IQuantity quantity))
                return quantity;

            throw new ArgumentException(
                $"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
        }
    }
}
