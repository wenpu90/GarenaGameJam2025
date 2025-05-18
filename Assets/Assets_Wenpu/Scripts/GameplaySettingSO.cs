using UnityEngine;

[CreateAssetMenu(menuName = "GameplaySettingSO")]
public class GameplaySettingSO : ScriptableObject
{
    public int badGuyMultiplier;
    public int goodGuyMultiplier;
    public int destroyObjectMultiplier;
    public int remainingTimeMultiplier;
}
