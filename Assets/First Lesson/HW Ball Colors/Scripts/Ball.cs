using UnityEngine;

public class Ball : MonoBehaviour
{
    private int _ballType;

    public void Initialize(int ballType, Color color)
    {
        _ballType = ballType;
        GetComponent<Renderer>().material.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBallPicker ballPicker))
        {
            ballPicker.PickBall(_ballType);
            Destroy(gameObject);
        }
    }
}
