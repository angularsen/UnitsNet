using System;
using System.Collections.Generic;
using System.Linq;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class StaticQuantityGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;
        private readonly bool _quantityType;
        private readonly string _name;
        private readonly string _namespaceName;
        private readonly bool _useNullity;
        private readonly IEnumerable<string> _usingNamespaces;
        private readonly bool _checkQuantityType;

        public StaticQuantityGenerator(Quantity[] quantities, bool quantityType, string name, string namespaceName, bool useNullity, IEnumerable<string> usingNamespaces, bool checkQuantityType = true)
        {
            _quantities = quantities;
            _quantityType = quantityType;
            _name = name;
            _namespaceName = namespaceName;
            _useNullity = useNullity;
            _usingNamespaces = usingNamespaces ?? Enumerable.Empty<string>();
            this._checkQuantityType = checkQuantityType;
        }

        public override string Generate()
        {
            var newline = Environment.NewLine;
            string usingNamespaces = string.Join(Environment.NewLine, _usingNamespaces.Select(ns => $@"using {ns};"));
            var n = _useNullity ? "?" : string.Empty;
            var nullableEnable = _useNullity ? "#nullable enable\r\n" : string.Empty;
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using System;
using System.Globalization;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;
using System.Collections.Generic;
{usingNamespaces}
{nullableEnable}");
            Writer.WL($@"
namespace {_namespaceName}");
            Writer.WL(@"
{
            /// <summary>
            ///     Dynamically parse or construct quantities when types are only known at runtime.
            /// </summary>");
            Writer.WL($@"
    public static partial class {_name}");
            Writer.WL(@"
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
");

            if (_quantityType)
            {
                Writer.WL(@"
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
");
            }

            Writer.WL(@"
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

            Writer.WL($@"
                default:
                    throw new ArgumentException($""{{quantityInfo.Name}} is not a supported quantity."");
            }}
        }}

        /// <summary>
        ///     Try to dynamically construct a quantity.
        /// </summary>
        /// <param name=""value"">Numeric value.</param>
        /// <param name=""unit"">Unit enum value.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns><c>True</c> if successful with <paramref name=""quantity""/> assigned the value, otherwise <c>false</c>.</returns>
        public static bool TryFrom(QuantityValue value, Enum unit, out IQuantity{n} quantity)
        {{
            switch (unit)
            {{");
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

        /// <summary>
        ///     Try to dynamically parse a quantity string representation.
        /// </summary>
        /// <param name=""formatProvider"">The format provider to use for lookup. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        /// <param name=""quantityType"">Type of quantity, such as <see cref=""Length""/>.</param>
        /// <param name=""quantityString"">Quantity string representation, such as ""1.5 kg"". Must be compatible with given quantity type.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns>The parsed quantity.</returns>
        public static bool TryParse(IFormatProvider{n} formatProvider, Type quantityType, string quantityString, out IQuantity{n} quantity)
        {{
            quantity = default(IQuantity);
");
            if (_checkQuantityType)
            {
                // Wrap() is internal
                Writer.WL($@"
                if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                return false;
");
            }
            Writer.WL($@"

            var parser = QuantityParser.Default;

            switch(quantityType)
            {{");
            foreach (var quantity in _quantities)
            {
                var quantityName = quantity.Name;
                Writer.WL($@"
                case Type _ when quantityType == typeof({quantityName}):
                    return parser.TryParse<{quantityName}, {quantityName}Unit>(quantityString, formatProvider, {quantityName}.From, out quantity);");
            }

            Writer.WL(@"
                default:
                    return false;
            }
        }
    }
}");
            return Writer.ToString();
        }
    }
}
