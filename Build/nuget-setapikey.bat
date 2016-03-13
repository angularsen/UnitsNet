@echo off
call powershell -NoProfile %ROOT%\Build\nuget-setapikey.ps1
if %errorlevel% neq 0 exit /b %errorlevel%