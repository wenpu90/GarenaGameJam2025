using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDashTopdownMovement : MonoBehaviour
{
    [SerializeField] private SkillIcon dashSkillUI;
    [SerializeField] private Animator anim;
    public float dashForce = 10f;

    private Rigidbody rb;
    public float cooldownTime = 2f;
    private float usedTime;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > usedTime + cooldownTime)
            {
                DashForward();
                dashSkillUI.UseSkill();
                usedTime = Time.time;
                anim.SetTrigger("Attack");
                StartCoroutine(PauseRotating());
            }
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

    private IEnumerator PauseRotating()
    {
        CharacterRacingMovement.Instance.pauseRotate = true;
        yield return new WaitForSeconds(0.8f);
        CharacterRacingMovement.Instance.pauseRotate = false;
        anim.ResetTrigger("Attack");
    }
}
