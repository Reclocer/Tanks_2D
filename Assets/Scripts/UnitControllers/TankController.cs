using UnityEngine;
using Corebin.Tanks.UnitSystems;
using Corebin.Tanks.Tanks;

namespace Corebin.Tanks.UnitControllers
{    
    public abstract class TankController : MonoBehaviour
    {
        private TankBase _tank;

        public virtual void Initialize(TankBase tank)
        {
            _tank = tank;
        }

        private void Update()
        {
            ProcessHandling(_tank.MovementSystem);
            ProcessFire(_tank.WeaponSystem);
        }

        protected abstract void ProcessHandling(MovementSystem movementSystem);
        protected abstract void ProcessFire(WeaponSystem fireSystem);
    }
}
