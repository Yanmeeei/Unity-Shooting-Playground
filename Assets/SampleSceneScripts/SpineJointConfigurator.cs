using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class SpineJointConfigurator : MonoBehaviour
{
    public float angleLimit = 20.0f; // Maximum angle from the initial position

    void Start()
    {
        ConfigureJoint();
    }

    private void ConfigureJoint()
    {
        HingeJoint joint = GetComponent<HingeJoint>();

        // Anchor and Axis
        joint.anchor = Vector3.zero; // Should be adjusted according to the specific model geometry
        joint.axis = Vector3.forward; // Set to correct axis, commonly the Z-axis for vertical hinges

        // Limits
        JointLimits limits = new JointLimits();
        limits.min = -angleLimit;
        limits.max = angleLimit;
        joint.limits = limits;
        joint.useLimits = true;

        // Spring settings to help the joint maintain its position or return to start
        JointSpring spring = new JointSpring();
        spring.spring = 0; // Adjust this to apply a spring force that tries to return the joint to a zero position
        spring.damper = 0; // Adjust damping to smooth out the motion and prevent oscillations
        spring.targetPosition = 0; // Typically the midpoint of the limits
        joint.spring = spring;
        joint.useSpring = false; // Enable if you need the joint to be "springy"

        // Motor settings, if you need the joint to be motor-driven
        JointMotor motor = new JointMotor();
        motor.force = 0; // Maximum motor force
        motor.freeSpin = false; // Should the motor be allowed to spin freely?
        motor.targetVelocity = 0; // Target velocity of the motor
        joint.motor = motor;
        joint.useMotor = false; // Enable if using motorized motion

        // Configure mass and inertia if necessary
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 1; // Adjust mass appropriately for the scale of your objects
        rb.useGravity = true; // Typically you want gravity, unless specific scenarios
        rb.interpolation = RigidbodyInterpolation.Interpolate; // Helps smooth out the physics simulation
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // For high-speed or important collision accuracy
    }
}
