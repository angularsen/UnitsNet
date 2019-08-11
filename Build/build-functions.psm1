$root = "$PSScriptRoot\.."
$artifactsDir = "$root\Artifacts"
$nugetOutDir = "$root\Artifacts\NuGet"
$testReportDir = "$root\Artifacts\Logs"
$testCoverageDir = "$root\Artifacts\Coverage"
$nuget = "$root\Tools\NuGet.exe"
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuild = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -property installationPath
if ($msbuild) {
  $msbuild = join-path $msbuild 'MSBuild\15.0\Bin\MSBuild.exe'
}

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

function Start-Build([boolean] $IncludeWindowsRuntimeComponent = $false) {
  write-host -foreground blue "Start-Build...`n---"

  $fileLoggerArg = "/logger:FileLogger,Microsoft.Build;logfile=$testReportDir\UnitsNet.msbuild.log"

  $appVeyorLoggerDll = "C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll"
  $appVeyorLoggerNetCoreDll = "C:\Program Files\AppVeyor\BuildAgent\dotnetcore\Appveyor.MSBuildLogger.dll"
  $appVeyorLoggerArg = if (Test-Path "$appVeyorLoggerNetCoreDll") { "/logger:$appVeyorLoggerNetCoreDll" } else { "" }

  dotnet build --configuration Release "$root\UnitsNet.sln" $fileLoggerArg $appVeyorLoggerArg
  if ($lastexitcode -ne 0) { exit 1 }

  if (-not $IncludeWindowsRuntimeComponent)
  {
    write-host -foreground yellow "Skipping WindowsRuntimeComponent build."
  }
  else
  {
    $fileLoggerArg = "/logger:FileLogger,Microsoft.Build;logfile=$testReportDir\UnitsNet.WindowsRuntimeComponent.msbuild.log"
    $appVeyorLoggerArg = if (Test-Path "$appVeyorLoggerDll") { "/logger:$appVeyorLoggerDll" } else { "" }

    # dontnet CLI does not support WindowsRuntimeComponent project type yet
    # msbuild does not auto-restore nugets for this project type
    write-host -foreground yellow "WindowsRuntimeComponent project not yet supported by dotnet CLI, using MSBuild15 instead"
    & "$msbuild" "$root\UnitsNet.WindowsRuntimeComponent.sln" /verbosity:minimal /p:Configuration=Release /t:restore
    & "$msbuild" "$root\UnitsNet.WindowsRuntimeComponent.sln" /verbosity:minimal /p:Configuration=Release $fileLoggerArg $appVeyorLoggerArg
    if ($lastexitcode -ne 0) { exit 1 }
  }

  write-host -foreground blue "Start-Build...END`n"
}

function Start-Tests {
  $projectPaths = @(
    "UnitsNet.Tests\UnitsNet.Tests.csproj",
    "UnitsNet.Serialization.JsonNet.Tests\UnitsNet.Serialization.JsonNet.Tests.csproj",
    "UnitsNet.Serialization.JsonNet.CompatibilityTests\UnitsNet.Serialization.JsonNet.CompatibilityTests.csproj"
    )

  # Parent dir must exist before xunit tries to write files to it
  new-item -type directory -force $testReportDir 1> $null
  new-item -type directory -force $testCoverageDir 1> $null

  write-host -foreground blue "Run tests...`n---"
  foreach ($projectPath in $projectPaths) {
    $projectFileNameNoEx = [System.IO.Path]::GetFileNameWithoutExtension($projectPath)
    $reportFile = "$testReportDir\${projectFileNameNoEx}.xunit.xml"
    $coverageReportFile = "$testCoverageDir\${projectFileNameNoEx}.coverage.xml"
    $projectDir = [System.IO.Path]::GetDirectoryName($projectPath)

    # dotnet commands (xunit, dotcover) must run in same dir as project
    push-location $projectDir

    # Create coverage report for this test project
    & dotnet dotcover test `
      --dotCoverFilters="+:module=UnitsNet*;-:module=*Tests" `
      --dotCoverOutput="$coverageReportFile" `
      --dcReportType=DetailedXML

    if ($lastexitcode -ne 0) { exit 1 }
    pop-location
  }

  # Generate a summarized code coverage report for all test projects
  & "Tools/reportgenerator.exe" -reports:"$root/Artifacts/Coverage/*.coverage.xml" -targetdir:"$root/Artifacts/Coverage" -reporttypes:HtmlSummary

  write-host -foreground blue "Run tests...END`n"
}

function Start-PackNugets {
  $projectPaths = @(
    "UnitsNet\UnitsNet.csproj",
    "UnitsNet.Serialization.JsonNet\UnitsNet.Serialization.JsonNet.csproj"
    )

  write-host -foreground blue "Pack nugets...`n---"
  foreach ($projectPath in $projectPaths) {
    dotnet pack --configuration Release -o $nugetOutDir "$root\$projectPath"
    if ($lastexitcode -ne 0) { exit 1 }
  }

  if (-not $IncludeWindowsRuntimeComponent) {
    write-host -foreground yellow "Skipping WindowsRuntimeComponent nuget pack."
  } else {
    write-host -foreground yellow "WindowsRuntimeComponent project not yet supported by dotnet CLI, using nuget.exe instead"
    & $nuget pack "$root\UnitsNet.WindowsRuntimeComponent\UnitsNet.WindowsRuntimeComponent.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
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
