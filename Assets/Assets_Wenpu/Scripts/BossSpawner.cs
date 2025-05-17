using System;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public float bossSpawnTime = 20;
    public GameObject bossNPC;
    public bool isSpawned = false;


    private void Start()
    {
        isSpawned = false;
    }

    private void Update()
    {
        if (isSpawned || !GameManager.Instance.IsStarted) return;
        if (GameManager.Instance.maxTime - bossSpawnTime >= GameManager.Instance.currentTime)
        {
            bossNPC.gameObject.SetActive(true);
            isSpawned = true;
        }
    }
}
