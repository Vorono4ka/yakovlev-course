using UnityEngine;

public class WalkingToRestState : NPCState
{
    private readonly NPCWalkingStateConfig _walkingStateConfig;
    private readonly Transform _restingPoint;
    private readonly SimpleMover _simpleMover;

    public WalkingToRestState(IStateSwitcher stateSwitcher, NPC npc) : base(stateSwitcher, npc)
    {
        _walkingStateConfig = npc.Config.WalkingStateConfig;
        _restingPoint = npc.RestingPoint;
        _simpleMover = new SimpleMover(npc);
    }

    public override void Update()
    {
        base.Update();

        Vector3 direction = _simpleMover.MoveToTarget(_restingPoint);

        if (direction.magnitude <= _walkingStateConfig.MinDistanceToTarget)
        {
            StateSwitcher.SwitchState<RestingState>();
        }
    }
}
