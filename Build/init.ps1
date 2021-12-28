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

$VsWherePath = "${env:PROGRAMFILES(X86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$VsPath = $(&$VsWherePath -latest -property installationPath)
$msbuildPath = Join-Path -Path $VsPath -ChildPath "\MSBuild"

# Install .NET nanoFramework build components
if (!(Test-Path "$msbuildPath/nanoFramework")) {
  Write-Host "Installing .NET nanoFramework VS extension..."

  [System.Net.WebClient]$webClient = New-Object System.Net.WebClient
  $webClient.UseDefaultCredentials = $true

  $vsixFeedXml = Join-Path -Path $tempDir -ChildPath "vs-extension-feed.xml"
  $webClient.DownloadFile("http://vsixgallery.com/feed/author/nanoframework", $vsixFeedXml)
  [xml]$feedDetails = Get-Content $vsixFeedXml

  foreach ($entry in $feedDetails.feed.entry)
  {
      if($entry.id -eq '455f2be5-bb07-451e-b351-a9faf3018dc9')
      {
          $extensionUrl = $entry.content.src
          $extensionVersion = $entry.Vsix.Version
          break
      }
  }

  $vsixPath = Join-Path -Path $tempDir -ChildPath "nf-extension.zip"
  $webClient.DownloadFile($extensionUrl,$vsixPath)
  Expand-Archive -LiteralPath $vsixPath -DestinationPath $tempDir\nf-extension\ | Write-Host

  Copy-Item -Path "$tempDir\nf-extension\`$MSBuild\nanoFramework" -Destination $msbuildPath -Recurse

  Write-Host "Installed VS extension v$extensionVersion"
}

# Cleanup
[system.io.Directory]::Delete($tempDir, $true) | out-null

Write-Host -Foreground Green "Initialized."
