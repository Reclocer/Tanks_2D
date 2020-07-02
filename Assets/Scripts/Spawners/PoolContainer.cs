using UnityEngine;
using Corebin.Core.ObjectsPool.ObjectsQueue;

namespace Corebin.Tanks
{
    public sealed class PoolContainer : MonoBehaviour
    {
        [SerializeField] private int _countObjectsInPool = 10;
        [SerializeField] private int _poolsCount = 3;
                
        public ObjectsPoolQueue<GameObject> ObjectsPoolQueue;
        
        private void Start()
        {
            ObjectsPoolQueue = new ObjectsPoolQueue<GameObject>(_countObjectsInPool, _poolsCount);
        }
    }
}