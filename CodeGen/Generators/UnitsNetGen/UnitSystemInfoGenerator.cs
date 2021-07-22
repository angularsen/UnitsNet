using System;
using System.Linq;
using CodeGen.Helpers;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitSystemInfoGenerator : GeneratorBase
    {
        private readonly Quantity[] _quantities;
        private readonly string _unitSystemName;

        public UnitSystemInfoGenerator(string unitSystemName, Quantity[] quantities)
        {
            _quantities = quantities;
            _unitSystemName = unitSystemName;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
// ReSharper disable once CheckNamespace
namespace UnitsNet.UnitSystems
{{

    public partial class {_unitSystemName}
    {{
        /// <summary>
        /// Returns the list of unit mappings for the current unit system
        /// </summary>
        /// <returns>The list of unit system infos</returns>
        public static UnitSystemInfo[] GetDefaultSystemUnits()
        {{
            return new UnitSystemInfo[]
            {{");
            foreach (Quantity quantity in _quantities)
            {
                UnitSystemMapping unitSystemMapping = quantity.UnitSystems.FirstOrDefault(x => x.UnitSystem == _unitSystemName);
                if (unitSystemMapping == null)
                {
                    var firstCommonUnitIndex = Array.FindIndex(quantity.Units,  x => x.UnitSystems.Contains(_unitSystemName));

                    if (firstCommonUnitIndex < 0)
                    {
                        Writer.WL(4, "null,"); // no mapping for current quantity
                    }
                    else
                    {
                        Writer.WL(4, $@"new UnitSystemInfo(null, new UnitInfo[]{{");
                        Writer.WL(5, $@"{quantity.Name}.Info.UnitInfos[{firstCommonUnitIndex}],");
                        var startingIndex = firstCommonUnitIndex + 1;
                        while (true)
                        {
                            var nextIndex = Array.FindIndex(quantity.Units, startingIndex, x => x.UnitSystems.Contains(_unitSystemName));
                            if (nextIndex < 0)
                            {
                                Writer.WL(5, @"}),");
                                break;
                            }
                            else
                            {
                                Writer.WL(5, $@"{quantity.Name}.Info.UnitInfos[{nextIndex}],");
                                startingIndex = nextIndex + 1;
                            }
                        }
                    }
                }
                else
                {
                    // find the unit index in the generated unit infos
                    var defaultIndex = Array.FindIndex(quantity.Units, x => x.SingularName == unitSystemMapping.BaseUnit);
                   
                    Writer.WL(4, $@"new UnitSystemInfo({quantity.Name}.Info.UnitInfos[{defaultIndex}], new UnitInfo[]{{");
                    var startingIndex = 0;
                    while(true)
                    {
                        var nextIndex = Array.FindIndex(quantity.Units, startingIndex, x => x.UnitSystems.Contains(_unitSystemName));
                        if (nextIndex < 0)
                        {
                            Writer.WL(5, @"}),");
                            break;
                        }
                        else
                        {
                            Writer.WL(5, $@"{quantity.Name}.Info.UnitInfos[{nextIndex}],");
                            startingIndex = nextIndex + 1;
                        }
                    }
                }
            }

            Writer.WL(@"
            };
        }
    }
}
");

            return Writer.ToString();
        }
    }
}
