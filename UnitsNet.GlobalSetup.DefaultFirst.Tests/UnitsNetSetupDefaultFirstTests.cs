// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.GlobalSetup.DefaultFirst.Tests;

// This assembly intentionally contains a single test because UnitsNetSetup.Default is process-wide and cannot be reset.
public class UnitsNetSetupDefaultFirstTests
{
    [Fact]
    public void ConfigureDefaults_AfterDefaultIsCreated_ThrowsInvalidOperationException()
    {
        UnitsNetSetup originalDefault = UnitsNetSetup.Default;
        bool configurationInvoked = false;

        Assert.Throws<InvalidOperationException>(() => UnitsNetSetup.ConfigureDefaults(_ => configurationInvoked = true));

        Assert.False(configurationInvoked);
        Assert.Same(originalDefault, UnitsNetSetup.Default);
    }
}
