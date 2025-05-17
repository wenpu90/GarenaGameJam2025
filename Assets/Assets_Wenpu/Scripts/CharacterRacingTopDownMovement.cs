using UnityEngine;

public class CharacterRacingTopDownMovement : MonoBehaviour
{
    [SerializeField] private Transform model;
    public float forwardForce = 20f;
    public float turnTorque = 50f;
    public float maxSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 1f;
        rb.angularDamping = 2f;
    }

    void FixedUpdate()
    {
        // Get camera's forward on the XZ plane
        Vector3 modelForward = model.forward;
        modelForward.y = 0;
        modelForward.Normalize();

        // Apply forward force based on camera direction
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(modelForward * forwardForce);
        }

        // Steer input (relative to camera’s right direction)
        float steer = Input.GetAxis("Horizontal");
        Vector3 modelRight =  model.right;
        modelRight.y = 0;
        modelRight.Normalize();

        // Add torque to rotate character around Y axis (world up)
        rb.AddTorque(Vector3.up * steer * turnTorque);
    }
}