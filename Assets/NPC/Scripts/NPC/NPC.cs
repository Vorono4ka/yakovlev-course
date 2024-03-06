using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NPC : MonoBehaviour
{
    private NPCStateMachine _stateMachine;
    private CharacterController _characterController;

    [field: SerializeField] public NPCConfig Config { get; private set; }
    [field: SerializeField] public Transform TradingPoint { get; private set; }
    [field: SerializeField] public Transform RestingPoint { get; private set; }
    public CharacterController Controller => _characterController;

    private void Awake()
    {
        _stateMachine = new NPCStateMachine(this);
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
