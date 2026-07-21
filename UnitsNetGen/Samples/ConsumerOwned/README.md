# Consumer-owned generation samples

`ConsumerOwned.Units` is the canonical consumer setup. It references locally packed `UnitsNetGen`
and `Fictional.Measurements.Definitions` packages, and the definition package contributes its JSON
and relationships through `build/*.props`, just as it would for an external consumer.

`ConsumerOwned.Units.ProjectReferences` is the repository-maintainer setup. It compiles the exact
same linked `ApplicationUnits.cs`, but references the runtime, generator, and definition provider
projects directly. Because a `ProjectReference` does not import a NuGet package's `build/*.props`,
this project also includes the provider's definition and relation files explicitly.

`ConsumerOwned.Domain` and `ConsumerOwned.Reporting` reference the canonical package-facing units
project. They demonstrate that an application generates its quantities in one assembly and shares
those exact CLR types between downstream projects.

Build both dependency modes:

```powershell
dotnet build UnitsNetGen/Samples/ConsumerOwned/ConsumerOwned.Units/ConsumerOwned.Units.csproj
dotnet build `
  UnitsNetGen/Samples/ConsumerOwned/ConsumerOwned.Units.ProjectReferences/ConsumerOwned.Units.ProjectReferences.csproj
```

Debug builds of the package-facing project incrementally repack changed local sources before
restore. Set `UnitsNetGenSampleUpdateLocalPackagesOnBuild=true` for another configuration or
`false` to use the newest packages already present in `Artifacts/Nugets`.
