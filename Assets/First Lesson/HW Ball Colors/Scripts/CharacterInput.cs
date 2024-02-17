using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private BallPickerCharacter _player;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDirection.magnitude > 0 )
        {
            _player.Move(Quaternion.LookRotation(_player.transform.forward) * moveDirection.normalized);
        }
    }
}
