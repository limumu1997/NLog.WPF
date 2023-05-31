# NLog.WPF
 NLog.WPF


dotnet pack --configuration Release
dotnet nuget push "bin/Release/NLog.WPF.1.2.0.nupkg"  --api-key YOUR_GITHUB_PAT  --source "https://nuget.pkg.github.com/limumu1997/index.json"