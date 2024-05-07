using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceshipScripts
{
    public class Destructible : MonoBehaviour
    {
        public GameObject[] smallBoxFragments; // Assign your smaller box prefabs here
        public int numberOfFragments = 10; // Adjust based on how many fragments you want
        public float force = 10f; // Adjust based on how many fragments you want
        private CameraShaker cameraShaker; // Reference to the CameraShaker script

        private void Start()
        {
            cameraShaker = Camera.main.GetComponent<CameraShaker>();
        }
        
        public void BreakIntoFragments()
        {
            for (int i = 0; i < numberOfFragments; i++)
            {
                if (smallBoxFragments.Length > 0)
                {
                    GameObject fragment = Instantiate(smallBoxFragments[Random.Range(0, smallBoxFragments.Length)],
                        transform.position,
                        Quaternion.identity);

                    Rigidbody2D rb = fragment.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.2f, 1f));
                        rb.AddForce(forceDirection.normalized * force); 
                        rb.AddTorque(Random.Range(-100f, 100f));
                    }
                }
            }
            cameraShaker?.ShakeCamera(0.15f, 0.4f); 
        }
    }
}
