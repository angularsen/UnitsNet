$root = Resolve-Path $PSScriptRoot/..

[int]$exitCode = 0

# When this change is made available, we can possibly simplify below with: `dotnet test MySolution.sln`
# Run tests only for test projects by smadala · Pull Request #1745 · Microsoft/vstest
# https://github.com/Microsoft/vstest/pull/1745
Get-ChildItem -Path $root -Recurse -Filter "*Tests*.csproj" | % {
    $projectFilePath = $_.FullName
    $projectName = [IO.Path]::GetFileNameWithoutExtension($projectFilePath)
    $reportFilePath = [IO.Path]::GetFullPath("$root/TestResults/$projectName.xml")
    dotnet test $projectFilePath --logger "trx;LogFileName=$reportFilePath"
    if ($LASTEXITCODE) { $exitCode = $LASTEXITCODE }
}

Write-Host -ForegroundColor Green "All tests run."
exit $exitCode