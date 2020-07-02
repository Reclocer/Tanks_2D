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
        public    Team  Team => _team;
        protected Team _team;        

        public float Damage => _damage;

        public void Initialize(Team team)
        {
            _team = team;
        }        

        protected void Update()
        {
            Move(_speed);
        }
        
        protected void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            
            if (damagableObject != null &&
                damagableObject.Team != _team)
            {
                damagableObject.ApplyDamage(this);
            }
        }

        protected abstract void Move(float speed);
    }
}
