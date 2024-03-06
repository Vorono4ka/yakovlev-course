using UnityEngine;

[CreateAssetMenu(fileName = "NPCConfig", menuName = "Configs/NPCConfig")]
public class NPCConfig : ScriptableObject
{
    [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; } = 1;
    [field: SerializeField] public TradingStateConfig TradingStateConfig { get; private set; }
    [field: SerializeField] public RestingStateConfig RestingStateConfig { get; private set; }
    [field: SerializeField] public NPCWalkingStateConfig WalkingStateConfig { get; private set; }
}
