using TnTRFMod.Scenes.Enso;
using Xunit;

namespace TnTRFMod.Tests;

public class HitStatsPanelPresentationPolicyTests
{
    [Fact]
    public void PanelScale_UsesNinetyPercentSize()
    {
        Assert.Equal(0.90f, HitStatsPanelPresentationPolicy.PanelScale);
    }

    [Fact]
    public void PanelPosition_UsesFixedLeftAndBottomOffset()
    {
        Assert.Equal(37.5f, HitStatsPanelPresentationPolicy.PanelPositionX);
        Assert.Equal(35f, HitStatsPanelPresentationPolicy.PanelBottomOffset);
        Assert.Equal(667f, HitStatsPanelPresentationPolicy.CalculatePanelPositionY(screenHeight: 1080f, panelHeight: 420f));
    }

    [Theory]
    [InlineData(50f, 42.5f)]
    [InlineData(48f, 40.8f)]
    [InlineData(40f, 34f)]
    public void ScaleFont_ReducesBaseFontSizes(float baseFontSize, float expected)
    {
        Assert.Equal(expected, HitStatsPanelPresentationPolicy.ScaleFont(baseFontSize), precision: 3);
    }

    [Fact]
    public void ShouldShow_WhenPlayingBeforeResult()
    {
        Assert.True(HitStatsPanelPresentationPolicy.ShouldShow(isPaused: false, isResultOrLater: false));
    }

    [Fact]
    public void ShouldHide_WhenPaused()
    {
        Assert.False(HitStatsPanelPresentationPolicy.ShouldShow(isPaused: true, isResultOrLater: false));
    }

    [Fact]
    public void ShouldHide_WhenResultOrLater()
    {
        Assert.False(HitStatsPanelPresentationPolicy.ShouldShow(isPaused: false, isResultOrLater: true));
    }
}
