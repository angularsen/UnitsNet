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
# Generate a version number.
# Note: customize this function to generate it using your version schema.
#-------------------------------------------------------------------------------
function Generate-VersionNumber {
	$today = Get-Date
	return "1.0." + ( ($today.year - 2000) * 1000 + $today.DayOfYear )+ ".0"
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
# Parse arguments.
#-------------------------------------------------------------------------------
$version = $args[0]
while ($version -notmatch "[0-9]+(\.([0-9]+|\*)){1,3}") {
	if ($version -eq '/?') {
		Help
	}
	else {
		"About to update the version of nuget package .nuspec and AssemblyInfo.cs files."
		$version = Read-Host 'Enter new version'
	}
}

Update-AssemblyInfoFiles $version
Update-NuspecFiles $version


