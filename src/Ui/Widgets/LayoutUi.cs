using TnTRFMod.Ui.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace TnTRFMod.Ui.Widgets;

public class LayoutUi : BaseUi, ILayoutable
{
    public LayoutUi()
    {
    }

    public LayoutUi(LayoutConfig layoutConfig)
    {
        ChangeLayoutMode(layoutConfig);
    }

    public void ChangeLayoutMode(LayoutConfig? layoutConfig = null, AutoSizeConfig? autoSizeFitter = null)
    {
        if (layoutConfig.HasValue)
        {
            switch (layoutConfig.Value.mode)
            {
                case LayoutMode.None:
                {
                    if (_go.TryGetComponent(out HorizontalLayoutGroup hl))
                        UnityEngine.Object.Destroy(hl);

                    if (_go.TryGetComponent(out VerticalLayoutGroup vl))
                        UnityEngine.Object.Destroy(vl);

                    if (_go.TryGetComponent(out ContentSizeFitter fitter))
                        UnityEngine.Object.Destroy(fitter);

                    break;
                }
                case LayoutMode.Vertical:
                {
                    if (_go.TryGetComponent(out HorizontalLayoutGroup hl)) UnityEngine.Object.Destroy(hl);

                    var vl = _go.GetComponent<VerticalLayoutGroup>() ?? _go.AddComponent<VerticalLayoutGroup>();
                    vl.childControlWidth = true;
                    vl.childControlHeight = true;
                    vl.childForceExpandWidth = false;
                    vl.childForceExpandHeight = false;
                    vl.spacing = layoutConfig.Value.spacing;

                    if (autoSizeFitter != null)
                    {
                        var fitter = _go.GetComponent<ContentSizeFitter>() ?? _go.AddComponent<ContentSizeFitter>();
                        fitter.horizontalFit = autoSizeFitter.Value.horizontalFit;
                        fitter.verticalFit = autoSizeFitter.Value.verticalFit;
                    }

                    break;
                }
                case LayoutMode.Horizontal:
                {
                    if (_go.TryGetComponent(out VerticalLayoutGroup vl))
                        UnityEngine.Object.Destroy(vl);

                    var hl = _go.GetComponent<HorizontalLayoutGroup>() ?? _go.AddComponent<HorizontalLayoutGroup>();
                    hl.childControlWidth = true;
                    hl.childControlHeight = true;
                    hl.childForceExpandWidth = false;
                    hl.childForceExpandHeight = false;
                    hl.spacing = layoutConfig.Value.spacing;

                    if (autoSizeFitter != null)
                    {
                        var fitter = _go.GetComponent<ContentSizeFitter>() ?? _go.AddComponent<ContentSizeFitter>();
                        fitter.horizontalFit = autoSizeFitter.Value.horizontalFit;
                        fitter.verticalFit = autoSizeFitter.Value.verticalFit;
                    }

                    break;
                }
            }
        }
        else
        {
            if (_go.TryGetComponent(out HorizontalLayoutGroup hl))
                UnityEngine.Object.Destroy(hl);

            if (_go.TryGetComponent(out VerticalLayoutGroup vl))
                UnityEngine.Object.Destroy(vl);

            if (_go.TryGetComponent(out ContentSizeFitter fitter))
                UnityEngine.Object.Destroy(fitter);
        }
    }
}