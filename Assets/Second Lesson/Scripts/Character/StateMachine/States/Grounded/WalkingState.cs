public class WalkingState : GroundedState
{
    private readonly WalkingStateConfig _walkingStateConfig;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _walkingStateConfig = character.Config.WalkingStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _walkingStateConfig.Speed;

        View.StartWalking();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWalking();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero)
            StateSwitcher.SwitchState<IdlingState>();

        // Возможно, стоило сделать это через подписку на событие кнопки, но вдруг игрок отожмёт кнопку во время смены стейтов? Тогда коллбек не придёт и игрок "застрянет" в определенном стейте
        if (Input.Movement.Run.ReadValue<float>() > 0)
        {
            StateSwitcher.SwitchState<RunningState>();
        }
    }
}