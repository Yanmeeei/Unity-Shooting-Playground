using System;
using UnityEngine;

namespace SpaceshipScripts
{
    public class CanShootBullet : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public float bulletSpeed = 5f;
        public Transform barrel;
        public Grabbable _Grabbable;

        private Vector3 barrel_hand_offset;

        private void Start()
        {
            barrel_hand_offset = barrel.position - transform.position;
        }

        private void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.J)) && _Grabbable.isGrabbed) // Check if the 'J' key is pressed
            {
                Fire();
            }
        }

        void Fire()
        {
            if (bulletPrefab != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, barrel.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = new Vector2(barrel.transform.position.x - transform.position.x,
                        barrel.transform.position.y - transform.position.y).normalized;
                    rb.velocity = direction * bulletSpeed;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
            else
            {
                Debug.LogError("Bullet prefab is not assigned!");
            }
        }
    }
}