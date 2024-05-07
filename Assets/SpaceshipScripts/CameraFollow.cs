using UnityEngine;

namespace SpaceshipScripts
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;  // The target to follow (Assign the player GameObject here)
        public float smoothSpeed = 0.125f;  // Smoothing speed
        public Vector3 offset;  // Offset from the target

        void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Optionally keep the camera's z position fixed (useful in 2D games or top-down 3D games)
            transform.position = new Vector3(transform.position.x, transform.position.y, -10); // Adjust the z-coordinate as needed
        }
    }
}