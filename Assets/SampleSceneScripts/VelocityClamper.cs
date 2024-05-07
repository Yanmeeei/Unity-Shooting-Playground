using UnityEngine;

public class VelocityClamper : MonoBehaviour
{
    [SerializeField] public float maxVelocity;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if the current velocity exceeds the maximum allowed velocity
        if (rb.velocity.magnitude > maxVelocity)
        {
            // Clamp the velocity
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
}