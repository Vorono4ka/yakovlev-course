using System;
using UnityEngine;

public class ShotgunBehavior : GunBehavior
{
    private Vector3 offset = Vector3.left;

    private Bullet _bulletPrefab;
    private int _charge;

    public void Initialize(Bullet bullet, int maxCharge)
    {
        _bulletPrefab = bullet;
        _charge = maxCharge;
    }

    public bool CanShoot()
    {
        return _charge > 3;
    }

    public void Shoot(Vector3 origin, Vector3 direction)
    {
        if (_charge < 3)
            throw new InvalidOperationException("There is no charge to shoot bullet");

        Quaternion rotation = Quaternion.LookRotation(direction);
        shootBullet(origin + rotation * offset, direction);
        shootBullet(origin, direction);
        shootBullet(origin - rotation * offset, direction);
    }

    private void shootBullet(Vector3 position, Vector3 direction)
    {
        _charge--;

        Bullet bullet = UnityEngine.Object.Instantiate(_bulletPrefab);
        bullet.Initialize(position, direction);
    }
}
