# Licensed under MIT No Attribution, see LICENSE file at the root.

$ErrorActionPreference = 'Stop'

$repositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
$sampleProject = Join-Path $PSScriptRoot 'GettingStartedSample.csproj'
$restoreId = [DateTime]::UtcNow.ToString('yyyyMMddHHmmssfff')
$restorePackages = Join-Path $repositoryRoot "Artifacts\GettingStartedSample\packages\$restoreId"

# The sample's local build dependency packs and restores the latest package before compilation.
& dotnet run `
    --project $sampleProject `
    --configuration Debug `
    -p:Platform=LocalPackages `
    "-p:RestorePackagesPath=$restorePackages"
if ($LASTEXITCODE -ne 0) {
    throw "Running the getting-started sample failed."
}
