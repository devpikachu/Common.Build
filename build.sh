set -e

pushd Common.Build.Cake
dotnet run --project Common.Build.Cake.csproj -- "$@"
popd
