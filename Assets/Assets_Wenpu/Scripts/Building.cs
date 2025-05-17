using UnityEngine;

public class Building : KnockableObject
{
    public GameObject[] prefab;
    protected override void KnockbackReaction(Collider other)
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            GameObject go = Instantiate(prefab[i]);
            go.transform.position = transform.position;
            go.AddComponent<DestroyAfterPlay>();
        }
    }
}
