using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private Rigidbody rb;
    private FixedJoint joint;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grabbed(GameObject grabber)
    {
        if (joint == null) // Ensure the object isn't already grabbed
        {
            // Add a FixedJoint to the grabber, connecting it to this object
            joint = grabber.AddComponent<FixedJoint>();
            joint.connectedBody = rb;
            joint.breakForce = Mathf.Infinity;  // Set break force to a very high value to prevent accidental breaks
            joint.breakTorque = Mathf.Infinity; // Prevent the joint from breaking due to torque

            rb.isKinematic = false;  // Keep physics interactions

            // Optionally set constraints if needed
            // rb.constraints = RigidbodyConstraints.None; // Uncomment to apply specific constraints
        }
    }

    public void Release()
    {
        if (joint != null)
        {
            // Destroy the joint to release the object
            Destroy(joint);
            joint = null;

            // Optionally reset the Rigidbody's properties
            // rb.isKinematic = false; // Uncomment if you toggled kinematic on grab
            // rb.constraints = RigidbodyConstraints.None; // Reset constraints if they were changed
        }
    }
}