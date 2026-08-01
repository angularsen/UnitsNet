// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Reflection;
using Microsoft.CodeAnalysis;
using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class DiagnosticDocumentationTests
{
    [Fact]
    public void EveryDiagnosticLinksToRelevantDocumentation()
    {
        DiagnosticDescriptor[] descriptors = typeof(UnitsNetModularGenerator)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Static)
            .Where(field => field.FieldType == typeof(DiagnosticDescriptor))
            .Select(field => (DiagnosticDescriptor)field.GetValue(null)!)
            .ToArray();

        Assert.Equal(13, descriptors.Length);
        Assert.All(
            descriptors,
            descriptor => Assert.StartsWith(
                "https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Modular#",
                descriptor.HelpLinkUri,
                StringComparison.Ordinal));
    }
}
