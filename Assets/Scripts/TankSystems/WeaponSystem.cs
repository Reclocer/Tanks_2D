using System.Collections.Generic;
using UnityEngine;
using Corebin.Tanks.Tanks;
using Corebin.Tanks.Weapons;
using Corebin.Tanks.Bonuses;

namespace Corebin.Tanks.UnitSystems
{
    [RequireComponent(typeof(TankBase))]
    public sealed class WeaponSystem : MonoBehaviour, IWeaponSystem
    {
        /// <summary>
        /// Which side
        /// </summary>
        public Team TeamNumber => _teamNumber;
        private Team _teamNumber;
        
        [SerializeField] private List<Gun> _guns;

        [SerializeField] private List<MissileLauncher> _missileLauncher;

        public void Initialize(Team teamNumber)
        {
            _teamNumber = teamNumber;
            _guns.ForEach(w => w.Initialize(teamNumber));
            _missileLauncher.ForEach(w => w.Initialize(teamNumber));
        }        
        
        public void TriggerFire()
        {
            _guns.ForEach(gun => gun.TriggerFire());
            _missileLauncher.ForEach(ml => ml.TriggerFire());
        }

        public void ReductionWeaponCoolDownTime(IEnergyDealer energyDealer)
        {
            _guns.ForEach(gun => gun.ReductionCooldownTime(energyDealer.Energy));            
        }
    }
}
