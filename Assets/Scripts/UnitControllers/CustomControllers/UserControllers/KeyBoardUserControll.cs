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
        public bool MainGunFire => _mainGunFire;
        private bool _mainGunFire;
        
        public Object Object => this;
        
        void Update()
        {
            _forward = Input.GetAxis("Vertical");            
            _right =  -Input.GetAxis("Horizontal");
            
            _mainGunFire = Input.GetKey(KeyCode.X);
        }

        public Object GetObject()
        {
            return this;
        }
    }
}