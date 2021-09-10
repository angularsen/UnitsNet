@echo off
rem This scripts increases the version of nugets: UnitsNet.Serialization.JsonNet.
rem The change is committed and tagged locally, but must be pushed to origin/master to take effect.
rem Only contributors with write access can perform this directly to master, others must perform via pull request.

SET scriptdir=%~dp0
echo Bump version UnitsNet.Serialization.JsonNet nuget:
echo.
echo 1:   minor    4.90.0 to 4.91.0
echo 2:   patch    4.90.0 to 4.90.1
echo 3:   suffix   5.0.0-beta1 to 5.0.0-beta2
echo 999: major    4.90.0 to 5.0.0
echo 0:   Exit
echo.

set choice=
set /p choice=Choose option:

set bumpval=
if '%choice%'=='1' set bumpval=minor
if '%choice%'=='2' set bumpval=patch
if '%choice%'=='3' set bumpval=suffix
if '%choice%'=='999' set bumpval=major
if '%choice%'=='0' exit /b 0
if '%choice%'=='' exit /b 0

call powershell -NoProfile %scriptdir%\set-version-UnitsNet.Serialization.JsonNet.ps1 -bump %bumpval%
if %errorlevel% neq 0 exit /b %errorlevel%