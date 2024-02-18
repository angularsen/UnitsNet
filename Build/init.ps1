# Don't allow using undeclared variables
Set-Strictmode -version latest

$root = (Resolve-Path "$PSScriptRoot\..").Path
$nugetPath = "$root/.tools/NuGet.exe"

Write-Host -Foreground Blue "Initializing..."

# Ensure temp dir exists
$tempDir = "$root/.tools/temp_init"
[system.io.Directory]::CreateDirectory($tempDir) | out-null

# Report generator for unit test coverage reports.
if (-not (Test-Path "$root/.tools/reportgenerator.exe")) {
  Write-Host -Foreground Blue "Install dotnet-reportgenerator-globaltool..."
  dotnet tool install dotnet-reportgenerator-globaltool --tool-path .tools
  Write-Host -Foreground Green "✅ Installed dotnet-reportgenerator-globaltool"
}

# NuGet.exe for non-SDK style projects, like UnitsNet.nanoFramework.
if (-not (Test-Path "$nugetPath")) {
  Write-Host -Foreground Blue "Downloading NuGet.exe..."
  Invoke-WebRequest -Uri https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile $nugetPath
  Write-Host -Foreground Green "✅ Downloaded NuGet.exe: $nugetPath"
}

###################################################
## TODO: OK to remove after moving to AZDO pipeline
$VsWherePath = "${env:PROGRAMFILES(X86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$VsPath = $(&$VsWherePath -latest -property installationPath)
$msbuildPath = Join-Path -Path $VsPath -ChildPath "\MSBuild"

# Install dotnet CLI tools declared in /.config/dotnet-tools.json
pushd $root
dotnet tool restore
popd

# Install .NET nanoFramework build components
if (!(Test-Path "$msbuildPath/nanoFramework")) {
  Write-Host "Installing .NET nanoFramework VS extension..."

  [System.Net.WebClient]$webClient = New-Object System.Net.WebClient
  $webClient.Headers.Add("User-Agent", "request")
  $webClient.Headers.Add("Accept", "application/vnd.github.v3+json")

  $releaseList = $webClient.DownloadString('https://api.github.com/repos/nanoframework/nf-Visual-Studio-extension/releases?per_page=100')

  if($releaseList -match '\"(?<VS2022_version>v2022\.\d+\.\d+\.\d+)\"')
  {
      $vs2022Tag =  $Matches.VS2022_version
  }

  if($releaseList -match '\"(?<VS2019_version>v2019\.\d+\.\d+\.\d+)\"')
  {
      $vs2019Tag =  $Matches.VS2019_version
  }

  # Find which VS version is installed
  $VsWherePath = "${env:PROGRAMFILES(X86)}\Microsoft Visual Studio\Installer\vswhere.exe"

  Write-Output "VsWherePath is: $VsWherePath"

  $VsInstance = $(&$VSWherePath -latest -property displayName)

  Write-Output "Latest VS is: $VsInstance"

  # Get extension details according to VS version, starting from VS2022 down to VS2019
  if($vsInstance.Contains('2022'))
  {
      $extensionUrl = "https://github.com/nanoframework/nf-Visual-Studio-extension/releases/download/$vs2022Tag/nanoFramework.Tools.VS2022.Extension.vsix"
      $vsixPath = Join-Path  $tempDir "nanoFramework.Tools.VS2022.Extension.zip"
      $extensionVersion = $vs2022Tag
  }
  elseif($vsInstance.Contains('2019'))
  {
      $extensionUrl = "https://github.com/nanoframework/nf-Visual-Studio-extension/releases/download/$vs2019Tag/nanoFramework.Tools.VS2019.Extension.vsix"
      $vsixPath = Join-Path  $tempDir "nanoFramework.Tools.VS2019.Extension.zip"
      $extensionVersion = $vs2019Tag
  }

  Write-Output "Downloading visx..."

  # download VS extension
  Write-Host "Download VSIX file from $extensionUrl to $vsixPath"
  $webClient.DownloadFile($extensionUrl, $vsixPath)

  $outputPath = "$tempDir\nf-extension"

  $vsixPath = Join-Path -Path $tempDir -ChildPath "nf-extension.zip"
  $webClient.DownloadFile($extensionUrl, $vsixPath)

  Write-Host "Extract VSIX file to $outputPath"
  Expand-Archive -LiteralPath $vsixPath -DestinationPath $outputPath -Force | Write-Host

  $copyFrom = "$outputPath\`$MSBuild\nanoFramework"

  Write-Host "Copy from $copyFrom to $msbuildPath"
  Copy-Item -Path "$copyFrom" -Destination $msbuildPath -Recurse

  Write-Host "Installed VS extension $extensionVersion"
}
###################################################

# Cleanup
[system.io.Directory]::Delete($tempDir, $true) | out-null

Write-Host -Foreground Green "Initialized."
