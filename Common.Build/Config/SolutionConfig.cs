using JetBrains.Annotations;

namespace Common.Build.Config;

[UsedImplicitly]
public class SolutionConfig
{
    public required string Name { get; [UsedImplicitly] init; }
    public required string Version { get; [UsedImplicitly] init; }
}
