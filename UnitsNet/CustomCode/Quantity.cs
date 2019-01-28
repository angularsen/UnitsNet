using System;
using System.Linq;
using System.Reflection;
using UnitsNet.InternalHelpers;

namespace UnitsNet
{
    public partial class Quantity
    {
        static Quantity()
        {
            var quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().Except(new[] {QuantityType.Undefined}).ToArray();
            Types = quantityTypes;
            Names = quantityTypes.Select(qt => qt.ToString()).ToArray();

            // A bunch of reflection to enumerate quantity types, instantiate with the default constructor and return its QuantityInfo property
            InfosLazy = new Lazy<QuantityInfo[]>(() => Assembly.GetAssembly(typeof(Length))
                .GetExportedTypes()
                .Where(typeof(IQuantity).IsAssignableFrom)
                .Where(t => t.IsClass() || t.IsValueType()) // Future-proofing: Considering changing quantities from struct to class
                .Select(Activator.CreateInstance)
                .Cast<IQuantity>()
                .Select(q => q.QuantityInfo)
                .OrderBy(q => q.Name)
                .ToArray());
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
        public static QuantityInfo[] Infos => InfosLazy.Value;

        private static readonly Lazy<QuantityInfo[]> InfosLazy;
    }
}
