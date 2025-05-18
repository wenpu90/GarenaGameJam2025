using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : KnockableObject
{
    public GameObject[] prefab;

    private void Start()
    {
        transform.eulerAngles = new Vector3(0f, Random.Range(0f, 360f), 0f);
    }

    protected override void KnockbackReaction(Collider other)
    {
        base.KnockbackReaction(other);
        for (int i = 0; i < prefab.Length; i++)
        {
            GameObject go = Instantiate(prefab[i]);
            go.transform.position = transform.position;
            go.AddComponent<DestroyAfterPlay>();
        }

        switch (unitType)
        {
            case UnitType.BadGuy:
                BroadcastManager.Instance.ShowBroadcast(BroadcastManager.BroadcastType.VillainNews);
                break;
            case UnitType.GoodGuy:
                BroadcastManager.Instance.ShowBroadcast(BroadcastManager.BroadcastType.CitizenNews);
                break;
        }
        gameObject.AddComponent<DestroyAfterPlay>();
    }
}
