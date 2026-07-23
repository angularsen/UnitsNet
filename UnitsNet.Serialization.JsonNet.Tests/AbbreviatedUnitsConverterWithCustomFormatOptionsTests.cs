// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Serialization.JsonNet.Value;

namespace UnitsNet.Serialization.JsonNet.Tests;

public class AbbreviatedUnitsConverterWithCustomFormatOptionsTests : JsonNetSerializationTestsBase
{
    public AbbreviatedUnitsConverterWithCustomFormatOptionsTests()
        : base(
            new AbbreviatedUnitsConverter(
                new QuantityValueFormatOptions(QuantityValueSerializationFormat.Custom, QuantityValueDeserializationFormat.Custom)),
            new QuantityValueFractionalNotationConverter())
    {
    }
}
