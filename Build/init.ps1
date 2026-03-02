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

# Install dotnet CLI tools declared in /.config/dotnet-tools.json
pushd $root
dotnet tool restore
popd

# Cleanup
[system.io.Directory]::Delete($tempDir, $true) | out-null

Write-Host -Foreground Green "Initialized."
