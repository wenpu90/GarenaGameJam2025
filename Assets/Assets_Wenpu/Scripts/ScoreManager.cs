using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }
    public int currentScore = 0;
    public int maxScore = 6;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentScore = 0;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore >= maxScore)
        {
            GameManager.Instance.EnterResultMode();
        }
    }
}
