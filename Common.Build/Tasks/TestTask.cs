using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Clean;
using Cake.Common.Tools.DotNet.Publish;
using Cake.Common.Tools.DotNet.Test;
using Cake.Frosting;
using Common.Build.Core;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class TestTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var testConfig = new DotNetTestSettings
        {
            Configuration = context.InternalConfig.Profile,
            NoRestore = true,
            NoBuild = true
        };
        context.DotNetTest(context.InternalConfig.ProjectFilePath, testConfig);
    }
}
