using JetBrains.Annotations;

namespace Common.Build.Config;

[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
public class SolutionConfig
{
    public required string? ArchiveName { get; init; }
    public required string? DefaultProject { get; init; }
    public required List<ProjectConfig> Projects { get; init; }
    public required Dictionary<string, string>? Substitutions { get; init; }
}
