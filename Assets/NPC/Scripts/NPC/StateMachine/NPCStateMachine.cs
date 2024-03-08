using System.Collections.Generic;
using System.Linq;

namespace Assets.NPC.Scripts.NPC
{
    public class NPCStateMachine : IStateSwitcher
    {
        private readonly List<IState> _states;
        private IState _currentState;

        public NPCStateMachine(NPC npc)
        {
            _states = new List<IState>()
            {
                new RestingState(this, npc),
                new WalkingToTradeState(this, npc),
                new WalkingToRestState(this, npc),
                new TradingState(this, npc),
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<State>() where State : IState
        {
            IState state = _states.FirstOrDefault(state => state is State);
            if (state == null)
                throw new System.InvalidOperationException("Target state is not found.");

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
        public void Update() => _currentState.Update();
    }
}