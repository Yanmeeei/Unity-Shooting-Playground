using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceshipScripts
{
    public class BulletControl : MonoBehaviour
    {
        public GameObject[] sparkFragments;
        public int numberOfFragments = 10;
        public CameraShaker cameraShaker; // Reference to the CameraShaker script

        public float sparkRandomAngleXMin = -0.2f;
        public float sparkRandomAngleXMax = 0.2f;
        public float sparkRandomAngleYMin = -0.2f;
        public float sparkRandomAngleYMax = 0.2f;

        private void Start()
        {
            cameraShaker = Camera.main.GetComponent<CameraShaker>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            ContactPoint2D contact = other.contacts[0];

            Vector2 contactDirection = contact.point - (Vector2)transform.position;
            contactDirection.Normalize();
            Vector2 oppositeDirection = -contactDirection;

            BreakIntoFragments(oppositeDirection, contact.point);
            cameraShaker?.ShakeCamera(0.15f, 0.2f); // Shake the camera with these parameters
            Destroy(gameObject);
        }

        void BreakIntoFragments(Vector2 oppositeDirection, Vector2 contactPoint)
        {
            for (int i = 0; i < numberOfFragments; i++)
            {
                if (sparkFragments.Length > 0)
                {
                    GameObject fragment = Instantiate(sparkFragments[Random.Range(0, sparkFragments.Length)],
                        transform.position,
                        Quaternion.identity);

                    Rigidbody2D rb = fragment.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 forceDirection = oppositeDirection +
                                                 new Vector2(Random.Range(sparkRandomAngleXMin, sparkRandomAngleXMax),
                                                     Random.Range(sparkRandomAngleYMin, sparkRandomAngleYMax));
                        forceDirection.Normalize();

                        rb.AddForce(forceDirection * 500f);
                        rb.AddTorque(Random.Range(-100f, 100f));
                    }
                }
            }
        }
    }
}
