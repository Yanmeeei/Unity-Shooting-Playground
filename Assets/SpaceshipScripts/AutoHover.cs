using UnityEngine;

namespace SpaceshipScripts
{
    public class AutoHover : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float speedFactor = 0.005f;
        private SpriteRenderer _spriteRenderer;
        public float yOffset = 3f;
        public float force = 6f;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void FixedUpdate()
        {
            Vector2 desiredAccel = new Vector2(0, force * (yOffset - rb.position.y) + 1);
            rb.AddForce(desiredAccel, ForceMode2D.Force);
        }

        private void Update()
        {
            
        }
    }
}