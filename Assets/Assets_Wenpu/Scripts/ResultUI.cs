using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private GameplaySettingSO _gameplaySettingSo;
    [SerializeField] private TextMeshProUGUI scoreUI;
    
    public TextMeshProUGUI badGuyText;
    public TextMeshProUGUI goodGuyText;
    public TextMeshProUGUI destroyedText;
    public TextMeshProUGUI remainingTimeText;
    public TextMeshProUGUI totalText;

    public int badGuyCount => ScoreManager.Instance.badGuyCount;
    public int goodGuyCount=> ScoreManager.Instance.goodGuyCount;
    public int destroyedCount=> ScoreManager.Instance.objectCount;
    
    public int remainingTime=> Mathf.FloorToInt(GameManager.Instance.currentTime);

    public float countDuration = 1.0f;
    public float delayBetweenCounters = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(ShowResults());
    }

    IEnumerator ShowResults()
    {
        // Bad Guy Count
        int total_badGuy = badGuyCount * _gameplaySettingSo.badGuyMultiplier;
        yield return StartCoroutine(CountUp(badGuyText, total_badGuy));
        yield return new WaitForSeconds(delayBetweenCounters);

        // Good Guy Count
        int total_goodGuy = goodGuyCount * _gameplaySettingSo.goodGuyMultiplier;
        yield return StartCoroutine(CountUp(goodGuyText, total_goodGuy));
        yield return new WaitForSeconds(delayBetweenCounters);

        // Destroyed Count
        int total_destroyObject = destroyedCount * _gameplaySettingSo.destroyObjectMultiplier;
        yield return StartCoroutine(CountUp(destroyedText, total_destroyObject));
        yield return new WaitForSeconds(delayBetweenCounters);
        
        //Remaining Time
        int total_RemainingTime = remainingTime * _gameplaySettingSo.remainingTimeMultiplier;
        yield return StartCoroutine(CountUp(remainingTimeText, total_RemainingTime));
        yield return new WaitForSeconds(delayBetweenCounters);
        
        // Total
        int total = total_badGuy + total_goodGuy + total_destroyObject + total_RemainingTime ;
        yield return StartCoroutine(CountUp(totalText, total));
    }

    IEnumerator CountUp(TextMeshProUGUI text, int target)
    {
        float elapsed = 0f;
        int current = 0;

        while (elapsed < countDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / countDuration);
            current = Mathf.RoundToInt(Mathf.Lerp(0, target, t));
            text.text = current.ToString();
            yield return null;
        }

        text.text = target.ToString();
    }
}
