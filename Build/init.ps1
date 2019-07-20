# Don't allow using undeclared variables
Set-Strictmode -version latest

$root = "$PSScriptRoot\.."
Write-Host -Foreground Blue "Initializing..."

# Ensure temp dir exists
$tempDir = "$root/Tools/Temp"
[system.io.Directory]::CreateDirectory($tempDir) | out-null

if (-not (Test-Path "$root/Tools/OpenCover/OpenCover.Console.exe")) {
  Write-Host -Foreground Blue "Downloading OpenCover..."
  # Workaround for GitHub requiring TLS1.2 and PowerShell defaulting to TLS1:
  # https://stackoverflow.com/a/48030563/134761
  [Net.ServicePointManager]::SecurityProtocol = "tls12, tls11, tls"
  wget https://github.com/OpenCover/opencover/releases/download/4.7.922/opencover.4.7.922.zip -OutFile "$tempDir/opencover.zip"
  Expand-Archive "$tempDir/opencover.zip" -DestinationPath "$root/Tools/opencover/" -Force
  Write-Host -Foreground Green "OpenCover downloaded."
}

if (-not (Test-Path "$root/Tools/xunit.exe")) {
  Write-Host -Foreground Blue "Download xunit-cli..."
  dotnet tool install xunit-cli --add-source https://myget.org/F/natemcmaster/api/v3/index.json --tool-path Tools
  Write-Host -Foreground Green "Download xunit-cli...OK."
}

if (-not (Test-Path "$root/Tools/reportgenerator.exe")) {
  Write-Host -Foreground Blue "Download dotnet-reportgenerator-globaltool..."
  dotnet tool install dotnet-reportgenerator-globaltool --tool-path Tools
  Write-Host -Foreground Green "Download dotnet-reportgenerator-globaltool...OK."
}

# Cleanup
[system.io.Directory]::Delete($tempDir, $true) | out-null

Write-Host -Foreground Green "Initialized."
