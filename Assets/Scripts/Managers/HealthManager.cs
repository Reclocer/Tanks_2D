using UnityEngine;
using UnityEngine.UI;
using Corebin.Core;
using Corebin.Tanks.Tanks;

namespace Corebin.Tanks.Managers
{
    public sealed class HealthManager : SingletonBase<HealthManager>
    {
        [SerializeField] private Text _healthValueText;
        [SerializeField] private TankBase _tank;

        private float _maxHealthPlayerShip = 1;

        private void OnEnable()
        {
            _tank.RefreshHealth += OnRefreshHealth;
        }

        private void Start()
        {
            _maxHealthPlayerShip = _tank.MaxHealth; 
            OnRefreshHealth(_tank.Health);
        }

        private void OnDisable()
        {
            _tank.RefreshHealth -= OnRefreshHealth;
        }

        protected override HealthManager GetInstance()
        {
            return this;
        }

        /// <summary>
        /// Refresh health text
        /// </summary>
        /// <param name="health"></param>
        private void OnRefreshHealth(float health)
        {
            string newHealth = health.ToString();
            _healthValueText.text = $"{newHealth} / {_maxHealthPlayerShip} ";
        }
    }
}
