namespace Assets.NPC.Scripts.NPC
{
    public interface IStateSwitcher
    {
        void SwitchState<State>() where State : IState;
    }
}