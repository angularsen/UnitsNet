using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;

namespace UnitsNet
{
    public partial class Quantity
    {
        /// <summary>
        /// A dictionary of info structs for each known type.
        /// </summary>
        public static Dictionary<string, KnownQuantityInfo> KnownQuantities => new Dictionary<string, KnownQuantityInfo>();

        /// <summary>
        /// A class capturing the details of a known type.
        /// </summary>
        public class KnownQuantityInfo
        {
            /// <summary>
            /// The quantity type of the known type.
            /// </summary>
            public Type QuantityType { get; set; }
            /// <summary>
            /// The type for the enumeration of valid units.
            /// </summary>
            public Type UnitEnumType { get; set; }
        }

        /// <summary>
        ///     Adds a type defined in an external assembly for serialisation
        /// </summary>
        /// <param name="quantityType">The quantity type.</param>
        /// <param name="unitEnumType">The unit enum matching the quantity type.</param>
        public static void AddUnit(Type quantityType, Type unitEnumType)
        {
            if ($"{quantityType.Name}Unit" != unitEnumType.Name)
            {
                var ex = new UnitsNetException("Quantity type and unit enum type names don't match.");
                ex.Data["type"] = quantityType.Name;
                throw ex;
            }
            KnownQuantities.Add(quantityType.Name, new KnownQuantityInfo() {QuantityType = quantityType, UnitEnumType = unitEnumType});
        }

        private static readonly Lazy<QuantityInfo[]> InfosLazy;

        private static readonly MethodInfo GenericTryParse = typeof(QuantityParser)
            .GetMethods().First((method)=>(method.Name=="TryParse") && method.GetParameters()[3].ParameterType == typeof(IQuantity));

        static Quantity()
        {
            _quantityTypes = Enum.GetValues(typeof(QuantityType)).Cast<QuantityType>().Except(new[] {QuantityType.Undefined}).ToList();

            InfosLazy = new Lazy<QuantityInfo[]>(() => Types
                .Select(quantityType => FromQuantityType(quantityType, 0.0).QuantityInfo)
                .OrderBy(quantityInfo => quantityInfo.Name)
                .ToArray());
        }

        private static readonly List<QuantityType> _quantityTypes;

        /// <summary>
        /// All enum values of <see cref="QuantityType"/>, such as <see cref="QuantityType.Length"/> and <see cref="QuantityType.Mass"/>.
        /// </summary>
        public static QuantityType[] Types => _quantityTypes.ToArray();

        /// <summary>
        /// All enum value names of <see cref="QuantityType"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names => _quantityTypes.Select(qt => qt.ToString()).Concat(KnownQuantities.Keys).ToArray();

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static QuantityInfo[] Infos => InfosLazy.Value;

        /// <summary>
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public static IQuantity From(QuantityValue value, Enum unit)
        {
            if (TryFrom(value, unit, out IQuantity quantity))
                return quantity;

            throw new ArgumentException(
                $"Unit value {unit} of type {unit.GetType()} is not a known unit enum type. Expected types like UnitsNet.Units.LengthUnit. Did you pass in a third-party enum type defined outside UnitsNet library?");
        }

        /// <inheritdoc cref="TryFrom(QuantityValue,System.Enum,out UnitsNet.IQuantity)"/>
        public static bool TryFrom(double value, Enum unit, out IQuantity quantity)
        {
            // Implicit cast to QuantityValue would prevent TryFrom from being called,
            // so we need to explicitly check this here for double arguments.
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                quantity = default(IQuantity);
                return false;
            }

            if (KnownQuantities.ContainsKey(unit.GetType().Name))
            {
                quantity = (IQuantity)Activator.CreateInstance(KnownQuantities[unit.GetType().Name].QuantityType, BindingFlags.CreateInstance, null, value, unit);
                return quantity != null;
            }

            return TryFrom((QuantityValue)value, unit, out quantity);
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        public static IQuantity Parse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
            {
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");
            }

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity quantity))
                return quantity;

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType}.");
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, out IQuantity quantity)
        {
            if (KnownQuantities.ContainsKey(quantityType.Name))
            {
                var typeDetails = KnownQuantities[quantityType.Name];
                quantity = default(IQuantity);

                if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                    return false;

                var parser = QuantityParser.Default;

                var fromMethod = quantityType.GetMethod("From");
                var unitEnumType = typeDetails.UnitEnumType;
                var tryParseMethod = GenericTryParse.MakeGenericMethod(quantityType, unitEnumType);
                var parameters = new object[] {quantityString, null, fromMethod, null};
                var success = (bool)tryParseMethod.Invoke(parser,parameters);
                if (success)
                {
                    quantity = (IQuantity) parameters[3];
                }

                return success;
            }
            else
                return TryParse(null, quantityType, quantityString, out quantity);
        }


        /// <summary>
        ///     Get information about the given quantity type.
        /// </summary>
        /// <param name="quantityType">The quantity type enum value.</param>
        /// <returns>Information about the quantity and its units.</returns>
        public static QuantityInfo GetInfo(QuantityType quantityType)
        {
            return Infos.First(qi => qi.QuantityType == quantityType);
        }

        /// <summary>
        ///     Get a list of quantities that has the given base dimensions.
        /// </summary>
        /// <param name="baseDimensions">The base dimensions to match.</param>
        public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(BaseDimensions baseDimensions)
        {
            return InfosLazy.Value.Where(info => info.BaseDimensions.Equals(baseDimensions));
        }
    }
}
