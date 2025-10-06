$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true

Push-Location Common.Build.Cake
dotnet run --project Common.Build.Cake.csproj -- $args
Pop-Location
