using System;
using UnityEngine;

public class CharacterRacingMovement : MonoBehaviour
{
    public static CharacterRacingMovement Instance { get; set; }
    public float moveForce = 10f;
    public float turnSpeed = 100f;
    public float maxSpeed = 10f;

    private Rigidbody rb;
    public bool pauseRotate;

    public bool isCharging = false;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 1.5f;
        rb.angularDamping = 2f;
    }

    void FixedUpdate()
    {
        if (!rb.useGravity) rb.useGravity = true;
        if (!GameManager.Instance.IsStarted || GameManager.Instance.isEnded) return;
        // 1. Constantly move forward in local forward direction
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            if (isCharging)
            {
                rb.AddForce(transform.forward * (moveForce * 0.25f));
            }
            else
            {
                rb.AddForce(transform.forward * moveForce);
            }
      
        }

        if (pauseRotate) return;
        // 2. Turn left/right with A/D
        float turnInput = Input.GetAxis("Horizontal"); // A = -1, D = +1
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f));
    }
    
}
