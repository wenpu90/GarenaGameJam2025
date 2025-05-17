using System;
using UnityEngine;
using DG.Tweening;


public class KnockableObject : MonoBehaviour
{
    public bool isKnockedBack;
    public float knockbackDistance = 3f;
    public float knockbackDuration = 0.2f;
    public float knockbackHeight = 1f;
    public float rotationDuration = 0.15f;

    private void OnTriggerEnter(Collider other)
    {
        if (isKnockedBack) return;
        if (other.CompareTag("Player"))
        {
            Transform player = other.transform;
            Transform npc = transform; // this NPC’s transform

            // Direction from player to NPC (flattened for top-down)
            Vector3 flatDirection = (npc.position - player.position);
            flatDirection.y = 0f;
            flatDirection.Normalize();
            
            // Calculate rotation to face away from player
            Quaternion targetRotation = Quaternion.LookRotation(flatDirection);
            
            // Calculate knockback target position with Y bump
            Vector3 knockTarget = npc.position + flatDirection * knockbackDistance;
            knockTarget.y += knockbackHeight;

            // Optional: stop ongoing movement tweens
            npc.DOKill();

            // Tween NPC knockback
            npc.DOMove(knockTarget, knockbackDuration)
                .SetEase(Ease.OutQuad);
            
            // Rotate to face away from player
            npc.DORotateQuaternion(targetRotation, rotationDuration)
                .SetEase(Ease.OutSine);
            
            isKnockedBack = true;
            ScoreManager.Instance.AddScore(1);
        }
    }
}
