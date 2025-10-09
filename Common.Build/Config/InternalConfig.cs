namespace Common.Build.Config;

public class InternalConfig
{
    public required string Project { get; set; }
    public required string Profile { get; init; }
    public required string Version { get; init; }
    public required bool SkipSubstitution { get; init; }
    public required string ProjectFilePath { get; set; }
}
