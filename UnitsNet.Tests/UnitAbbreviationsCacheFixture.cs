using Xunit;

namespace UnitsNet.Tests
{
    [CollectionDefinition(nameof(UnitAbbreviationsCacheFixture), DisableParallelization = true)]
    public class UnitAbbreviationsCacheFixture : ICollectionFixture<object>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.

        // Apply this collection fixture to classes:
        // 1. That rely on manipulating CultureInfo. See https://github.com/angularsen/UnitsNet/issues/436
        // 2. To avoid accessing static ToString/Parse from multiple tests where UnitAbbreviationsCache.Default is modified
    }
}
