#!/bin/bash
# Sets version of nuget UnitNets.Serialization.JsonNet.
script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
set_version_script="$script_dir/set-version-UnitsNet.Serialization.JsonNet.ps1"

if [ $# -eq 1 ]; then
    powershell -NoProfile $set_version_script -setVersion $1
    exit 0
else
    echo "Usage: ./set-version-json.sh <version>"
    echo ""
    echo "Examples:"
    echo "$ ./set-version-json.sh 5.0.0-alpha001"
    echo "$ ./set-version-json.sh 5.1.2"
    exit 1
fi