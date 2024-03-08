using UnityEngine;

namespace Assets.NPC.Scripts.NPC
{
    [RequireComponent(typeof(CharacterController))]
    public class NPC : MonoBehaviour, IMovable
    {
        private NPCStateMachine _stateMachine;
        private CharacterController _characterController;

        [field: SerializeField] public NPCConfig Config { get; private set; }
        public Transform TradingPoint { get; private set; }
        public Transform RestingPoint { get; private set; }
        public CharacterController Controller => _characterController;

        public Transform Transform => transform;
        public float Speed => Config.Speed;

        internal void Initialize(Transform tradingPoint, Transform restingPoint)
        {
            TradingPoint = tradingPoint;
            RestingPoint = restingPoint;
        }

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
}