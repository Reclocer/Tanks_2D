using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Corebin.Core;
using Corebin.Core.LinkedLists;
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
        
        [SerializeField] private List<WeaponBase> _guns;
        [SerializeField] private List<WeaponBase> _missileLauncher;

        private DoublyLinkedStacks<WeaponBase> _weapons;
        private WeaponBase _selectedWeapon;        

        public void Initialize(Team teamNumber)
        {
            _teamNumber = teamNumber;
            _guns.ForEach(w => w.Initialize(teamNumber));
            _missileLauncher.ForEach(w => w.Initialize(teamNumber));

            _weapons = new DoublyLinkedStacks<WeaponBase>(_guns, _missileLauncher);
            _selectedWeapon = _weapons.SelectedObj;
        }        
        
        public void TriggerFire()
        {
            _selectedWeapon.TriggerFire();            
        }

        public void ReductionWeaponCoolDownTime(IEnergyDealer energyDealer)
        {
            _guns.ForEach(gun => gun.ReductionCooldownTime(energyDealer.Energy));            
        }

        public void SelectNextWeapon()
        {            
            _selectedWeapon = _weapons.Next();
        }

        public void SelectPreviousWeapon()
        {
            _selectedWeapon = _weapons.Previous();
        }   
    }
}
