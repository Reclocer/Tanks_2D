using UnityEngine;

namespace Corebin.Tanks.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected float _damage;

        /// <summary>
        /// Which side
        /// </summary>
        public    Team  TeamNumber => _teamNumber;
        protected Team _teamNumber;        

        public float Damage => _damage;

        public void Initialize(Team teamNumber)
        {
            _teamNumber = teamNumber;
        }        

        protected void Update()
        {
            Move(_speed);
        }
        
        protected void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            
            if (damagableObject != null &&
                damagableObject.TeamNumber != TeamNumber)
            {
                damagableObject.ApplyDamage(this);
            }
        }

        protected abstract void Move(float speed);
    }
}
