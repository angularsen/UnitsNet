@echo off
SET ROOT=".."
SET NugetSpecFile=%ROOT%\UnitsNet.nuspec
SET NuGetExe=%ROOT%\Src\.nuget\NuGet.exe

%NuGetExe% pack %NugetSpecFile% -Verbosity detailed -OutputDirectory "%ROOT%\Build" -BasePath "%ROOT%"
pause