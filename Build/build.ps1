<#
.SYNOPSIS
    Build, run tests and pack nugets for all Units.NET projects.
.DESCRIPTION
    This file builds everything and is run on the build server as part of
    building, testing and packing nugets for all master commits and pull requests.

    Publishing nugets is handled by nuget-publish.bat and run by the build server
    on the master branch.
.EXAMPLE
  powershell ./build.ps1

.NOTES
    Author: Andreas Gullberg Larsen
    Last modified: Jan 21, 2018
    #>
[CmdletBinding()]
Param()

remove-module build-functions -ErrorAction SilentlyContinue
import-module (Join-Path $PSScriptRoot "build-functions.psm1")

try {
  & "$PSScriptRoot/init.ps1" # Ensure tools are downloaded

  Remove-ArtifactsDir
  Update-GeneratedCode

  # Build main projects with dotnet CLI (cross-platform)
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
