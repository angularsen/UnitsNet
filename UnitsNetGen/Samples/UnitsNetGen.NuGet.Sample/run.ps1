# Licensed under MIT No Attribution, see LICENSE file at the root.

$ErrorActionPreference = 'Stop'

$repositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
$sampleProject = Join-Path $PSScriptRoot 'UnitsNetGen.NuGet.Sample.csproj'
$restoreId = [DateTime]::UtcNow.ToString('yyyyMMddHHmmssfff')
$restorePackages = Join-Path $repositoryRoot "Artifacts\UnitsNetGen.NuGet.Sample\packages\$restoreId"

# The sample's local build dependency packs and restores the latest package before compilation.
& dotnet run `
    --project $sampleProject `
    -p:ImportDirectoryBuildProps=false `
    -p:ImportDirectoryBuildTargets=false `
    "-p:RestorePackagesPath=$restorePackages"
if ($LASTEXITCODE -ne 0) {
    throw "Running the NuGet sample failed."
}
