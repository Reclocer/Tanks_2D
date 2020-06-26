using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corebin.Core.Builders
{
    public sealed class Factory<BT> : MonoBehaviour
                          where BT  : MonoBehaviour
    {
        [SerializeField] private List<BT> _objects;

        public BT CreateArrow<T>() where T : BT
        {
            foreach (BT @object in _objects)
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
    }
}
