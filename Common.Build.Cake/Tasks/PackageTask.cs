using Cake.Frosting;
using JetBrains.Annotations;

namespace Common.Build.Cake.Tasks;

[UsedImplicitly]
[TaskName("Package")]
[IsDependentOn(typeof(BuildTask))]
public class PackageTask : Build.Tasks.PackageTask;
