using CodeGen.Helpers;
using CodeGen.Helpers.UnitEnumValueAllocation;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitTypeGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;
        private readonly UnitEnumNameToValue _unitEnumNameToValue;
        private readonly string _unitEnumName;

        public UnitTypeGenerator(Quantity quantity, UnitEnumNameToValue unitEnumNameToValue)
        {
            _quantity = quantity;
            _unitEnumNameToValue = unitEnumNameToValue;
            _unitEnumName = $"{quantity.Name}Unit";
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
// ReSharper disable once CheckNamespace
namespace UnitsNet.Units
{{
    // Disable missing XML comment warnings for the generated unit enums.
    #pragma warning disable 1591

    public enum {_unitEnumName}
    {{");
            foreach (var unit in _quantity.Units)
            {
                if (unit.XmlDocSummary.HasText())
                {
                    Writer.WL();
                    Writer.WL($@"
        /// <summary>
        ///     {unit.XmlDocSummary}
        /// </summary>");
                }

                if (unit.XmlDocRemarks.HasText())
                {
                    Writer.WL($@"
        /// <remarks>{unit.XmlDocRemarks}</remarks>");
                }

                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit.ObsoleteText));
                Writer.WL($@"
        {unit.SingularName} = {_unitEnumNameToValue[unit.SingularName]},");
            }

            Writer.WL($@"
    }}

    #pragma warning restore 1591
}}");
            return Writer.ToString();
        }

        private static string? GetObsoleteAttributeOrNull(string? obsoleteText) => string.IsNullOrWhiteSpace(obsoleteText)
            ? null
            : $"[System.Obsolete(\"{obsoleteText}\")]";
    }
}
