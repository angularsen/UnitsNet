<#
.SYNOPSIS
    Build, run tests and pack nugets for all Units.NET projects.
.DESCRIPTION
    This file builds everything and is run on the build server as part of
    building, testing and packing nugets for all master commits and pull requests.

    Publishing nugets is handled by nuget-publish.bat and run by the build server
    on the master branch.
.PARAMETER skipUWP
    If flag is set, will skip the UWP (Windows Runtime Component) build step as this requires
    some large, extra Visual Studio features to be installed.
.EXAMPLE
  powershell ./build.ps1
  powershell ./build.ps1 -IncludeWindowsRuntimeComponent -IncludeNanoFramework

.NOTES
    Author: Andreas Gullberg Larsen
    Last modified: Jan 21, 2018
    #>
[CmdletBinding()]
Param(
    [switch] $IncludeWindowsRuntimeComponent,
    [switch] $IncludeNanoFramework
  )

remove-module build-functions -ErrorAction SilentlyContinue
import-module $PSScriptRoot\build-functions.psm1

try {
  & "$PSScriptRoot/init.ps1" # Ensure tools are downloaded

  Remove-ArtifactsDir
  Update-GeneratedCode
  Start-Build -IncludeWindowsRuntimeComponent $IncludeWindowsRuntimeComponent -IncludeNanoFramework $IncludeNanoFramework
  Start-Tests
  Start-PackNugets -IncludeNanoFramework $IncludeNanoFramework
  Compress-ArtifactsAsZip
}
catch {
  $myError = $_.Exception.ToString()
  write-error "Failed to build.`n---`n$myError' ]"
  exit 1
}
