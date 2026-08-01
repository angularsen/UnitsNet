# Shared units library sample

This multi-project sample generates quantities once in `SharedUnitsLibrarySample.Units` and shares
those exact CLR types with a domain library and console application. It demonstrates the assembly
boundary an application can use when several projects need the same generated quantities.

The projects have deliberately separate responsibilities:

- `Fictional.Measurements.Definitions` supplies reusable quantity specifications, JSON definitions,
  localization, and relationships. It contains no generated quantity structs.
- `SharedUnitsLibrarySample.Units` selects the built-in and fictional definitions and owns the
  generated types.
- `SharedUnitsLibrarySample.Domain` consumes those types in domain logic.
- `SharedUnitsLibrarySample.App` references both libraries and proves that the generated types have
  one shared assembly identity.

## Dependency modes

Choose `ProjectReferences`, `LocalPackages`, or `PublishedPackages` in the solution platform
selector. See the [samples overview](../README.md) for the complete mode matrix.

In `LocalPackages` mode, both `UnitsNet.Modular` and the fictional definition provider are packed
and consumed through `PackageReference`. This validates that the definition package contributes its
`build/*.props` files like an external package.

In `ProjectReferences` and `PublishedPackages` modes, the fictional provider remains a project
reference and its JSON files are included explicitly because project references do not import NuGet
`build/*.props`. `UnitsNet.Modular` still comes from the selected source.

Run the complete scenario from the repository root:

```powershell
dotnet run `
  --project UnitsNet.Modular/Samples/SharedUnitsLibrarySample/SharedUnitsLibrarySample.App/SharedUnitsLibrarySample.App.csproj `
  --configuration Debug `
  -p:Platform=ProjectReferences
```
