using JetBrains.Annotations;

namespace Common.Build.Config;

[UsedImplicitly]
public class ProjectConfig
{
    public required string? Name { get; [UsedImplicitly] init; }
    public required string? OutputSubdir { get; [UsedImplicitly] init; }
    public required List<string> Substitute { get; [UsedImplicitly] init; }
}
