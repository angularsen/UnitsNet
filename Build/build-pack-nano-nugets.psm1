$root = "$PSScriptRoot\.."
$nugetOutDir = "$root\Artifacts\NuGet"
$nuget = "$root\Tools\NuGet.exe"

function Invoke-Build-NanoNugets {

  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Temperature\UnitsNet.NanoFramework.Temperature.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"

}

export-modulemember -function Invoke-Build-NanoNugets
