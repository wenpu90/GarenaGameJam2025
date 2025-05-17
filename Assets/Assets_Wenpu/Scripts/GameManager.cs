using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void Awake()
    {
        Instance = this;
        isEnded = false;
        GameSpeed = 1f;
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
        _resultUI.ShowResultUI();
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
}
