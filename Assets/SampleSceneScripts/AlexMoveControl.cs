using System;
using UnityEngine;

public class AlexMoveControl : MonoBehaviour
{
    public float moveForce = 5f;
    public float airFrictionCoefficient = 0.05f;
    [SerializeField] private AlexStatusManager _alexStatusManager;
    public Vector3 forwardDir;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardDir = Vector3.zero;
    }

    void Update()
    {
        if (!_alexStatusManager.isHovering)
        {
            forwardDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            rb.AddForce(forwardDir * moveForce);
        }
        else
        {
            forwardDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            rb.AddForce(forwardDir * moveForce);
        }

        if (forwardDir.magnitude > 0)
        {
            forwardDir /= forwardDir.magnitude;
        }
        
    }
    
    void FixedUpdate()
    {
        Vector3 airFrictionForce = -airFrictionCoefficient * rb.velocity.magnitude * rb.velocity;
        rb.AddForce(airFrictionForce);
    }
}