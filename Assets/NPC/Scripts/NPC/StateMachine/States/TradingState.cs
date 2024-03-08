using UnityEngine;

namespace Assets.NPC.Scripts.NPC
{
    public class TradingState : NPCState
    {
        private readonly TradingStateConfig _tradingStateConfig;

        private readonly Timer _timer;

        public TradingState(IStateSwitcher stateSwitcher, NPC npc) : base(stateSwitcher, npc)
        {
            _tradingStateConfig = npc.Config.TradingStateConfig;
            _timer = new Timer();
        }

        public override void Enter()
        {
            base.Enter();

            _timer.Reset(_tradingStateConfig.TradingTime);
        }

        public override void Update()
        {
            base.Update();

            _timer.Update(Time.deltaTime);

            if (_timer.IsRunning() == false)
            {
                StateSwitcher.SwitchState<WalkingToRestState>();
            }
        }
    }
}