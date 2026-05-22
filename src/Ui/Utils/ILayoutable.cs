namespace TnTRFMod.Ui.Utils;

public interface ILayoutable
{
    public void ChangeLayoutMode(LayoutConfig? layoutConfig = null, AutoSizeConfig? autoSizeFitter = null);
}