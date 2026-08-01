function Get-NewProjectVersion(
  [string]$projectPath,
  [string]$paramSet,
  [string]$setVersionParam,
  [string]$bumpVersionParam) {
  switch ($paramSet) {
    "set" {
      return $setVersionParam
    }
    "bump" {
      return Get-BumpedProjectVersion $projectPath $bumpVersionParam
    }
    default {
      throw "Parameter set not implemented: $paramSet"
    }
  }
}

function Invoke-StashPush() {
  $oldSha=$(git rev-parse -q --verify refs/stash)
  git reset --quiet
  git stash push --include-untracked --message "Before version bump" --quiet
  $newSha=$(git rev-parse -q --verify refs/stash)
  return $oldSha -ne $newSha
}

function Invoke-StashPop() {
  git stash pop --quiet
}

function Invoke-CommitVersionBump(
  [string[]]$projectNames,
  [string] $newSemVer) {
  try {
    $projectNamesConcat = [string]::Join(", ", $projectNames)
    Write-Host -Foreground Green "Committing new version: $newSemVer"
    git commit -a -m "${projectNamesConcat}: $newSemVer"
  }
  catch {
    $err = $PSItem.Exception
    Write-Error "ERROR: Failed to commit version: `n---`n$err`n---`n$($PSItem.ScriptStackTrace)"
    exit 1
  }
}

function Invoke-TagVersionBump(
  [string] $projectName,
  [string] $newSemVer) {
    git tag -a "$projectName/$newSemVer" -m "$projectName/$newSemVer" -m "TODO List changes here"
}

function Set-ProjectVersion([string] $file, [string] $version) {
  $assemblyVersion = $version  -replace "(\d+)(?:\.\d+)+.*", '$1.0.0.0'
  Write-Host "$file -> $version (AssemblyVersion $assemblyVersion)"
  (Get-Content $file) -replace '<Version>.*?</Version>', "<Version>$version</Version>" | Set-Content $file
  (Get-Content $file) -replace '<AssemblyVersion>.*?</AssemblyVersion>', "<AssemblyVersion>$assemblyVersion</AssemblyVersion>" | Set-Content $file
}

function Set-AssemblyInfoVersion([string] $file, [string] $version) {
  # Strip out any suffix: "4.0.0-alpha1" => "4.0.0"
  $version = $version.Split('-')[0]
  Write-Host "$file -> $version"
  (Get-Content $file) -replace 'Assembly(File)?Version\(".*?"\)', "Assembly`$1Version(`"$version`")" | Set-Content $file
}

function Set-NuspecVersion([string] $file, [string] $version) {
  Write-Host "$file -> $version"
  (Get-Content $file) -replace '<version>.*?</version>', "<version>$version</version>" | Set-Content $file
}

function Get-BumpedProjectVersion([string] $projectPath, [string] $bumpVersion) {
  [xml]$projectXml = Get-Content -Path $projectPath

  $oldSemVer = [string]($projectXml.Project.PropertyGroup.Version)[0]

  return Get-BumpedSemanticVersion $oldSemVer $bumpVersion
}

function Get-BumpedSemanticVersion(
  [string] $semanticVersion,
  [string] $bumpVersion,
  [string] $defaultPreReleaseIdentifiers = "alpha000") {
  $match = [regex]::Match(
    $semanticVersion,
    '^(?<major>0|[1-9][0-9]*)\.(?<minor>0|[1-9][0-9]*)\.(?<patch>0|[1-9][0-9]*)(?:-(?<prerelease>[0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?(?:\+(?<metadata>[0-9A-Za-z-]+(?:\.[0-9A-Za-z-]+)*))?$')

  if (!$match.Success) {
    throw "Unable to parse semantic version '$semanticVersion'."
  }

  $preRelease = $match.Groups["prerelease"].Value
  foreach ($identifier in $preRelease.Split(".", [StringSplitOptions]::RemoveEmptyEntries)) {
    if ($identifier -match '^[0-9]+$' -and $identifier.Length -gt 1 -and $identifier.StartsWith("0")) {
      throw "Numeric prerelease identifier '$identifier' in '$semanticVersion' must not contain leading zeroes."
    }
  }

  $major = [long]$match.Groups["major"].Value
  $minor = [long]$match.Groups["minor"].Value
  $patch = [long]$match.Groups["patch"].Value

  switch ($bumpVersion) {
    "major" {
      return "$($major + 1).0.0"
    }
    "minor" {
      return "$major.$($minor + 1).0"
    }
    "patch" {
      return "$major.$minor.$($patch + 1)"
    }
    "suffix" {
      $newSuffix = BumpSuffix $(if ($preRelease) { "-$preRelease" } else { "" }) $defaultPreReleaseIdentifiers
      return "$major.$minor.$patch$newSuffix"
    }
    default {
      throw "Unrecognized 'bumpVersion' argument: $bumpVersion"
    }
  }
}

function BumpSuffix(
  [string] $oldSuffix,
  [string] $defaultPreReleaseIdentifiers = "alpha000") {
  $oldSuffix = $oldSuffix.Trim()

  $preRelease = $oldSuffix.TrimStart("-")
  if (!$preRelease) {
    $preRelease = $defaultPreReleaseIdentifiers
  }

  $identifiers = [Collections.Generic.List[string]]::new()
  $identifiers.AddRange([string[]]$preRelease.Split("."))
  $lastIdentifierIndex = $identifiers.Count - 1
  $lastIdentifier = $identifiers[$lastIdentifierIndex]

  if ($lastIdentifier -match '^[0-9]+$') {
    $identifiers[$lastIdentifierIndex] = ([long]$lastIdentifier + 1).ToString()
  }
  elseif ($lastIdentifier -match '^(?<prefix>.*?)(?<number>[0-9]+)$') {
    $numberWidth = $Matches["number"].Length
    $number = [long]$Matches["number"] + 1
    $identifiers[$lastIdentifierIndex] = $Matches["prefix"] + $number.ToString("D$numberWidth")
  }
  elseif ($identifiers.Count -eq 1) {
    # Preserve the repository's existing alpha001/beta001 suffix convention.
    $identifiers[0] += "001"
  }
  else {
    $identifiers.Add("1")
  }

  return "-" + [string]::Join(".", $identifiers)
}

function Resolve-Error ($ErrorRecord=$Error[0])
{
  # Gives a fairly good summary of error and where it occurred
  $ErrorRecord.InvocationInfo.PositionMessage

  # Stack trace leading up to error
  $ErrorRecord | Format-List * -Force
  $ErrorRecord.InvocationInfo |Format-List *
  $Exception = $ErrorRecord.Exception
  for ($i = 0; $Exception; $i++, ($Exception = $Exception.InnerException))
  {
    "$i" * 80
    $Exception |Format-List * -Force
  }
}

export-modulemember -function Get-NewProjectVersion,
  Get-BumpedSemanticVersion,
  Invoke-CommitVersionBump,
  Invoke-TagVersionBump,
  Set-ProjectVersion,
  Set-AssemblyInfoVersion,
  Set-NuspecVersion,
  Invoke-StashPush,
  Invoke-StashPop
