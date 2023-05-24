// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace UnitsNet
{
    public partial class Quantity
    {
        private static readonly Lazy<Dictionary<(Type, string), UnitInfo>> UnitTypeAndNameToUnitInfoLazy;

        static Quantity()
        {
            // Automatically load quantity types from UnitsNet libraries. Custom quantity types must be explicitly loaded.
            // Example full name: "UnitsNet, Version=5.0.0.0, Culture=neutral, PublicKeyToken=f8601875a1f041da"
            // Example full name: "UnitsNet.Modular.Length, Version=5.0.0.0, Culture=neutral, PublicKeyToken=f8601875a1f041da"
            var unitsNetAssemblyRegex = new Regex(@"^UnitsNet(\.[^,]+)?\,");
            var quantityTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Where(ass => ass.FullName != null && unitsNetAssemblyRegex.IsMatch(ass.FullName))
                .SelectMany(ass => ass.DefinedTypes.Where(t => typeof(IQuantity).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract))
                .ToList();

            QuantityTypes = quantityTypes.AsReadOnly();

            List<QuantityInfo> quantityInfos = quantityTypes
                .Select(t => t.GetProperty("Info", BindingFlags.Public|BindingFlags.Static)?.GetMethod?.Invoke(null, null) as QuantityInfo)
                .Where(info => info != null)
                .Select(info => info!)
                .ToList();

            Names = quantityInfos.Select(qt => qt.Name).ToArray();
            EnumToQuantityInfo = new ReadOnlyDictionary<Type, QuantityInfo>(quantityInfos.ToDictionary(qt => qt.UnitType, qt => qt));

            Infos = quantityInfos
                .OrderBy(quantityInfo => quantityInfo.Name)
                .ToArray();

            UnitTypeAndNameToUnitInfoLazy = new Lazy<Dictionary<(Type, string), UnitInfo>>(() =>
            {
                return Infos
                    .SelectMany(quantityInfo => quantityInfo.UnitInfos
                        .Select(unitInfo => new KeyValuePair<(Type, string), UnitInfo>(
                            (unitInfo.Value.GetType(), unitInfo.Name),
                            unitInfo)))
                    .ToDictionary(x => x.Key, x => x.Value);
            });
        }

        /// <summary>
        /// Map unit enum type to its corresponding QuantityInfo, such as LengthUnit -> Length.Info.
        /// </summary>
        public static ReadOnlyDictionary<Type,QuantityInfo> EnumToQuantityInfo { get; }

        /// <summary>
        /// All quantity types found in loaded assemblies that implement <see cref="IQuantity"/>.
        /// </summary>
        public static ReadOnlyCollection<TypeInfo> QuantityTypes { get; }

        /// <summary>
        /// All enum value names of <see cref="Infos"/>, such as "Length" and "Mass".
        /// </summary>
        public static string[] Names { get; }

        /// <summary>
        /// All quantity information objects, such as <see cref="Length.Info"/> and <see cref="Mass.Info"/>.
        /// </summary>
        public static IReadOnlyList<QuantityInfo> Infos { get; }

        /// <summary>
        /// Get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static UnitInfo GetUnitInfo(Enum unitEnum) => UnitTypeAndNameToUnitInfoLazy.Value[(unitEnum.GetType(), unitEnum.ToString())];

        /// <summary>
        /// Try to get <see cref="UnitInfo"/> for a given unit enum value.
        /// </summary>
        public static bool TryGetUnitInfo(Enum unitEnum, [NotNullWhen(true)] out UnitInfo? unitInfo) =>
            UnitTypeAndNameToUnitInfoLazy.Value.TryGetValue((unitEnum.GetType(), unitEnum.ToString()), out unitInfo);

        /// <summary>
        ///     Dynamically construct a quantity.
        /// </summary>
        /// <param name="value">Numeric value.</param>
        /// <param name="unit">Unit enum value.</param>
        /// <returns>An <see cref="IQuantity"/> object.</returns>
        /// <exception cref="ArgumentException">Unit value is not a know unit enum type.</exception>
        public static IQuantity From(QuantityValue value, Enum unit)
        {
            if (!EnumToQuantityInfo.TryGetValue(unit.GetType(), out QuantityInfo? quantityInfo))
            {
                throw new ArgumentException($"Unit enum type '{unit.GetType()}' is not a known unit enum type. Make sure to expose a static QuantityInfo getter-property named 'Info' on the quantity class and to configure this unit enum type there.", nameof(unit));
            }

            return quantityInfo.CreateQuantity(value, unit);
        }

        /// <inheritdoc cref="TryFrom(QuantityValue,System.Enum,out UnitsNet.IQuantity)"/>
        public static bool TryFrom(double value, Enum unit, [NotNullWhen(true)] out IQuantity? quantity)
        {
            // Implicit cast to QuantityValue would prevent TryFrom from being called,
            // so we need to explicitly check this here for double arguments.
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                quantity = default(IQuantity);
                return false;
            }

            return TryFrom((QuantityValue)value, unit, out quantity);
        }

        /// <inheritdoc cref="TryFrom(QuantityValue,System.Enum,out UnitsNet.IQuantity)"/>
        public static bool TryFrom(QuantityValue value, Enum unit, [NotNullWhen(true)] out IQuantity? quantity)
        {
            if (!EnumToQuantityInfo.TryGetValue(unit.GetType(), out QuantityInfo? quantityInfo))
            {
                quantity = null;
                return false;
            }

            quantity = quantityInfo.CreateQuantity(value, unit);
            return true;
        }

        /// <inheritdoc cref="Parse(IFormatProvider, System.Type,string)"/>
        public static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="quantityType">Type of quantity, such as <see cref="Length"/>.</param>
        /// <param name="quantityString">Quantity string representation, such as "1.5 kg". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref="ArgumentException">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        public static IQuantity Parse(IFormatProvider? formatProvider, Type quantityType, string quantityString)
        {
            if (!typeof(IQuantity).IsAssignableFrom(quantityType))
                throw new ArgumentException($"Type {quantityType} must be of type UnitsNet.IQuantity.");

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity? quantity)) return quantity;

            throw new ArgumentException($"Quantity string could not be parsed to quantity {quantityType}.");
        }

        private static bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity)
        {
            quantity = null;

            if (!typeof(IQuantity).IsAssignableFrom(quantityType)) return false;

            // TODO Create dictionary to optimize lookup.
            if (Infos.FirstOrDefault(i => i.ValueType == quantityType) is not { } qi) return false;

            return qi.TryParse(formatProvider, quantityString, out quantity);
        }

        /// <inheritdoc cref="TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)"/>
        public static bool TryParse(Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity) =>
            TryParse(null, quantityType, quantityString, out quantity);

        /// <summary>
        ///     Get a list of quantities that has the given base dimensions.
        /// </summary>
        /// <param name="baseDimensions">The base dimensions to match.</param>
        public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(BaseDimensions baseDimensions)
        {
            return Infos.Where(info => info.BaseDimensions.Equals(baseDimensions));
        }
    }
}
