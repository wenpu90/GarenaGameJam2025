using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAddVelocityMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform target;
    public float timeToReachTarget = 1.0f;
    public float stopThreshold = 0.1f;

    private Vector3 velocityNeeded;
    private bool isMoving = false;

    public List<KnockableObject> knockList = new List<KnockableObject>();
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartMovement();
        }
    }

    void FixedUpdate()
    {

    }

    private void TimeScaling()
    {
        if (isMoving)
        {
            Vector3 toTarget = target.position - transform.position;

            // Check if we've arrived (or very close)
            if (toTarget.magnitude < stopThreshold)
            {
                rb.linearVelocity = Vector3.zero;
                isMoving = false;
                return;
            }

            // Calculate desired velocity to arrive in remaining time
            Vector3 desiredVelocity = toTarget / timeToReachTarget;

            // Apply the velocity difference to push toward it
            Vector3 velocityDiff = desiredVelocity - rb.linearVelocity;

            rb.AddForce(velocityDiff, ForceMode.VelocityChange);
        }
    }

    void StartMovement()
    {
        isMoving = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out KnockableObject knockableObject))
        {
   
        }
    }
}
