public class RunningState : GroundedState
{
    private RunningStateConfig _runningStateConfig;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _runningStateConfig = character.Config.RunningStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _runningStateConfig.Speed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero)
            StateSwitcher.SwitchState<IdlingState>();
    }
}