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
        if (string.IsNullOrWhiteSpace(context.SolutionConfig.ArchiveName))
        {
            throw new InvalidOperationException("Archival task invoked without specifying an archive name in the build config");
        }

        var archiveName = new StringBuilder(context.SolutionConfig.ArchiveName);
        if (!string.IsNullOrWhiteSpace(context.ProjectConfig.ArchiveSuffix))
        {
            archiveName.Append('_');
            archiveName.Append(context.ProjectConfig.ArchiveSuffix);
        }

        archiveName.Append('_');
        archiveName.Append(context.InternalConfig.Version);
        archiveName.Append(".zip");

        context.Zip(PathHandling.InputPath(context), PathHandling.OutputPath(context, archiveName.ToString()));
    }
}
