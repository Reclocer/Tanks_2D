using UnityEngine;
using Corebin.Tanks;
using Corebin.Tanks.Tanks;

namespace Corebin.Tanks.Bonuses
{
    [RequireComponent(typeof(GameUnit))]
    public class BonusSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _objectForSpawn;

        private GameUnit _unit;

        private void Start()
        {
            _unit = GetComponent<TankBase>();
            _unit.UnitDestroyed += SpawnBonus;
        }

        private void SpawnBonus()
        {
            Instantiate(_objectForSpawn, transform.position, transform.rotation);
        }
    }
}
