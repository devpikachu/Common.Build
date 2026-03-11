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
        var configFile = context.Argument<string>("general-config", "buildConfig.json");
        var project = context.Argument<string?>("general-project", null);
        var profile = context.Argument<string>("general-profile", "Release");
        var version = context.Argument<string>("general-version", "12.34.56");
        var skipSubstitution = context.Argument("general-skipSubstitution", false);

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
            SolutionConfig = LoadConfig<SolutionConfig>(context, Path.Combine("..", configFile));
        }

        // Project picking
        {
            if (project is null)
            {
                if (SolutionConfig.DefaultProject is null)
                {
                    throw new InvalidOperationException("No project specified as an argument and no default project specified in the build config");
                }

                InternalConfig.Project = SolutionConfig.DefaultProject;
            }
            else
            {
                InternalConfig.Project = project;
            }

            ProjectConfig = SolutionConfig.Projects.First(projectConfig => projectConfig.Name == InternalConfig.Project);
        }
    }

    private static TConfig LoadConfig<TConfig>(ICakeContext context, string path)
    {
        return !File.Exists(path)
            ? throw new InvalidOperationException($"Configuration file {path} not found")
            : context.DeserializeJsonFromFile<TConfig>(path);
    }
}
