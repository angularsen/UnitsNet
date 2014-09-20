@echo off
SET ROOT=%~dp0..
SET NugetSpecFile=%ROOT%\Build\UnitsNet.nuspec
SET NuGetExe=%ROOT%\Src\.nuget\NuGet.exe
SET NuGetOutDir=%ROOT%\Artifacts\NuGet

mkdir "%NuGetOutDir%"

%NuGetExe% pack %NugetSpecFile% -Verbosity detailed -OutputDirectory "%NuGetOutDir%" -BasePath "%ROOT%"