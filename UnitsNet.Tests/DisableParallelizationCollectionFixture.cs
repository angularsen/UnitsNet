using System.Globalization;
using UnitsNet.Tests.Helpers;
using Xunit;

namespace UnitsNet.Tests;

/// <summary>
///     Apply to test classes that manipulate static fields, such as
///     <see cref="UnitsNetSetup"/>.<see cref="UnitsNetSetup.Default"/>.<see cref="UnitsNetSetup.UnitAbbreviations"/>,
///     to disable parallelization and avoid flaky tests.
///     <br /><br />
///     To apply to test class, add attribute just before class definition: <c>[Collection(nameof(UnitAbbreviationsCacheFixture))]</c>
/// </summary>
/// <remarks>
///     This is not necessary for thread-static fields like <see cref="CultureInfo"/>.<see cref="CultureInfo.CurrentCulture"/>, typically used when testing Parse/ToString() without an explicit culture,
///     as long as each test method reverts its changes with try-finally or <see cref="CultureScope"/>.
/// </remarks>
[CollectionDefinition(nameof(DisableParallelizationCollectionFixture), DisableParallelization = true)]
public class DisableParallelizationCollectionFixture : ICollectionFixture<object>;
