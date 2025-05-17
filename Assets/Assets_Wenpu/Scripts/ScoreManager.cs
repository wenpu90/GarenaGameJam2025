using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }
    public int maxScore = 6;
    public int badGuyCount;
    public int goodGuyCount;
    public int objectCount;
    public int bossCount;

    public Action OnScoreChanged;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        maxScore = NPCManager.Instance.GetTotalNpcCount;
    }

    public void AddScore(KnockableObject.UnitType unitType)
    {
        switch (unitType)
        {
            case KnockableObject.UnitType.BadGuy:
                badGuyCount += 1;
                break;
            case KnockableObject.UnitType.GoodGuy:
                goodGuyCount += 1;
                break;
            case KnockableObject.UnitType.Object:
                objectCount += 1;
                break;
        }
        OnScoreChanged?.Invoke();
    }
    
}
