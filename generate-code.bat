@echo off
SET scriptdir=%~dp0
powershell -ExecutionPolicy Bypass -NoProfile -File "%scriptdir%UnitsNet/Scripts/GenerateUnits.ps1"
powershell -ExecutionPolicy Bypass -NoProfile -File "%scriptdir%UnitsNet.WindowsRuntimeComponent./Scripts/GenerateUnits.ps1"
