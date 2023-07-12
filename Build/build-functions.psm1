$root = (Resolve-Path "$PSScriptRoot\..").Path
$artifactsDir = "$root\Artifacts"
$nugetOutDir = "$artifactsDir\NuGet"
$logsDir = "$artifactsDir\Logs"
$testReportDir = "$artifactsDir\TestResults"
$testCoverageDir = "$artifactsDir\Coverage"
$toolsDir = "$root\.tools"

$nuget = "$toolsDir\NuGet.exe"
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuildPath = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -property installationPath

if ($msbuildPath) {
  $msbuildx64 = join-path $msbuildPath 'MSBuild\Current\Bin\amd64\MSBuild.exe'
}

import-module $PSScriptRoot\build-pack-nano-nugets.psm1

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

function Start-Build([boolean] $IncludeNanoFramework = $false) {
  write-host -foreground blue "Start-Build...`n---"

  $fileLoggerArg = "/logger:FileLogger,Microsoft.Build;logfile=$logsDir\UnitsNet.msbuild.log"

  dotnet build --configuration Release /p:ContinuousIntegrationBuild=true "$root\UnitsNet.sln" $fileLoggerArg
  if ($lastexitcode -ne 0) { exit 1 }

  if (-not $IncludeNanoFramework)
  {
    write-host -foreground yellow "Skipping .NET nanoFramework build."
  }
  else
  {
    write-host -foreground green "Build .NET nanoFramework."
    $fileLoggerArg = "/logger:FileLogger,Microsoft.Build;logfile=$logsDir\UnitsNet.NanoFramework.msbuild.log"

    # msbuild does not auto-restore nugets for this project type
    & "$nuget" restore "$root\UnitsNet.NanoFramework\GeneratedCode\UnitsNet.nanoFramework.sln"

    # now build
    & "$msbuildx64" "$root\UnitsNet.NanoFramework\GeneratedCode\UnitsNet.nanoFramework.sln" /verbosity:minimal /p:Configuration=Release /p:Platform="Any CPU" /p:ContinuousIntegrationBuild=true $fileLoggerArg
    if ($lastexitcode -ne 0) { exit 1 }
  }

  write-host -foreground blue "Start-Build...END`n"
}

function Start-Tests {
  $projectPaths = @(
    "UnitsNet.Tests\UnitsNet.Tests.csproj",
    "UnitsNet.NumberExtensions.Tests\UnitsNet.NumberExtensions.Tests.csproj",
    "UnitsNet.Serialization.JsonNet.Tests\UnitsNet.Serialization.JsonNet.Tests.csproj"
    )

  # Parent dir must exist before xunit tries to write files to it
  new-item -type directory -force $testReportDir 1> $null
  new-item -type directory -force $testCoverageDir 1> $null

  write-host -foreground blue "Run tests...`n---"
  foreach ($projectPath in $projectPaths) {
    $projectFileNameNoEx = [System.IO.Path]::GetFileNameWithoutExtension($projectPath)
    $coverageReportFile = "$testCoverageDir\${projectFileNameNoEx}.coverage.xml"
    $projectDir = [System.IO.Path]::GetDirectoryName($projectPath)

    # dotnet commands (xunit, dotcover) must run in same dir as project
    push-location $projectDir

    # Create coverage report for this test project
    & dotnet dotcover test `
      --no-build `
      --logger trx `
      --results-directory "$testReportDir" `
      --dotCoverFilters="+:module=UnitsNet*;-:module=*Tests" `
      --dotCoverOutput="$coverageReportFile" `
      --dcReportType=DetailedXML

    if ($lastexitcode -ne 0) { exit 1 }
    pop-location
  }

  # Generate a summarized code coverage report for all test projects
  & "$toolsDir/reportgenerator.exe" -reports:"$testCoverageDir/*.coverage.xml" -targetdir:"$testCoverageDir" -reporttypes:HtmlSummary

  write-host -foreground blue "Run tests...END`n"
}

function Start-PackNugets([boolean] $IncludeNanoFramework = $false) {
  $projectPaths = @(
    "UnitsNet\UnitsNet.csproj",
    "UnitsNet.Serialization.JsonNet\UnitsNet.Serialization.JsonNet.csproj",
    "UnitsNet.NumberExtensions\UnitsNet.NumberExtensions.csproj"
    )

  write-host -foreground blue "Pack nugets...`n---"
  foreach ($projectPath in $projectPaths) {
    dotnet pack --configuration Release `
      --no-build `
      --output $nugetOutDir `
      /p:ContinuousIntegrationBuild=true `
      "$root\$projectPath"

    if ($lastexitcode -ne 0) { exit 1 }
  }

  if (-not $IncludeNanoFramework) {
    write-host -foreground yellow "Skipping nanoFramework nuget pack."
  } else {
    write-host -foreground yellow "nanoFramework project not yet supported by dotnet CLI, using nuget.exe instead"
    Invoke-BuildNanoNugets
  }

  write-host -foreground blue "Pack nugets...END`n"
}

function Compress-ArtifactsAsZip {
  write-host -foreground blue "Zip artifacts...`n---"

  $zipFileName = "UnitsNet.zip"
  $tempZipFile = "$root\$zipFileName"
  $zipFile = "$artifactsDir\$zipFileName"`

  rm $tempZipFile -ErrorAction Ignore
  rm $zipFile -ErrorAction Ignore

  # Create zip file
  add-type -assembly "system.io.compression.filesystem"
  [IO.Compression.ZipFile]::CreateFromDirectory($artifactsDir, $tempZipFile)

  mv $tempZipFile $zipFile
  if (-not $?) { write-host -foreground red "Failed to move [$tempZipFile] to [$zipFileName]."; exit 1 }

  write-host -foreground blue "Zip artifacts...END`n"
}

export-modulemember -function Start-NugetRestore, Remove-ArtifactsDir, Update-GeneratedCode, Start-Build, Start-SignedBuild, Start-Tests, Start-PackNugets, Compress-ArtifactsAsZip
