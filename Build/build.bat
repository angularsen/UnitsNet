@echo off
rem This file builds everything and is run on the build server as part of
rem building, testing and packing nugets for all master commits and pull requests.

rem Publishing nugets is handled by nuget-publish.bat and run by the build server
rem on the master branch.

rem Optional strong name signing .pfx key file to produce signed binaries and nugets.
set StrongNameSignFile="%1"

set ROOT=%~dp0..

rem Colors
set Reset=[0m
set Red=[31m
set Green=[32m
set Blue=[34m

if exist %StrongNameSignFile% (
	echo %Green%Using strong name signing key file: %StrongNameSignFile%%Reset%
) else (
	echo %Red%No strong name signing key file specified. Will only build unsigned binaries and nugets.[0m
)


echo.
echo %Blue%Clean up%Reset%
echo %Blue%---%Reset%
if exist %ROOT%\Artifacts rmdir /Q /S %ROOT%\Artifacts

rem Regenerate all source code and test stubs before building
rem since there is no guarantee that merged pull requests
rem have properly regenerated code.
echo.
echo %Blue%Generate code%Reset%
echo %Blue%---%Reset%
call %ROOT%\generate-code.bat
if %errorlevel% neq 0 exit /b %errorlevel%

rem Update AsseemblyInfo.cs versions from .nuspec files
echo.
echo %Blue%Update AssemblyInfo.cs files%Reset%
echo %Blue%---%Reset%
call powershell -NoProfile %ROOT%\Build\UpdateAssemblyInfo.ps1
if %errorlevel% neq 0 exit /b %errorlevel%

rem Restore nugets
echo.
echo %Blue%Restore nugets%Reset%
echo %Blue%---%Reset%
call %ROOT%\Build\nuget-restore.bat
if %errorlevel% neq 0 exit /b %errorlevel%

rem Build source and tests
echo.
echo %Blue%Build src and tests%Reset%
echo %Blue%---%Reset%
call %ROOT%\Build\build-all-release.bat
if %errorlevel% neq 0 exit /b %errorlevel%

rem Run all tests
echo.
echo %Blue%Run tests%Reset%
echo %Blue%---%Reset%
call %ROOT%\Build\run-tests.bat
if %errorlevel% neq 0 exit /b %errorlevel%

rem Only build signed binaries if tests pass
echo.
echo %Blue%Build signed src%Reset%
echo %Blue%---%Reset%
call %ROOT%\Build\build-signed-release.bat %StrongNameSignFile%
if %errorlevel% neq 0 exit /b %errorlevel%

rem Pack nugets for both signed and unsigned binaries
echo.
echo %Blue%Pack nugets%Reset%
echo %Blue%---%Reset%
call %ROOT%\Build\pack-nuget.bat
if %errorlevel% neq 0 exit /b %errorlevel%

rem Create a zip bundle of everything, becomes available in TeamCity for download
echo.
echo %Blue%Zip artifacts%Reset%
echo %Blue%---%Reset%
call %ROOT%\Build\zip-artifacts.bat
if %errorlevel% neq 0 exit /b %errorlevel%