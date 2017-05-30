function Set-ProjectVersionAndCommit(
  [string]$projectName,
  [string[]]$projectPaths,
  [string]$paramSet,
  [string]$setVersion,
  [string]$bumpVersion) {

  try {
    foreach ($path in $projectPaths) {
      switch ($paramSet) {
        "set" {
          # Imported from module: set-version.psm1
          Set-ProjectVersion $path $setVersion
          $newSemVer = $setVersion
        }
        "bump" {
          # Imported from module: set-version.psm1
          $newSemVer = Set-BumpedProjectVersion $path $bumpVersion
        }
        default {
          throw "Parameter set not implemented: $paramSet"
        }
      }
    }

    $gitAddProjects = [string]::Join(" ", $projectPaths)
    git add $gitAddProjects
    git commit -m "${projectName}: $newSemVer"
    git tag -a "$projectName/$newSemVer" -m "$projectName/$newSemVer" -m "TODO List changes here"

    Write-Host "New tag: $newSemVer"
  }
  catch {
    $ex = $Error[0]
    $err = Resolve-Error
    Write-Error "ERROR: Failed to update build parameters from .csproj file: `n---`n$err"
    exit 1
  }
}

function Set-ProjectVersion([string] $projectPath, [string] $setVersion) {
  [xml]$projectXml = Get-Content -Path $projectPath

  Write-Host "$projectPath -> $setVersion"

  # Update <Version> property
  $projectXml.Project.PropertyGroup.Version = $setVersion
  $projectXml.Save($projectPath)
}

function Set-BumpedProjectVersion([string] $projectPath, [string] $bumpVersion) {
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
  Set-ProjectVersion $projectPath $newSemVer
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
  # -alpha => -alpha2
  # -alpha1 => -alpha2
  $match = [regex]::Match($oldSuffix, '^-(\w+)(\d+)?$');
  $oldSuffix = $match.Groups[1].Value
  $numberGroup = $match.Groups[2]

  $number = if ($numberGroup.Success) { 1+$match.Groups[2].Value } else { 2 }
  return [string]::Format("-{0}{1}", $oldSuffix, $number)
}

# Returns object with properties: Version, Suffix
function Get-ProjectVersionAndSuffix([xml] $projectXml) {

  # Split "1.2.3-alpha" into ["1.2.3", "alpha"]
  # Split "1.2.3" into ["1.2.3"]
  $oldSemVer = $projectXml.Project.PropertyGroup.Version
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

export-modulemember -function Set-ProjectVersionAndCommit, Set-ProjectVersion, Set-BumpedProjectVersion