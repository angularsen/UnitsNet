<#
.SYNOPSIS
    Build, run tests and pack nugets for all Units.NET projects.
.DESCRIPTION
    This file builds everything and is run on the build server as part of
    building, testing and packing nugets for all master commits and pull requests.

    Publishing nugets is handled by nuget-publish.bat and run by the build server
    on the master branch.

    Optional strong name signing .pfx key file to produce signed binaries for the signed nugets.
.EXAMPLE
  powershell ./UpdateAssemblyInfo.ps1 c:\UnitsNet_Key.snk

.NOTES
    Author: Andreas Gullberg Larsen
    Last modified: June 1, 2017
    #>
[CmdletBinding()]
Param()

remove-module build-functions -ErrorAction SilentlyContinue
import-module $PSScriptRoot\build-functions.psm1

try {
  Remove-ArtifactsDir
  Start-NugetRestore
  Update-GeneratedCode
  Start-Build
  Start-Tests
  Start-PackNugets
  Compress-ArtifactsAsZip
}
catch {
  $myError = $_.Exception.ToString()
  write-error "Failed to build.`n---`n$myError' ]"
  exit 1
}
