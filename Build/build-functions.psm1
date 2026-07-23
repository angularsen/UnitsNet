$root = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
$artifactsDir = Join-Path $root "Artifacts"
$nugetOutDir = Join-Path $artifactsDir "NuGet"
$logsDir = Join-Path $artifactsDir "Logs"
$testReportDir = Join-Path $artifactsDir "TestResults"
$testCoverageDir = Join-Path $artifactsDir "Coverage"
$toolsDir = Join-Path $root ".tools"
$reportGeneratorName = if ([System.Environment]::OSVersion.Platform -eq [PlatformID]::Win32NT) { "reportgenerator.exe" } else { "reportgenerator" }
$reportGenerator = Join-Path $toolsDir $reportGeneratorName

function Remove-ArtifactsDir {
  if (Test-Path $artifactsDir) {
    write-host -foreground blue "Clean up...`n"
    rm $artifactsDir -Recurse -Force -ErrorAction Stop
    write-host -foreground blue "Clean up...END`n"
  }
}

function Update-GeneratedCode {
  write-host -foreground blue "Generate code...`n---"
  dotnet run --project "$root/CodeGen"
  if ($lastexitcode -ne 0) { exit 1 }
  write-host -foreground blue "Generate code...END`n"
}

function Start-Build {
  write-host -foreground blue "Start-Build (dotnet CLI)...`n---"

  # Use dotnet CLI for all main projects - cross-platform compatible
  dotnet build --configuration Release /p:ContinuousIntegrationBuild=true "$root\UnitsNet.slnx"
  if ($lastexitcode -ne 0) { exit 1 }

  write-host -foreground blue "Start-Build...END`n"
}

function Get-TestProjects {
  Param(
    [Parameter(Mandatory)]
    [string] $Framework
  )

  $testProjects = Get-ChildItem -Path $root -Recurse -Filter "*.Tests.csproj" -File | Sort-Object FullName
  foreach ($testProject in $testProjects) {
    $propertiesJson = & dotnet msbuild $testProject.FullName `
      -getProperty:TargetFrameworks,TargetFramework `
      -nologo
    if ($lastexitcode -ne 0) { throw "Failed to read target frameworks from $($testProject.FullName)." }

    $properties = $propertiesJson | ConvertFrom-Json
    $targetFrameworks = @($properties.Properties.TargetFrameworks -split ';') + $properties.Properties.TargetFramework
    if ($targetFrameworks -contains $Framework) {
      $testProject
    }
  }
}

function Start-Tests {
  Param(
    [switch] $SkipCoverage
  )

  $testProjects = @(Get-TestProjects -Framework "net10.0")
  if ($testProjects.Count -eq 0) { throw "No test projects targeting net10.0 were found." }

  # Parent dir must exist before xunit tries to write files to it
  new-item -type directory -force $testReportDir 1> $null
  if (-not $SkipCoverage) {
    new-item -type directory -force $testCoverageDir 1> $null
  }

  write-host -foreground blue "Run tests...`n---"
  foreach ($testProject in $testProjects) {
    $coverageReportFile = Join-Path $testCoverageDir "$($testProject.BaseName).coverage.xml"
    $projectDir = $testProject.DirectoryName

    # dotnet commands (xunit, dotcover) must run in same dir as project
    push-location $projectDir

    # Build validates every target framework. Run tests only on the latest .NET runtime because
    # net8.0, net9.0, and net10.0 compile the same code paths. The separate CLR4 workflow tests
    # the meaningfully different netstandard2.0 assets on .NET Framework.
    if ($SkipCoverage) {
      & dotnet test `
        --no-build `
        --framework net10.0 `
        --logger trx `
        --results-directory "$testReportDir"
    }
    else {
      & dotnet tool run dotCover -- cover-dotnet `
        --TargetWorkingDir $projectDir `
        --Output "$coverageReportFile" `
        --ReportType DetailedXML `
        --Filters '+:module=UnitsNet*;-:module=*Tests' `
        --ReturnTargetExitCode `
        -- test `
        --no-build `
        --framework net10.0 `
        --logger trx `
        --results-directory "$testReportDir"
    }

    if ($lastexitcode -ne 0) { exit 1 }
    pop-location
  }

  if (-not $SkipCoverage) {
    # Generate a summarized code coverage report for all test projects
    & $reportGenerator -reports:"$testCoverageDir/*.coverage.xml" -targetdir:"$testCoverageDir" -reporttypes:HtmlSummary
  }

  write-host -foreground blue "Run tests...END`n"
}

function Start-PackNugets {
  $projectPaths = @(
    "UnitsNet/UnitsNet.csproj",
    "UnitsNet.Serialization.JsonNet/UnitsNet.Serialization.JsonNet.csproj",
    "UnitsNet.NumberExtensions/UnitsNet.NumberExtensions.csproj",
    "UnitsNet.NumberExtensions.CS14/UnitsNet.NumberExtensions.CS14.csproj"
    )

  write-host -foreground blue "Pack nugets (dotnet CLI)...`n---"
  foreach ($projectPath in $projectPaths) {
    dotnet pack --configuration Release `
      --no-build `
      --output $nugetOutDir `
      /p:ContinuousIntegrationBuild=true `
      (Join-Path $root $projectPath)

    if ($lastexitcode -ne 0) { exit 1 }
  }

  write-host -foreground blue "Pack nugets...END`n"
}

function Compress-ArtifactsAsZip {
  write-host -foreground blue "Zip artifacts...`n---"

  $zipFileName = "UnitsNet.zip"
  $tempZipFile = Join-Path $root $zipFileName
  $zipFile = Join-Path $artifactsDir $zipFileName

  rm $tempZipFile -ErrorAction Ignore
  rm $zipFile -ErrorAction Ignore

  # Create zip file
  add-type -assembly "system.io.compression.filesystem"
  [IO.Compression.ZipFile]::CreateFromDirectory($artifactsDir, $tempZipFile)

  mv $tempZipFile $zipFile
  if (-not $?) { write-host -foreground red "Failed to move [$tempZipFile] to [$zipFileName]."; exit 1 }

  write-host -foreground blue "Zip artifacts...END`n"
}

export-modulemember -function Remove-ArtifactsDir, Update-GeneratedCode, Start-Build, Get-TestProjects, Start-Tests, Start-PackNugets, Compress-ArtifactsAsZip
