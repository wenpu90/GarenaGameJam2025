using UnityEngine;
using TMPro;
public class JsListener : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageUI;
    public void GetMessage(string _message)
    {
        messageUI.text = _message;
    }
}
