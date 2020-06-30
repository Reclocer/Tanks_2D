using System.Collections.Generic;
using UnityEngine;

namespace Corebin.Tanks.Spawners
{
    public abstract class SpawnerBase : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> _objects;
        [SerializeField] protected List<Transform> _parents;               
    }
}
