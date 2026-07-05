namespace TnTRFMod.Scenes.Enso;

internal static class HitStatsPanelPresentationPolicy
{
    internal const float PanelScale = 0.90f;
    internal const float PanelPositionX = 37.5f;
    internal const float PanelBottomOffset = 35f;
    internal const float FontScale = 0.85f;

    internal static float ScaleFont(float baseFontSize)
    {
        return baseFontSize * FontScale;
    }

    internal static float CalculatePanelPositionY(float screenHeight, float panelHeight)
    {
        return screenHeight - PanelBottomOffset - panelHeight * PanelScale;
    }

    internal static bool ShouldShow(bool isPaused, bool isResultOrLater)
    {
        return !isPaused && !isResultOrLater;
    }
}
