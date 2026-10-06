using System.Linq;
using CodeGen.Helpers;
using CodeGen.Helpers.ExpressionAnalyzer;
using CodeGen.Helpers.ExpressionAnalyzer.Expressions;
using CodeGen.JsonTypes;
using Fractions;

namespace CodeGen.Generators.UnitsNetGen
{
    /// <summary>
    ///     Generates the static class of the units of a quantity as <c>UnitOf&lt;TQuantity&gt;</c>, such as
    ///     <c>LengthUnits.Meter</c>, with their names, base units and conversions.
    /// </summary>
    internal class UnitsClassGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;
        private readonly string _unitEnumName;

        public UnitsClassGenerator(Quantity quantity)
        {
            _quantity = quantity;
            _unitEnumName = $"{quantity.Name}Unit";
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
// ReSharper disable once CheckNamespace
namespace UnitsNet.Units
{{
    /// <summary>
    ///     The units of <see cref=""{_quantity.Name}""/>, such as <see cref=""{_quantity.Name}Units.{_quantity.BaseUnit}""/>.
    /// </summary>");
            Writer.WLIfText(1, GetObsoleteAttributeOrNull(_quantity.ObsoleteText));
            Writer.WL($@"
    public static class {_quantity.Name}Units
    {{");
            var isFirst = true;
            foreach (Unit unit in _quantity.Units)
            {
                if (!isFirst)
                {
                    Writer.WL();
                }

                isFirst = false;
                Writer.WL($@"
        /// <summary>
        ///     The <see cref=""{_unitEnumName}.{unit.SingularName}""/> unit of <see cref=""{_quantity.Name}""/>.
        /// </summary>");
                Writer.WLIfText(2, GetObsoleteAttributeOrNull(unit.ObsoleteText));
                Writer.WL($@"
        public static readonly UnitOf<{_quantity.Name}> {unit.SingularName} = new(""{unit.SingularName}"", ""{unit.PluralName}"", {GetBaseUnitsFormat(unit)},{GetConversionFormat(unit)});");
            }

            Writer.WL($@"
    }}
}}");
            return Writer.ToString();
        }

        private string GetConversionFormat(Unit unit)
        {
            if (unit.SingularName == _quantity.BaseUnit)
            {
                return " 1";
            }

            CompositeExpression expressionFromBaseToUnit = ExpressionEvaluator.Evaluate(unit.FromBaseToUnitFunc, "{x}");
            // A conversion with a single term is described by the value of the unit in the base unit, the reciprocal of its
            // coefficient. Otherwise, such as for units with an offset, it needs both conversion expressions.
            if (expressionFromBaseToUnit.Terms.Count == 1 && expressionFromBaseToUnit.Degree == Fraction.One)
            {
                return " " + expressionFromBaseToUnit.GetReciprocalCoefficientFormat();
            }

            return $@"
            {expressionFromBaseToUnit.GetConversionExpressionFormat()},
            {unit.GetUnitToBaseConversionExpressionFormat()}";
        }

        private static string GetBaseUnitsFormat(Unit unit)
        {
            BaseUnits? baseUnits = unit.BaseUnits;
            if (baseUnits == null)
            {
                return "BaseUnits.Undefined";
            }

            return $"new BaseUnits({string.Join(", ",
                new[]
                {
                    baseUnits.L != null ? $"length: LengthUnit.{baseUnits.L}" : null,
                    baseUnits.M != null ? $"mass: MassUnit.{baseUnits.M}" : null,
                    baseUnits.T != null ? $"time: DurationUnit.{baseUnits.T}" : null,
                    baseUnits.I != null ? $"current: ElectricCurrentUnit.{baseUnits.I}" : null,
                    baseUnits.Θ != null ? $"temperature: TemperatureUnit.{baseUnits.Θ}" : null,
                    baseUnits.N != null ? $"amount: AmountOfSubstanceUnit.{baseUnits.N}" : null,
                    baseUnits.J != null ? $"luminousIntensity: LuminousIntensityUnit.{baseUnits.J}" : null
                }.Where(str => str != null))})";
        }

        private static string? GetObsoleteAttributeOrNull(string? obsoleteText) => string.IsNullOrWhiteSpace(obsoleteText)
            ? null
            : $"[System.Obsolete(\"{obsoleteText}\")]";
    }
}
