@echo off
SET ROOT=%~dp0..
SET NuGetExe=%ROOT%\Tools\NuGet.exe
SET SolutionFile=%ROOT%\UnitsNet.sln
%NuGetExe% restore %SolutionFile%
if %errorlevel% neq 0 exit /b %errorlevel%