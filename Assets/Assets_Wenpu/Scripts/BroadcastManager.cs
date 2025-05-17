using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class BroadcastManager : MonoBehaviour
{
    public MarqueeText marqueeText;
    public GameObject panel; // The UI panel containing the banner
    public RectTransform messageText; // The moving text
    public RectTransform maskArea; // The mask for the banner
    public TextMeshProUGUI textComponent; // The text component

    public float scrollSpeed = 100f;

    private Queue<string> messageQueue = new Queue<string>();
    private bool isShowing = false;

    public enum BroadcastType{ VillainNews, CitizenNews, BuildingNews }
    
    
    public void EnqueueMessage(string message)
    {
        messageQueue.Enqueue(message);
        if (!isShowing)
            ShowNextMessage();
    }

    private void ShowNextMessage()
    {
        if (messageQueue.Count == 0)
        {
            panel.SetActive(false);
            isShowing = false;
            return;
        }

        string message = messageQueue.Dequeue();
        textComponent.text = message;
        panel.SetActive(true);
        isShowing = true;

        float startX = maskArea.rect.width;
        float endX = -textComponent.preferredWidth;
        messageText.anchoredPosition = new Vector2(startX, messageText.anchoredPosition.y);

        float duration = (startX - endX) / scrollSpeed;

        messageText.DOAnchorPosX(endX, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                ShowNextMessage(); // Continue to next message
            });
    }

    [Button]
    public void ShowBroadcast(BroadcastType broadcastType)
    {
        var msg = "";
        switch (broadcastType)
        {
            case BroadcastType.VillainNews:
                msg = marqueeText.GetRandomVillainNews();
                break;
            case BroadcastType.CitizenNews:
                msg = marqueeText.GetRandomCitizenNews();
                break;
            case BroadcastType.BuildingNews:
                msg = marqueeText.GetRandomBuildingNews();
                break;
        }

        EnqueueMessage(msg);
    }
}

