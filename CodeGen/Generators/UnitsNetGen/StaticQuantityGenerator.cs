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

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System;
using System.Globalization;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Dynamically parse or construct quantities when types are only known at runtime.
    /// </summary>
    public static partial class Quantity
    {
        /// <summary>
        /// Dynamically constructs a quantity of the given <see cref=""QuantityType""/> with the value in the quantity's base units.
        /// </summary>
        /// <param name=""quantityType"">The <see cref=""QuantityType""/> of the quantity to create.</param>
        /// <param name=""value"">The value to construct the quantity with.</param>
        /// <returns>The created quantity.</returns>
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
        ///     Try to dynamically construct a quantity.
        /// </summary>
        /// <param name=""value"">Numeric value.</param>
        /// <param name=""unit"">Unit enum value.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns><c>True</c> if successful with <paramref name=""quantity""/> assigned the value, otherwise <c>false</c>.</returns>
        public static bool TryFrom(QuantityValue value, Enum unit, out IQuantity quantity)
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

            Writer.WL(@"
                default:
                {
                    quantity = default(IQuantity);
                    return false;
                }
            }
        }

        /// <summary>
        ///     Try to dynamically parse a quantity string representation.
        /// </summary>
        /// <param name=""formatProvider"">The format provider to use for lookup. Defaults to <see cref=""CultureInfo.CurrentUICulture"" /> if null.</param>
        /// <param name=""quantityType"">Type of quantity, such as <see cref=""Length""/>.</param>
        /// <param name=""quantityString"">Quantity string representation, such as ""1.5 kg"". Must be compatible with given quantity type.</param>
        /// <param name=""quantity"">The resulting quantity if successful, otherwise <c>default</c>.</param>
        /// <returns>The parsed quantity.</returns>
        public static bool TryParse([CanBeNull] IFormatProvider formatProvider, Type quantityType, string quantityString, out IQuantity quantity)
        {
            quantity = default(IQuantity);

            if (!typeof(IQuantity).Wrap().IsAssignableFrom(quantityType))
                return false;

            var parser = QuantityParser.Default;

            switch(quantityType)
            {");
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
