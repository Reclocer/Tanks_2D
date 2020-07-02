using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corebin.Tanks.Weapons;

namespace Corebin.Tanks.Tanks
{
    public class TankMK1 : TankBase
    {
        protected override void Start()
        {
            base.Start();
        }

        public override void ApplyDamage(IDamageDealer damageDealer)
        {
            base.ApplyDamage(damageDealer);
        }

        protected override void DestroyUnit()
        {
            base.DestroyUnit();
        }
    }
}