using UnityEngine;

public class WalkingToTradeState : NPCState
{
    private readonly WalkingStateConfig _walkingStateConfig;
    private readonly Transform _tradingPoint;
    private readonly Transform _npcTransform;

    public WalkingToTradeState(IStateSwitcher stateSwitcher, NPC npc) : base(stateSwitcher, npc)
    {
        _walkingStateConfig = npc.Config.WalkingStateConfig;
        _tradingPoint = npc.TradingPoint;
        _npcTransform = npc.transform;
    }

    public override void Update()
    {
        base.Update();

        Vector3 direction = _tradingPoint.position - Controller.transform.position;
        direction.y = 0;

        Vector3 moveVector = direction * _walkingStateConfig.Speed * Time.deltaTime;
        _npcTransform.Translate(moveVector);

        if (direction.magnitude <= _walkingStateConfig.MinDistanceToTarget)
        {
            StateSwitcher.SwitchState<TradingState>();
        }
    }
}
