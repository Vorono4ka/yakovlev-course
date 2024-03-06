using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; } = 1;
    [field: SerializeField, Range(0.05f, 10f)] public float MinDistanceToTarget { get; private set; } = 0.05f;
}
