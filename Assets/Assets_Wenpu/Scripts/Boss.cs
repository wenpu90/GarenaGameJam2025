using System;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine;

public class Boss : KnockableObject
{
    [SerializeField] private GameObject vc;
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

    private IEnumerator Start()
    {
        GameManager.Instance.IsStarted = false;
        yield return GameManager.Instance.EasyFadeIn();
        vc.SetActive(true);
        yield return GameManager.Instance.EasyFadeOut();
        yield return new WaitForSeconds(4.5f);
        yield return GameManager.Instance.EasyFadeIn();
        vc.SetActive(false);
        yield return GameManager.Instance.EasyFadeOut();
        GameManager.Instance.IsStarted = true;
    }
    

}

public class DestroyAfterPlay : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 2.5f);
    }
}
