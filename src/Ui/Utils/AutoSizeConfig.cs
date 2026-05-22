using UnityEngine.UI;

namespace TnTRFMod.Ui.Utils;

public struct AutoSizeConfig(
    ContentSizeFitter.FitMode horizontalFit = ContentSizeFitter.FitMode.Unconstrained,
    ContentSizeFitter.FitMode verticalFit = ContentSizeFitter.FitMode.Unconstrained)
{
    public ContentSizeFitter.FitMode horizontalFit = horizontalFit;
    public ContentSizeFitter.FitMode verticalFit = verticalFit;
}