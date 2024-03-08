public abstract class MoveState : GroundedState
{
    protected readonly WalkingStateConfig Config;

    public MoveState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        Config = character.Config.WalkingStateConfig;
    }

    protected bool IsSneakingKeyDown => Input.Movement.Sneak.ReadValue<float>() > 0;
    protected bool IsRunningKeyDown => Input.Movement.Run.ReadValue<float>() > 0;

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero)
            StateSwitcher.SwitchState<IdlingState>();
    }
}