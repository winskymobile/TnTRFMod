using System.Text.RegularExpressions;
using TnTRFMod;
using Xunit;

namespace TnTRFMod.Tests;

public class ModVersionInfoTests
{
    [Fact]
    public void PluginVersion_IsPlainSemanticVersionForBepInExMetadata()
    {
        Assert.Equal("0.9.0", ModVersionInfo.PluginVersion);
        Assert.Matches(new Regex(@"^\d+\.\d+\.\d+$"), ModVersionInfo.PluginVersion);
    }

    [Fact]
    public void DisplayVersion_CanUseGameUiSuffix()
    {
        Assert.Equal("0.9.0-vt", ModVersionInfo.DisplayVersion);
    }
}
