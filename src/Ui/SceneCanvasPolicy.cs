namespace TnTRFMod.Ui;

internal enum LocalCanvasPlacement
{
    SceneCanvas,
    DetachedOverlay
}

internal static class SceneCanvasPolicy
{
    internal static LocalCanvasPlacement GetPlacement(string sceneName, bool hitStatsPanelEnabled)
    {
        if (!hitStatsPanelEnabled) return LocalCanvasPlacement.SceneCanvas;

        return sceneName is "Enso" or "EnsoTest"
            ? LocalCanvasPlacement.DetachedOverlay
            : LocalCanvasPlacement.SceneCanvas;
    }

    internal static bool ShouldForceVisible(LocalCanvasPlacement placement)
    {
        return placement == LocalCanvasPlacement.DetachedOverlay;
    }
}
