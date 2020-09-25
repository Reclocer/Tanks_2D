using UnityEngine;
using Corebin.Tanks.Weapons.Projectiles;

public class Bullet : Projectile
{
    protected override void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
