using TnTRFMod.Patches;
using Xunit;

namespace TnTRFMod.Tests;

public class PatchCompatibilityPolicyTests
{
    [Fact]
    public void ShouldSkipOptionalPatch_WhenTargetMethodIsMissing()
    {
        Assert.False(PatchCompatibilityPolicy.ShouldPatchOptionalTarget(null));
    }

    [Fact]
    public void ShouldPatchOptionalPatch_WhenTargetMethodExists()
    {
        Assert.True(PatchCompatibilityPolicy.ShouldPatchOptionalTarget(typeof(object).GetMethod(nameof(object.GetHashCode))));
    }

    [Fact]
    public void ShouldNotRollbackAllPatches_WhenOnePatchFails()
    {
        Assert.False(PatchCompatibilityPolicy.ShouldRollbackAllPatchesAfterFailure());
    }
}
