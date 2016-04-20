@echo off
SET ROOT=%~dp0..
SET MainNuspec=%ROOT%\Build\UnitsNet.nuspec
SET UwpNuspec=%ROOT%\Build\UnitsNet.WindowsRuntimeComponent.nuspec
SET SerializationNuspec=%ROOT%\Build\UnitsNet.Serialization.JsonNet.nuspec
SET NuGetExe=%ROOT%\Tools\NuGet.exe
SET NuGetOutDir=%ROOT%\Artifacts\NuGet

mkdir "%NuGetOutDir%"

%NuGetExe% pack %MainNuspec% -Verbosity detailed -OutputDirectory "%NuGetOutDir%" -BasePath "%ROOT%" -Symbols
if %errorlevel% neq 0 exit /b %errorlevel%
%NuGetExe% pack %UwpNuspec% -Verbosity detailed -OutputDirectory "%NuGetOutDir%" -BasePath "%ROOT%" -Symbols
if %errorlevel% neq 0 exit /b %errorlevel%
%NuGetExe% pack %SerializationNuspec% -Verbosity detailed -OutputDirectory "%NuGetOutDir%" -BasePath "%ROOT%" -Symbols
if %errorlevel% neq 0 exit /b %errorlevel%
