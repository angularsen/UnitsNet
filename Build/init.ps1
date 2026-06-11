# Don't allow using undeclared variables
Set-Strictmode -version latest

$root = (Resolve-Path "$PSScriptRoot\..").Path

Write-Host -Foreground Blue "Initializing..."

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

Write-Host -Foreground Green "Initialized."
