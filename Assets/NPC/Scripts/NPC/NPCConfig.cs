using UnityEngine;

[CreateAssetMenu(fileName = "NPCConfig", menuName = "Configs/NPCConfig")]
public class NPCConfig : ScriptableObject
{
    [field: SerializeField] public TradingStateConfig TradingStateConfig { get; private set; }
    [field: SerializeField] public RestingStateConfig RestingStateConfig { get; private set; }
    [field: SerializeField] public WalkingStateConfig WalkingStateConfig { get; private set; }
}
