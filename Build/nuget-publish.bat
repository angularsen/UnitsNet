@echo off
SET ROOT=%~dp0..
call powershell -NoProfile %ROOT%\Build\nuget-publish.ps1