@echo off
SET ROOT=%~dp0..
set /p apikey=Enter API key for nuget.org:
echo New api key: %apikey%
%ROOT%\Tools\nuget.exe setApiKey %apikey%