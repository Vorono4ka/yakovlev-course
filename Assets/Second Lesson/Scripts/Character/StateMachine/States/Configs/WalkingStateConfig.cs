using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [field: SerializeField, Range(0, 10)] public float SneakingSpeed { get; private set; }
    [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    [field: SerializeField, Range(0, 10)] public float RunningSpeed { get; private set; }
}