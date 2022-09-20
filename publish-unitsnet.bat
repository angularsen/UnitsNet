@echo off
call git checkout master
if %errorlevel% neq 0 goto EXIT

call git pull --rebase --prune
if %errorlevel% neq 0 goto EXIT

call build\bump-version-OasysUnits-minor.bat
if %errorlevel% neq 0 goto EXIT

call git push --follow-tags --set-upstream
if %errorlevel% neq 0 goto EXIT

echo.
echo New version of OasysUnits pushed!

:EXIT
echo.
pause