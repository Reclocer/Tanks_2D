using UnityEngine;

namespace Corebin.Tanks.UnitSystems
{    
    public class MovementSystem : MonoBehaviour, IMovable
    {     
        [SerializeField] private float _longitudinalMovementSpeed = 5;
        [SerializeField] private float _rotateSpeed = 80;
        
        public void LongitudinalMovement(float value)
        {            
            transform.Translate(value * _longitudinalMovementSpeed * Vector3.up);
        }

        public void Rotate(float value)
        {
            transform.Rotate(Vector3.forward, _rotateSpeed * value);
        }
    }
}
