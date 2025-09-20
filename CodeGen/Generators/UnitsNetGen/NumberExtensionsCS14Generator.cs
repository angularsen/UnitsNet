using System;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class NumberExtensionsCS14Generator(Quantity quantity) : GeneratorBase
    {
        private readonly Quantity _quantity = quantity ?? throw new ArgumentNullException(nameof(quantity));
        private readonly Unit[] _units = quantity.Units;
        private readonly string _quantityName = quantity.Name;

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);

            Writer.WL(
                $@"
using System;

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

#nullable enable

namespace UnitsNet.NumberExtensions.NumberTo{_quantityName}
{{
    /// <summary>
    /// A number to {_quantityName} Extensions
    /// </summary>");

            Writer.WLIfText(1, GetObsoleteAttributeOrNull(_quantity));
            Writer.WL(@$"
    public static class NumberTo{_quantityName}Extensions
    {{");

            Writer.WL(@"
#pragma warning disable CS1591
        extension<T>(T value)
#pragma warning restore CS1591
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#else
            , IConvertible
#endif
        {");


            foreach (var unit in _units)
            {
                if (unit.SkipConversionGeneration)
                    continue;

                Writer.WL(3, $@"
/// <inheritdoc cref=""{_quantityName}.From{unit.PluralName}(double)"" />");

                // Include obsolete text from the quantity per extension method, to make it visible when the class is not explicitly referenced in code.
                Writer.WLIfText(3, GetObsoleteAttributeOrNull(unit.ObsoleteText ?? _quantity.ObsoleteText));

                Writer.WL(3, $@"public {_quantityName} {unit.PluralName}
#if NET7_0_OR_GREATER
                => {_quantityName}.From{unit.PluralName}(double.CreateChecked(value));
#else
                => {_quantityName}.From{unit.PluralName}(value.ToDouble(null));
#endif
");
            }

            Writer.WL(2, @"}
    }
}");
            return Writer.ToString();
        }

        /// <inheritdoc cref="GetObsoleteAttributeOrNull(string)"/>
        private static string? GetObsoleteAttributeOrNull(Quantity quantity) => GetObsoleteAttributeOrNull(quantity.ObsoleteText);

        private static string? GetObsoleteAttributeOrNull(string? obsoleteText) =>
            string.IsNullOrWhiteSpace(obsoleteText) ? null : $"[Obsolete(\"{obsoleteText}\")]";
    }
}
