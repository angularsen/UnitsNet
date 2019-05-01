using CodeGen.JsonTypes;

namespace CodeGen.Generators.UnitsNetGen
{
    internal class UnitTestStubGenerator : GeneratorBase
    {
        private readonly Quantity _quantity;

        public UnitTestStubGenerator(Quantity quantity)
        {
            _quantity = quantity;
        }

        public override string Generate()
        {
            Writer.WL(GeneratedFileHeader);
            Writer.WL($@"
using System;

namespace UnitsNet.Tests.CustomCode
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
