using UnityEngine;

namespace SpaceshipScripts
{
    public class GrabbableDetect : MonoBehaviour
    {
        [SerializeField] private CanGrab canGrab;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Grabbable") && canGrab.objectToGrab == null)
            {
                canGrab.objectToGrab = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == canGrab.objectToGrab)
            {
                canGrab.objectToGrab = null;
            }
        }
    }
}
