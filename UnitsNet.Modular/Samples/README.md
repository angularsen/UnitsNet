# UnitsNet.Modular samples

Each sample has one distinct purpose. In Rider or Visual Studio, choose the normal `Debug` or
`Release` configuration together with the dependency platform that you want to exercise.

| Sample | Purpose |
|---|---|
| [Getting started](GettingStartedSample) | Minimal built-in `Length`, `Duration`, and `Speed` application matching the main quick start |
| [Quantity selection](QuantitySelectionSample) | Select individual quantities and filter their generated unit sets |
| [Custom quantity](CustomQuantitySample) | Generate an application-owned quantity from a JSON definition |
| [All SI profile](Profiles/AllSiProfileSample) | Include `AllSiProfile` and exercise its SI relationship chain |
| [Modular playground](ModularPlayground) | Explore parsing, arithmetic, metadata, serialization, relationships, and custom definitions |
| [Shared units library](SharedUnitsLibrarySample) | Generate quantities once in a class library and share their CLR types across multiple projects |

The broader playground complements the focused samples: it is intended for experimentation, while
the other projects keep one concept easy to find and copy.

## Run and debug in VS Code

Open the samples as the VS Code workspace:

```powershell
code UnitsNet.Modular/Samples
```

The workspace loads the samples-only solution automatically. In **Run and Debug**, choose any
`Sample: ...` configuration, then press `F5` to debug or `Ctrl+F5` to run without the debugger.
There is one launch configuration for each runnable sample; the shared-units configuration starts
its console application. These launches use `Debug | ProjectReferences`, so they build directly
from the current checkout without preparing packages.

Use **Terminal > Run Task > Samples: build** (or `Ctrl+Shift+B`) to build every sample. To prepare
fresh local packages for all samples, run the **Samples: refresh local packages** task.

## Choose the dependency source

The solution platform controls where every sample gets `UnitsNet.Modular`:

| Platform | Dependency source |
|---|---|
| `ProjectReferences` | Runtime and generator projects from the current checkout |
| `LocalPackages` | Fresh packages built into `Artifacts/Nugets` from the current checkout |
| `PublishedPackages` | The published `UnitsNet.Modular` package from NuGet.org |

`Debug | ProjectReferences` is the contributor-friendly default. The output and NuGet restore
state for each dependency platform are isolated, so switching the IDE selector cannot reuse stale
assets from another mode.

The same modes are available from the command line:

```powershell
dotnet build UnitsNet.Modular.slnx --configuration Debug -p:Platform=ProjectReferences
dotnet build UnitsNet.Modular.slnx --configuration Debug -p:Platform=LocalPackages
dotnet build UnitsNet.Modular.slnx --configuration Debug -p:Platform=PublishedPackages
```

Direct sample-project builds that do not specify `Platform` default to `ProjectReferences`.
`LocalPackages` builds update the packages automatically; pass
`-p:UnitsNetModularSampleUpdateLocalPackagesOnBuild=false` to use packages already in the local
feed. Override `UnitsNetModularPublishedVersion` to test a different published version.

If an IDE build bypasses the local-package build target, explicitly pack fresh, uniquely versioned
packages and force every sample project to restore them:

```powershell
pwsh UnitsNet.Modular/Samples/refresh-local-packages.ps1
```

Pass `-Configuration Release` to restore the samples for `Release | LocalPackages` instead.

The shared-units sample also contains an intentionally fictional definition package. In
`LocalPackages` mode both packages cross the local NuGet boundary. In the other modes the fictional
definitions remain source-local while `UnitsNet.Modular` comes from the selected dependency source.
