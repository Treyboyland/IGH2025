using UnityEngine;
using UnityEngine.UI;

public class CurrentDirectionImageUI : MonoBehaviour
{
    [SerializeField]
    Image arrow;

    public void UpdateArorw(MovementDirectionSO data)
    {
        arrow.sprite = data.DirectionSprite;
    }
}
