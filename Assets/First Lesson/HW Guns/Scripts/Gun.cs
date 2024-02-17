using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private IGunBehavior _behavior;
    [SerializeField] private Bullet _bullet;
    [SerializeField, Range(1, 100)] private int _maxCharge;

    private void Start()
    {
        SetBehavior(new ShotgunBehavior());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_behavior.CanShoot())
                _behavior.Shoot(transform.position, transform.forward);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetBehavior(new PistolBehavior());
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetBehavior(new InfinitePistolBehavior());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetBehavior(new ShotgunBehavior());
        }
    }

    private void SetBehavior(IGunBehavior behavior)
    {
        _behavior = behavior;
        _behavior.Initialize(_bullet, _maxCharge);
    }
}
