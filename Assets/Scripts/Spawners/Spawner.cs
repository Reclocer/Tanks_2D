using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Corebin.Tanks.Spawners
{
    public sealed class Spawner : SpawnerBase
    {                
        [SerializeField] private Vector2 _spawnPeriodRange;        
        [SerializeField] private Vector2 _spawnDelayRange;

        [SerializeField] private bool _autoStart = true;
        
        private void Start()
        {
            if (_autoStart)
            {
                StartSpawn();
            }
        }

        public void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));
            
            while (true)
            {
                //Instantiate(_object, transform.position, transform.rotation, _parent);
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
