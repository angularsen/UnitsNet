using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitTypeGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;
        private readonly string _unitEnumName;

        public UnitTypeGenerator(Quantity quantity)
        {
            _quantity = quantity;
            _unitEnumName = $"{quantity.Name}Unit";
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
// ReSharper disable once CheckNamespace
namespace UnitsNet.Units
{{
    // Disable missing XML comment warnings for the generated unit enums.
    #pragma warning disable 1591

    public enum {_unitEnumName}
    {{
        Undefined = 0,");

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

                Writer.WLIfText(2, QuantityGenerator.GetObsoleteAttributeOrNull(unit));
                Writer.WL($@"
        {unit.SingularName},");
            }

            Writer.WL($@"
    }}

    #pragma warning restore 1591
}}");
            return Writer.ToString();
        }
    }
}
