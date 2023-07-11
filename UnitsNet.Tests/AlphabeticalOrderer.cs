// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitsNet.Tests;

/// <summary>
///     Useful for debugging tests where a particular order of tests is required.
/// </summary>
/// <example>
/// Add the attribute to your test class:
/// <code>
/// <![CDATA[
/// [TestCaseOrderer(
/// ordererTypeName: "UnitsNet.Tests.AlphabeticalOrderer",
/// ordererAssemblyName: "UnitsNet.Tests")]
/// ]]>
/// </code>
/// </example>
public class AlphabeticalOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
        IEnumerable<TTestCase> testCases) where TTestCase : ITestCase =>
        testCases.OrderBy(testCase => testCase.TestMethod.Method.Name);
}
