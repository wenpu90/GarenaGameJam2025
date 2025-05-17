using UnityEngine;

public class NPC : KnockableObject
{
    protected override void OnKnockbackComplete()
    {
        base.OnKnockbackComplete();
        NPCManager.Instance.GetBackToStorage(this);
    }
}
