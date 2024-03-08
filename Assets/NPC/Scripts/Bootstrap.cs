using Assets.NPC.Scripts.NPC;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private NPC _npc;
    [SerializeField] private Transform _tradingPoint;
    [SerializeField] private Transform _restingPoint;

    void Awake()
    {
        _npc.Initialize(_tradingPoint, _restingPoint);
    }
}
