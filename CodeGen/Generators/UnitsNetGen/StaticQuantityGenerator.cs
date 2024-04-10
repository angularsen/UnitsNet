using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class StaticQuantityGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public StaticQuantityGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System;
using System.Globalization;
using UnitsNet.Units;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable enable

namespace UnitsNet
{
    /// <summary>
    ///     Dynamically parse or construct quantities when types are only known at runtime.
    /// </summary>
    public partial class Quantity
    {
        /// <summary>
        /// All QuantityInfo instances mapped by quantity name that are present in UnitsNet by default.
        /// </summary>
        public static readonly IDictionary<string, QuantityInfo> ByName = new Dictionary<string, QuantityInfo>
        {");
            foreach (var quantity in _quantities)
                Writer.WL($@"
            {{ ""{quantity.Name}"", {quantity.Name}.Info }},");
            Writer.WL(@"
        };

        /// <summary>
        /// Dynamically constructs a quantity of the given <see cref=""QuantityInfo""/> with the value in the quantity's base units.
        /// </summary>
        /// <param name=""quantityInfo"">The <see cref=""QuantityInfo""/> of the quantity to create.</param>
        /// <param name=""value"">The value to construct the quantity with.</param>
        /// <returns>The created quantity.</returns>
        public static IQuantity FromQuantityInfo(QuantityInfo quantityInfo, QuantityValue value)
        {
            return quantityInfo.Name switch
            {");
            foreach (var quantity in _quantities)
            {
                var quantityName = quantity.Name;
                Writer.WL($@"
                ""{quantityName}"" => {quantityName}.From(value, {quantityName}.BaseUnit),");
            }

            Writer.WL(@"
                _ => throw new ArgumentException($""{quantityInfo.Name} is not a supported quantity."")
            };
        }

        /// <summary>
        ///     Try to dynamically construct a quantity.
        /// </summary>
        /// <param name=""value"">Numeric value.</param>
        /// <param name=""unit"">Unit enum value.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns><c>True</c> if successful with <paramref name=""quantity""/> assigned the value, otherwise <c>false</c>.</returns>
        public static bool TryFrom(QuantityValue value, Enum? unit, [NotNullWhen(true)] out IQuantity? quantity)
        {
            quantity = unit switch
            {");
            foreach (var quantity in _quantities)
            {
                var quantityName = quantity.Name;
                var unitTypeName = $"{quantityName}Unit";
                var unitValue = unitTypeName.ToCamelCase();
                Writer.WL($@"
                {unitTypeName} {unitValue} => {quantityName}.From(value, {unitValue}),");
            }

            Writer.WL(@"
                _ => null
            };

            return quantity is not null;
        }

        /// <summary>
        ///     Try to dynamically parse a quantity string representation.
        /// </summary>
        /// <param name=""formatProvider"">The format provider to use for lookup. Defaults to <see cref=""CultureInfo.CurrentCulture"" /> if null.</param>
        /// <param name=""quantityType"">Type of quantity, such as <see cref=""Length""/>.</param>
        /// <param name=""quantityString"">Quantity string representation, such as ""1.5 kg"". Must be compatible with given quantity type.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns>The parsed quantity.</returns>
        public static bool TryParse(IFormatProvider? formatProvider, Type quantityType, string quantityString, [NotNullWhen(true)] out IQuantity? quantity)
        {
            quantity = default(IQuantity);

            if (!typeof(IQuantity).IsAssignableFrom(quantityType))
                return false;

            var parser = QuantityParser.Default;

            return quantityType switch
            {");
            foreach (var quantity in _quantities)
            {
                var quantityName = quantity.Name;
                Writer.WL($@"
                Type _ when quantityType == typeof({quantityName}) => parser.TryParse<{quantityName}, {quantityName}Unit>(quantityString, formatProvider, {quantityName}.From, out quantity),");
            }

            Writer.WL(@"
                _ => false
            };
        }

        internal static IEnumerable<Type> GetQuantityTypes()
        {");
            foreach (var quantity in _quantities)
                Writer.WL($@"
            yield return typeof({quantity.Name});");
            Writer.WL(@"
        }
    }
}");
            return Writer.ToString();
        }
    }
}
