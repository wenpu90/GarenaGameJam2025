using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fastSpeedMultiplier = 2f;
    public float lookSpeed = 2f;

    private float rotationX;
    private float rotationY;

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) speed *= fastSpeedMultiplier;

        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += transform.forward;
        if (Input.GetKey(KeyCode.S)) direction -= transform.forward;
        if (Input.GetKey(KeyCode.A)) direction -= transform.right;
        if (Input.GetKey(KeyCode.D)) direction += transform.right;
        if (Input.GetKey(KeyCode.E)) direction += transform.up;
        if (Input.GetKey(KeyCode.Q)) direction -= transform.up;

        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

            rotationY += mouseX;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
    }
}