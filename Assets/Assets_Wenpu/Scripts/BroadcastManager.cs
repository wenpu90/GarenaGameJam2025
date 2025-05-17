using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class BroadcastManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI broadcastUI;

    public void Broadcast(string broadcastMessage)
    {
        broadcastUI.text = broadcastMessage;
    }

    
    
    
    
    
    
    
    [System.Serializable]
    public class BroadcastData
    {
        public string broadcastMessage;
    }
}

