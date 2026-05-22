namespace TnTRFMod.Ui.Utils;

public struct LayoutConfig(
    LayoutMode mode = LayoutMode.None,
    float spacing = 0f
)
{
    public LayoutMode mode = mode;
    public float spacing = spacing;
}