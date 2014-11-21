@echo off
SET ROOT=%~dp0..

call %ROOT%\Tools\nuget.exe push %ROOT%\Artifacts\NuGet\*.nupkg