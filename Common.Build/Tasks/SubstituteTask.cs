using Cake.Frosting;
using Common.Build.Core;
using JetBrains.Annotations;

namespace Common.Build.Tasks;

[UsedImplicitly]
public class SubstituteTask : FrostingTask<BuildContext>
{
    private const string VersionPlaceholder = "12.34.56";

    public override bool ShouldRun(BuildContext context) => !context.InternalConfig.SkipSubstitution && context.ProjectConfig.SubstitutionTargets.Count != 0;

    public override void Run(BuildContext context)
    {
        foreach (var substitutionTarget in context.ProjectConfig.SubstitutionTargets)
        {
            var path = Path.Combine("..", context.InternalConfig.Project, substitutionTarget);
            if (!File.Exists(path))
            {
                throw new ApplicationException($"File for substitution \"{path}\" does not exist");
            }

            var contents = File.ReadAllText(path);

            contents = contents.Replace(VersionPlaceholder, context.InternalConfig.Version);
            foreach (var substitution in context.SolutionConfig.Substitutions ?? [])
            {
                contents = contents.Replace(substitution.Key, substitution.Value);
            }

            File.WriteAllText(path, contents);
        }
    }
}
