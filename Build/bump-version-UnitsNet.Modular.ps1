<# .SYNOPSIS
  Creates an annotated UnitsNet.Modular release tag with a bumped version.
.DESCRIPTION
  Finds the nearest reachable UnitsNet.Modular/* tag, bumps its minor, patch, or prerelease suffix,
  and creates an annotated tag on HEAD. MinVer uses that tag to version both UnitsNet.Modular and
  UnitsNet.Core.

  Minor and patch bumps remove any prerelease suffix, matching the existing UnitsNet version scripts.
  A suffix bump increments the final numeric prerelease identifier, for example alpha.1 to alpha.2.
  After a stable tag, a suffix bump starts the next patch prerelease at alpha.1, matching MinVer's
  post-release version range.
.PARAMETER Bump
  The semantic version component to bump: minor, patch, or suffix.
.EXAMPLE
  ./Build/bump-version-UnitsNet.Modular.ps1 -Bump suffix
.EXAMPLE
  ./Build/bump-version-UnitsNet.Modular.ps1 -Bump minor -WhatIf
#>
[CmdletBinding(SupportsShouldProcess = $true)]
Param(
  [Parameter(Mandatory = $true, Position = 0)]
  [ValidateSet("minor", "patch", "suffix")]
  [string] $Bump
)

$ErrorActionPreference = "Stop"
$tagPrefix = "UnitsNet.Modular/"
$repositoryRoot = Resolve-Path "$PSScriptRoot\.."

Remove-Module set-version -ErrorAction Ignore
Import-Module "$PSScriptRoot\set-version.psm1"

function Invoke-Git([string[]] $Arguments) {
  $output = & git -C $repositoryRoot @Arguments 2>&1
  if ($LASTEXITCODE -ne 0) {
    throw "git $([string]::Join(' ', $Arguments)) failed:`n$([string]::Join([Environment]::NewLine, $output))"
  }

  return $output
}

$status = Invoke-Git @("status", "--porcelain", "--untracked-files=normal")
if ($status) {
  throw "The working tree must be clean before tagging a release."
}

$latestTag = [string](Invoke-Git @(
  "describe",
  "--tags",
  "--abbrev=0",
  "--match",
  "$tagPrefix*",
  "HEAD"
))
$latestTag = $latestTag.Trim()

if (!$latestTag.StartsWith($tagPrefix, [StringComparison]::OrdinalIgnoreCase)) {
  throw "Latest tag '$latestTag' does not start with '$tagPrefix'."
}

$currentVersion = $latestTag.Substring($tagPrefix.Length)
if ($Bump -eq "suffix" -and !$currentVersion.Contains("-")) {
  $nextPatchVersion = Get-BumpedSemanticVersion $currentVersion "patch"
  $newVersion = Get-BumpedSemanticVersion "$nextPatchVersion-alpha.0" "suffix" "alpha.0"
}
else {
  $newVersion = Get-BumpedSemanticVersion $currentVersion $Bump "alpha.0"
}
$newTag = "$tagPrefix$newVersion"

& git -C $repositoryRoot rev-parse --verify --quiet "refs/tags/$newTag" *> $null
if ($LASTEXITCODE -eq 0) {
  throw "Tag '$newTag' already exists."
}

$message = "UnitsNet.Modular $newVersion"
if ($PSCmdlet.ShouldProcess("HEAD", "Create annotated tag '$newTag'")) {
  Invoke-Git @("tag", "--annotate", $newTag, "--message", $message, "HEAD") | Out-Null
  Write-Host "Created annotated tag $newTag"
  Write-Host "Push it with: git push origin $newTag"
}
