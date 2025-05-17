using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public bool moveCloser = true;       // true = 靠近，false = 遠離
    public float moveSpeed = 2f;
    
    public float bounceAmplitude = 0.15f; // 彈跳幅度
    public float bounceFrequency = 20f;   // 彈跳頻率

    private Vector3 basePosition;        // 記錄初始 Y 位置

    void Start()
    {
        basePosition = transform.position;
    }

    void Update()
    {
        if (Attractor.Target == null) return;

        // 移動方向計算
        Vector3 dir = (Attractor.Target.position - transform.position).normalized;
        if (!moveCloser)
            dir *= -1;

        // 更新基礎位置（忽略 Y 軸彈跳）
        basePosition += dir * moveSpeed * Time.deltaTime;

        // 加入上下彈跳效果
        float bounce = Mathf.Sin(Time.time * bounceFrequency) * bounceAmplitude;
        Vector3 bouncedPosition = basePosition + new Vector3(0, bounce, 0);

        transform.position = bouncedPosition;
    }
}