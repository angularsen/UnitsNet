using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitAbbreviationsCacheGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public UnitAbbreviationsCacheGenerator(Quantity[] quantities)
        {
            _quantities = quantities;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL(@"
using System;
using UnitsNet.Units;

// ReSharper disable RedundantCommaInArrayInitializer
// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    public partial class UnitAbbreviationsCache
    {
        private static readonly (string CultureName, Type UnitType, int UnitValue, string[] UnitAbbreviations)[] GeneratedLocalizations
            = new []
            {");
            foreach (var quantity in _quantities)
            {
                var unitEnumName = $"{quantity.Name}Unit";

                foreach (var unit in quantity.Units)
                {
                    foreach (var localization in unit.Localization)
                    {
                        var cultureName = localization.Culture;

                        // All units must have a unit abbreviation, so fallback to "" for units with no abbreviations defined in JSON
                        var abbreviationParams = localization.Abbreviations.Any()
                            ? string.Join(", ", localization.Abbreviations.Select(abbr => $"\"{abbr}\""))
                            : "\"\"";
                        Writer.WL($@"
                (""{cultureName}"", typeof({unitEnumName}), (int){unitEnumName}.{unit.SingularName}, new string[]{{{abbreviationParams}}}),");
                    }
                }
            }

            Writer.WL(@"
            };
    }
}");
            return Writer.ToString();
        }
    }
}
