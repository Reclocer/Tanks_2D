using UnityEngine;
using Corebin.Tanks.UnitSystems;

namespace Corebin.Tanks.Bonuses
{
    public sealed class EnergyStorageBonus : BonusBase, IEnergyDealer
    {
        /// <summary>
        /// Energy Value
        /// </summary>
        public float Energy => _energy;
        [SerializeField] private float _energy = 1;

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            var weaponSystem = other.gameObject.GetComponent<IWeaponSystem>();

            if (weaponSystem != null &&
                weaponSystem.Team.TeamIndex == _forTeam)
            {
                weaponSystem.ReductionWeaponCoolDownTime(this);
                Destroy(gameObject);
            }
        }       
    }
}
