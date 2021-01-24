using System;
using System.Collections.Generic;
using System.Linq;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitAbbreviationsCacheGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;
        private readonly string _className;
        private readonly string _namespaceName;
        private readonly IEnumerable<string> _usingNamespaces;

        public UnitAbbreviationsCacheGenerator(Quantity[] quantities, string className, string namespaceName, IEnumerable<string> usingNamespaces)
        {
            _quantities = quantities;
            _className = className ?? "UnitAbbreviationsCache";
            _namespaceName = namespaceName ?? "UnitsNet";
            _usingNamespaces = usingNamespaces ?? Enumerable.Empty<string>();
        }

        public override string Generate()
        {
            var usingNamespaces = string.Join(Environment.NewLine, _usingNamespaces.Select(ns => $@"    using {ns};"));
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"

// ReSharper disable RedundantCommaInArrayInitializer
// ReSharper disable once CheckNamespace
namespace {_namespaceName}
{{
    using System;
    using UnitsNet.Units;
{usingNamespaces}

    public partial class {_className}
    {{
        private static readonly (string CultureName, Type UnitType, int UnitValue, string[] UnitAbbreviations)[] GeneratedLocalizations
            = new []
            {{");
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
