using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BallPickerCharacter : MonoBehaviour, IBallPicker
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField, Range(0.1f, 5f)] private float _speed = 1f;

    private void OnValidate()
    {
        _characterController ??= GetComponent<CharacterController>();
    }

    public void PickBall(int type)
    {
        EventManager.NotifyBallPicked(type);
    }

    public void Move(Vector3 moveDirection)
    {
        _characterController.Move(moveDirection * _speed * Time.deltaTime);
    }
}
