using UnityEngine;

namespace Corebin.Tanks.UnitControllers
{
    public class KeyBoardUserControll : MonoBehaviour, IUserControl
    {
        /// <summary>
        /// Forward move delta position
        /// </summary>
        public float Forward => _forward;
        private float _forward;
        
        /// <summary>
        /// Rotate to the right 
        /// </summary>
        public float Right => _right;
        private float _right;

        /// <summary>
        /// Main gun fire
        /// </summary>
        public bool WeaponFire => _weaponFire;
        private bool _weaponFire;

        /// <summary>
        /// Select next weapon
        /// </summary>
        public bool SelectNextWeapon => _selectNextWeapon;
        private bool _selectNextWeapon;

        /// <summary>
        /// Select previous weapon
        /// </summary>
        public bool SelectPreviousWeapon => _selectPreviousWeapon;
        private bool _selectPreviousWeapon;

        public Object Object => this;
        
        void Update()
        {
            _forward = Input.GetAxis("Vertical");            
            _right =  -Input.GetAxis("Horizontal");
            
            _weaponFire = Input.GetKey(KeyCode.Space);

            _selectNextWeapon = Input.GetKeyDown(KeyCode.E);
            _selectPreviousWeapon = Input.GetKeyDown(KeyCode.Q);
        }

        public Object GetObject()
        {
            return this;
        }
    }
}