using TnTRFMod.Ui.Widgets;
using UnityEngine;

namespace TnTRFMod.Ui.Utils;

public class StackLayoutBuilder
{
    private readonly List<BaseUi> _children = [];
    private readonly BaseUi _container;

    private readonly LayoutMode _layoutMode;

    public StackLayoutBuilder(LayoutMode layoutMode, BaseUi container)
    {
        if (layoutMode == LayoutMode.None)
            throw new ArgumentException("LayoutMode must be None to use LayoutMode.None");

        _layoutMode = layoutMode;
        _container = container;
    }

    public Rect Padding { get; set; } = new();
    public CrossAxisAlign CrossAxisAlign { get; set; } = CrossAxisAlign.Start;

    public void AddChild(BaseUi child)
    {
        _children.Add(child);
    }

    public void Build()
    {
        var childrenPreferredSizes = _children.Select(c => c.PreferredSize).ToArray();
        var crossAxisMaxSize = _layoutMode == LayoutMode.Horizontal
            ? childrenPreferredSizes.Max(s => s.y)
            : childrenPreferredSizes.Max(s => s.x);

        if (_layoutMode == LayoutMode.Horizontal)
        {
        }
        else if (_layoutMode == LayoutMode.Vertical)
        {
        }
    }
}