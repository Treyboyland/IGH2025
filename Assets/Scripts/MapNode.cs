using UnityEngine;

public class MapNode : MonoBehaviour
{
    Vector2Int mapPosition;

    public Vector2Int MapPosition
    {
        get
        {
            return mapPosition;
        }
        set
        {
            mapPosition = value;
            gameObject.name = $"MapNode[{mapPosition.x},{mapPosition.y}]";
        }
    }
}
