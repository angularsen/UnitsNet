$root="$PSScriptRoot\.."
$nugetDir="$root\Artifacts\NuGet\"
$apiKeyFile="nuget-apikey.txt"

$apiKey = Get-Content $apiKeyFile
Write-Host "Using API key: $apiKey"

$list = gci -Path $nugetDir -Filter UnitsNet.*.nupkg | where-object {$_.Name -NotMatch "\.symbols\."}
foreach ($file in $list)
{
  Write-Host "Publishing nuget: $($file.Name)"
  Invoke-Expression "$root\Tools\nuget.exe push -ApiKey $apiKey $($file.FullName)"
}