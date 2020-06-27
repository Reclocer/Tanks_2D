using UnityEngine;

namespace Corebin.Helpers
{
    public static class GameAreaHelper
    {     
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds, Camera camera)
        {
            var camHalfHeight = camera.orthographicSize;
            var camHalfWidth = camHalfHeight * camera.aspect;
            var camPos = camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);            
        }

        #region RestrictMovement

        /// <summary>
        /// Restrict lateral object movement  
        /// </summary>
        /// <param name="objectPosition">Object pozition for restrict</param>
        /// <param name="deltaPositionX">Horizontal delta position for new position</param>
        /// <param name="objectBounds">Object bounds</param>
        /// <returns>Return true if object within GamePlayArea</returns>
        public static bool RestrictLateralMovement(ref Vector3 objectPosition, float deltaPositionX, Bounds objectBounds, Camera camera)
        {             
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width,
                                                                         Screen.height,
                                                                         camera.transform.position.z));

            float pos = objectPosition.x + deltaPositionX;
            float rightBound = screenBounds.x - objectBounds.size.x / 2;
            float leftBound = -screenBounds.x + objectBounds.size.x / 2;
            float positionX = Mathf.Clamp(pos, leftBound, rightBound);

            if (pos > positionX)
            {
                objectPosition = new Vector3(rightBound, objectPosition.y, objectPosition.z);
                return false;
            }
            else if (pos < positionX)
            {
                objectPosition = new Vector3(leftBound, objectPosition.y, objectPosition.z);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Restrict longitudinal object movement  
        /// </summary>
        /// <param name="objectPosition">Object pozition for restrict</param>
        /// <param name="deltaPositionY">Vertical delta position for new position</param>
        /// <param name="objectBounds">Object bounds</param>
        /// <returns>Return true if object within GamePlayArea</returns>
        public static bool RestrictLongitudinalMovement(ref Vector3 objectPosition, float deltaPositionY, Bounds objectBounds, Camera camera)
        {             
            Vector2 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width,
                                                                         Screen.height,
                                                                         camera.transform.position.z));

            float pos = objectPosition.y + deltaPositionY;
            float topBound = screenBounds.y - objectBounds.size.y / 2;
            float bottomBound = -screenBounds.y + objectBounds.size.y / 2;
            float positionY = Mathf.Clamp(pos, bottomBound, topBound);

            Debug.Log($"{pos}  {positionY}");

            if (pos > positionY)
            {
                objectPosition = new Vector3(objectPosition.x, topBound, objectPosition.z);
                return false;
            }
            else if (pos < positionY)
            {
                objectPosition = new Vector3(objectPosition.x, bottomBound, objectPosition.z);
                return false;
            }

            return true;
        }

        #endregion RestrictMovement

    }
}
