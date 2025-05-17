using UnityEngine;

public class CharacterDashTopdownMovement : MonoBehaviour
{
    public float dashForce = 10f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DashForward();
        }
    }

    void DashForward()
    {
        // Get the flat (XZ-only) forward direction
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        // Add force in that direction
        rb.AddForce(forward * dashForce, ForceMode.Impulse);
    }
}
