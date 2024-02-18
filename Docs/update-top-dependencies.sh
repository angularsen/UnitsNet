#!/bin/bash
echo "Pre-requisites:"
echo "Install Python and PIP package manager."
echo "Configure GitHub access token: export GHTOPDEP_TOKEN=[token]"
echo ""

script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
pip install --quiet ghtopdep
ghtopdep --minstar=10 https://github.com/angularsen/unitsnet | tee "$script_dir/top-dependencies.md"