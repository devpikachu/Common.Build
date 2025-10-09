using JetBrains.Annotations;

namespace Common.Build.Config;

[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
public class SolutionConfig
{
    public required string Name { get; init; }
    public required string? DefaultProject { get; init; }
}
