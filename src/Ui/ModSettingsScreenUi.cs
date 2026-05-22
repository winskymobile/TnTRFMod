using System;
using System.Collections.Generic;
using TnTRFMod.Config;
using TnTRFMod.Ui.Widgets;
using TnTRFMod.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Logger = TnTRFMod.Utils.Logger;

namespace TnTRFMod.Ui;

/// <summary>
/// 模组设置界面 —— 跨场景持久化的右侧设置面板。
/// 按 F10 切换显示 / 隐藏。
/// </summary>
public static class ModSettingsScreenUi
{
    // 面板常量
    private const float PanelWidth = 640f;
    private const float Margin = 32f;

    // UI 组件引用
    private static FrameUi? _panel;
    private static TextUi? _titleText;
    private static ButtonUi? _tabSceneBtn;
    private static ButtonUi? _tabAllBtn;
    private static ScrollContainerUi? _scrollContainer;

    private static bool _visible;
    private static bool _showingSceneFeatures = true; // true = 当前场景功能, false = 所有设置

    // 等待按键映射的状态
    private static ConfigItemMetadata? _waitingForKeyBinding;
    private static ButtonUi? _waitingKeyButton;

    // 已创建的设置行控件
    private static readonly List<BaseUi> _settingRows = [];

    /// <summary>设置面板是否可见</summary>
    public static bool Visible => _visible;

    public static void Init()
    {
        BuildPanel();
        _visible = false;
        _panel!.Visible = false;
        CloseSettings();
    }

    public static void OpenSettings()
    {
        if (_panel == null) BuildPanel();
        _visible = true;
        _panel!.Visible = true;
    }

    public static void CloseSettings()
    {
        _visible = false;
        _waitingForKeyBinding = null;
        _waitingKeyButton = null;
        _panel!.Visible = false;
    }

    public static void ToggleSettings()
    {
        if (_visible) CloseSettings();
        else OpenSettings();
    }

    /// <summary>
    /// 每帧轮询 F10 和按键映射捕获。
    /// </summary>
    public static void Update()
    {
        // F10 切换
        if (Keyboard.current[Key.F10].wasPressedThisFrame)
            ToggleSettings();

        if (!_visible) return;
    }

    /// <summary>保存配置（占位，TOML 写出待实现）</summary>
    public static void SaveConfig()
    {
        // TODO: 实现 TOML 写出
        Logger.Info("[ModSettings] SaveConfig called (not yet implemented)");
    }

    // ==================== 面板构建 ====================

    private static void BuildPanel()
    {
        // 背景面板 —— 放在全局不死 Canvas 上，靠右
        _panel = new FrameUi
        {
            Name = "ModSettingsPanel",
            Size = new Vector2(PanelWidth, Common.ScreenHeight - Margin * 2 + 18f),
            Position = new Vector2(Common.ScreenWidth - PanelWidth - Margin + 15f, Margin)
        };
        _panel.MoveToNoDestroyCanvas();


        LayoutRebuilder.ForceRebuildLayoutImmediate(_panel._transform);
    }

    private static void SwitchTab(bool sceneFeatures)
    {
        _showingSceneFeatures = sceneFeatures;
        _tabSceneBtn!.ButtonColor = sceneFeatures
            ? new Color(0.2f, 0.6f, 0.2f)
            : new Color(0.25f, 0.25f, 0.35f);
        _tabAllBtn!.ButtonColor = !sceneFeatures
            ? new Color(0.2f, 0.6f, 0.2f)
            : new Color(0.25f, 0.25f, 0.35f);
    }
}