using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

namespace SpaceshipScripts
{
    public class SoldierMoveControl : MonoBehaviour
    {
        public float moveForce = 5f;
        private Rigidbody2D _rb;
        public float targetScaleX;
        public float flipTime = 0.5f;
        private Coroutine _flipCoroutine;
        
        public float jumpForce = 300f;  // Force applied vertically for jump
        private bool isGrounded;  // Flag to check if the player is grounded
        public LayerMask groundLayer;  // Layer used to identify the ground
        public Transform groundCheck;  // Position marking where to check if the player is grounded
        public float groundCheckRadius = 0.2f;
        public Vector3 _forwardDir;
        [SerializeField] private Transform eye;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            targetScaleX = transform.localScale.x;
            _forwardDir = eye.position - transform.position;
        }

        private void Update()
        {
            _forwardDir = Vector3.Normalize(eye.position - transform.position);
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveForce, _rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

            HandleGroundCheck();

            // Flip based on mouse position instead of movement direction
            HandleMouseBasedFlip();

        }

        private void HandleMouseBasedFlip()
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float mouseRelativeToSoldier = mouseWorldPosition.x - transform.position.x;

            var newTargetScaleX = Mathf.Sign(mouseRelativeToSoldier);
            if (!targetScaleX.Equals(newTargetScaleX))
            {
                targetScaleX = newTargetScaleX;
                if (_flipCoroutine != null) StopCoroutine(_flipCoroutine);
                _flipCoroutine = StartCoroutine(SmoothFlip(targetScaleX));
            }
        }

        public IEnumerator SmoothFlip(float _targetScaleX)
        {
            float elapsedTime = 0;
            float startScaleX = transform.localScale.x;

            while (elapsedTime < flipTime)
            {
                elapsedTime += Time.deltaTime;
                float newScaleX = Mathf.Lerp(startScaleX, _targetScaleX, elapsedTime / flipTime);
                transform.localScale = new Vector3(newScaleX, 1, 1);
                yield return null;
            }

            transform.localScale = new Vector3(_targetScaleX, 1, 1);
        }

        private void HandleGroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        private void OnDrawGizmos()
        {
            // Visualizing the ground check
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
