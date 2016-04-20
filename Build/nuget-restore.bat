@echo off
SET ROOT=%~dp0..
SET NuGetExe=%ROOT%\Tools\NuGet.exe

%NuGetExe% restore %ROOT%\UnitsNet.sln
if %errorlevel% neq 0 exit /b %errorlevel%

%NuGetExe% restore %ROOT%\UnitsNet.WindowsRuntimeComponent.sln
if %errorlevel% neq 0 exit /b %errorlevel%