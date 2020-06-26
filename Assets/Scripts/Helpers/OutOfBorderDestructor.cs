using UnityEngine;

namespace Corebin.Helpers
{
    public class OutOfBorderDestructor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _representation;

        void Update()
        {
            CheckBorders();
        }

        private void CheckBorders()
        {
            if (!GameAreaHelper.IsInGameplayArea(transform, _representation.bounds, Camera.main))
            {
                Destroy(gameObject);
            }
        }
    }
}