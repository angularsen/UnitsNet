// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.GlobalSetup.DefaultFirst.Tests;

/// <summary>
///     Tests configuring the process-wide default setup after first use.
/// </summary>
/// <remarks>
///     This assembly intentionally contains a single test because <see cref="UnitsNetSetup.Default" /> cannot be reset.
/// </remarks>
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
