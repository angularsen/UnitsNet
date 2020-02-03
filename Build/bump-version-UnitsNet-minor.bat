@echo off
SET scriptdir=%~dp0
call powershell -NoProfile %scriptdir%\set-version-UnitsNet.ps1 -bump minor
call powershell -NoProfile %scriptdir%\set-version-UnitsNet.NumberExtensions.ps1 -bump minor
if %errorlevel% neq 0 exit /b %errorlevel%