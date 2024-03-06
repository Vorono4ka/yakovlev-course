using UnityEngine;

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
        Debug.Log("State entered: " + GetType());
    }

    public virtual void Exit() 
    {
        Debug.Log("State exited: " + GetType());
    }

    public virtual void HandleInput() { }

    public virtual void Update() { }
}
