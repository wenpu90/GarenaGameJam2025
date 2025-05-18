using System;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{

    public GameObject[] buildingEffects;

    public GameObject[] smallPropEffects;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody != null)
        {
            if(other.rigidbody.CompareTag("Building"))
            {
                ScoreManager.Instance.AddScore(KnockableObject.UnitType.Object);
                BroadcastManager.Instance.ShowBroadcast(BroadcastManager.BroadcastType.BuildingNews);
                //Debug.LogError("Building!");
                for (int i = 0; i < buildingEffects.Length; i++)
                {
                    GameObject go = Instantiate(buildingEffects[i]);
                    go.transform.position = transform.position + (transform.forward * 2f);
                    go.AddComponent<DestroyAfterPlay>();
                }
                Destroy(other.rigidbody.gameObject);
            }
            else if (other.rigidbody.CompareTag("SmallProp"))
            {
                //Debug.LogError("Building!");
                for (int i = 0; i < smallPropEffects.Length; i++)
                {
                    GameObject go = Instantiate(smallPropEffects[i]);
                    go.transform.position = transform.position + (transform.forward * 2f);
                    go.AddComponent<DestroyAfterPlay>();
                }
                Destroy(other.rigidbody.gameObject);
            }
        }
    }
}
