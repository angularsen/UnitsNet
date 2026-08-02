# Modular playground

This console app plans a day for an electric delivery van using mixed-unit route inputs, a parcel
manifest, driving estimates, and a charging stop. The generated quantity structs and unit enums
become part of this app at build time; no generated C# is checked in. Choose its dependency source
with the solution platform described in the [samples overview](../README.md).

The scenario is split into readable sections that exercise:

- parsing and defensive `TryParse` at input boundaries;
- numeric conversion, `As`, `ToUnit`, and formatted `ToString` output;
- arithmetic and collection aggregation across mixed units;
- generated `Length / Duration = Speed` and `Power * Duration = Energy` relationships;
- an application-specific `ParcelCount` generated from JSON;
- the selected-module registry and the legacy-shaped `Quantity` facade;
- explicit immutable `UnitSystem` policy and generated System.Text.Json support.

## Run it from VS Code

Open the samples workspace as described in the [samples overview](../README.md), choose
**Sample: Modular playground** in **Run and Debug**, then press `F5` to debug or `Ctrl+F5` to run
without the debugger. Output appears in the integrated terminal.

You can also open a terminal and run:

```shell
dotnet run
```

Every edit uses the usual .NET feedback loop: save a file and run `dotnet run` again.

## Refresh the local package

When using `Debug | LocalPackages` in an IDE, run the sample refresh script to create uniquely
versioned packages from the current checkout and force every sample to restore that exact version:

```powershell
pwsh ../refresh-local-packages.ps1
```

The unique version avoids reusing older packages from NuGet's global package cache. The script
packs the library and sample definition package in `Release`, then restores all samples for
`Debug | LocalPackages`; pass `-Configuration Release` to restore the release configuration instead.

## Experiment

Start with any of these:

1. In `ApplicationUnits.cs`, add or remove a built-in `IInclude<...>` quantity selection.
2. Change a `[UnitSet]` list and see which enum members remain available after rebuilding.
3. In `ParcelCount.unitsnet.json`, add a unit or change a conversion expression.
4. In `Program.cs`, use the generated types, conversions, parsing, formatting, or operators.

The project enables `EmitCompilerGeneratedFiles`, so after a build you can also inspect the emitted
C# under `obj/<dependency-platform>/<configuration>/<framework>/Generated/UnitsNet.Modular.Generator/UnitsNet.Modular.Generator.UnitsNetModularGenerator/`.
Delete or ignore that folder when you are done; it is build output and is not part of the project.

For the complete authoring model, see the [UnitsNet.Modular documentation](../../README.md).
