using UnityEngine;

namespace Corebin.Tanks
{
    public abstract class GameUnit : MonoBehaviour, IHaveTeam
    {
        public Team TeamNumber => _teamNumber;
        [SerializeField] protected Team _teamNumber;

        public void SetTeamNumber(Team team)
        {
            _teamNumber = team;
        }
    }
}
