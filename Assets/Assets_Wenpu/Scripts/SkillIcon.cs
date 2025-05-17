using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    public float cooldownTime = 2.5f;
    [SerializeField] private Image skillIcon_Cooldown;
    [SerializeField] private Image skillIcon_FadeBlocker;
    
    [Button]
    public void UseSkill()
    {
        skillIcon_FadeBlocker.gameObject.SetActive(true);
        skillIcon_Cooldown.gameObject.SetActive(true);
        skillIcon_Cooldown.fillAmount = 1f;
        skillIcon_Cooldown.DOFillAmount(0f, cooldownTime).OnComplete(FinishCooldown);
    }

    private void FinishCooldown()
    {
        skillIcon_FadeBlocker.gameObject.SetActive(false);
    }
}
