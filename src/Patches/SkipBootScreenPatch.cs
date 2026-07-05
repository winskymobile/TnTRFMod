using HarmonyLib;
using System.Reflection;
using TnTRFMod.Config;
using UnityEngine;
using UnityEngine.SceneManagement;
#if BEPINEX
using Scripts.OutGame.Boot;
using Scripts.OutGame.Common;
#endif

#if MELONLOADER
using Il2CppScripts.OutGame.Boot;
using Il2CppScripts.OutGame.Common;
#endif

namespace TnTRFMod.Patches;

[HarmonyPatch]
internal class SkipBootScreenPatch
{
    private static bool IsBootScene()
    {
        return SceneManager.GetActiveScene().name == "Boot";
    }

    [HarmonyPatch(typeof(BootImage))]
    [HarmonyPatch(nameof(BootImage.PlayAsync))]
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPrefix]
    private static void BootImage_PlayAsync_Prefix(BootImage __instance, ref float duration, ref bool skippable)
    {
        if (!ModConfig.EnableSkipBootScreenPatch.Value) return;
        duration = 0f;
        skippable = true;
    }

    [HarmonyPatch(typeof(FadeCover))]
    [HarmonyPatch(nameof(FadeCover.FadeOutAsync))]
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPrefix]
    private static void FadeCover_FadeOutAsync_Prefix(FadeCover __instance, ref Color color, ref float duration)
    {
        if (!ModConfig.EnableSkipBootScreenPatch.Value) return;
        if (IsBootScene()) duration = 0f;
    }

    [HarmonyPatch(typeof(FadeCover))]
    [HarmonyPatch(nameof(FadeCover.FadeInAsync))]
    [HarmonyPatch(MethodType.Normal)]
    [HarmonyPrefix]
    private static void FadeCover_FadeInAsync_Prefix(FadeCover __instance, ref Color color, ref float duration)
    {
        if (!ModConfig.EnableSkipBootScreenPatch.Value) return;
        if (IsBootScene()) duration = 0f;
    }
}

[HarmonyPatch]
internal class SkipBootMoviePatch
{
    [HarmonyPrepare]
    private static bool Prepare()
    {
        return PatchCompatibilityPolicy.ShouldPatchOptionalTarget(TargetMethod());
    }

    [HarmonyTargetMethod]
    private static MethodBase? TargetMethod()
    {
        return typeof(BootImage).GetMethod("PlayMovieAsync",
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    }

    [HarmonyPrefix]
    private static void BootImage_PlayMovieAsync_Prefix(object __instance, ref bool skippable)
    {
        if (!ModConfig.EnableSkipBootScreenPatch.Value) return;
        skippable = true;

        var movieController = AccessTools.Property(__instance.GetType(), "MovieController")?.GetValue(__instance);
        var player = movieController?.GetType().GetField("player")?.GetValue(movieController);
        player?.GetType().GetMethod("SetVolume")?.Invoke(player, [0]);
    }
}
