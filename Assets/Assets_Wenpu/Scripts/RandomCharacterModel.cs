using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class RandomCharacterModel : MonoBehaviour
{
    [Button]
    private void OnEnable()
    {
        var random = UnityEngine.Random.Range(0, transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == random);
        }
    }
}
