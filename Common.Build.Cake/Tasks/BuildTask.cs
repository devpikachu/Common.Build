using Cake.Frosting;
using JetBrains.Annotations;

namespace Common.Build.Cake.Tasks;

[UsedImplicitly]
[TaskName("Build")]
[IsDependentOn(typeof(SubstituteTask))]
public class BuildTask : Build.Tasks.BuildTask;
