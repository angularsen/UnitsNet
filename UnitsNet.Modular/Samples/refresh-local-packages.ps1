# Licensed under MIT No Attribution, see LICENSE file at the root.

<#
.SYNOPSIS
Packs the current UnitsNet.Modular checkout and force-restores every sample from the local feed.

.DESCRIPTION
Creates uniquely versioned UnitsNet.Modular and sample-definition packages so NuGet cannot reuse
stale global-cache entries, then restores every sample project to that exact version. Use this when
an IDE's optimized build path bypasses the repository's automatic LocalPackages preparation target.
#>

param(
  [ValidateSet('Debug', 'Release')]
  [string] $Configuration = 'Debug'
)

$ErrorActionPreference = 'Stop'

$repositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..')).Path
$packageProject = Join-Path $repositoryRoot 'UnitsNet.Modular\UnitsNet.Modular\UnitsNet.Modular.csproj'
$definitionPackageProject = Join-Path $PSScriptRoot 'SharedUnitsLibrarySample\Fictional.Measurements.Definitions\Fictional.Measurements.Definitions.csproj'
$localFeed = Join-Path $repositoryRoot 'Artifacts\Nugets'
$packageVersion = "6.0.0-local.dev.$([DateTime]::UtcNow.ToString('yyyyMMddHHmmssfff'))"

Write-Host "Packing UnitsNet.Modular $packageVersion from the current checkout..."
& dotnet pack `
    $packageProject `
    --configuration Release `
    --output $localFeed `
    -p:Platform=ProjectReferences `
    "-p:MinVerVersionOverride=$packageVersion"
if ($LASTEXITCODE -ne 0) {
  throw "Packing UnitsNet.Modular failed."
}

Write-Host "Packing the sample definition package $packageVersion..."
& dotnet pack `
    $definitionPackageProject `
    --configuration Release `
    --output $localFeed `
    -p:Platform=ProjectReferences `
    "-p:MinVerVersionOverride=$packageVersion" `
    "-p:PackageVersion=$packageVersion"
if ($LASTEXITCODE -ne 0) {
  throw "Packing the sample definition package failed."
}

$sampleProjects = Get-ChildItem -Path $PSScriptRoot -Recurse -Filter '*.csproj' |
    Sort-Object FullName

foreach ($sampleProject in $sampleProjects) {
  Write-Host "Force-restoring $($sampleProject.BaseName) from $localFeed..."
  & dotnet restore `
      $sampleProject.FullName `
      --force-evaluate `
      --no-cache `
      "-p:Configuration=$Configuration" `
      -p:Platform=LocalPackages `
      -p:UnitsNetModularSampleUpdateLocalPackagesOnBuild=false `
      "-p:UnitsNetModularSampleLocalVersion=$packageVersion"
  if ($LASTEXITCODE -ne 0) {
    throw "Restoring $($sampleProject.BaseName) failed."
  }
}

Write-Host "All UnitsNet.Modular samples now resolve local package version $packageVersion."
