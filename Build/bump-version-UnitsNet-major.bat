@echo off
SET scriptdir=%~dp0
call powershell -NoProfile %scriptdir%\set-version-UnitsNet.ps1 -bump major
if %errorlevel% neq 0 exit /b %errorlevel%