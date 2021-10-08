using Xunit;

namespace UnitsNet.Tests
{
    [CollectionDefinition(nameof(UnitLocalizedNamesCacheFixture), DisableParallelization = true)]
    public class UnitLocalizedNamesCacheFixture : ICollectionFixture<object>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.

        // Apply this collection fixture to classes:
        // 1. That rely on manipulating CultureInfo. 
    }
}
