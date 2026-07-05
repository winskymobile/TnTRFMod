using System.Reflection;

namespace TnTRFMod.Patches;

internal static class PatchCompatibilityPolicy
{
    internal static bool ShouldPatchOptionalTarget(MethodBase? targetMethod)
    {
        return targetMethod != null;
    }

    internal static bool ShouldRollbackAllPatchesAfterFailure()
    {
        return false;
    }
}
