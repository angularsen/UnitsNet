<#
.SYNOPSIS
    Update AssemblyInfo.cs files.
.DESCRIPTION
    Sets the AssemblyVersion and AssemblyFileVersion of AssemblyInfo.cs files.
.EXAMPLE
  Set new version.
  powershell UpdateAssemblyInfo.ps1 1.2.3.4

.NOTES
    Author: Andreas Gullberg Larsen
    Date:   May 2, 2014
    Based on original work by Luis Rocha from: http://www.luisrocha.net/2009/11/setting-assembly-version-with-windows.html
#>
[CmdletBinding()]

$root=Resolve-Path "$PSScriptRoot\.."

#-------------------------------------------------------------------------------
# Displays how to use this script.
#-------------------------------------------------------------------------------
function Help {
  "Sets the AssemblyVersion and AssemblyFileVersion of AssemblyInfo.cs files`n"
  ".\UpdateAssemblyInfo.ps1 [VersionNumber]`n"
  "   [VersionNumber]     The version number to set, for example: 1.1.9301.0"
}

#-------------------------------------------------------------------------------
# Returns the <version></version> element value of the .nuspec file.
#-------------------------------------------------------------------------------
function Get-VersionFromNuspec ([string] $nuspecFilePath) {


  [ xml ]$nuspecXml = Get-Content -Path $nuspecFilePath
  $semVerVersionParts = $nuspecXml.package.metadata.version.Split('-')
  $version = [Version]::Parse($semVerVersionParts[0])

  Write-Host "Read <version> of $($nuspecFilePath): $version"
  return $version;
}

#-------------------------------------------------------------------------------
# Description: Sets the AssemblyVersion and AssemblyFileVersion of
#              AssemblyInfo.cs files.
#
# Author: Andreas Larsen
# Version: 1.0
#-------------------------------------------------------------------------------
function Update-AssemblyInfoFiles ([string] $nuspecFilePath, [string] $assemblyInfoFilePath) {

    [Version]$version = Get-VersionFromNuspec "$root\$nuspecFilePath"

    $assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
    $fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
    $assemblyVersion = 'AssemblyVersion("' + $version + '")';
    $fileVersion = 'AssemblyFileVersion("' + $version + '")';

    Get-ChildItem "$root\$assemblyInfoFilePath" | ForEach-Object {
        $filename = $_.Directory.ToString() + '\' + $_.Name
        $filename + ' -> ' + $version

        (Get-Content $filename -Encoding UTF8) | ForEach-Object {
            % {$_ -replace $assemblyVersionPattern, $assemblyVersion } |
            % {$_ -replace $fileVersionPattern, $fileVersion }
        } | Set-Content $filename -Encoding UTF8
    }
}

try {
  "Updating assembly info to version: $setVersion"
  ""
  Update-AssemblyInfoFiles "Build\UnitsNet.nuspec" "UnitsNet\Properties\AssemblyInfo.cs"
  Update-AssemblyInfoFiles "Build\UnitsNet.WindowsRuntimeComponent.nuspec" "UnitsNet\Properties\AssemblyInfo.WindowsRuntimeComponent.cs"
  Update-AssemblyInfoFiles "Build\UnitsNet.Serialization.JsonNet.nuspec" "UnitsNet.Serialization.JsonNet\Properties\AssemblyInfo.cs"
}
catch {
  $myError = $_.Exception.ToString()
    Write-Error "Failed to update AssemblyInfo files: `n$myError' ]"
    exit 1
}