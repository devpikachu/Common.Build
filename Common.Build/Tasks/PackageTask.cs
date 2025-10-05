using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Pack;
using Cake.Frosting;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class PackageTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var packConfig = new DotNetPackSettings
        {
            Configuration = context.Profile,
            NoRestore = true,
            NoBuild = true,
            OutputDirectory = context.OutputPath()
        };
        context.DotNetPack(context.ProjectFile, packConfig);
    }
}
