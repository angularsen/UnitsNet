@echo off
SET ROOT=%~dp0..
rmdir /Q /S %ROOT%\Artifacts

call %ROOT%\Build\nuget-restore.bat
call %ROOT%\Build\build-src-release.bat
call %ROOT%\Build\build-tests.bat
call %ROOT%\Build\run-tests.bat
call %ROOT%\Build\pack-nuget.bat
call %ROOT%\Build\zip-artifacts.bat