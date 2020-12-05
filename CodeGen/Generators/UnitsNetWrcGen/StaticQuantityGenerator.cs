using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetWrcGen
{
    internal class StaticQuantityGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public StaticQuantityGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;
using System.Collections.Generic;

namespace UnitsNet
{
    /// <summary>
    ///     Dynamically parse or construct quantities when types are only known at runtime.
    /// </summary>
    internal static partial class Quantity
    {
        public static readonly IDictionary<string, QuantityInfo> ByName = new Dictionary<string, QuantityInfo>
        {");
            foreach (var quantity in _quantities)
                Writer.WL($@"
            {{ ""{quantity.Name}"", {quantity.Name}.Info }},");
            Writer.WL(@"
        };

        // Used by the QuantityInfo .ctor to map a name to a QuantityType. Will be removed when QuantityType
        // will be removed.
        internal static readonly IDictionary<string, QuantityType> QuantityTypeByName = new Dictionary<string, QuantityType>
        {");
            foreach (var quantity in _quantities)
                Writer.WL($@"
            {{ ""{quantity.Name}"", QuantityType.{quantity.Name} }},");
            Writer.WL(@"
        };

        /// <summary>
        /// Dynamically constructs a quantity of the given <see cref=""QuantityType""/> with the value in the quantity's base units.
        /// </summary>
        /// <param name=""quantityType"">The <see cref=""QuantityType""/> of the quantity to create.</param>
        /// <param name=""value"">The value to construct the quantity with.</param>
        /// <returns>The created quantity.</returns>
        [Obsolete(""QuantityType will be removed. Use FromQuantityInfo(QuantityInfo, QuantityValue) instead."")]
        public static IQuantity FromQuantityType(QuantityType quantityType, QuantityValue value)
        {
            switch(quantityType)
            {");
            foreach (var quantity in _quantities)
            {
                var quantityName = quantity.Name;
                Writer.WL($@"
                case QuantityType.{quantityName}:
                    return {quantityName}.From(value, {quantityName}.BaseUnit);");
            }

            Writer.WL(@"
                default:
                    throw new ArgumentException($""{quantityType} is not a supported quantity type."");
            }
        }

        /// <summary>
        /// Dynamically constructs a quantity of the given <see cref=""QuantityInfo""/> with the value in the quantity's base units.
        /// </summary>
        /// <param name=""quantityInfo"">The <see cref=""QuantityInfo""/> of the quantity to create.</param>
        /// <param name=""value"">The value to construct the quantity with.</param>
        /// <returns>The created quantity.</returns>
        public static IQuantity FromQuantityInfo(QuantityInfo quantityInfo, QuantityValue value)
        {
            switch(quantityInfo.Name)
            {");
            foreach (var quantity in _quantities)
            {
                var quantityName = quantity.Name;
                Writer.WL($@"
                case ""{quantityName}"":
                    return {quantityName}.From(value, {quantityName}.BaseUnit);");
            }

            Writer.WL(@"
                default:
                    throw new ArgumentException($""{quantityInfo.Name} is not a supported quantity."");
            }
        }

        /// <summary>
        ///     Try to dynamically construct a quantity.
        /// </summary>
        /// <param name=""value"">Numeric value.</param>
        /// <param name=""unit"">Unit enum value.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns><c>True</c> if successful with <paramref name=""quantity""/> assigned the value, otherwise <c>false</c>.</returns>
        internal static bool TryFrom(double value, Enum unit, out IQuantity quantity)
        {
            switch (unit)
            {");
            foreach (var quantity in _quantities)
            {
                var quantityName = quantity.Name;
                var unitTypeName = $"{quantityName}Unit";
                var unitValue = unitTypeName.ToCamelCase();
                Writer.WL($@"
                case {unitTypeName} {unitValue}:
                    quantity = {quantityName}.From(value, {unitValue});
                    return true;");
            }

            Writer.WL($@"
                default:
                {{
                    quantity = default(IQuantity);
                    return false;
                }}
            }}
        }}

        /// <inheritdoc cref=""Parse(IFormatProvider, System.Type,string)""/>
        internal static IQuantity Parse(Type quantityType, string quantityString) => Parse(null, quantityType, quantityString);

        /// <summary>
        ///     Dynamically parse a quantity string representation.
        /// </summary>
        /// <param name=""formatProvider"">The format provider to use for lookup. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        /// <param name=""quantityType"">Type of quantity, such as <see cref=""Length""/>.</param>
        /// <param name=""quantityString"">Quantity string representation, such as ""1.5 kg"". Must be compatible with given quantity type.</param>
        /// <returns>The parsed quantity.</returns>
        /// <exception cref=""ArgumentException"">Type must be of type UnitsNet.IQuantity -or- Type is not a known quantity type.</exception>
        internal static IQuantity Parse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString)
        {{
            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                throw new ArgumentException($""Type {{quantityType}} must be of type UnitsNet.IQuantity."");

            if (TryParse(formatProvider, quantityType, quantityString, out IQuantity quantity)) return quantity;

            throw new ArgumentException($""Quantity string could not be parsed to quantity {{quantityType}}."");
        }}

        /// <inheritdoc cref=""TryParse(IFormatProvider,System.Type,string,out UnitsNet.IQuantity)""/>
        internal static bool TryParse(Type quantityType, string quantityString, out IQuantity quantity) =>
            TryParse(null, quantityType, quantityString, out quantity);

        /// <summary>
        ///     Try to dynamically parse a quantity string representation.
        /// </summary>
        /// <param name=""formatProvider"">The format provider to use for lookup. Defaults to <see cref=""GlobalConfiguration.DefaultCulture"" /> if null.</param>
        /// <param name=""quantityType"">Type of quantity, such as <see cref=""Length""/>.</param>
        /// <param name=""quantityString"">Quantity string representation, such as ""1.5 kg"". Must be compatible with given quantity type.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns>The parsed quantity.</returns>
        internal static bool TryParse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString, out IQuantity quantity)
        {{
            quantity = default(IQuantity);

            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                return false;

            var parser = QuantityParser.Default;
");
            foreach (var quantity in _quantities)
            {
                Writer.WL($@"
            if (quantityType == typeof({quantity.Name}))
                return parser.TryParse<{quantity.Name}, {quantity.Name}Unit>(quantityString, formatProvider, {quantity.Name}.From, out quantity);
");
            }

            Writer.WL($@"
            throw new ArgumentException(
                $""Type {{quantityType}} is not a known quantity type. Did you pass in a third-party quantity type defined outside UnitsNet library?"");
        }}
    }}
}}");
            return Writer.ToString();
        }
    }
}
