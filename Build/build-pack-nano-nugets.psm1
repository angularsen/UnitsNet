$root = "$PSScriptRoot\.."
$nugetOutDir = "$root\Artifacts\NuGet"
$nuget = "$root\Tools\NuGet.exe"

function Invoke-Build-NanoNugets {

  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Duration\OasysUnitsNet.NanoFramework.Duration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\ElectricCurrent\OasysUnitsNet.NanoFramework.ElectricCurrent.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\ElectricPotential\OasysUnitsNet.NanoFramework.ElectricPotential.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\ElectricPotentialDc\OasysUnitsNet.NanoFramework.ElectricPotentialDc.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\ElectricResistance\OasysUnitsNet.NanoFramework.ElectricResistance.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Frequency\OasysUnitsNet.NanoFramework.Frequency.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Illuminance\OasysUnitsNet.NanoFramework.Illuminance.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Length\OasysUnitsNet.NanoFramework.Length.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Pressure\OasysUnitsNet.NanoFramework.Pressure.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Ratio\OasysUnitsNet.NanoFramework.Ratio.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\RelativeHumidity\OasysUnitsNet.NanoFramework.RelativeHumidity.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Temperature\OasysUnitsNet.NanoFramework.Temperature.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\VolumeConcentration\OasysUnitsNet.NanoFramework.VolumeConcentration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Power\OasysUnitsNet.NanoFramework.Power.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Density\OasysUnitsNet.NanoFramework.Density.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Mass\OasysUnitsNet.NanoFramework.Mass.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\MassConcentration\OasysUnitsNet.NanoFramework.MassConcentration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\OasysUnitsNet.NanoFramework\GeneratedCode\Angle\OasysUnitsNet.NanoFramework.Angle.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"

}

export-modulemember -function Invoke-Build-NanoNugets
