using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Pack;
using Cake.Frosting;
using Common.Build.Core;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class PackageTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var packConfig = new DotNetPackSettings
        {
            Configuration = context.InternalConfig.Profile,
            NoRestore = true,
            NoBuild = true,
            OutputDirectory = PathHandling.OutputPath(context)
        };
        context.DotNetPack(context.InternalConfig.ProjectFilePath, packConfig);
    }
}
