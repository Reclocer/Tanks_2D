using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Corebin.Tanks.Tanks;

namespace Corebin.Tanks.Spawners
{
    public sealed class TankFactory : MonoBehaviour
    {
        [SerializeField] private List<TankBase> _objects = new List<TankBase>();

        public TankBase Create<T>() where T : TankBase
        {
            foreach (TankBase @object in _objects)
            {
                if (@object.GetType() == typeof(T))
                {
                    return Instantiate(@object, transform.position, transform.rotation, transform);
                }
            }

#if UNITY_EDITOR
            Debug.LogWarning("Factory cant create object. Please add object to 'Objects' ");
#endif
            return default;
        }

        public void SetObjects(List<TankBase> objects)
        {
            _objects = objects;
        }

        public void CopySetObjects(List<TankBase> objects)
        {
            _objects = objects.ToList();
        }
    }
}