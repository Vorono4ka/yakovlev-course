using UnityEngine;

public class InfinitePistolBehavior : IGunBehavior
{
    private Bullet _bulletPrefab;

    public void Initialize(Bullet bullet, int maxCharge)
    {
        _bulletPrefab = bullet;
    }

    public bool CanShoot()
    {
        return true;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        shootBullet(origin, direction);
    }

    private void shootBullet(Vector3 position, Vector3 direction)
    {
        Bullet bullet = Object.Instantiate(_bulletPrefab);
        bullet.Initialize(position, direction);
    }
}
