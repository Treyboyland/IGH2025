using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    MovementDirectionSO directionData;

    [SerializeField]
    SpriteRenderer sprite;

    public MovementDirectionSO DirectionData
    {
        get => directionData;
        set
        {
            directionData = value;
            UpdateData();
        }
    }

    void Start()
    {
        UpdateData();
    }

    void UpdateData()
    {
        sprite.sprite = directionData.DirectionSprite;
    }
}
