using TnTRFMod.Patches;
using Xunit;

namespace TnTRFMod.Tests;

public class SkipRewardStateMachinePolicyTests
{
    private sealed class FieldBackedStateMachine
    {
        public int __1__state;
    }

    private sealed class PropertyBackedStateMachine
    {
        public int __1__state { get; set; }
    }

    private sealed class MissingStateMachine
    {
        public int OtherState { get; set; }
    }

    [Fact]
    public void TryForceCompleted_SetsFieldBackedState()
    {
        var stateMachine = new FieldBackedStateMachine { __1__state = -1 };

        var result = SkipRewardStateMachinePolicy.TryForceCompleted(stateMachine);

        Assert.True(result);
        Assert.Equal(SkipRewardStateMachinePolicy.CompletedState, stateMachine.__1__state);
    }

    [Fact]
    public void TryForceCompleted_SetsPropertyBackedState()
    {
        var stateMachine = new PropertyBackedStateMachine { __1__state = -1 };

        var result = SkipRewardStateMachinePolicy.TryForceCompleted(stateMachine);

        Assert.True(result);
        Assert.Equal(SkipRewardStateMachinePolicy.CompletedState, stateMachine.__1__state);
    }

    [Fact]
    public void TryForceCompleted_ReturnsFalseWhenStateIsMissing()
    {
        var stateMachine = new MissingStateMachine();

        var result = SkipRewardStateMachinePolicy.TryForceCompleted(stateMachine);

        Assert.False(result);
    }
}
