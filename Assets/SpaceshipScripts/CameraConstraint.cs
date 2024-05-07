using UnityEngine;

namespace SpaceshipScripts
{
    public class CameraConstraint : MonoBehaviour
    {
        public BoxCollider2D bounds;  // Assign the bounds collider in the inspector
        private Camera cam;
        private float verticalExtent;
        private float horizontalExtent;

        void Start()
        {
            cam = GetComponent<Camera>();
            verticalExtent = cam.orthographicSize;
            horizontalExtent = verticalExtent * cam.aspect;
        }

        void LateUpdate()
        {
            Vector3 camPosition = transform.position;
            float minX = bounds.bounds.min.x + horizontalExtent;
            float maxX = bounds.bounds.max.x - horizontalExtent;
            float minY = bounds.bounds.min.y + verticalExtent;
            float maxY = bounds.bounds.max.y - verticalExtent;

            // Clamp the camera's position to keep the viewport within the bounds
            camPosition.x = Mathf.Clamp(camPosition.x, minX, maxX);
            camPosition.y = Mathf.Clamp(camPosition.y, minY, maxY);

            transform.position = camPosition;
        }
    }
}
