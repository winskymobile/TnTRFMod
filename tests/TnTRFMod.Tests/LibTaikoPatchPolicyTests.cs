using TnTRFMod.Patches;
using Xunit;

namespace TnTRFMod.Tests;

public class LibTaikoPatchPolicyTests
{
    [Fact]
    public void ShouldApplyKnownPatch_WhenCrcIsSupported_WithoutUnsafeOverride()
    {
        Assert.True(LibTaikoPatchPolicy.ShouldApplyKnownPatch(0x1E5B3CFF, 0x1E5B3CFF, false));
    }

    [Fact]
    public void ShouldNotApplyKnownPatch_WhenCrcIsUnsupported_AndUnsafeOverrideDisabled()
    {
        Assert.False(LibTaikoPatchPolicy.ShouldApplyKnownPatch(0x12345678, 0x1E5B3CFF, false));
    }

    [Fact]
    public void ShouldApplyKnownPatch_WhenCrcIsUnsupported_AndUnsafeOverrideEnabled()
    {
        Assert.True(LibTaikoPatchPolicy.ShouldApplyKnownPatch(0x12345678, 0x1E5B3CFF, true));
    }
}
