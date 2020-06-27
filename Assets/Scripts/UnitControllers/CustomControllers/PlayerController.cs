using UnityEngine;
using Corebin.Tanks.Tanks;
using Corebin.Tanks.UnitSystems;
using Corebin.Tanks.UnitControllers;
using Corebin.Helpers;

namespace Corebin.Tanks.UnitControllers.CustomControllers
{
    [RequireComponent(typeof(TankBase))]
    public class PlayerController : TankController
    {
        [SerializeField] private SpriteRenderer _representation;

        private IUserControl _userControl;

        public override void Initialize(TankBase spaceship)
        {
            base.Initialize(spaceship);
            _userControl = GetComponent<IUserControl>();
        }

        /// <summary>
        /// Set control system
        /// </summary>
        /// <param name="userControl"></param>
        public void SetControl(IUserControl userControl)
        {
            if (_userControl != null)
            {
                Destroy(_userControl.Object);
            }

            _userControl = userControl;
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            if (_userControl == null)
                return;

            float forward = _userControl.Forward * Time.deltaTime;
            Vector3 transformPosition = transform.position;
                      

            if (GameAreaHelper.RestrictLateralMovement     (ref transformPosition, forward, _representation.bounds, Camera.main) 
             && GameAreaHelper.RestrictLongitudinalMovement(ref transformPosition, forward, _representation.bounds, Camera.main))
            {
                movementSystem.LongitudinalMovement(forward);
            }
            else
            {
                transform.position = transformPosition;
                Debug.Log("dont move");
            }

            float rotate = _userControl.Right * Time.deltaTime;
            movementSystem.Rotate(rotate);

        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (_userControl == null)
                return;

            if (_userControl.MainGunFire)
            {
                fireSystem.TriggerFire();
            }
        }
    }
}
