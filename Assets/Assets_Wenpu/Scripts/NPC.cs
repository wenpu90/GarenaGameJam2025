using UnityEngine;

public class NPC : KnockableObject
{
  public GameObject prefab;
  protected override void KnockbackReaction(Collider other)
  {
      GameObject go = Instantiate(prefab);
      go.transform.position = transform.position;
  }
}
