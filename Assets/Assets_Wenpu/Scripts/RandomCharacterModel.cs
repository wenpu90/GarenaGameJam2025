using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class RandomCharacterModel : MonoBehaviour
{
    [Button]
    private void OnEnable()
    {
        var random = UnityEngine.Random.Range(0, transform.childCount - 1);
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == random);
        }
    }
}
