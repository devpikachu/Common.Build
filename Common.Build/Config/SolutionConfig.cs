using JetBrains.Annotations;

namespace Common.Build.Config;

public class SolutionConfig
{
    public required string Name { get; [UsedImplicitly] init; }
    public required string? DefaultProject { get; [UsedImplicitly] init; }
}
