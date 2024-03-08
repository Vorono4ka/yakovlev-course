using UnityEngine;

namespace Assets.NPC.Scripts.NPC
{
    public abstract class NPCState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;

        private readonly NPC _npc;

        protected CharacterController Controller => _npc.Controller;

        protected NPCState(IStateSwitcher stateSwitcher, NPC npc)
        {
            StateSwitcher = stateSwitcher;
            _npc = npc;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update() { }
    }
}