using Cake.Frosting;
using JetBrains.Annotations;

namespace Common.Build.Cake.Tasks;

[UsedImplicitly]
[TaskName("Archive")]
[IsDependentOn(typeof(BuildTask))]
public class ArchiveTask : Build.Tasks.ArchiveTask;
