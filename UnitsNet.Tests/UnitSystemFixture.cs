using Xunit;

namespace UnitsNet.Tests
{
    [CollectionDefinition(nameof(UnitSystemFixture), DisableParallelization = true)]
    public class UnitSystemFixture : ICollectionFixture<object>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.

        // Apply this collection fixture to classes:
        // 1. that rely on manipulating CultureInfo. See https://github.com/angularsen/UnitsNet/issues/436
        // 2. to avoid accessing static prop DefaultToString in parallel from multiple tests:
        //      a. UnitSystemTests.DefaultToStringFormatting()
        //      b. LengthTests.ToStringReturnsCorrectNumberAndUnitWithCentimeterAsDefualtUnit()
    }
}
