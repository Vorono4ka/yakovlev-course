using System.Collections.Generic;
using UnityEngine;

public class PointByPointMover : IMover
{
    private const float MinDistanceToTarget = 0.05f;

    private IMovable _movable;
    private Queue<Vector3> _targets;

    private Vector3 _currentTarget;

    private bool _isMoving;

    public PointByPointMover(IMovable movable, IEnumerable<Vector3> targets)
    {
        _movable = movable;
        _targets = new Queue<Vector3>(targets);

        _currentTarget = _targets.Dequeue();
    }

    public void StartMoving() => _isMoving = true;

    public void StopMoving() => _isMoving = false;

    public void Update()
    {
        if (_isMoving == false) 
            return;

        Vector3 direction = _currentTarget - _movable.Transform.position;
        _movable.Transform.Translate(direction.normalized * _movable.Speed * Time.deltaTime);

        if (direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();
    }

    private void SwitchTarget() { 
        _targets.Enqueue(_currentTarget);

        _currentTarget = _targets.Dequeue();
    }
}
