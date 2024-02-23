using System;
using UnityEngine;

[Serializable]
public class AirborneStateConfig
{
    [field: SerializeField] public JumpingStateConfig JumpingStateConfig { get; private set; }

    public float BaseGravity => 2f * JumpingStateConfig.MaxHeight / Mathf.Pow(JumpingStateConfig.TimeToReachMaxHeight, 2);
}