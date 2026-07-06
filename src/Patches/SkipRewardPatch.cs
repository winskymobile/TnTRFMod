// The patch is from https://github.com/Deathbloodjr/RF.SkipCoinAndRewardScreen
// Under MIT License


using HarmonyLib;
using System.Reflection;
using TnTRFMod.Utils;

#if BEPINEX

#elif MELONLOADER
using Il2CppScripts.CrownPoint;
#endif

namespace TnTRFMod.Patches;

[HarmonyPatch]
internal class SkipRewardPatch
{
    private static readonly (Type OwnerType, int[] Suffixes)[] TargetStateMachines =
    [
        (typeof(ResultPlayer), [164, 163]),
        (typeof(ResultPlayerScenario), [157]),
        (typeof(ResultVsPlayer), [92])
    ];

    private static readonly HashSet<Type> WarnedMissingStateMembers = [];

    [HarmonyTargetMethods]
    private static IEnumerable<MethodBase> TargetMethods()
    {
        foreach (var (ownerType, suffixes) in TargetStateMachines)
        {
            foreach (var suffix in suffixes)
            {
                var stateMachine = AccessTools.Inner(ownerType, $"_ShowDonCoinAndRewardAsync_d__{suffix}");
                if (stateMachine == null) continue;

                var moveNext = AccessTools.Method(stateMachine, "MoveNext");
                if (moveNext != null) yield return moveNext;
            }
        }
    }

    [HarmonyPrefix]
    public static void ResultPlayer_ShowDonCoinAndRewardAsync_MoveNext_Prefix(object __instance)
    {
        if (SkipRewardStateMachinePolicy.TryForceCompleted(__instance)) return;

        var type = __instance.GetType();
        if (!WarnedMissingStateMembers.Add(type)) return;

        Logger.Warn($"SkipRewardPatch could not find a compatible state member on {type.FullName}; reward skip was not applied for this state machine.");
    }
}
