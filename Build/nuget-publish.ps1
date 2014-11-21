$root="$PSScriptRoot\.."
$nugetDir="$root\Artifacts\NuGet\"

$list = gci -Path $nugetDir -Filter UnitsNet.*.nupkg | where-object {$_.Name -NotMatch "\.symbols\."}
foreach ($file in $list)
{
  write-host "Publishing nuget: $($file.Name)"
  & "$root\Tools\nuget.exe push $file"
}