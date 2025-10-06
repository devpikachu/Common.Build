using System.Text;
using Cake.Common.IO;
using Cake.Frosting;
using Common.Build.Core;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class ArchiveTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        var archiveName = new StringBuilder(context.SolutionConfig.Name.ToLowerInvariant());
        if (!string.IsNullOrWhiteSpace(context.ProjectConfig.Name))
        {
            archiveName.Append('_');
            archiveName.Append(context.ProjectConfig.Name.ToLowerInvariant());
        }

        archiveName.Append('_');
        archiveName.Append(context.Version);
        archiveName.Append(".zip");

        context.Zip(context.InputPath(), context.OutputPath(archiveName.ToString()));
    }
}
