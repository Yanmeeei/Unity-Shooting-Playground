using System;
using System.Collections;
using UnityEngine;

namespace SpaceshipScripts
{
    public class Grabbable : MonoBehaviour
    {
        private Rigidbody2D rb;
        private FixedJoint2D joint;
        public bool isGrabbed;
        [SerializeField] private float moveSpeed = 5f;
        private Transform oldParent = null;
        private Vector3 originalScale;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            originalScale = transform.localScale;
        }

        // public void Grabbed(GameObject grabber)
        // {
        //     rb.isKinematic = true;
        //     isGrabbed = true;
        //     oldParent = transform.parent;
        //     transform.localScale =
        //         new Vector3(
        //             transform.localScale.x *
        //             Math.Sign(grabber.GetComponentInParent<SoldierMoveControl>()._forwardDir.x),
        //             transform.localScale.y, transform.localScale.z);
        //     transform.SetParent(grabber.transform);
        //     transform.localRotation = Quaternion.Euler(0, 0, grabber.transform.localEulerAngles.z);
        //     StartCoroutine(FlyToPosition(grabber.transform.position));
        // }
        
        public void Grabbed(GameObject grabber)
        {
            rb.isKinematic = true;
            isGrabbed = true;
            oldParent = transform.parent;

            // Ensure the grabbed item's scale matches the direction of the grabber
            transform.localScale = new Vector3(
                transform.localScale.x * Math.Sign(grabber.GetComponentInParent<SoldierMoveControl>()._forwardDir.x),
                transform.localScale.y, transform.localScale.z);

            // Set the parent to the grabber so the item moves with the grabber
            transform.SetParent(grabber.transform);

            // Set rotation to match the grabber's rotation
            transform.localRotation = Quaternion.identity;

            StartCoroutine(FlyToPosition(grabber.transform.position));
        }

        public void Released()
        {
            isGrabbed = false;
            rb.isKinematic = false;
            transform.SetParent(oldParent);
            transform.localScale = originalScale;
        }

        private IEnumerator FlyToPosition(Vector3 destination)
        {
            while ((transform.position - destination).magnitude >= 0.05f)
            {
                transform.position += moveSpeed * 0.1f * (destination - transform.position);
                yield return null;
            }

            transform.position = destination;
        }
    }
}