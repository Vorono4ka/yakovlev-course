using System;
using UnityEngine;

public class PistolBehavior : IGunBehavior
{
    private Bullet _bulletPrefab;
    private int _charge;

    public void Initialize(Bullet bullet, int maxCharge)
    {
        _bulletPrefab = bullet;
        _charge = maxCharge;
    }

    public bool CanShoot()
    {
        return _charge >= 1;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        if (_charge < 1)
            throw new InvalidOperationException("There is no charge to shoot bullet");

        shootBullet(origin, direction);
    }

    private void shootBullet(Vector3 position, Vector3 direction)
    {
        _charge--;

        Bullet bullet = UnityEngine.Object.Instantiate(_bulletPrefab);
        bullet.Initialize(position, direction);
    }
}
