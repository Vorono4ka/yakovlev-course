using System;
using UnityEngine;

[Serializable]
public class TradingStateConfig
{
    [field: SerializeField] public float TradingTime { get; private set; }
}
