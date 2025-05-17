using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class CharacterAddforceMovement : MonoBehaviour
{
    private Camera mainCam;
    private Rigidbody rb;
    [SerializeField] private Transform modelTransform;

    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float force;

    [Range(0f, 1f)] [SerializeField][OnValueChanged(nameof(ChangeTimeScale))]
    private float timeScale = 1f;

    [SerializeField] private float fov;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rb.AddForce(modelTransform.forward * force, _forceMode);
            StartCoroutine(SlowTimeWithCurve());
        }
    }

    [Header("Slow Motion Settings")]
    public float slowTimeScale = 0.1f;
    public float duration = 1.5f;
    public AnimationCurve timeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public bool isDashing = false;
    
    public void TriggerTimeSlow()
    {
        StartCoroutine(SlowTimeWithCurve());
    }

    private IEnumerator SlowTimeWithCurve()
    {
        isDashing = true;
        Time.timeScale = slowTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float curveValue = timeCurve.Evaluate(t);
            Time.timeScale = Mathf.Lerp(slowTimeScale, 1f, curveValue);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Debug.Log(rb.linearVelocity);
            yield return null;
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        isDashing = false;
    }

    private void ChangeTimeScale()
    {
        Time.timeScale = timeScale;
    }
}
