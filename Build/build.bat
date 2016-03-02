@echo off
SET ROOT=%~dp0..
rmdir /Q /S %ROOT%\Artifacts

call powershell -NoProfile %ROOT%\Build\UpdateAssemblyInfo.ps1
call powershell -ExecutionPolicy Bypass -NoProfile -File %ROOT%\UnitsNet\Scripts\GenerateUnits.ps1
call %ROOT%\Build\nuget-restore.bat
call %ROOT%\Build\build-src-release.bat
call %ROOT%\Build\build-tests.bat
call %ROOT%\Build\run-tests.bat
call %ROOT%\Build\pack-nuget.bat
call %ROOT%\Build\zip-artifacts.bat