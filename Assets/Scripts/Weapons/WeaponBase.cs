﻿using System.Collections;
using UnityEngine;

namespace Corebin.Tanks.Weapons
{
    public abstract class WeaponBase : MonoBehaviour, IHaveTeam
    {        
        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _cooldown;

        public Team TeamNumber => _teamNumber;
        protected Team _teamNumber;

        protected bool _readyToFire = true;
                       
        public virtual void Initialize(Team teamNumber)
        {
            _teamNumber = teamNumber;
        }

        public abstract void TriggerFire(); 

        /// <summary>
        /// Reduction cooldown time
        /// </summary>
        /// <param name="time">Time</param>
        public virtual void ReductionCooldownTime(float time)
        {
            if (_cooldown > 0)
            {
                _cooldown -= time;
            }
            else
            {
                _cooldown = 0;
            }            
        }

        protected IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }
    }
}
