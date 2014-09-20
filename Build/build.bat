@echo off
rmdir /Q /S %CD%\..\Artifacts

call build-src-release.bat
call build-tests.bat
call run-tests.bat
call pack-nuget.bat
call zip-artifacts.bat
pause