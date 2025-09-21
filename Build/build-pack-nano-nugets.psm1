$root = (Resolve-Path "$PSScriptRoot\..").Path
$nugetOutDir = "$root\Artifacts\NuGet"
$toolsDir = "$root\.tools"
$nuget = "$toolsDir\NuGet.exe"
$nugetsToProcess = (Get-ChildItem -Path "$root\UnitsNet.NanoFramework\GeneratedCode\" -Filter *.nuspec -r | % { echo $_.FullName });

function Invoke-BuildNanoNugets {
Foreach ($nuget in $nugetsToProcess)
  {
    & $nuget pack "$nuget" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  }
}

export-modulemember -function Invoke-BuildNanoNugets
