#!/bin/bash
# Increments version of nugets UnitNets, OasysUnits.NumberExtensions.
script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
set_version_script="$script_dir/set-version-OasysUnits.ps1"

if [ $# -eq 1 ]; then
    powershell -NoProfile $set_version_script -setVersion $1
    exit 0
else
    echo "Usage: ./set-version.sh <version>"
    echo ""
    echo "Examples:"
    echo "$ ./set-version.sh 5.0.0-alpha001"
    echo "$ ./set-version.sh 5.1.2"
    exit 1
fi