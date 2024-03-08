namespace Assets.NPC.Scripts.NPC
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }
}