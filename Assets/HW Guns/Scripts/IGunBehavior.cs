using UnityEngine;

public interface IGunBehavior
{
    void Initialize(Bullet bullet, int maxCharge);
    bool CanShoot();
    void Shoot(Vector3 origin, Vector3 direction);
}
