@echo off
SET scriptdir=%~dp0
SET projectdir="%scriptdir%..\.."
SET exportdir="%projectdir%\Artifacts\Benchmark"
:: this fails on the build server (also tested with the nightly benchmark.net package: 0.12.1.1533): possibly related to https://github.com/dotnet/BenchmarkDotNet/issues/1487
dotnet run --project "%projectdir%\UnitsNet.Benchmark" -c Release ^
--framework net5.0 ^
--runtimes net472 net48 netcoreapp2.1 netcoreapp3.1 net6.0 ^
--artifacts=%exportdir% ^
--exporters rplot ^
--filter * ^
--iterationTime 1500 ^
--statisticalTest 10us ^
--join %1 %2 %3

:: this creates an R script producing that uses the Job_Runtime instead of Job_Id (for readibility)
powershell "(Get-Content %exportdir%\results\BuildPlots.R) -replace 'Job_Id', 'Job_Runtime' | Out-File -encoding ASCII %exportdir%\results\BuildPlots_Runtime.R"
