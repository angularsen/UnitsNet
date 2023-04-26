$root = "$PSScriptRoot\.."
$nugetOutDir = "$root\Artifacts\NuGet"
$nuget = "$root\Tools\NuGet.exe"

function Invoke-BuildNanoNugets {

  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Duration\OasysUnits.NanoFramework.Duration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\ElectricCurrent\OasysUnits.NanoFramework.ElectricCurrent.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\ElectricPotential\OasysUnits.NanoFramework.ElectricPotential.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\ElectricPotentialDc\OasysUnits.NanoFramework.ElectricPotentialDc.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\ElectricResistance\OasysUnits.NanoFramework.ElectricResistance.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Frequency\OasysUnits.NanoFramework.Frequency.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Illuminance\OasysUnits.NanoFramework.Illuminance.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Length\OasysUnits.NanoFramework.Length.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Pressure\OasysUnits.NanoFramework.Pressure.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Ratio\OasysUnits.NanoFramework.Ratio.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\RelativeHumidity\OasysUnits.NanoFramework.RelativeHumidity.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Temperature\OasysUnits.NanoFramework.Temperature.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\VolumeConcentration\OasysUnits.NanoFramework.VolumeConcentration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Power\OasysUnits.NanoFramework.Power.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Density\OasysUnits.NanoFramework.Density.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Mass\OasysUnits.NanoFramework.Mass.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\MassConcentration\OasysUnits.NanoFramework.MassConcentration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnits.NanoFramework\GeneratedCode\Angle\OasysUnits.NanoFramework.Angle.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"

}

export-modulemember -function Invoke-BuildNanoNugets
