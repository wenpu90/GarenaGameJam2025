using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] private ResultUI _resultUI;
    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        
    }

    public void EnterResultMode()
    {
        Time.timeScale = 0f;
        _resultUI.ShowResultUI();
    }

    public void RestartGame()
    {
        
    }
    
    
}
