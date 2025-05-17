using UnityEngine;

public class CharacterRacingMovement : MonoBehaviour
{
    public float moveForce = 10f;
    public float turnSpeed = 100f;
    public float maxSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 1.5f;
        rb.angularDamping = 2f;
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.IsStarted) return;
        // 1. Constantly move forward in local forward direction
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * moveForce);
        }

        // 2. Turn left/right with A/D
        float turnInput = Input.GetAxis("Horizontal"); // A = -1, D = +1
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f));
    }
}
