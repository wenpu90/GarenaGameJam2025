using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance { get; set; }
    public List<NPC> npcList = new List<NPC>();
    public int GetTotalNpcCount => npcList.Count;
    private void Awake()
    {
        Instance = this;
    }


    public void GetBackToStorage(NPC npc)
    {
        
    }
}
