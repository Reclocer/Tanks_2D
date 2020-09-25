using UnityEngine;
using Corebin.Tanks.Weapons.Projectiles;

namespace Corebin.Tanks.Weapons
{
    public class Gun : WeaponBase
    {
        [SerializeField] protected Projectile _projectile;
                
        public override void TriggerFire()
        {
            if (!_readyToFire)
                return;

            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation, transform);
            proj.Initialize(_team);

            StartCoroutine(Reload(_cooldown));
        }
    }
}
