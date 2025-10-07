using Cake.Common.IO;

namespace Common.Build.Core;

public static class PathHandling
{
    public static string InputPath(BuildContext context, string? path = null)
    {
        var inputPath = Path.Combine("..", context.InternalConfig.Project, "bin", context.InternalConfig.Profile);

        if (!string.IsNullOrWhiteSpace(context.ProjectConfig.OutputSubdir))
        {
            inputPath = Path.Combine(inputPath, context.ProjectConfig.OutputSubdir);
        }

        inputPath = Path.Combine(inputPath, "publish");
        return path == null ? inputPath : Path.Combine(inputPath, path);
    }

    public static string OutputPath(BuildContext context, string? path = null)
    {
        var outputPath = Path.Combine("..", "out");
        context.EnsureDirectoryExists(outputPath);

        return path == null ? outputPath : Path.Combine(outputPath, path);
    }
}
