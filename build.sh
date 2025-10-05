#!/usr/bin/env bash
pushd Common.Build.Cake || exit 1
dotnet run --project Common.Build.Cake/Common.Build.Cake.csproj -- "$@"
popd || exit 1
