@echo off
SET scriptdir=%~dp0
pushd "%scriptdir%UnitsNet\Scripts\
powershell -ExecutionPolicy Bypass -NoProfile -File ".\GenerateUnits.ps1"
popd
