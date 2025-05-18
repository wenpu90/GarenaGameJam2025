using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class BroadcastManager : MonoBehaviour
{
    public static BroadcastManager Instance { get; set; }
    public MarqueeText marqueeText;
    public GameObject panel; // The UI panel containing the banner
    public RectTransform messageText; // The moving text
    public RectTransform maskArea; // The mask for the banner
    public TextMeshProUGUI textComponent; // The text component

    public float scrollSpeed = 100f;

    private Queue<string> messageQueue = new Queue<string>();
    private bool isShowing = false;

    public enum BroadcastType{ VillainNews, CitizenNews, BuildingNews }

    private void Awake()
    {
        Instance = this;
    }

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

        // float startX = maskArea.rect.width;
        // float endX = -textComponent.preferredWidth;
        // messageText.anchoredPosition = new Vector2(startX, messageText.anchoredPosition.y);
        //
        // float duration = (startX - endX) / scrollSpeed;
        //
        // messageText.DOAnchorPosX(endX, duration)
        //     .SetEase(Ease.Linear)
        //     .OnComplete(() =>
        //     {
        //         ShowNextMessage(); // Continue to next message
        //     });
        
        messageText.anchoredPosition = new Vector2(-90, -90f);
        messageText.DOAnchorPosY(0f, 0.5f).OnComplete(() => WaitForXSec(2.5f));


        void WaitForXSec(float sec)
        {
            Invoke(nameof(ShowNextMessage), sec);
        }
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

