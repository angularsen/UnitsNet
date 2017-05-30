@echo off
SET scriptdir=%~dp0
call powershell -NoProfile %scriptdir%\clean.ps1
if %errorlevel% neq 0 exit /b %errorlevel%