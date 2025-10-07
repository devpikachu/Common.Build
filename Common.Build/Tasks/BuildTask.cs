using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Clean;
using Cake.Common.Tools.DotNet.Publish;
using Cake.Frosting;
using Common.Build.Core;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var cleanConfig = new DotNetCleanSettings
        {
            Configuration = context.InternalConfig.Profile
        };
        context.DotNetClean(context.InternalConfig.ProjectFilePath, cleanConfig);

        var publishConfig = new DotNetPublishSettings
        {
            Configuration = context.InternalConfig.Profile
        };
        context.DotNetPublish(context.InternalConfig.ProjectFilePath, publishConfig);
    }
}
