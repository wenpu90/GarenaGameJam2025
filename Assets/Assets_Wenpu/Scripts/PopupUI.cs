using DG.Tweening;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
