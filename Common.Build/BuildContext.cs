using Cake.Common;
using Cake.Common.IO;
using Cake.Core;
using Cake.Frosting;
using Cake.Json;
using Common.Build.Config;
using JetBrains.Annotations;

namespace Common.Build;

[UsedImplicitly]
public class BuildContext : FrostingContext
{
    private const string ConfigFileName = "buildConfig.json";

    public string Project { get; }
    public string Profile { get; }
    public SolutionConfig SolutionConfig { get; }
    public ProjectConfig ProjectConfig { get; }

    public string ProjectFile { get; }

    public BuildContext(ICakeContext context) : base(context)
    {
        Project = context.Argument<string>("project");
        Profile = context.Argument<string>("profile", "Release");

        var solutionPath = Path.Combine("..", ConfigFileName);
        if (!File.Exists(solutionPath))
        {
            Console.WriteLine(solutionPath);
            throw new ApplicationException($"Solution-level \"{ConfigFileName}\" is missing");
        }

        SolutionConfig = context.DeserializeJsonFromFile<SolutionConfig>("../buildConfig.json");

        var projectPath = Path.Combine("..", Project, ConfigFileName);
        if (!File.Exists(projectPath))
        {
            throw new ApplicationException($"Project-level \"{ConfigFileName}\" is missing");
        }

        ProjectConfig = context.DeserializeJsonFromFile<ProjectConfig>(projectPath);

        ProjectFile = Path.Combine("..", Project, $"{Project}.csproj");
    }

    public string InputPath(string? fileName = null)
    {
        var inputPath = Path.Combine("..", Project, "bin", Profile);
        if (!string.IsNullOrWhiteSpace(ProjectConfig.OutputSubdir))
        {
            inputPath = Path.Combine(inputPath, ProjectConfig.OutputSubdir);
        }

        inputPath = Path.Combine(inputPath, "publish");
        return fileName == null ? inputPath : Path.Combine(inputPath, fileName);
    }

    public string OutputPath(string? fileName = null)
    {
        var outputPath = Path.Combine("..", "out");
        this.EnsureDirectoryExists(outputPath);
        return fileName == null ? outputPath : Path.Combine(outputPath, fileName);
    }
}
