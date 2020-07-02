using UnityEngine;

namespace Corebin.Tanks.Bonuses
{
    public abstract class BonusBase : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        /// <summary>
        /// Which side
        /// </summary>
        public TeamIndex ForTeam => _forTeam;
        [SerializeField] protected TeamIndex _forTeam;
            
        protected abstract void OnCollisionEnter2D(Collision2D other);
    }
}
