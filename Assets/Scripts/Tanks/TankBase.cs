using System;
using UnityEngine;
using Corebin.Core.NextVar;
using Corebin.Tanks.UnitSystems;
using Corebin.Tanks.UnitControllers;
using Corebin.Tanks.Weapons;

namespace Corebin.Tanks.Tanks
{
    public abstract class TankBase : GameUnit, IDamagable
    {
        [SerializeField] protected TankController _tankController;

        public MovementSystem MovementSystem => _movementSystem;
        [SerializeField] protected MovementSystem _movementSystem;

        public WeaponSystem WeaponSystem => _weaponSystem;
        [SerializeField] protected WeaponSystem _weaponSystem;            

        /// <summary>
        /// Health
        /// </summary>
        public float Health => _health.Value;
        [SerializeField] protected NextFloat _health = new NextFloat();

        /// <summary>
        /// Max health points
        /// </summary>
        public float MaxHealth => _maxHealth;
        [SerializeField] protected float _maxHealth = 1;
        
        /// <summary>
        /// Action after destroy this tank 
        /// </summary>
        public event Action TankDestroyed = () => { };
          
        protected virtual void Start()
        {
            _tankController.Initialize(this);
            _weaponSystem.  Initialize(_teamNumber);
            
            //Health value normalize
            if (_health.Value > _maxHealth)
            {
                _health.Value = _maxHealth;
            }
        }

        public virtual void ApplyDamage(IDamageDealer damageDealer)
        {
            _health.Value -= damageDealer.Damage;

            if (_health.Value <= 0)
            {
                DestroyTank();
            }
        }

        protected virtual void DestroyTank()
        {
            Destroy(gameObject);
            TankDestroyed();
        }
    }
}
