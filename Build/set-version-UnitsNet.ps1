<# .SYNOPSIS
  Updates the version of all UnitsNet core projects.
.DESCRIPTION
  Updates the <Version> property of the .csproj project files and versions of AssemblyInfo.cs files.
.PARAMETER set
  Set new version
.PARAMETER bump
  Bump major, minor, patch or semver suffix number. Only one can be specified at a time, and bumping one part will reset all the lesser parts.
.EXAMPLE
  Set new version.
  -version 2.3.4-beta3: 1.0.0 => 2.3.4-beta3
.EXAMPLE
  Bump the major, minor, patch or suffix part of the version.
  -bump major: 1.2.3-alpha1 => 2.0.0
  -bump minor: 1.2.3-alpha1 => 1.3.0
  -bump patch: 1.2.3-alpha1 => 1.2.4
  -bump suffix: 1.2.3-alpha => 1.2.3-alpha2
  -bump suffix: 1.2.3-alpha2 => 1.2.3-alpha3
  -bump suffix: 1.2.3-beta2 => 1.2.3-beta3
  -bump suffix: 1.2.3-rc2 => 1.2.3-rc3

.NOTES
  Author: Andreas Gullberg Larsen
  Date:   Feb 8, 2014
  Based on original work by Luis Rocha from: http://www.luisrocha.net/2009/11/setting-assembly-version-with-windows.html
  #>
  [CmdletBinding()]
  Param(
    [Parameter(Mandatory=$true, Position=0, ParameterSetName="set", HelpMessage="Set version string")]
    [Alias("version")]
    [string]$setVersion,

    [Parameter(Mandatory=$true, Position=0, ParameterSetName="bump", HelpMessage="Bump one or more version parts")]
    [Alias("bump")]
    [ValidateSet('major','minor','patch','suffix')]
    [string]$bumpVersion
    )

  function Help {
    "Sets the version of .csproj (or .props) files as well as versions in AssemblyInfo.cs files.`n"
    ".\set-version.ps1 -Version 1.2.3-alpha`n"
    ".\set-version.ps1 -Bump Major`n"
    ".\set-version.ps1 -Bump Minor`n"
    ".\set-version.ps1 -Bump Patch`n"
    ".\set-version.ps1 -Bump Suffix`n"
  }

# Import functions: Get-NewProjectVersion, Set-ProjectVersion, Set-AssemblyInfoVersion, Invoke-CommitAndTagVersion
Import-Module "$PSScriptRoot\set-version.psm1"

$root = Resolve-Path "$PSScriptRoot\.."
$paramSet = $PsCmdlet.ParameterSetName
$projFile = "$root\UnitsNet\UnitsNet.csproj"
$winrtAssemblyInfoFile = "$root\UnitsNet.WindowsRuntimeComponent\Properties\AssemblyInfo.cs"
$winrtNuspecFile = "$root\UnitsNet.WindowsRuntimeComponent\UnitsNet.WindowsRuntimeComponent.nuspec"
$versionFiles = @($projFile, $winrtAssemblyInfoFile, $winrtNuspecFile)
$projectName = "UnitsNet"

# Use UnitsNet.Common.props version as base if bumping major/minor/patch
$newVersion = Get-NewProjectVersion $projFile $paramSet $setVersion $bumpVersion

Set-ProjectVersion $projFile $newVersion
Set-AssemblyInfoVersion $winrtAssemblyInfoFile $newVersion
Set-NuspecVersion $winrtNuspecFile $newVersion
Invoke-CommitAndTagVersion $projectName $versionFiles $newVersion
