using UnityEngine;
using Corebin.Tanks.Weapons.Projectiles;

namespace Corebin.Tanks.Weapons
{
    public class MissileLauncher : WeaponBase
    {
        [SerializeField] private Missile _projectile;
        [SerializeField] private MissileSO _missile;
                
        public override void TriggerFire()
        {
            if (!_readyToFire)
                return;

            Missile projectile = Instantiate(_projectile, _barrel.position, _barrel.rotation, transform);
            projectile.Initialize(_team);
            projectile.SetML(_missile);

            StartCoroutine(Reload(_cooldown));
        }
    }
}
