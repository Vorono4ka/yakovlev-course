public class SneakingState : MoveState
{
    public SneakingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = Config.SneakingSpeed;

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

        if (IsSneakingKeyDown == false)
        {
            StateSwitcher.SwitchState<WalkingState>();
        }
    }
}