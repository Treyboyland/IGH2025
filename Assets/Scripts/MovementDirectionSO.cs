using UnityEngine;

[CreateAssetMenu(fileName = "MovementDirectionSO-", menuName = "Scriptable Objects/MovementDirectionSO")]
public class MovementDirectionSO : ScriptableObject
{
    [SerializeField]
    string directionName;

    [SerializeField]
    Sprite directionSprite;

    [SerializeField]
    Vector2Int direction;

    public string DirectionName { get => directionName; }
    public Sprite DirectionSprite { get => directionSprite; }
    public Vector2Int Direction { get => direction; }
}
