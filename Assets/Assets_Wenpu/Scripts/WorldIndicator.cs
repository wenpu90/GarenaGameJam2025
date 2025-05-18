using UnityEngine;

public class WorldIndicator : MonoBehaviour
{
    public Transform target;             // 3D target
    public Camera cam;                   // Main Camera
    public RectTransform arrowUI;       // UI arrow image
    public float hideDistance = 10f;     // Distance to hide the indicator
    public float edgePadding = 50f;      // Padding from screen edge

    void Update()
    {
        if (target == null) return;

        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        Vector3 dirToTarget = (target.position - cam.transform.position).normalized;
        float targetDistance = Vector3.Distance(cam.transform.position, target.position);

        // Check if in front of camera
        bool isBehind = Vector3.Dot(cam.transform.forward, dirToTarget) < 0;

        bool onScreen = !isBehind &&
                        screenPos.x >= 0 && screenPos.x <= Screen.width &&
                        screenPos.y >= 0 && screenPos.y <= Screen.height;

        // Hide if close
        if (targetDistance < hideDistance || onScreen)
        {
            arrowUI.gameObject.SetActive(false);
            return;
        }

        arrowUI.gameObject.SetActive(true);

        // Clamp position to screen edge
        Vector3 clampedPos = screenPos;

        if (isBehind)
        {
            clampedPos *= -1;
        }

        clampedPos.x = Mathf.Clamp(clampedPos.x, edgePadding, Screen.width - edgePadding);
        clampedPos.y = Mathf.Clamp(clampedPos.y, edgePadding, Screen.height - edgePadding);
        clampedPos.z = 0;

        arrowUI.position = clampedPos;

        // Rotate the arrow to point to the target
        Vector3 dir = (screenPos - new Vector3(Screen.width / 2, Screen.height / 2, 0)).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrowUI.rotation = Quaternion.Euler(0, 0, angle - 90); // Arrow up = 0 degree
    }
}
