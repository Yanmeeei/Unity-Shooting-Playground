using System;
using UnityEngine;

namespace SpaceshipScripts
{
    public class OnCollision2D : MonoBehaviour
    {
        public bool destroy;
        public bool stopKinematic;
        public bool resetGravity;
        public bool activateDestoryAfterTimePeriod;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (destroy) Destroy(gameObject);
            if (stopKinematic)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }

            if (resetGravity)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 1;
                }
            }

            if (activateDestoryAfterTimePeriod)
            {
                DestroyAfterTimePeriod _d = GetComponent<DestroyAfterTimePeriod>();
                _d.enabled = true;
            }
        }
    }
}