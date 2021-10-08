using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitSingularNamesCacheGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;

        public UnitSingularNamesCacheGenerator(Quantity[] quantities)
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
    public partial class UnitSingularNamesCache
    {
        private static readonly (string CultureName, Type UnitType, int UnitValue, string[] Strings)[] GeneratedLocalizations
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

                        // All units must have a unit abbreviation, so fallback to the default singular name if no localized name is defined in JSON
                        // var singularNames = string.IsNullOrEmpty(localization.SingularName) ? $"\"{unit.SingularName}\"" : $"\"{localization.SingularName}\"";
                        var singularNames = string.IsNullOrEmpty(localization.SingularName) ? "\"BOB\"" : $"\"{localization.SingularName}\"";
                        Writer.WL($@"
                (""{cultureName}"", typeof({unitEnumName}), (int){unitEnumName}.{unit.SingularName}, new string[]{{{singularNames}}}),");
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
