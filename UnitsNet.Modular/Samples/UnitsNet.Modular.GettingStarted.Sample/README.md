# UnitsNet.Modular getting started

This minimal console app matches the two-file quick start in the main
[UnitsNet.Modular documentation](../../README.md). It selects `Length`, `Duration`, and `Speed`,
then constructs, parses, converts, and combines the generated quantities.

In an ordinary application, install the package and copy `ApplicationUnits.cs` and `Program.cs`:

```shell
dotnet add package UnitsNet.Modular --prerelease
dotnet run
```

The project file in this repository contains additional maintainer-only automation that packs the
current checkout to the repository-local NuGet feed before restoring the sample. Consumers do not
need that import or any of the `UnitsNetModularSample*` properties.

Run the repository scenario from its root with:

```powershell
pwsh UnitsNet.Modular/Samples/UnitsNet.Modular.GettingStarted.Sample/run.ps1
```
