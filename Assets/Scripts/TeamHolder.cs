using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corebin.Core;
using Corebin.Tanks;

namespace Corebin.Helpers
{
    public sealed class TeamHolder : SingletonBase<TeamHolder>
    {
        [SerializeField] private Team[] _teams;
        private Dictionary<TeamIndex, Team> _teamsDict =
            new Dictionary<TeamIndex, Team>();

        protected override void Awake()
        {
            base.Awake();
            InitializeDict();
        }

        private void InitializeDict()
        {
            for (int i = 0; i < _teams.Length; i++)
            {
                var team = _teams[i];

                if (!_teamsDict.ContainsKey(team.TeamIndex))
                {
                    _teamsDict.Add(team.TeamIndex, team);
                }
                else
                {
                    Debug.LogError($"Team with index: {team.TeamIndex} already exists!");
                }
            }
        }

        public Team GetTeamByIndex(TeamIndex index)
        {
            if (!_teamsDict.ContainsKey(index))
            {
                Debug.LogError($"Team with index: {index} not exists!");
                return null;
            }

            return _teamsDict[index];
        }

        protected override TeamHolder GetInstance()
        {
            return this;
        }
    }
}

