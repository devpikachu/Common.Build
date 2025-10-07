using JetBrains.Annotations;

namespace Common.Build.Config;

public class InternalConfig
{
    public required string Project { get; [UsedImplicitly] set; }
    public required string Profile { get; [UsedImplicitly] init; }
    public required string Version { get; [UsedImplicitly] init; }
    public required bool SkipSubstitution { get; [UsedImplicitly] init; }
    public required string ProjectFilePath { get; [UsedImplicitly] set; }
}
