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
        [Space]
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
        /// On change health value
        /// </summary>
        public event Action<float> RefreshHealth = (health) => { };

        protected override void Start()
        {
            base.Start();

            if (_tankController != null)
            {
                _tankController.Initialize(this);
            }

            _weaponSystem.Initialize(_team);
            
            //Health value normalize
            if (_health.Value > _maxHealth)
            {
                _health.Value = _maxHealth;
            }

            _health.AddAction((f) => { RefreshHealth(f); });
        }

        public virtual void SetController(TankController controller)
        {
            _tankController = controller;
        }

        public virtual void ApplyDamage(IDamageDealer damageDealer)
        {
            _health.Value -= damageDealer.Damage;

            if (_health.Value <= 0)
            {
                DestroyUnit();
            }
        }

        protected override void DestroyUnit()
        {
            base.DestroyUnit();
        }
    }
}
