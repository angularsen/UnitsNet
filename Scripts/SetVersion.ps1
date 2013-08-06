#-------------------------------------------------------------------------------
# Description: Sets the AssemblyVersion and AssemblyFileVersion of 
#              AssemblyInfo.cs files.
#			   Sets the <version></version> element of UnitsNet.nuspec file.
#
# Based on original work by Luis Rocha from: http://www.luisrocha.net/2009/11/setting-assembly-version-with-windows.html
#
# Author: Andreas Larsen
# Version: 1.0
#-------------------------------------------------------------------------------

#-------------------------------------------------------------------------------
# Displays how to use this script.
#-------------------------------------------------------------------------------
function Help {
	"Sets the AssemblyVersion and AssemblyFileVersion of AssemblyInfo.cs files`n"
	".\SetVersion.ps1 [VersionNumber]`n"
	"   [VersionNumber]     The version number to set, for example: 1.1.9301.0"
	"                       If not provided, a version number will be generated.`n"
}
 
#-------------------------------------------------------------------------------
# Update version numbers of AssemblyInfo.cs
#-------------------------------------------------------------------------------
function Update-AssemblyInfoFiles ([string] $version) {
	$assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
	$fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
	$assemblyVersion = 'AssemblyVersion("' + $version + '")';
	$fileVersion = 'AssemblyFileVersion("' + $version + '")';
	
	Get-ChildItem ..\ -r | Where { $_.PSChildName -match "^AssemblyInfo\.cs$"} | ForEach-Object {
		$filename = $_.Directory.ToString() + '\' + $_.Name
		$filename + ' -> ' + $version
		
		# If you are using a source control that requires to check-out files before 
		# modifying them, make sure to check-out the file here.
		# For example, TFS will require the following command:
		# tf checkout $filename
	
		(Get-Content $filename -Encoding UTF8) | ForEach-Object {
			% {$_ -replace $assemblyVersionPattern, $assemblyVersion } |
			% {$_ -replace $fileVersionPattern, $fileVersion }
		} | Set-Content $filename -Encoding UTF8
	}	
}

#-------------------------------------------------------------------------------
# Update version numbers of UnitsNet.nuspec
#-------------------------------------------------------------------------------
function Update-NuspecFiles ([string] $version) {
	$nugetVersionPattern = '<version>.*?</version>';
	$nugetVersion = '<version>'+$version+'</version>';
	
	Get-ChildItem ..\ -r | Where { $_.PSChildName -match "^UnitsNet\.nuspec$"} | ForEach-Object {
		$filename = $_.Directory.ToString() + '\' + $_.Name
		$filename + ' -> ' + $version
		
		# If you are using a source control that requires to check-out files before 
		# modifying them, make sure to check-out the file here.
		# For example, TFS will require the following command:
		# tf checkout $filename
	
		(Get-Content $filename -Encoding UTF8) | ForEach-Object {
			% {$_ -replace $nugetVersionPattern, $nugetVersion }
		} | Set-Content $filename -Encoding UTF8
	}
}

#-------------------------------------------------------------------------------
# Update <releaseNotes> element in UnitsNet.nuspec
#-------------------------------------------------------------------------------
function Update-NuspecFileReleaseNotes ([string] $releaseInfo) {
	$nugetReleaseNotesPattern = '<releaseNotes>.*?</releaseNotes>';
	$nugetReleaseNotes = '<releaseNotes>'+$releaseInfo+'</releaseNotes>';
	
	Get-ChildItem ..\ -r | Where { $_.PSChildName -match "^UnitsNet\.nuspec$"} | ForEach-Object {
		$filename = $_.Directory.ToString() + '\' + $_.Name
		$filename + ' -> ' + $releaseInfo
		
		# If you are using a source control that requires to check-out files before 
		# modifying them, make sure to check-out the file here.
		# For example, TFS will require the following command:
		# tf checkout $filename
	
		(Get-Content $filename -Encoding UTF8) | ForEach-Object {
			% {$_ -replace $nugetReleaseNotesPattern, $nugetReleaseNotes }
		} | Set-Content $filename -Encoding UTF8
	}
}

function BumpVersion([string] $currentVersion) {
	$versionParts = $currentVersion.split(".")
	$minor = [Int]($versionParts[1]) + 1

	$versionPattern = "(\d)\.(\d)\.(\d)"
	$versionReplacePattern = '$1.'+$minor+'.$3'

	$version = $currentVersion -replace $versionPattern, $versionReplacePattern
	return $version;
}

#-------------------------------------------------------------------------------
# Parse arguments.
#-------------------------------------------------------------------------------
#$version = $args[0]

$NuSpecFilePath = "..\UnitsNet.nuspec"
[ xml ]$nuspecXml = Get-Content -Path $NuSpecFilePath

$currentVersion = $nuspecXml.package.metadata.version
$newVersion = BumpVersion($currentVersion)

$nuspecXml.package.metadata.version = $newVersion
$nuspecXml.Save($NuSpecFilePath)

"Current version: " + $currentVersion
"New version: " + $newVersion

$releaseNotes = Read-Host 'Enter release notes for .nuspec file'

Update-AssemblyInfoFiles $newVersion
Update-NuspecFiles $newVersion
Update-NuspecFileReleaseNotes $releaseNotes

