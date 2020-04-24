<# .SYNOPSIS
  Updates the version of all UnitsNet.Serialiation.JsonNet projects.
.DESCRIPTION
  Updates the <Version> property of the .csproj project files.
.PARAMETER set
  Set new version
.PARAMETER bump
  Bump major, minor, patch or semver suffix number. Only one can be specified at a time, and bumping one part will reset all the lesser parts.
.EXAMPLE
  Set new version.
  -v 2.3.4-beta3: 1.0.0 => 2.3.4-beta3
.EXAMPLE
  Bump the major, minor, patch or suffix part of the version.
  -b major: 1.2.3-alpha1 => 2.0.0
  -b minor: 1.2.3-alpha1 => 1.3.0
  -b patch: 1.2.3-alpha1 => 1.2.4
  -b suffix: 1.2.3-alpha => 1.2.3-alpha2
  -b suffix: 1.2.3-alpha2 => 1.2.3-alpha3
  -b suffix: 1.2.3-beta2 => 1.2.3-beta3
  -b suffix: 1.2.3-rc2 => 1.2.3-rc3

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
    "Sets the AssemblyVersion and AssemblyFileVersion of AssemblyInfo.cs files`n"
    ".\SetVersion.ps1 [VersionNumber]`n"
    "   [VersionNumber]     The version number to set, for example: 1.1.9301.0"
    "                       If not provided, a version number will be generated.`n"
  }

# Import functions: Get-NewProjectVersion, Set-ProjectVersion, Invoke-CommitAndTagVersion
Import-Module "$PSScriptRoot\set-version.psm1"

$root = Resolve-Path "$PSScriptRoot\.."
$paramSet = $PsCmdlet.ParameterSetName
$projFile = "$root\UnitsNet.Serialization.JsonNet\UnitsNet.Serialization.JsonNet.csproj"
$versionFiles = @($projFile)
$projectName = "JsonNet"

# Use UnitsNet.Common.props version as base if bumping major/minor/patch
$newVersion = Get-NewProjectVersion $projFile $paramSet $setVersion $bumpVersion

Set-ProjectVersion $projFile $newVersion
Invoke-CommitAndTagVersion $projectName $versionFiles $newVersion
