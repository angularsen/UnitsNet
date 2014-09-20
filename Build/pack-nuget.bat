@echo off
SET ROOT="%CD%\.."
SET NugetSpecFile=%CD%\UnitsNet.nuspec
SET NuGetExe=%ROOT%\Src\.nuget\NuGet.exe
SET OutDir=%ROOT%\Artifacts\NuGet

mkdir "%OutDir%"

%NuGetExe% pack %NugetSpecFile% -Verbosity detailed -OutputDirectory "%OutDir%" -BasePath "%ROOT%"