using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Clean;
using Cake.Common.Tools.DotNet.Publish;
using Cake.Frosting;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var cleanConfig = new DotNetCleanSettings
        {
            Configuration = context.Profile
        };
        context.DotNetClean(context.ProjectFile, cleanConfig);

        var publishConfig = new DotNetPublishSettings
        {
            Configuration = context.Profile
        };
        context.DotNetPublish(context.ProjectFile, publishConfig);
    }
}
