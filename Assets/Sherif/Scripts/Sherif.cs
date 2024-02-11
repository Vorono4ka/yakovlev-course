using UnityEngine;

public class Sherif : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private IMover _mover;

    public Transform Transform => transform;
    public float Speed => _speed;

    private void Update()
    {
        _mover.Update();
    }

    public void SetMover(IMover mover)
    {
        _mover?.StopMoving();
        _mover = mover;
        _mover.StartMoving();
    }
}
