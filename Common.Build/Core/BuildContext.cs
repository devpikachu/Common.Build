using Cake.Common;
using Cake.Core;
using Cake.Frosting;
using Cake.Json;
using Common.Build.Config;
using JetBrains.Annotations;

namespace Common.Build.Core;

[UsedImplicitly]
public class BuildContext : FrostingContext
{
    public InternalConfig InternalConfig { get; }
    public SolutionConfig SolutionConfig { get; }
    public ProjectConfig ProjectConfig { get; }

    public BuildContext(ICakeContext context) : base(context)
    {
        // General
        var project = context.Argument<string?>("general-project", null);
        var profile = context.Argument<string>("general-profile", "Release");
        var version = context.Argument<string>("general-version", "12.34.56");
        var skipSubstitution = context.Argument("general-skipSubstitution", false);
        var solutionConfigFile = context.Argument<string>("config-solution", "buildConfig.json");
        var projectConfigFile = context.Argument<string>("config-project", "buildConfig.json");

        // Internal config
        {
            InternalConfig = new InternalConfig
            {
                Project = string.Empty,
                Profile = profile,
                Version = version,
                SkipSubstitution = skipSubstitution,
                ProjectFilePath = string.Empty
            };
        }

        // Solution config
        {
            SolutionConfig = LoadConfig<SolutionConfig>(context, Path.Combine("..", solutionConfigFile));
        }

        // Project picking
        {
            if (project is null)
            {
                if (SolutionConfig.DefaultProject is null)
                {
                    throw new InvalidOperationException("No project specified as an argument and no default project specified in the solution config");
                }

                InternalConfig.Project = SolutionConfig.DefaultProject;
            }
            else
            {
                InternalConfig.Project = project;
            }

            InternalConfig.ProjectFilePath = Path.Combine("..", InternalConfig.Project, $"{InternalConfig.Project}.csproj");
        }

        // Project config
        {
            ProjectConfig = LoadConfig<ProjectConfig>(context, Path.Combine("..", InternalConfig.Project, projectConfigFile));
        }
    }

    private static TConfig LoadConfig<TConfig>(ICakeContext context, string path)
    {
        return !File.Exists(path)
            ? throw new InvalidOperationException($"Configuration file {path} not found")
            : context.DeserializeJsonFromFile<TConfig>(path);
    }
}
