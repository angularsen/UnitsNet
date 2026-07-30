// Licensed under MIT No Attribution, see LICENSE file at the root.

using Xunit;

namespace UnitsNet.Modular.Generator.Tests;

public sealed class StableEnumGeneratorTests
{
    [Fact]
    public void FilteredBuiltIn_UsesUnitsNetEnumValues()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run("""
            using UnitsNet.Modular;

            [UnitSet("Meter", "Millimeter", "Megameter")]
            internal interface SelectedUnitSet;

            [UnitsNetModule]
            internal interface Module : IInclude<UnitsNet.Modular.BuiltIns.LengthSpec, SelectedUnitSet>;
            """);

        string generated = Assert.Single(
            run.Result.GeneratedTrees,
            tree => tree.FilePath.EndsWith("UnitsNet_Length.g.cs", StringComparison.Ordinal)).ToString();
        Assert.Contains("Meter = 21", generated, StringComparison.Ordinal);
        Assert.Contains("Millimeter = 26", generated, StringComparison.Ordinal);
        Assert.Contains("Megameter = 41", generated, StringComparison.Ordinal);
    }

    [Fact]
    public void FilteredCustomDefinition_UsesFullDefinitionOrdinals()
    {
        GeneratorTestHost.TestRun run = GeneratorTestHost.Run(
            """
            using UnitsNet.Modular;

            [QuantitySpec("Example.Widget")]
            internal interface WidgetSpec;

            [UnitSet("Base", "Third")]
            internal interface SelectedUnitSet;

            [UnitsNetModule]
            internal interface Module : IInclude<WidgetSpec, SelectedUnitSet>;
            """,
            ("Widget.unitsnet.json", """
                {
                  "Name": "Widget",
                  "Namespace": "Example",
                  "BaseUnit": "Base",
                  "Units": [
                    { "SingularName": "Base", "PluralName": "Bases", "FromUnitToBaseFunc": "{x}", "FromBaseToUnitFunc": "{x}" },
                    { "SingularName": "Second", "PluralName": "Seconds", "FromUnitToBaseFunc": "{x} * 2", "FromBaseToUnitFunc": "{x} / 2" },
                    { "SingularName": "Third", "PluralName": "Thirds", "FromUnitToBaseFunc": "{x} * 3", "FromBaseToUnitFunc": "{x} / 3" }
                  ]
                }
                """));

        string generated = Assert.Single(
            run.Result.GeneratedTrees,
            tree => tree.FilePath.EndsWith("Example_Widget.g.cs", StringComparison.Ordinal)).ToString();
        Assert.Contains("Base = 1", generated, StringComparison.Ordinal);
        Assert.Contains("Third = 3", generated, StringComparison.Ordinal);
        Assert.DoesNotContain("Second =", generated, StringComparison.Ordinal);
    }
}
