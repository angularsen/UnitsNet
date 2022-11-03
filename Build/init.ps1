# Don't allow using undeclared variables
Set-Strictmode -version latest

$root = "$PSScriptRoot\.."
Write-Host -Foreground Blue "Initializing..."

# Ensure temp dir exists
$tempDir = "$root/Tools/Temp"
[system.io.Directory]::CreateDirectory($tempDir) | out-null

if (-not (Test-Path "$root/Tools/reportgenerator.exe")) {
  Write-Host -Foreground Blue "Download dotnet-reportgenerator-globaltool..."
  dotnet tool install dotnet-reportgenerator-globaltool --tool-path Tools
  Write-Host -Foreground Green "Download dotnet-reportgenerator-globaltool...OK."
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

  Write-Output "Downloading visx..." -NoNewline

  # download VS extension
  Write-Debug "Download VSIX file from $extensionUrl to $vsixPath"
  $webClient.DownloadFile($extensionUrl, $vsixPath)

  $outputPath = "$tempDir\nf-extension"

  $vsixPath = Join-Path -Path $tempDir -ChildPath "nf-extension.zip"
  $webClient.DownloadFile($extensionUrl,$vsixPath)
  Expand-Archive -LiteralPath $vsixPath -DestinationPath $outputPath | Write-Host

  Copy-Item -Path "$outputPath\`$MSBuild\nanoFramework" -Destination $msbuildPath -Recurse

  Write-Host "Installed VS extension $extensionVersion"
}
###################################################

# Cleanup
[system.io.Directory]::Delete($tempDir, $true) | out-null

Write-Host -Foreground Green "Initialized."
