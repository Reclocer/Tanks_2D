using UnityEngine;
using Corebin.Tanks.Tanks;
using Corebin.Tanks.UnitSystems;
using Corebin.Tanks.UnitControllers;
using Corebin.Helpers;

namespace Corebin.Tanks.UnitControllers.CustomControllers
{    
    public class PlayerController : TankController
    {
        [SerializeField] private Transform _unitTransform;
        [SerializeField] private SpriteRenderer _representation;

        private IUserControl _userControl;

        public override void Initialize(TankBase tank)
        {
            base.Initialize(tank);
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
            Vector3 transformPosition = _unitTransform.position;
              
            if (GameAreaHelper.RestrictLateralMovement     (ref transformPosition, forward, _representation.bounds, Camera.main) 
             && GameAreaHelper.RestrictLongitudinalMovement(ref transformPosition, forward, _representation.bounds, Camera.main))
            {
                movementSystem.LongitudinalMovement(forward);
            }
            else
            {
                _unitTransform.position = transformPosition;
                Debug.Log("dont move");
            }

            float rotate = _userControl.Right * Time.deltaTime;
            movementSystem.Rotate(rotate);

        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (_userControl == null)
                return;

            if (_userControl.WeaponFire)
            {
                fireSystem.TriggerFire();
            }
        }

        protected override void SelectNextWeapon(WeaponSystem fireSystem)
        {
            if (_userControl == null)
                return;

            if(_userControl.SelectNextWeapon)
            {
                fireSystem.SelectNextWeapon();
            }
        }

        protected override void SelectPreviousWeapon(WeaponSystem fireSystem)
        {
            if (_userControl == null)
                return;

            if (_userControl.SelectPreviousWeapon)
            {
                fireSystem.SelectPreviousWeapon();
            }
        }
    }
}
