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


        public float Right => _right;
        private float _right;

        /// <summary>
        /// GetKey(KeyCode)
        /// </summary>
        public bool Key => _key;
        private bool _key;
        
        public Object Object => this;
        
        void Update()
        {
            _forward = Input.GetAxis("Vertical");            
            _right = -Input.GetAxis("Horizontal");
            
            _key = Input.GetKey(KeyCode.Space);
        }

        public Object GetObject()
        {
            return this;
        }
    }
}