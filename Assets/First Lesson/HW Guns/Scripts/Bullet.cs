using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)] private float _speed = 1f;
    [SerializeField, Range(0.1f, 10f)] private float _lifetime = 1f;

    private Vector3 _position;
    private Vector3 _direction;
    private Vector3 _finalPosition;

    public void Initialize(Vector3 position, Vector3 direction)
    {
        _position = position;
        _direction = direction;
        
        _finalPosition = _position + _direction * _speed * _lifetime;
    }

    private void Update()
    {
        _position += _direction * _speed * Time.deltaTime;
        transform.position = _position;
        _lifetime -= Time.deltaTime;

        if (_lifetime <= 0)
        {
            // Безусловно, лучше было бы использовать обьектный пул, но проект простой и здесь смысл в тренировке другого паттерна
            Destroy(gameObject);
        }
    }
}
