using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _characterController;

    [field: SerializeField] public CharacterConfig Config { get; private set; }
    [field: SerializeField] public CharacterView View { get; private set; }
    [field: SerializeField] public GroundChecker GroundChecker { get; private set; }
    public PlayerInput Input => _input;
    public CharacterController Controller => _characterController;

    private void Awake()
    {
        View.Initialize();
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();
}
