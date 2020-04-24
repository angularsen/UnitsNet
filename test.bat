@echo off
SET root=%~dp0

powershell -NoProfile -Command "Import-Module %root%/Build/build-functions.psm1; Start-Tests"
if %errorlevel% neq 0 exit /b %errorlevel%