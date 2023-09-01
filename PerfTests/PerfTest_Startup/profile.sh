#!/usr/bin/env bash
# shellcheck disable=SC2155
declare -r dirname=$(dirname -- "$0")

pushd "$dirname" || exit
dotnet publish
dotnet timeit "$dirname/timeit.json"
popd || exit
