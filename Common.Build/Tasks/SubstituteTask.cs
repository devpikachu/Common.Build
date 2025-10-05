using Cake.Frosting;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class SubstituteTask : FrostingTask<BuildContext>
{
    private const string VersionPlaceholder = "12.34.56";

    public override void Run(BuildContext context)
    {
        foreach (var substitute in context.ProjectConfig.Substitute)
        {
            var path = Path.Combine("..", context.Project, substitute);
            if (!File.Exists(path))
            {
                throw new ApplicationException($"File for substitution \"{path}\" does not exist");
            }

            var contents = File.ReadAllText(path);
            contents = contents.Replace(VersionPlaceholder, context.SolutionConfig.Version);

            File.WriteAllText(path, contents);
        }
    }
}
