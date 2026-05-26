using HarmonyLib;

namespace TnTRFMod.Patches;

[HarmonyPatch]
public class GameUiPatches
{
    public static bool DisableMouseWheelInGame = false;

    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPatch(typeof(ControllerManager))]
    [HarmonyPatch(nameof(ControllerManager.GetDirectionMouseScrollWheel))]
    [HarmonyPrefix]
    public static bool GetDirectionMouseScrollWheelPatch(ControllerManager __instance,
        ref ControllerManager.Dir __result)
    {
        if (!DisableMouseWheelInGame) return true;

        __result = ControllerManager.Dir.None;
        return false;
    }
}