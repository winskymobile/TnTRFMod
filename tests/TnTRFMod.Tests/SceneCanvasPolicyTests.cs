using TnTRFMod.Ui;
using Xunit;

namespace TnTRFMod.Tests;

public class SceneCanvasPolicyTests
{
    [Fact]
    public void UsesDetachedOverlay_ForEnso_WhenHitStatsPanelIsEnabled()
    {
        Assert.Equal(
            LocalCanvasPlacement.DetachedOverlay,
            SceneCanvasPolicy.GetPlacement("Enso", hitStatsPanelEnabled: true));
    }

    [Fact]
    public void UsesDetachedOverlay_ForEnsoTest_WhenHitStatsPanelIsEnabled()
    {
        Assert.Equal(
            LocalCanvasPlacement.DetachedOverlay,
            SceneCanvasPolicy.GetPlacement("EnsoTest", hitStatsPanelEnabled: true));
    }

    [Fact]
    public void UsesSceneCanvas_ForEnso_WhenHitStatsPanelIsDisabled()
    {
        Assert.Equal(
            LocalCanvasPlacement.SceneCanvas,
            SceneCanvasPolicy.GetPlacement("Enso", hitStatsPanelEnabled: false));
    }

    [Fact]
    public void UsesSceneCanvas_ForNonGameplayScenes()
    {
        Assert.Equal(
            LocalCanvasPlacement.SceneCanvas,
            SceneCanvasPolicy.GetPlacement("SongSelect", hitStatsPanelEnabled: true));
    }

    [Fact]
    public void DetachedOverlay_ForcesCanvasVisible()
    {
        Assert.True(SceneCanvasPolicy.ShouldForceVisible(LocalCanvasPlacement.DetachedOverlay));
        Assert.False(SceneCanvasPolicy.ShouldForceVisible(LocalCanvasPlacement.SceneCanvas));
    }
}
