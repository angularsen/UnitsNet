# UnitsNet.Modular getting started

This minimal console app matches the two-file quick start in the main
[UnitsNet.Modular documentation](../../README.md). It selects `Length`, `Duration`, and `Speed`,
then constructs, parses, converts, and combines the generated quantities.

In an ordinary application, install the package and copy `ApplicationUnits.cs` and `Program.cs`:

```shell
dotnet add package UnitsNet.Modular --prerelease
dotnet run
```

In this repository the same project supports all three dependency platforms described in the
[samples overview](../README.md). Choose `PublishedPackages` to mirror the ordinary application,
`LocalPackages` to test a package built from this checkout, or `ProjectReferences` while developing.

Run the repository scenario from its root with:

```powershell
pwsh UnitsNet.Modular/Samples/GettingStartedSample/run.ps1
```

The script selects `Debug | LocalPackages` and uses an isolated package cache.
