using UnityEngine;

public class NPC : KnockableObject
{
    public GameObject[] prefab;
    protected override void KnockbackReaction(Collider other)
    {
        base.KnockbackReaction(other);
        for (int i = 0; i < prefab.Length; i++)
        {
            GameObject go = Instantiate(prefab[i]);
            go.transform.position = transform.position;
        }
    }
}
