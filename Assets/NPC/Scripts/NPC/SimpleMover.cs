using UnityEngine;

public class SimpleMover
{
    private IMovable _movable;

    public SimpleMover(IMovable movable)
    {
        _movable = movable;
    }

    public Vector3 MoveToTarget(Transform target)
    {
        Vector3 direction = target.position - _movable.Transform.position;
        direction.y = 0;

        Vector3 moveVector = direction * _movable.Speed * Time.deltaTime;
        _movable.Transform.Translate(moveVector);

        return direction;
    }
}
