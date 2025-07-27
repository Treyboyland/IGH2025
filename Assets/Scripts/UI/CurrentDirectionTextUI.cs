using TMPro;
using UnityEngine;

public class CurrentDirectionTextUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text arrowText;

    public void UpdateArorw(MovementDirectionSO data)
    {
        arrowText.text = data.DirectionName;
    }
}
