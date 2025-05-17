using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] private ResultUI _resultUI;

    public float currentTime;
    public float maxTime;
    [SerializeField] private bool isEnded = false;
    public bool IsStarted = false;
    private void Awake()
    {
        Instance = this;
        isEnded = false;
    }

    private void Start()
    {
       
    }

    public void StartGame()
    {
        IsStarted = true;
        currentTime = maxTime;
    }

    private void Update()
    {
        if (!IsStarted || isEnded) return;

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
        Time.timeScale = 0f;
        _resultUI.ShowResultUI();
    }

    public void RestartGame()
    {
        
    }

    public void ShowTimesUp()
    {
        Time.timeScale = 0f;
        Debug.LogError("TimesUp!!");
        _resultUI.gameObject.SetActive(true);
    }
}
