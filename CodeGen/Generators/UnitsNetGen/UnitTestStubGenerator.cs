using CodeGen.JsonTypes;

namespace CodeGen.Generators.OasysUnitsGen
{
    internal class UnitTestStubGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;

        public UnitTestStubGenerator(Quantity quantity)
        {
            _quantity = quantity;
        }

        public string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using System;

namespace OasysUnits.Tests.CustomCode
{{
    public class {_quantity.Name}Tests : {_quantity.Name}TestsBase
    {{
        // Override properties in base class here
    }}
}}");
            return Writer.ToString();
        }
    }
}
