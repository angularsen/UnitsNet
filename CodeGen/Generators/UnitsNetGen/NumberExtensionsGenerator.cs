using System;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class NumberExtensionsGenerator : GeneratorBase
    {
        private readonly Unit[] _units;
        private readonly string _quantityName;

        public NumberExtensionsGenerator(Quantity quantity)
        {
            if (quantity is null)
                throw new ArgumentNullException(nameof(quantity));

            _units = quantity.Units;
            _quantityName = quantity.Name;
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);

            Writer.WL(
$@"
using System;

#nullable enable

namespace UnitsNet.NumberExtensions.NumberTo{_quantityName}
{{
    /// <summary>
    /// A number to {_quantityName} Extensions
    /// </summary>
    public static class NumberTo{_quantityName}Extensions
    {{");

            foreach (var unit in _units)
            {
                if (unit.SkipConversionGeneration)
                    continue;

                Writer.WL(2, $@"
/// <inheritdoc cref=""{_quantityName}.From{unit.PluralName}(UnitsNet.QuantityValue)"" />");

                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit.ObsoleteText));

                Writer.WL(2, $@"public static {_quantityName} {unit.PluralName}<T>(this T value) =>
            {_quantityName}.From{unit.PluralName}(Convert.ToDouble(value));
");
            }

            Writer.WL(1, @"}
}");
            return Writer.ToString();
        }

        private static string? GetObsoleteAttributeOrNull(string obsoleteText) =>
            string.IsNullOrWhiteSpace(obsoleteText) ?
            null :
            $"[Obsolete(\"{obsoleteText}\")]";
    }
}
