using UnityEngine;

namespace Corebin.Tanks.Bonuses
{
    public sealed class HealthBonus : BonusBase, IHealthDealer
    {
        /// <summary>
        /// Health value 
        /// </summary>
        public float Health => _health; 
        [SerializeField] private float _health = 1;
           
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            var recoverable = other.gameObject.GetComponent<IRecoverable>();

            if (recoverable != null &&
                recoverable.Team.TeamIndex == _forTeam)
            {
                if (recoverable.Health < recoverable.MaxHealth)
                {
                    recoverable.ApplyHealth(this);
                    Destroy(gameObject);
                }
            }
        }
    }
}
