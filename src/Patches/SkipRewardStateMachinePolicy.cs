using System.Reflection;

namespace TnTRFMod.Patches;

internal static class SkipRewardStateMachinePolicy
{
    internal const int CompletedState = 2;

    private const string StateMemberName = "__1__state";
    private static readonly BindingFlags StateMemberFlags =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    internal static bool TryForceCompleted(object? stateMachine)
    {
        if (stateMachine == null) return false;

        var type = stateMachine.GetType();

        var property = type.GetProperty(StateMemberName, StateMemberFlags);
        if (property?.CanWrite == true && property.PropertyType == typeof(int))
        {
            property.SetValue(stateMachine, CompletedState);
            return true;
        }

        var field = type.GetField(StateMemberName, StateMemberFlags);
        if (field?.FieldType == typeof(int))
        {
            field.SetValue(stateMachine, CompletedState);
            return true;
        }

        return false;
    }
}
