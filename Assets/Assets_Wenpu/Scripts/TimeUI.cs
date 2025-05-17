using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private Image timeUI;

    // Update is called once per frame
    void Update()
    {
        UpdateTimeUI();
    }

    private void UpdateTimeUI()
    {
        var timeValue = GameManager.Instance.currentTime / GameManager.Instance.maxTime;
        timeUI.DOFillAmount(timeValue, 0.5f);
    }
}
