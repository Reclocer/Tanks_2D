using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Corebin.Core.ObjectsPool.ObjectsQueue;
using Corebin.Tanks.Tanks;
using Corebin.Tanks.UnitControllers;

using Random = UnityEngine.Random;

namespace Corebin.Tanks.Spawners
{
    public sealed class SpawnerWithPool : SpawnerBase
    {
        [Space]        
        [SerializeField] private PoolContainer _poolContainer;
        [SerializeField] private Vector2 _spawnDelayRange;
        [SerializeField] private Team _team;
        [SerializeField] private TankController _controller;

        [SerializeField] private int _maxCountUnitsInArea = 8;
        [SerializeField] private int _currentCountUnitsInArea = 0;

        private ObjectsPoolQueue<GameObject> _objectsPoolQueue;
        
        private void Start()
        {  
            if(_controller == null)
            {
                _controller = new EnemyController();
            }

            _objectsPoolQueue = _poolContainer.ObjectsPoolQueue;

            FillUpPool();
            StartCoroutine(Spawn());
        }

        private void FillUpPool()
        {
            int i = 0;

            while (i < _objectsPoolQueue.ObjectsCount)
            {
                for (int j = 0; j < _objects.Count; j++)
                {
                    if (i == _objectsPoolQueue.ObjectsCount)
                        return;

                    GameObject @object = CreateObject(_objects[j], _parents[0]);

                    _objectsPoolQueue.Enqueue(@object, j);

                    i++;
                }
            }
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));

                if (_currentCountUnitsInArea < _maxCountUnitsInArea)
                {
                    if (_objectsPoolQueue.Peek() != null)
                    {
                        GameObject @object = _objectsPoolQueue.Dequeue();
                        SetActiveObject(@object, _team);
                    }
                    else
                    {
                        int objectNumber = Random.Range(0, _objects.Count);
                        GameObject @object = CreateObject(_objects[objectNumber], _parents[0]);
                        _objectsPoolQueue.Enqueue(@object);
                    }
                }
            }
        }

        private GameObject CreateObject(GameObject @object, Transform parent)
        {
            GameObject newObject = Instantiate(@object, parent.position, parent.rotation, parent);
            newObject.GetComponent<TankBase>().SetController(_controller);
            newObject.SetActive(false);
            return newObject;
        }

        private bool SetActiveObject(GameObject @object)
        {            
            if (_currentCountUnitsInArea < _maxCountUnitsInArea)
            {
                @object.SetActive(true);
                _currentCountUnitsInArea++;
                return true;
            }

            return false;
        }

        private bool SetActiveObject(GameObject @object, Team team)
        {
            if (_currentCountUnitsInArea < _maxCountUnitsInArea)
            {
                @object.SetActive(true);
                @object.GetComponent<GameUnit>().SetTeam(team);
                _currentCountUnitsInArea++;
                return true;
            }

            return false;
        }
    }
}
