@echo off
SET scriptdir=%~dp0
call powershell -NoProfile %scriptdir%\nuget-version.ps1 -b major
if %errorlevel% neq 0 exit /b %errorlevel%