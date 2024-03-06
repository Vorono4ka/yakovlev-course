using UnityEngine;

public class WalkingToRestState : NPCState
{
    private readonly WalkingStateConfig _walkingStateConfig;
    private readonly Transform _restingPoint;
    private readonly Transform _npcTransform;

    public WalkingToRestState(IStateSwitcher stateSwitcher, NPC npc) : base(stateSwitcher, npc)
    {
        _walkingStateConfig = npc.Config.WalkingStateConfig;
        _restingPoint = npc.RestingPoint;
        _npcTransform = npc.transform;
    }

    public override void Update()
    {
        base.Update();

        Vector3 direction = _restingPoint.position - Controller.transform.position;
        direction.y = 0;

        Vector3 moveVector = direction * _walkingStateConfig.Speed * Time.deltaTime;
        _npcTransform.Translate(moveVector);

        if (direction.magnitude <= _walkingStateConfig.MinDistanceToTarget)
        {
            StateSwitcher.SwitchState<RestingState>();
        }
    }
}
