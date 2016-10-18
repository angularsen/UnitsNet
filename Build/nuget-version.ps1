<# .SYNOPSIS
	Update the project version.
.DESCRIPTION
	Updates the nuget .nuspec file and all AssemblyInfo.cs files.
.PARAMETER set
	Set new version
.PARAMETER bump
	Bump major, minor, patch or semver label number. Only one can be specified at a time, and bumping one part will reset all the lesser parts.	
.EXAMPLE
	Set new version.
	-v 2.3.4-beta3: 1.0.0 => 2.3.4-beta3	
.EXAMPLE
	Bump the major, minor, patch or label part of the version.
	-b major: 1.2.3-alpha1 => 2.0.0
	-b minor: 1.2.3-alpha1 => 1.3.0
	-b patch: 1.2.3-alpha1 => 1.2.4
	-b label: 1.2.3-alpha => 1.2.3-alpha2
	-b label: 1.2.3-alpha2 => 1.2.3-alpha3
	-b label: 1.2.3-beta2 => 1.2.3-beta3
	-b label: 1.2.3-rc2 => 1.2.3-rc3
	
.NOTES
	Author: Andreas Gullberg Larsen
	Date:   Feb 8, 2014
	Based on original work by Luis Rocha from: http://www.luisrocha.net/2009/11/setting-assembly-version-with-windows.html
	#>
	[CmdletBinding()]
	Param(  
		[Parameter(Mandatory=$true, Position=0, ParameterSetName="set", HelpMessage="Set version string")] 
		[Alias("v")] 
		[string]$setVersion,
		[Parameter(Mandatory=$true, Position=0, ParameterSetName="bump", HelpMessage="Bump one or more version parts")] 

		[Alias("b")] 
		[ValidateSet('major','minor','patch','label')]
		[string]$bumpVersion
		)

	function Help {
		"Sets the AssemblyVersion and AssemblyFileVersion of AssemblyInfo.cs files`n"
		".\SetVersion.ps1 [VersionNumber]`n"
		"   [VersionNumber]     The version number to set, for example: 1.1.9301.0"
		"                       If not provided, a version number will be generated.`n"
	}

	function Update-NuspecVersion([string] $nuspecPath, [xml] $nuspecXml, [string] $newSemVer) {
		Write-Host "$nuspecPath -> $newSemVer"
		$nuspecXml.package.metadata.version = $newSemVer
		$nuspecXml.Save($nuspecPath)
	}

	function BumpMajor ([Version] $currentVersion) {
		return New-Object System.Version -ArgumentList ($currentVersion.Major+1), 0, 0
	}

	function BumpMinor([Version] $currentVersion) {
		return New-Object System.Version -ArgumentList $currentVersion.Major, ($currentVersion.Minor+1), 0
	}

	function BumpPatch([Version] $currentVersion) {    
		return New-Object System.Version -ArgumentList $currentVersion.Major, $currentVersion.Minor, ($currentVersion.Build+1);
	}

	function BumpLabel([string] $label) {
		$label = $label.Trim()
		#if ($label -eq "alpha") {	return "alpha2"; }
		#if ($label -eq "beta") { return "beta2"; }	

		# alpha, beta and rc labels supported
		# Example:
		# alpha => alpha2
		# alpha1 => alpha2	
		$match = [regex]::Match($label, '^-(alpha|beta|rc)(\d+)?$');
		$label = $match.Groups[1].Value
		$numberGroup = $match.Groups[2]

		$number = if ($numberGroup.Success) { 1+$match.Groups[2].Value } else { 2 }
		return [string]::Format("-{0}{1}", $label, $number)
	}

	function Update-NuspecFile([string] $nuspecPath) {
		try {
			#-------------------------------------------------------------------------------
			# Parse arguments.
			#-------------------------------------------------------------------------------
			[ xml ]$nuspecXml = Get-Content -Path $nuspecPath

			# Split "1.2.3-alpha" into ["1.2.3", "alpha"]
			# Split "1.2.3" into ["1.2.3"]
			$currentSemVer = $nuspecXml.package.metadata.version
			$semVerVersionParts = $currentSemVer.Split('-')
			$currentVersion = [Version]$null
			if (-not [Version]::TryParse($semVerVersionParts[0], [ref] $currentVersion)) {
				$currentVersion = new-object System.Version("0.0.0")
			}
			$currentLabel = if ($semVerVersionParts.Length -eq 2) { "-" + $semVerVersionParts[1]} else { "" }

			$newVersion = $currentVersion
			$newLabel = $currentLabel

			switch ($PsCmdlet.ParameterSetName) {
				"set" {		
					$newSemVer = $setVersion
					$newSemVerVersionParts = $newSemVer.Split('-')

					$newVersion = [Version]::Parse($newSemVerVersionParts[0])
					$newLabel = if ($newSemVerVersionParts.Length -eq 2) { "-" + $newSemVerVersionParts[1]} else { "" }
				}
				"bump" {	
					switch ($bumpVersion) {
						"major" {
							$newVersion = BumpMajor $newVersion 
							$newLabel = ""
						}
						"minor" { 
							$newVersion = BumpMinor $newVersion 
							$newLabel = ""
						}	
						"patch" { 
							$newVersion = BumpPatch $newVersion 
							$newLabel = ""
						}
						"label" { 
							$newLabel = BumpLabel $newLabel
						}
					}		
					$newSemVer = $newVersion.ToString() + $newLabel
				}
			}

			Update-NuspecVersion $nuspecPath $nuspecXml $newSemVer
			return $newSemVer
		}
		catch {
			$myError = $error[0]
			Write-Error "ERROR: Failed to update build parameters from .nuspec file: `n$myError' ]"
			exit 1
		}
	}


$nuspecPaths = "UnitsNet.nuspec", "UnitsNet.WindowsRuntimeComponent.nuspec"
$newSemVer = $null
foreach ($path in $nuspecPaths) { 
	$newSemVer = Update-NuspecFile $path
}

git add UnitsNet.nuspec UnitsNet.WindowsRuntimeComponent.nuspec
git commit -m "UnitsNet: $newSemVer"
git tag $newSemVer

Write-Host "New tag: $newSemVer"