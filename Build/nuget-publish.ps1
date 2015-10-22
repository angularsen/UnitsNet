$root="$PSScriptRoot\.."
$nugetDir="$root\Artifacts\NuGet\"
$apiKeyFile="$env:appdata\NuGet\unitsnet-apikey.txt"

# Read API key from file
$apiKey = Get-Content $apiKeyFile

if ([string]::IsNullOrWhitespace($apiKey)) {

    # Ask user to input API key
    Invoke-Expression "$root\Build\nuget-setapikey.ps1"

    $apiKey = Get-Content $apiKeyFile

    if ([string]::IsNullOrWhitespace($apiKey)) {
        return
    }
}

Write-Host "Using API key: $apiKey"

$list = gci -Path $nugetDir -Filter UnitsNet.*.nupkg | where-object {$_.Name -NotMatch "\.symbols\."}
foreach ($file in $list)
{
  Write-Host "Publishing nuget: $($file.Name)"
  Invoke-Expression "$root\Tools\nuget.exe push -ApiKey $apiKey $($file.FullName)"
}