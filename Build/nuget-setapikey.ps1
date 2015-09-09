$root="$PSScriptRoot\.."
$nugetDir="$root\Artifacts\NuGet\"
$apiKeyFile="$env:appdata\NuGet\unitsnet-apikey.txt"

# Ask user to input key
$apiKey = Read-Host "Enter nuget.org API key"

if ([string]::IsNullOrWhitespace($apiKey)) {
    Write-Error "No API key specified."
    return
}

Set-Content $apiKeyFile $apiKey 
Write-Host "Using API key: $apiKey"