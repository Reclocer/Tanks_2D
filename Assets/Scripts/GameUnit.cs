using System;
using UnityEngine;
using Corebin.Helpers;

namespace Corebin.Tanks
{
    public abstract class GameUnit : MonoBehaviour, IHaveTeam
    {
        public Team Team => _team;
        [SerializeField] protected Team _team;

        [SerializeField] protected SpriteRenderer _teamIndicator;

        /// <summary>
        /// Action after destroy this unit 
        /// </summary>
        public event Action UnitDestroyed = () => { };

        protected virtual void Start()
        {
            _team = TeamHolder.Instance.GetTeamByIndex(_team.TeamIndex);            
            _teamIndicator.color = _team.TeamColor;
        }

        public void SetTeam(Team team)
        {
            _team = team;
            _teamIndicator.color = team.TeamColor;
        }

        protected virtual void DestroyUnit()
        {
            Destroy(gameObject);
            UnitDestroyed();
        }
    }
}
