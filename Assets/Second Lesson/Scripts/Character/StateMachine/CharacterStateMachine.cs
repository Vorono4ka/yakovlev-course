using System.Collections.Generic;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{
    private readonly List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(Character character)
    {
        StateMachineData data = new();

        _states = new List<IState>()
        {
            new IdlingState(this, data, character),
            new WalkingState(this, data, character),
            new RunningState(this, data, character),
            new JumpingState(this, data, character),
            new FallingState(this, data, character),
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

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}