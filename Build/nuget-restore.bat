@echo off
SET ROOT=%~dp0..
SET NuGetExe=%ROOT%\Tools\NuGet.exe
SET SolutionFile=%ROOT%\UnitsNet.2015.sln
%NuGetExe% restore %SolutionFile%