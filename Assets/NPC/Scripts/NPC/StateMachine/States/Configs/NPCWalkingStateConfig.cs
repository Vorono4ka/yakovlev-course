using System;
using UnityEngine;

[Serializable]
public class NPCWalkingStateConfig
{
    [field: SerializeField, Range(0.05f, 10f)] public float MinDistanceToTarget { get; private set; } = 0.05f;
}
