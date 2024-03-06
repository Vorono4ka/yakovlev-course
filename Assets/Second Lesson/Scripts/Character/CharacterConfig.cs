using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [field: SerializeField] public WalkingStateConfig WalkingStateConfig { get; private set; }
    [field: SerializeField] public RunningStateConfig RunningStateConfig { get; private set; }
    [field: SerializeField] public AirborneStateConfig AirbornStateConfig { get; private set; }
}