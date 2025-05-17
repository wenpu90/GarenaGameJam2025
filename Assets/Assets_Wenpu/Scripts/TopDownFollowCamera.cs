using Sirenix.OdinInspector;
using UnityEngine;

public class TopDownFollowCamera : MonoBehaviour
{
    public Transform target;      // The player
    [OnValueChanged(nameof(LateUpdate))]
    public Vector3 offset = new Vector3(0f, 10f, -5f); // Camera height + slight backward
    [OnValueChanged(nameof(LateUpdate))]
    public Vector3 eulerAngleOffset = new Vector3(90f, 0f, 0f);
    public float followSpeed = 10f;

    void LateUpdate()
    {
        if (!target) return;

        // Desired camera position (ignoring rotation)
        Vector3 targetPos = target.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);

        // Always look at the player (optional)
        transform.rotation = Quaternion.Euler(eulerAngleOffset); // Top-down look, directly downward
    }
}