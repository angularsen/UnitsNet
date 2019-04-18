@echo off
SET scriptdir=%~dp0
dotnet run --project "%scriptdir%/CodeGen"
rem NOTE: WRC is still on the old PowerShell based codegen as it is not actively maintained anymore and
rem I'm not sure it's worth porting over.
powershell -ExecutionPolicy Bypass -NoProfile -File "%scriptdir%UnitsNet.WindowsRuntimeComponent./Scripts/GenerateUnits.ps1"
