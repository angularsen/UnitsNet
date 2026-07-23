// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.GlobalSetup.Tests;

/// <summary>
///     Tests configuring the process-wide default setup before first use.
/// </summary>
/// <remarks>
///     This assembly intentionally contains a single test because <see cref="UnitsNetSetup.Default" /> cannot be reset.
///     Keep additional global-configuration scenarios isolated in separate test processes.
/// </remarks>
public class UnitsNetSetupGlobalConfigurationTests
{
    [Fact]
    public void ConfigureDefaults_BeforeFirstUse_ConfiguresAndFreezesDefaultSetup()
    {
        UnitsNetSetup configured = UnitsNetSetup.ConfigureDefaults(builder => builder.WithQuantities([Mass.Info]));

        Assert.Same(configured, UnitsNetSetup.Default);
        Assert.Same(configured.UnitAbbreviations, UnitAbbreviationsCache.Default);
        Assert.Same(configured.UnitParser, UnitParser.Default);
        Assert.Equal([Mass.Info], configured.Quantities.Infos);
        Assert.Throws<UnitNotFoundException>(() => configured.UnitParser.Parse<LengthUnit>("m"));
        Assert.Throws<InvalidOperationException>(() => UnitsNetSetup.ConfigureDefaults(_ => { }));
    }
}
