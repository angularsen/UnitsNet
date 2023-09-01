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

  $old = Get-ProjectVersionAndSuffix $projectXml

  switch ($bumpVersion) {
    "major" {
      $newVersion = BumpMajor $old.Version
      $newSuffix = ""
    }
    "minor" {
      $newVersion = BumpMinor $old.Version
      $newSuffix = ""
    }
    "patch" {
      $newVersion = BumpPatch $old.Version
      $newSuffix = ""
    }
    "suffix" {
      $newVersion = $old.Version
      $newSuffix = BumpSuffix $old.Suffix
    }
    default {
      throw "Unrecognized 'bumpVersion' argument: $bumpVersion"
    }
  }

  $newSemVer = $newVersion.ToString() + $newSuffix
  return $newSemVer
}

function BumpMajor ([Version] $oldVersion) {
  return New-Object System.Version -ArgumentList ($oldVersion.Major+1), 0, 0
}

function BumpMinor([Version] $oldVersion) {
  return New-Object System.Version -ArgumentList $oldVersion.Major, ($oldVersion.Minor+1), 0
}

function BumpPatch([Version] $oldVersion) {
  return New-Object System.Version -ArgumentList $oldVersion.Major, $oldVersion.Minor, ($oldVersion.Build+1);
}

function BumpSuffix([string] $oldSuffix) {
  $oldSuffix = $oldSuffix.Trim()

  # A suffix is a dash '-', then a sequcence of word characters followed by an optional number
  # Example:
  # ""      => "-alpha001"
  # "-beta" => "-beta001"
  # "-beta1"=> "-beta002"
  $match = [regex]::Match($oldSuffix, '^-([a-zA-Z]+)(\d+)?$');
  $oldSuffix = $match.Groups[1].Value
  if (!$oldSuffix) {
    $oldSuffix = "alpha"
  }

  $numberGroup = $match.Groups[2]

  $number = if ($numberGroup.Success) { 1+$match.Groups[2].Value } else { 1 }

  # Use 3 digits for the number "-alpha003", for 999 releases lexically sorted.
  return [string]::Format("-{0}{1:D3}", $oldSuffix, $number)
}

# Returns object with properties: Version, Suffix
function Get-ProjectVersionAndSuffix([xml] $projectXml) {

  # Split "1.2.3-alpha" into ["1.2.3", "alpha"]
  # Split "1.2.3" into ["1.2.3"]
  $oldSemVer = $($projectXml.Project.PropertyGroup.Version)[0]

  $oldSemVerParts = $oldSemVer.Split('-')
  $oldVersion = $null
  if (-not [Version]::TryParse($oldSemVerParts[0], [ref] $oldVersion)) { throw "Unable to parse old version." }

  $oldSuffix = if ($oldSemVerParts.Length -eq 2) { "-" + $oldSemVerParts[1]} else { "" }
  return [PSCustomObject]@{
    PSTypeName = "VersionAndSuffix"
    Version = $oldVersion
    Suffix = $oldSuffix
  }
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
  Invoke-CommitVersionBump,
  Invoke-TagVersionBump,
  Set-ProjectVersion,
  Set-AssemblyInfoVersion,
  Set-NuspecVersion,
  Invoke-StashPush,
  Invoke-StashPop
