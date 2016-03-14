@echo off
SET ROOT=%~dp0..
SET MainLibNuspec=%ROOT%\Build\UnitsNet.nuspec
SET SerializationLibNuspec=%ROOT%\Build\UnitsNet.Serialization.JsonNet.nuspec
SET NuGetExe=%ROOT%\Tools\NuGet.exe
SET NuGetOutDir=%ROOT%\Artifacts\NuGet

mkdir "%NuGetOutDir%"

%NuGetExe% pack %MainLibNuspec% -Verbosity detailed -OutputDirectory "%NuGetOutDir%" -BasePath "%ROOT%" -Symbols
if %errorlevel% neq 0 exit /b %errorlevel%
%NuGetExe% pack %SerializationLibNuspec% -Verbosity detailed -OutputDirectory "%NuGetOutDir%" -BasePath "%ROOT%" -Symbols
if %errorlevel% neq 0 exit /b %errorlevel%