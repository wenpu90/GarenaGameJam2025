using System;
using UnityEngine;

public class Boss : KnockableObject
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
        
        GameManager.Instance.BossDead();
    }
}

public class DestroyAfterPlay : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 2.5f);
    }
}
