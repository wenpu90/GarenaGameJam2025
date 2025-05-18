using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] private ResultUI _resultUI;

    public float currentTime;
    public float maxTime;
    public bool isEnded = false;
    public bool IsStarted = false;

    public static float GameSpeed = 1f;

    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject timesUpPanel;
    [SerializeField] private Image fadeImage;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject menuPanel;
    private void Awake()
    {
        Instance = this;
        isEnded = false;
        GameSpeed = 1f;
    }

    private void Start()
    {
        fadeImage.fillAmount = 1f;
        fadeImage.DOFade(0f, 0.5f);
    }

    public void StartGame()
    {
        EnterGamePlay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            RestartGame();
        }
        
        if (!IsStarted || isEnded) return;


        if (Input.GetKeyDown(KeyCode.Plus))
        {
            currentTime += 10;
        }
        else if(Input.GetKeyDown(KeyCode.Minus))
        {
            currentTime -= 10;
        }
        
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            isEnded = true;
            ShowTimesUp();
        }
        
    }

    public void EnterResultMode()
    {
        Debug.LogError("ShowResult!");
        _resultUI.gameObject.SetActive(true);
    }

    [Button]
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowTimesUp()
    {
        if (isEnded) return;
        isEnded = true;
        Debug.LogError("TimesUp!!");
        timesUpPanel.SetActive(true);
    }

    public void BossDead()
    {
        if (isEnded) return;
        isEnded = true;
        victoryPanel.SetActive(true);
    }

    private bool isFading = false;

    public IEnumerator EasyFadeIn()
    {
        fadeImage.DOFade(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator EasyFadeOut()
    {
        fadeImage.DOFade(0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }
    
    public void StartFading(float waitTime, Action OnFade = null, Action OnComplete = null)
    {
        if (isFading) return;
        StartCoroutine(Fading());
        IEnumerator Fading()
        {
            isFading = true;
            fadeImage.DOFade(1f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            OnFade?.Invoke();
            yield return new WaitForSeconds(waitTime);
            fadeImage.DOFade(0f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            OnComplete?.Invoke();
            isFading = true;
        }
    }

    public void EnterGamePlay()
    {
        if (isFading) return;
        StartCoroutine(Fading());
        IEnumerator Fading()
        {
            IsStarted = false;
            yield return EasyFadeIn();
            menuPanel.SetActive(false);
            gameplayPanel.SetActive(true);
            yield return new WaitForSeconds(1f);
            yield return EasyFadeOut();
            IsStarted = true;
            currentTime = maxTime;
        }
    }
}
