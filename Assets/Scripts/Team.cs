using System;
using System.Collections.Generic;
using UnityEngine;

namespace Corebin.Tanks
{
    [Serializable]
    public class Team
    {
        public TeamIndex TeamIndex => _teamIndex;
        [SerializeField] private TeamIndex _teamIndex = TeamIndex.Neutral;

        public Color TeamColor => _teamColor;
        [SerializeField] private Color _teamColor = new Color(145, 145, 145, 200);
    }
}
