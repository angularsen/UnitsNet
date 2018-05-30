$root = "$PSScriptRoot\.."
$artifactsDir = "$root\Artifacts"
$nugetOutDir = "$root\Artifacts\NuGet"
$testReportDir = "$root\Artifacts\Logs"
$nuget = "$root\Tools\NuGet.exe"
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
$msbuild = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -property installationPath
if ($msbuild) {
  $msbuild = join-path $msbuild 'MSBuild\15.0\Bin\MSBuild.exe'
}

function Start-NugetRestore {
  write-host -foreground blue "Restore nugets...`n"
  dotnet restore "$root\UnitsNet.sln"

  # This project type is not supported by dotnet CLI yet
  & $nuget restore "$root\UnitsNet.WindowsRuntimeComponent.sln"
  write-host -foreground blue "Restore nugets...END`n"
}

function Remove-ArtifactsDir {
  write-host -foreground blue "Clean up...`n"
  rm $artifactsDir -Recurse -ErrorAction Ignore
  write-host -foreground blue "Clean up...END`n"
}

function Update-GeneratedCode {
  # Regenerate source code since it occasionally happens that merged pull requests did not include all the regenerated code
  write-host -foreground blue "Generate code...`n---"
  write-host "$root\UnitsNet\Scripts\GenerateUnits.ps1"

  & "$root\UnitsNet\Scripts\GenerateUnits.ps1"
  if ($lastexitcode -ne 0) { exit 1 }

  write-host -foreground blue "Generate code...END`n"
}

function Start-Build([boolean] $skipUWP = $false) {
  write-host -foreground blue "Start-Build...`n---"
  dotnet build --configuration Release "$root\UnitsNet.sln"
  if ($lastexitcode -ne 0) { exit 1 }

  if ($skipUWP -eq $true)
  {
    write-host -foreground yellow "Skipping WindowsRuntimeComponent build by user-specified flag."
  }
  else
  {
    # dontnet CLI does not support WindowsRuntimeComponent project type yet
    write-host -foreground yellow "WindowsRuntimeComponent project not yet supported by dotnet CLI, using MSBuild15 instead"
    & "$msbuild" "$root\UnitsNet.WindowsRuntimeComponent.sln" /verbosity:minimal /p:Configuration=Release
    if ($lastexitcode -ne 0) { exit 1 }
  }

  write-host -foreground blue "Start-Build...END`n"
}

function Start-Tests {
  $projectPaths = @(
    "UnitsNet.Tests\UnitsNet.Tests.NetCore.csproj",
    "UnitsNet.Serialization.JsonNet.Tests\UnitsNet.Serialization.JsonNet.Tests.NetCore.csproj",
    "UnitsNet.Serialization.JsonNet.CompatibilityTests\UnitsNet.Serialization.JsonNet.CompatibilityTests.NetCore.csproj"
    )

  # Parent dir must exist before xunit tries to write files to it
  new-item -type directory $testReportDir 1> $null

  write-host -foreground blue "Run tests...`n---"
  foreach ($projectPath in $projectPaths) {
    $projectFileNameNoEx = [System.IO.Path]::GetFileNameWithoutExtension($projectPath)
    $reportFile = "$testReportDir\${projectFileNameNoEx}.xunit.xml"
    $projectDir = [System.IO.Path]::GetDirectoryName($projectPath)

    # dotnet-xunit command must run in same dir as project
    # https://github.com/xunit/xunit/issues/1216
    push-location $projectDir
    # -nobuild  <-- this gives an error, but might want to use this to avoid extra builds
    dotnet xunit -configuration Release -framework netcoreapp1.1 -xml $reportFile -nobuild
    if ($lastexitcode -ne 0) { exit 1 }
    pop-location
  }

  write-host -foreground blue "Run tests...END`n"
}

function Start-PackNugets {
  $projectPaths = @(
    "UnitsNet\UnitsNet.NetStandard10.csproj",
    "UnitsNet\UnitsNet.NetStandard10.Signed.csproj",
    "UnitsNet.Serialization.JsonNet\UnitsNet.Serialization.JsonNet.csproj",
    "UnitsNet.Serialization.JsonNet\UnitsNet.Serialization.JsonNet.Signed.csproj"
    )

  write-host -foreground blue "Pack nugets...`n---"
  foreach ($projectPath in $projectPaths) {
    dotnet pack --configuration Release -o $nugetOutDir "$root\$projectPath"
    if ($lastexitcode -ne 0) { exit 1 }
  }
  write-host -foreground yellow "WindowsRuntimeComponent project not yet supported by dotnet CLI, using NuGex.exe instead"
  & $nuget pack "$root\UnitsNet\UnitsNet.WindowsRuntimeComponent.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir" -Symbols

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
