$root = (Resolve-Path "$PSScriptRoot\..").Path
$nugetOutDir = "$root\Artifacts\NuGet"
$toolsDir = "$root\.tools"
$nuget = "$toolsDir\NuGet.exe"

function Invoke-BuildNanoNugets {

  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Duration\UnitsNet.NanoFramework.Duration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\ElectricCurrent\UnitsNet.NanoFramework.ElectricCurrent.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\ElectricPotential\UnitsNet.NanoFramework.ElectricPotential.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\ElectricPotentialDc\UnitsNet.NanoFramework.ElectricPotentialDc.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\ElectricResistance\UnitsNet.NanoFramework.ElectricResistance.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Frequency\UnitsNet.NanoFramework.Frequency.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Illuminance\UnitsNet.NanoFramework.Illuminance.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Length\UnitsNet.NanoFramework.Length.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Pressure\UnitsNet.NanoFramework.Pressure.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Ratio\UnitsNet.NanoFramework.Ratio.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\RelativeHumidity\UnitsNet.NanoFramework.RelativeHumidity.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Temperature\UnitsNet.NanoFramework.Temperature.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\VolumeConcentration\UnitsNet.NanoFramework.VolumeConcentration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Power\UnitsNet.NanoFramework.Power.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Density\UnitsNet.NanoFramework.Density.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Mass\UnitsNet.NanoFramework.Mass.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Speed\UnitsNet.NanoFramework.Speed.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\MassConcentration\UnitsNet.NanoFramework.MassConcentration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Angle\UnitsNet.NanoFramework.Angle.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\MagneticField\UnitsNet.NanoFramework.MagneticField.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"
  & $nuget pack "$root\UnitsNet.NanoFramework\GeneratedCode\Acceleration\UnitsNet.NanoFramework.Acceleration.nuspec" -Verbosity detailed -OutputDirectory "$nugetOutDir"

}

export-modulemember -function Invoke-BuildNanoNugets
