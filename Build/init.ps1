# Don't allow using undeclared variables
Param(
  [switch] $SkipCoverageTools
)

Set-Strictmode -version latest

$root = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
$toolsDir = Join-Path $root ".tools"
$reportGeneratorName = if ([System.Environment]::OSVersion.Platform -eq [PlatformID]::Win32NT) { "reportgenerator.exe" } else { "reportgenerator" }
$reportGenerator = Join-Path $toolsDir $reportGeneratorName

Write-Host -Foreground Blue "Initializing..."

if (-not $SkipCoverageTools) {
  # Report generator for unit test coverage reports.
  if (-not (Test-Path $reportGenerator)) {
    Write-Host -Foreground Blue "Install dotnet-reportgenerator-globaltool..."
    dotnet tool install dotnet-reportgenerator-globaltool --tool-path $toolsDir
    Write-Host -Foreground Green "✅ Installed dotnet-reportgenerator-globaltool"
  }

  # Install dotnet CLI tools declared in /.config/dotnet-tools.json
  pushd $root
  dotnet tool restore
  popd
}

Write-Host -Foreground Green "Initialized."
