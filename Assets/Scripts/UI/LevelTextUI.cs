using TMPro;
using UnityEngine;

public class LevelTextUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    public void UpdateLevel(int level)
    {
        text.text = $"Level {level}";
    }
}
