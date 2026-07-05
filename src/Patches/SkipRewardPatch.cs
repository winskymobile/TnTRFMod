// The patch is from https://github.com/Deathbloodjr/RF.SkipCoinAndRewardScreen
// Under MIT License


using HarmonyLib;
using System.Reflection;

#if BEPINEX

#elif MELONLOADER
using Il2CppScripts.CrownPoint;
#endif

namespace TnTRFMod.Patches;

[HarmonyPatch]
internal class SkipRewardPatch
{
    [HarmonyTargetMethods]
    private static IEnumerable<MethodBase> TargetMethods()
    {
        foreach (var suffix in new[] { 164, 163, 157, 92 })
        {
            var stateMachine = AccessTools.Inner(typeof(ResultPlayer), $"_ShowDonCoinAndRewardAsync_d__{suffix}");
            var moveNext = AccessTools.Method(stateMachine, "MoveNext");
            if (moveNext != null) yield return moveNext;
        }
    }

    [HarmonyPrefix]
    public static void ResultPlayer_ShowDonCoinAndRewardAsync_MoveNext_Prefix(object __instance)
    {
        AccessTools.Field(__instance.GetType(), "__1__state")?.SetValue(__instance, 2);
    }
}
