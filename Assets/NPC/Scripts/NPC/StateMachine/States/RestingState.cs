using UnityEngine;

public class RestingState : NPCState
{
    private readonly RestingStateConfig _restingStateConfig;

    private Timer _timer;

    public RestingState(IStateSwitcher stateSwitcher, NPC npc) : base(stateSwitcher, npc)
    {
        _restingStateConfig = npc.Config.RestingStateConfig;
        _timer = new Timer();
    }

    public override void Enter()
    {
        base.Enter();

        _timer.Reset(_restingStateConfig.RestingTime);
    }

    public override void Update()
    {
        base.Update();

        _timer.Update(Time.deltaTime);

        if (_timer.IsRunning() == false)
        {
            StateSwitcher.SwitchState<WalkingToTradeState>();
        }
    }
}
