using UnityEngine;

namespace Assets.NPC.Scripts.NPC
{
    public class WalkingToTradeState : NPCState
    {
        private readonly NPCWalkingStateConfig _walkingStateConfig;
        private readonly Transform _tradingPoint;
        private readonly SimpleMover _simpleMover;

        public WalkingToTradeState(IStateSwitcher stateSwitcher, NPC npc) : base(stateSwitcher, npc)
        {
            _walkingStateConfig = npc.Config.WalkingStateConfig;
            _tradingPoint = npc.TradingPoint;
            _simpleMover = new SimpleMover(npc);
        }

        public override void Update()
        {
            base.Update();

            Vector3 direction = _simpleMover.MoveToTarget(_tradingPoint);

            if (direction.magnitude <= _walkingStateConfig.MinDistanceToTarget)
            {
                StateSwitcher.SwitchState<TradingState>();
            }
        }
    }
}