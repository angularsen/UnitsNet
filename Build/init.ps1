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

# Cleanup
[system.io.Directory]::Delete($tempDir, $true) | out-null

Write-Host -Foreground Green "Initialized."
