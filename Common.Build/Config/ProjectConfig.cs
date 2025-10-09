using JetBrains.Annotations;

namespace Common.Build.Config;

[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.Members)]
public class ProjectConfig
{
    public required string? Name { get; init; }
    public required string? OutputSubdir { get; init; }
    public required List<string> Substitute { get; init; }
}
