using System;
using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class NumberExtensionsTestClassGenerator : GeneratorBase
    {
        private readonly Unit[] _units;
        private readonly string _quantityName;

        public NumberExtensionsTestClassGenerator(Quantity quantity)
        {
            if (quantity is null) throw new ArgumentNullException(nameof(quantity));

            _units = quantity.Units;
            _quantityName = quantity.Name;
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);

            Writer.WL(
$@"
using UnitsNet.NumberExtensions.NumberTo{_quantityName};
using Xunit;

namespace UnitsNet.Tests
{{
    public class NumberTo{_quantityName}ExtensionsTests
    {{");

            foreach (var unit in _units)
            {
                if (unit.SkipConversionGeneration)
                    continue;

                Writer.WL(2, $@"
[Fact]");

                Writer.WL(2, $@"public void NumberTo{unit.PluralName}Test() =>
            Assert.Equal({_quantityName}.From{unit.PluralName}(2), 2.{unit.PluralName}());
");
            }

            Writer.WL(1, @"}
}");
            return Writer.ToString();
        }
    }
}
